using AAI.DataContract.Common;
using AAI.DataContract.Models.Login;
using AAI.ServiceContract.Login;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AAI.Web.API.Controllers
{
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {

        protected readonly ILoginService _loginService;

        public LoginController(ILoginService loginservice)

        {
            _loginService = loginservice;
        }

        [HttpPost]
        [Route("loginDetail")]
        public async Task<IActionResult> LoginDetail(LoginInputApiModel model)
        {
            ResponseStatus<dynamic> response = new ResponseStatus<dynamic>();
            try
            {
                var result = await _loginService.LoginAsync(model.Email, model.Password);
                if (result != null)
                {
                    response.Data = result.Result;
                    response.Messages = "Success";
                    response.StatusCode = HttpStatusCode.OK;
                    return Ok(response);
                }
                else
                {
                    response.Messages = "Error";
                    response.StatusCode = HttpStatusCode.NoContent;
                    return NoContent();
                }

            }
            catch (Exception ex)
            {
                return NoContent();
            }

        }




    }
}
