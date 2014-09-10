using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;


namespace MvcApplication5.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Calendar(int month = 0, int year = 0)
        {
            int selMonth = month;
            int selYear = year;
            DateTime today = DateTime.Now;
            if (month < 1) { selMonth = today.Month; }
            if (year < 1) { selYear = today.Year; }
            if (selMonth > 12)
            {
                selYear += 1;
                selMonth = 1;
            }
            else if (selMonth < 1)
            {
                selYear -= 1;
                selMonth = 12;
            }

            int daysInMonth = DateTime.DaysInMonth(selYear, selMonth);
            DateTime firstOfMonth = new DateTime(selYear, selMonth, 1);
            int firstDayOfMonth = (int)firstOfMonth.DayOfWeek;
            int weeksInMonth = (int)Math.Ceiling((firstDayOfMonth + daysInMonth) / 7.0);
            ViewData["weeksInMonth"] = weeksInMonth;
            ViewData["firstDayOfMonth"] = firstDayOfMonth;
            ViewData["daysInCalMonth"] = weeksInMonth * 7;
            ViewData["daysInMonth"] = (int)DateTime.DaysInMonth(selYear, selMonth);
            ViewData["month"] = selMonth;
            ViewData["year"] = selYear;
            ViewData["monthInWords"] = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(selMonth);
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
