using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.BFF.Config
{
    public class UrlsConfig
    {
        public class NumberOneOperations
        {
            public static string GetItemById(int id) => $"/api/v1/catalog/items/{id}";
            public static string GetItemsById(IEnumerable<int> ids) => $"/api/v1/catalog/items?ids={string.Join(',', ids)}";
        }

        public class NumberTwoOperations
        {
            public static string GetItemById(string id) => $"/api/v1/basket/{id}";
            public static string UpdateBasket() => "/api/v1/basket";
        }


        public string NumberOne { get; set; }
        public string NumberTwo { get; set; }
    }
}
