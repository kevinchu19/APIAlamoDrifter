using APIAlamoAnclaflex.Models.Response;
using APIAlamoAnclaflex.Services;
using APIAlamoAnclaflex.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Reflection;
using APIAlamoAnclaflex.Models.Pedidos;
using System.Globalization;
using APIAlamoAnclaflex.Models.CambioDisponibilidad;

namespace APIAlamoAnclaflex.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CambioDisponibilidadController : ControllerBase
    {

        private Serilog.ILogger Logger { get; set; }

        public CambioDisponibilidadController(Serilog.ILogger logger, CambioDisponibilidadRepository repository, IConfiguration configuration)
        {
            Logger = logger;
            Repository = repository;
            Configuration = configuration;
        }

        public CambioDisponibilidadRepository Repository { get; }
        public IConfiguration Configuration { get; }

        [HttpPost]
        public async Task<ActionResult<List<ComprobanteResponse>>> PostStock([FromBody] CambiosDisponibilidadDTO payload)
        {
            List<ComprobanteResponse> response = new List<ComprobanteResponse>();
            bool dioError = false;

            var ControllerName = "CambioDisponibilidad";
            string JsonBody = JsonConvert.SerializeObject(payload);
            Logger.Information("{ControllerName} - Body recibido: {JsonBody}", ControllerName, JsonBody);


            //foreach (CambioDisponibilidadDTO cambio in payload.cambiosDisponibilidad)
            //{
            //    cambio.MSNroAplica = cambio.detalle.FirstOrDefault().MSNroAplica;
            //}
            

            FieldMapper mapping = new FieldMapper();
            if (!mapping.LoadMappingFile(AppDomain.CurrentDomain.BaseDirectory + @"\Services\FieldMapFiles\CambioDisponibilidad.json"))
            {
                response.Add (new ComprobanteResponse(new ComprobanteDTO((string?)payload.Cambios_disponibilidad.FirstOrDefault().MSNroAplica.ToString()
                    , "400", "Error de configuracion", "No se encontro el archivo de configuracion del endpoint", null)));

                return response;
            };

            foreach (CambioDisponibilidadDTO cambio in payload.Cambios_disponibilidad)
            {
                

                string errorMessage = await Repository.ExecuteSqlInsertToTablaSAR(mapping.fieldMap,
                                                                             cambio,
                                                                             cambio.MSNroAplica,
                                                                             Configuration["Stock:JobName"]);
                if (errorMessage != "")
                {
                    dioError = true;
                    response.Add(new ComprobanteResponse(new ComprobanteDTO(Convert.ToString(cambio.MSNroAplica, CultureInfo.CreateSpecificCulture("en-GB")), "400", "Bad Request", errorMessage, null)));
                    
                }
                else 
                { 
                    response.Add(new ComprobanteResponse(new ComprobanteDTO(Convert.ToString(cambio.MSNroAplica, CultureInfo.CreateSpecificCulture("en-GB")), "200", "OK", errorMessage, null)));
                };
            }

            JsonBody = JsonConvert.SerializeObject(response);
            Logger.Information("{ControllerName} - Respuesta: {JsonBody}", ControllerName, JsonBody);

            if (dioError)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

    }
}