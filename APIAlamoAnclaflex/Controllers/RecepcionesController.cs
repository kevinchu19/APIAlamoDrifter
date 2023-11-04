using APIAlamoAnclaflex.Models.Response;
using APIAlamoAnclaflex.Services;
using APIAlamoAnclaflex.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Reflection;
using APIAlamoAnclaflex.Models.Recepciones;

namespace APIAlamoAnclaflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecepcionesController : ControllerBase
    {

        
        public RecepcionesController(Serilog.ILogger logger, RecepcionesRepository repository, IConfiguration configuration)
        {
            Logger = logger;
            Repository = repository;
            Configuration = configuration;
        }

        public Serilog.ILogger Logger { get; }
        public RecepcionesRepository Repository { get; }
        public IConfiguration Configuration { get; }

        [HttpPost]
        public async Task<ActionResult<List<ComprobanteResponse>>> PostProduccion([FromBody] RecepcionesDTO payload)
        {
            var ControllerName = "Recepciones";
            string JsonBody = JsonConvert.SerializeObject(payload);
            Logger.Information("{ControllerName} - Body recibido: {JsonBody}", ControllerName, JsonBody);

            List<ComprobanteResponse> response = new List<ComprobanteResponse>();
            bool dioError = false;

            foreach (RecepcionDTO recepcion in payload.recepciones)
            {
                foreach (ItemRecepcionDTO item in recepcion.detalle)
                {
                    item.MSNroAplica = recepcion.MSNroAplica;
                }
            }


            FieldMapper mapping = new FieldMapper();
            if (!mapping.LoadMappingFile(AppDomain.CurrentDomain.BaseDirectory + @"\Services\FieldMapFiles\Recepciones.json"))
            {
                response.Add (new ComprobanteResponse(new ComprobanteDTO((string?)payload.recepciones.FirstOrDefault()
                    .GetType()
                    .GetProperty("MSNroComprobante")
                    .GetValue(payload.recepciones.FirstOrDefault().MSNroAplica), "400", "Error de configuracion", "No se encontro el archivo de configuracion del endpoint", null)));

                return response;
            };

            foreach (RecepcionDTO recepcion in payload.recepciones)
            {
                

                string errorMessage = await Repository.ExecuteSqlInsertToTablaSAR(mapping.fieldMap,
                                                                             recepcion,
                                                                             recepcion.MSNroAplica,
                                                                             Configuration["Produccion:JobName"]);
                if (errorMessage != "")
                {
                    dioError = true;
                    response.Add(new ComprobanteResponse(new ComprobanteDTO(recepcion.MSNroAplica.ToString(), "400", "Bad Request", errorMessage, null)));
                    
                }
                else 
                { 
                    response.Add(new ComprobanteResponse(new ComprobanteDTO(recepcion.MSNroAplica.ToString(), "200", "OK", errorMessage, null)));
                };
            }

            JsonBody = JsonConvert.SerializeObject(response);
            Logger.Information("{ControllerName} - Respuesta: {JsonBody}", ControllerName,JsonBody);

            if (dioError)
            {
                return BadRequest(response);
            }

            

            return Ok(response);

        }

    }
}