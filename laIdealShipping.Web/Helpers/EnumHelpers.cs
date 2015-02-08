﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace laIdealShipping.Web.Helpers
{
    public static class EnumHelpers
    {
        public static IEnumerable<SelectListItem> GetItems (this Type enumType)
        {
            if (!typeof(Enum).IsAssignableFrom(enumType))
            {
                throw new ArgumentException("Type must be an enum");
            }

            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType).Cast<int>();

            var items = names.Zip(values, (name, value) => 
                        new SelectListItem{
                            Text = name,
                            Value = value.ToString()
                        }
                );
            return items;
        }
    }
}