using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiciosDeFacturacion
{
    [Route("api/empresas")]
    [ApiController]
    public class EmpresaController : ControllerBase {
        // Mock de datos de empresas para demostración.
        private List<Empresa> empresas = new List<Empresa>
        {
            new Empresa
            {
                NombreCliente = "Samuel Ignacio", ApellidosCliente = "Moya Enrique", EdadCliente = 20, GiroEmp = "Cementerio",
                MontoIVAaPagar = 6, MontoUtilidades = 87587, MontoVentas = 3000000,
                NombreEmpresa = "Juanito's", RutCliente = "23435324", RutEmpresa = "324323", TotalVentas = 300
            },
            new Empresa
            {
                NombreCliente = "Lilia Teresa", ApellidosCliente = "Enrique Carhuapo", EdadCliente = 46, GiroEmp = "Comercio",
                MontoIVAaPagar = 12, MontoUtilidades = 878768, MontoVentas = 3000000,
                NombreEmpresa = "Acuenta", RutCliente = "2342234", RutEmpresa = "5322534", TotalVentas = 400
            },
            new Empresa
            {
                NombreCliente = "Alexis Carvajo", ApellidosCliente = "Soya Solange", EdadCliente = 25, GiroEmp = "Ventas",
                MontoIVAaPagar = 15, MontoUtilidades = 91673, MontoVentas = 472103,
                NombreEmpresa = "Farmacia", RutCliente = "21846723", RutEmpresa = "182471", TotalVentas = 200
            }
        };

        // A) Método GET para listar todas las empresas.
        [HttpGet("MostrarEmpresa")]
        public IActionResult ListarEmpresa()
        {
            if(empresas != null){

            //recorremos el arreglo de personas
            for(int i = 0; i < empresas.Count; i++){

                //Se imprime cada persona
                Console.WriteLine(empresas[i]);
            }

            //200 es correcto
            return StatusCode(200, empresas);
            
        }else{

            //Mostramos Empresa
            Console.WriteLine("No hay personas");
            return StatusCode(404);

        }
        }

        // B) Método GET para listar las primeras tres empresas.
        [HttpGet("Listar3Empresas")]
        public IActionResult Listar3Empresas()
        {
            var tresEmpresas = empresas.Take(3).ToList();
            return Ok(tresEmpresas);
        }

        // C) Método POST para crear y guardar una nueva empresa.
        [HttpPost("Empresa")]
        public IActionResult CrearEmpresa([FromBody] Empresa nuevaEmpresa)
        {
            if(empresas != null){

            //Se imprime que se creo la empresa
            Console.WriteLine("Se creo la persona");
            return StatusCode(200, empresas);
            
            }else{

                //Se dice que no se creo
                Console.WriteLine("No se pudo crear la persona");
                return StatusCode(404);
                
                }
        }

        // D) Método PUT para editar y guardar cambios en una empresa por su RUT.
        [HttpPut("Empresa/{rutEmpresa}")]
        public IActionResult EditarEmpresa(string rutEmpresa, [FromBody] Empresa empresaActualizada)
        {
            // Buscamos la empresa por su RUT
            var empresa = empresas.FirstOrDefault(e => e.RutEmpresa == rutEmpresa);
            
            if (empresa == null)
            {
                // La empresa no se encontró, devolvemos un código de estado 404 (No encontrado).
                Console.WriteLine("Empresa no encontrada");
                return StatusCode(404);
            }

            // Actualizamos los datos de la empresa con los valores de empresaActualizada.
            empresa.NombreCliente = empresaActualizada.NombreCliente;
            empresa.ApellidosCliente = empresaActualizada.ApellidosCliente;
            empresa.EdadCliente = empresaActualizada.EdadCliente;
            empresa.GiroEmp = empresaActualizada.GiroEmp;
            empresa.MontoIVAaPagar = empresaActualizada.MontoIVAaPagar;
            empresa.MontoUtilidades = empresaActualizada.MontoUtilidades;
            empresa.MontoVentas = empresaActualizada.MontoVentas;
            empresa.NombreEmpresa = empresaActualizada.NombreEmpresa;
            empresa.RutCliente = empresaActualizada.RutCliente;
            empresa.TotalVentas = empresaActualizada.TotalVentas;

            // Agrega código para la validación y persistencia de los cambios si es necesario.

            // Devolvemos un código de estado 200 (OK) junto con la empresa actualizada.
            return StatusCode(200, empresa);
        }


    // E) Método DELETE para eliminar una empresa por su RUT
    [HttpDelete("Empresa/{rutEmpresa}")]
        public IActionResult BorrarEmpresa(string rutEmpresa)
        {
            // Buscamos la empresa por su RUT
            var empresa = empresas.FirstOrDefault(e => e.RutEmpresa == rutEmpresa);

            if (empresa == null)
            {
                // La empresa no se encontró, devolvemos un código de estado 404 (No encontrado).
                Console.WriteLine("Empresa no encontrada");
                return StatusCode(404);
            }

            // Procedemos a la eliminación de la empresa.
            empresas.Remove(empresa);

            // Agrega código para eliminar la empresa de la persistencia si es necesario.

            // Devolvemos un código de estado 200 (OK) junto con un mensaje indicando que la empresa se eliminó con éxito.
            return StatusCode(200, "Empresa eliminada exitosamente");
        }

}
}
