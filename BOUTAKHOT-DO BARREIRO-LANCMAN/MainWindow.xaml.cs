using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BOUTAKHOT_DO_BARREIRO_LANCMAN
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Product> m_list_products = new List<Product>();
        List<string> m_list_categories = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        //public void GetAllProducts(string url)
        public void GetAllProducts()
        {
            string url = "https://fr.openfoodfacts.org/categorie/pains.json";
            WebClient webClient = new WebClient();
            webClient.UseDefaultCredentials = true;
            var json = webClient.DownloadString(url);

            JToken jtokens = JObject.Parse(json)["products"];
            foreach (JToken jtoken in jtokens)
            {
                //MessageBox.Show((string)jtoken["product_name"]);
                Product product = new Product
                {
                    product_name = (string)jtoken["product_name"],
                    image_url = (string)jtoken["image_thumb_url"],
                    quantity = (string)jtoken["quantity"],
                    expiration_date = (string)jtoken["expiration_date"],
                    brand = (string)jtoken["brands"],
                    nutriscore = (string)jtoken["nutriscore_grade"],
                    ingredients = (string)jtoken["ingredients_text"],
                    barcode = (string)jtoken["id"]
                };
                //Product product = new Product((string)jtoken["product_name"], (string)jtoken["image_thumb_url"], (string)jtoken["quantity"], (string)jtoken["expiration_date"], (string)jtoken["brands"], (string)jtoken["nutriscore_grade"], (string)jtoken["ingredients_text"], (string)jtoken["id"]);
                if (!String.IsNullOrEmpty(product.product_name))
                {
                    m_list_products.Add(product);
                }
            }
        }

        private void SearchNameClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("bite");
        }

        private void SearchBarcodeClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("oui");
        }

        private void SearchCategoryClick(object sender, RoutedEventArgs e)
        {
            //List<Product> m_list_products = new List<Product>();
            GetAllProducts();
            this.Box.ItemsSource = m_list_products;
        }

        private void CategorySelectChange(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("bite");
        }
        private string GetLink(Product produit)
        {
            return "https://fr.openfoodfacts.org/produit/" + produit.barcode;
        }
    }
}
