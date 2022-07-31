using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using imdbDBFirstDataAccessLayer;
using imdbDBFirstDataAccessLayer.Models;

namespace imdbWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : Controller
    {
        imdbRepository repository;
        public ActorController()
        {
            repository = new imdbRepository();
        }

        [HttpPost]
        public JsonResult AddActorUsingParams(string actorId, string actorName)
        {
            bool status = false;
            string message;
            try
            {
                status = repository.AddActor(actorId, actorName);
                if (status) message = "Actor Addition was Successful";
                else message = "Unsuccessful addition operation!";
            }
            catch (Exception ex)
            {
                message = "Some error occurred, Error Message - " + ex.Message;
            }
            return Json(message);
        }
    }
}
