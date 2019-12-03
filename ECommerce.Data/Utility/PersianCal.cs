using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace ECommerce.Data
{
    public static class PersianCal
    {
        public static string Toshamsi(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            return persianCalendar.GetYear(dateTime).ToString() + "/" + persianCalendar.GetMonth(dateTime).ToString("00") + "/" + persianCalendar.GetDayOfMonth(dateTime).ToString("00");
        }
    }
}