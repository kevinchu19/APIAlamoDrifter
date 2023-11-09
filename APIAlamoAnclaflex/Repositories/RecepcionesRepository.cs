using APIAlamoAnclaflex.Repositories;

namespace APIAlamoAnclaflex.Repositories
{
    public class RecepcionesRepository : RepositoryBase
    {
        public RecepcionesRepository(IConfiguration configuration, Serilog.ILogger logger ) : base(configuration, logger )
        {
        }


    }
}