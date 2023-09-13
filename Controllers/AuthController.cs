using System.Web.Http;

namespace WebAPI_DotNetMVC.Controllers
{
    public class AuthController : ApiController
    {
        [HttpGet]
        [ActionName("GetToken")]
        public string Token(string userName, string password)
        {
            string token = string.Empty;
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                // Database call

                token = TokenManager.GenerateToken(userName, 20);
            }

            return token;
        }
    }
}
