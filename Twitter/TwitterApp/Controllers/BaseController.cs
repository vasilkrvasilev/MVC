namespace TwitterApp.Controllers
{
    using System.Web.Mvc;
    using Twitter.Data;

    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Data = new UowData();
        }

        public BaseController(IUowData data)
        {
            this.Data = data;
        }

        protected IUowData Data { get; set; }
    }
}