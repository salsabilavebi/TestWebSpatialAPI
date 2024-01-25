using Microsoft.AspNetCore.Mvc;
using APIplaces.Model;
using APIplaces.EFCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIplaces.Controllers
{
    
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly DbHelper _db;

        public PlacesController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }

        // GET: api/<APIplacesController>
        [HttpGet]
        [Route("api/[controller]/Get")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<PlacesModel> data = _db.GetPlaces();
          
                return Ok(ResponHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
              
                return BadRequest(ResponHandler.GetExceptionResponse(ex));
            }
            
        }

        // GET api/<APIplacesController>/5
        [HttpGet]
        [Route("api/[controller]/Show/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                PlacesModel data = _db.GetPlaceByid(id);

                if (data == null )
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
               
                return BadRequest(ResponHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<APIplacesController>
        [HttpPost]
        [Route("api/[controller]/Store")]
        public IActionResult Post([FromBody] PlacesModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SavePlace(model);
                return Ok(ResponHandler.GetAppResponse(type, model));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<APIplacesController>/5
        [HttpPut]
        [Route("api/[controller]/Update/{id}")]
        public IActionResult Put([FromBody] PlacesModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SavePlace(model);
                return Ok(ResponHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<APIplacesController>/5
        [HttpDelete("{id}")]
        [Route("api/[controller]/Delete/{id}")]
        public IActionResult Delete(int id)

        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeletePlace(id);
                return Ok(ResponHandler.GetAppResponse(type, "Delete Sukses"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponHandler.GetExceptionResponse(ex));
            }
        }
    }
}
