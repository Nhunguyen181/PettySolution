using System;
using System.Collections.Generic;

namespace PettySolution.Data.Models
{
    public partial class Responses
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public double? Rating { get; set; }
        public int? ProductId { get; set; }
        public int? OrderProductDetailId { get; set; }
        public string Img { get; set; }

        public virtual Products Product { get; set; }
        public virtual OrderProductDetails OrderProductDetails { get; set; }
    }
}
