using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOUTAKHOT_DO_BARREIRO_LANCMAN
{
    public class Product
    {
        public string product_name { get; set; }
        public string image_url { get; set; }
        public string quantity { get; set; }
        public string expiration_date { get; set; }
        public string brand { get; set; }
        public string nutriscore { get; set; }
        public string ingredients { get; set; }
        public string barcode { get; set; }
    }
}