using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        private Context context = new Context();
        // GET: Statistic
        public ActionResult Index()
        {
            var result1 = context.Categories.Count();
            ViewBag.CategoryCount = result1;

            var result2 = context.Headings.Count(x => x.Category.CategoryName == "yazılım");
            ViewBag.HeadingOfSoftware = result2;

            var result3 = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.WriterNameContain = result3;

            var result4 = context.Headings.Max(x=>x.CategoryID);
            var categoryOfHeadingsMax = context.Categories.Find(result4).CategoryName;
            ViewBag.categoryOfHeadingMax = categoryOfHeadingsMax;

            var result5 = context.Categories.Count(x => x.CategoryStatus == true) -
                          context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.Difference = result5;

            return View();
        }
    }
}