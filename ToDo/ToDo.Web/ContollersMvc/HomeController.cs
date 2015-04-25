using System.Web.Mvc;
using System.Web.Security;

namespace ToDo.Web.ContollersMvc
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string emailAddress, string password)
        {
            if (Membership.ValidateUser(emailAddress, password))
            {
                FormsAuthentication.SetAuthCookie(emailAddress, true);
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }

            return View();
        }
    }
}