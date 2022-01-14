using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BOL_BusinessObjectLayer_
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }


        [ForeignKey("Categorys")]
        public int CategoryId { get; set; }
        public virtual Categorys Categorys { get; set; }
    }
}
