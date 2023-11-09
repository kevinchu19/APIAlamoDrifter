using APIAlamoAnclaflex.Repositories;

namespace APIAlamoAnclaflex.Repositories
{
    public class PedidosRepository : RepositoryBase
    {
        public PedidosRepository(IConfiguration configuration, Serilog.ILogger logger) : base(configuration, logger)
        {
        }


    }
}