﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTreeMVCWebApplication.Interfaces;

namespace TechTreeMVCWebApplication.Extensions
{
    public static class ConvertExtension
    {
        public static List<SelectListItem> ConvertToSelectList<T>(this IEnumerable<T> collection, int selectedValue) where T : IPrimaryProperties
        {
            return (from item in collection
                    select new SelectListItem
                    {
                        Text = item.Title,
                        Value = item.Id.ToString(),
                        //it's boolean value true or false
                        //Selected = (item.Id == selectedValue)
                    }).ToList();
        }
    }
}

