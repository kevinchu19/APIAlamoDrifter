using APIAlamoAnclaflex.Models.Response;
using APIAlamoAnclaflex.Services;
using APIAlamoAnclaflex.Models.Response;
using APIAlamoAnclaflex.Repositories;
using APIAlamoAnclaflex.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Reflection;
using APIAlamoAnclaflex.Models.Pedidos;

namespace APIAlamoAnclaflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {

        private readonly ILogger<PedidosController> Logger;

        public PedidosController(ILogger<PedidosController> logger, PedidosRepository repository, IConfiguration configuration)
        {
            Logger = logger;
            Repository = repository;
            Configuration = configuration;
        }

        public PedidosRepository Repository { get; }
        public IConfiguration Configuration { get; }

        [HttpPost]
        public async Task<ActionResult<List<ComprobanteResponse>>> PostFacturacion([FromBody] PedidosDTO payload)
        {
            List<ComprobanteResponse> response = new List<ComprobanteResponse>();
            bool dioError = false;

            foreach (PedidoDTO pedido in payload.pedidos)
            {
                pedido.MSNroAplica = pedido.detalle.FirstOrDefault().MSNroAplica;
            }
            

            FieldMapper mapping = new FieldMapper();
            if (!mapping.LoadMappingFile(AppDomain.CurrentDomain.BaseDirectory + @"\Services\FieldMapFiles\Pedidos.json"))
            {
                response.Add (new ComprobanteResponse(new ComprobanteDTO((string?)payload.pedidos.FirstOrDefault()
                    .GetType()
                    .GetProperty("NumeroComprobante")
                    .GetValue(payload.pedidos.FirstOrDefault().MSNroAplica), "400", "Error de configuracion", "No se encontro el archivo de configuracion del endpoint", null)));

                return response;
            };

            foreach (PedidoDTO pedido in payload.pedidos)
            {
                

                string errorMessage = await Repository.ExecuteSqlInsertToTablaSAR(mapping.fieldMap,
                                                                             pedido,
                                                                             pedido.MSNroAplica,
                                                                             Configuration["Facturacion:JobName"]);
                if (errorMessage != "")
                {
                    dioError = true;
                    response.Add(new ComprobanteResponse(new ComprobanteDTO(pedido.MSNroAplica.ToString(), "400", "Bad Request", errorMessage, null)));
                    
                }
                else 
                { 
                    response.Add(new ComprobanteResponse(new ComprobanteDTO(pedido.MSNroAplica.ToString(), "200", "OK", errorMessage, null)));
                };
            }

            if (dioError)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

    }
}