using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BOL_BusinessObjectLayer_
{
    public class Categorys
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Products> Products { get; set; }
    }
}
