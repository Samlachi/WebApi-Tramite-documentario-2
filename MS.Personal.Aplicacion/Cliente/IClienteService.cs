using dominio = MS.Personal.Dominio.Entidades;

namespace MS.Personal.Aplicacion.Cliente
{
    public interface IClienteService
    {
        List<dominio.Personal> ListarClientes();
        bool Registracliente(dominio.Personal cliente);
        dominio.Personal Cliente(int idCliente);
        void Eliminar(int idCliente);
    }
}
