using Release.MongoDB.Repository;
using MongoDB.Driver;
using System.Linq.Expressions;
using dominio = MS.Personal.Dominio.Entidades;



namespace MS.Personal.Aplicacion.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly ICollectionContext<dominio.Personal> _cliente;
        private readonly IBaseRepository<dominio.Personal> _clienteR;

        public ClienteService(ICollectionContext<dominio.Personal> cliente,
                                IBaseRepository<dominio.Personal> clienteR)
        {
            _cliente = cliente;
            _clienteR = clienteR;
        }

        public List<dominio.Personal> ListarClientes()
        {
            Expression<Func<dominio.Personal, bool>> filter = s => s.esEliminado == false;
            var items = (_cliente.Context().FindAsync(filter, null).Result).ToList();
            return items;
        }

        public bool Registracliente(dominio.Personal cliente)
        {
            cliente.esEliminado = false;
            cliente.fechaCreacion = DateTime.Now;
            cliente.esActivo = true;

            // _cliente.Context().InsertOne(cliente);                       

            var p = _clienteR.InsertOne(cliente);

            return true;
        }

        public dominio.Personal Cliente(int idCliente)
        {
            Expression<Func<dominio.Personal, bool>> filter = s => s.esEliminado == false && s.id == idCliente;
            var item = (_cliente.Context().FindAsync(filter, null).Result).FirstOrDefault();
            return item;
        }

        public void Eliminar(int idCliente)
        {
            Expression<Func<dominio.Personal, bool>> filter = s => s.esEliminado == false && s.id == idCliente;
            var item = (_cliente.Context().FindOneAndDelete(filter, null));

        }
    }
}
