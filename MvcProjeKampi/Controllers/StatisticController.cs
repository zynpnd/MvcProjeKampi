using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic

        Context context = new Context();
        public ActionResult Index()
        {
            //Toplam kategori sayısı
            var total = context.Categories.Count(); 
            ViewBag.categoryCount= total;

            // Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var softwarecategory = context.Headings.Count(x => x.HeadingName == "Yazılım").ToString();
            ViewBag.Heading = softwarecategory;

            //  Yazar adında 'a' harfi geçen yazar sayısı
            var writername = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.Writer = writername;

            // En fazla başlığa sahip kategori adı
            var mostTitles = context.Headings.Max(x => x.Category.CategoryName);
            ViewBag.MostTitles = mostTitles;

            //  Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var categoryStatusTrue = context.Categories.Count(x => x.CategoryStatus == true);
            var categoryStatusFalse = context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.CategoryStatus = (categoryStatusTrue-categoryStatusFalse);

            return View();
        }
    }
}