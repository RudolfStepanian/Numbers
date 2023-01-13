using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumbertTestTask.Models;
using NumbertTestTask.Services;

namespace NumbertTestTask.Controllers
{
    public class NumberController : Controller
    {
        NumberService objNumber = new NumberService();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] NumberConverterModel model)
        {
            try
            {
                return Ok(await objNumber.getNumberStringByValue(number: model.Number));
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }

    }
}
