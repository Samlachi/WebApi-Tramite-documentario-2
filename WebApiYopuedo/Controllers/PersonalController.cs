using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MS.Personal.Aplicacion.Cliente;
using static MS.Personal.Api.Routes.ApiRoutes;
using dominio = MS.Personal.Dominio.Entidades;


namespace WebApiYopuedo.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet(RouteCliente.GetAll)]
        public IEnumerable<dominio.Personal> ListarClientes()
        {

            var listaCliente = _service.ListarClientes();
            return listaCliente;
        }

        [HttpGet(RouteCliente.GetById)]
        public dominio.Personal BuscarCliente(int id)
        {
            var objCliente = _service.Cliente(id);

            return objCliente;
        }

        [HttpPost(RouteCliente.Create)]
        public ActionResult<dominio.Personal> CrearCliente([FromBody] dominio.Personal cliente)
        {
            _service.Registracliente(cliente);

            return Ok();
        }
        [HttpDelete(RouteCliente.Delete)]
        public ActionResult<dominio.Personal> EliminarCliente(int id)
        {
            _service.Eliminar(id);

            return Ok(id);
        }
    }

}