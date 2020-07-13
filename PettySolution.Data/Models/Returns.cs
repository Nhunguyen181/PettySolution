using System;
using System.Collections.Generic;

namespace PettySolution.Data.Models
{
    public partial class Returns
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Reasion { get; set; }
        public string Img { get; set; }
        public string Confirms { get; set; }
        public int? OrderProductDetailId { get; set; }

        public virtual OrderProductDetails OrderProductDetail { get; set; }
    }
}
