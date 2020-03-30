using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOUTAKHOT_DO_BARREIRO_LANCMAN
{
    public class Product
    {
        //public Product();
        /*public Product(string product_name, string image_url, string quantity, string expiration_date, string brand, string nutriscore, string ingredients, string barcode)
        {
            this.product_name = product_name;
            this.image_url = image_url;
            this.quantity = quantity;
            this.expiration_date = expiration_date;
            this.brand = brand;
            this.nutriscore = nutriscore;
            this.ingredients = ingredients;
            this.barcode = barcode;
        }*/
        public string product_name { get; set; }
        public string image_url { get; set; }
        public string quantity { get; set; }
        public string expiration_date { get; set; }
        public string brand { get; set; }
        public string nutriscore { get; set; }
        public string ingredients { get; set; }
        public string barcode { get; set; }
        public string stores { get; set; }
    }
}