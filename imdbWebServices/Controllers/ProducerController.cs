using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using imdbDBFirstDataAccessLayer;
using imdbDBFirstDataAccessLayer.Models;

namespace imdbWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : Controller
    {
        imdbRepository repository;
        public ProducerController()
        {
            repository = new imdbRepository();
        }

        [HttpPost]
        public JsonResult AddProducerUsingParams(string producerId, string producerName)
        {
            bool status = false;
            string message;
            try
            {
                status = repository.AddProducer(producerId, producerName);
                if (status) message = "Producer Addition was Successful";
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
