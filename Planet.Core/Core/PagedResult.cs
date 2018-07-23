using System;
using System.Collections.Generic;

namespace Planet.Infrastructure.Core
{
    public class PagedResult<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }    // kich thuoc 1 trang
        public int TotalItems { get; set; }  // tong so ban ghi trong csdl
        public IEnumerable<T> Items { get; set; }
        public int MaxPage { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}