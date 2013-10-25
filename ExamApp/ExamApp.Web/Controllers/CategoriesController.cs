using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamApp.Web.Models;

namespace ExamApp.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        [Authorize]
        public JsonResult GetCategories()
        {
            var categories = this.Data.Categories.All()
                .Select(CategoryModel.FromCategory).ToList();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }
    }
}