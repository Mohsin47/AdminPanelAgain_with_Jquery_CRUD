using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelAgain.Extentions
{
    public static class IEnumrableExtensions
    {
        //extension methodes have some rules 
        //1 is class is static and methodes should be static for extenstion methods
        //public static IEnumerable<SelectListItem>ToSelectListItem<T>(this IEnumerable<T> items, int selectedValue)
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Name"),//GetPropertyValue for making reflection extension
                       Value = item.GetPropertyValue("Id"),//GetPropertyValue for making reflection extension
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue)
                   };
        }
        //extra method add in a class is know as Extensions methods without any changing with compiling driveinng and changing 





        //extention for string for dropdown
        //public static IEnumerable<SelectListItem> ToSelectListItemString<T>(this IEnumerable<T> items, string selectedValue)
        //{
        //    if (selectedValue == null)
        //    {
        //        selectedValue = "";
        //    }
        //    return from item in items
        //           select new SelectListItem
        //           {
        //               Text = item.GetPropertyValue("Name"),//GetPropertyValue for making reflection extension
        //               Value = item.GetPropertyValue("Id"),//GetPropertyValue for making reflection extension
        //               Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())
        //           };
        //}
    }
}
