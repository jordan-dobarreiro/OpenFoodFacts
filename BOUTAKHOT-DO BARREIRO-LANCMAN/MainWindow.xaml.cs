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
            GetAllCategories();
            this.CategoryBox.ItemsSource = m_list_categories;
        }

        public void GetAllProducts(string category)
        {
            m_list_products.Clear();
            string url = "https://fr.openfoodfacts.org/categorie/" + category + ".json";
            WebClient webClient = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            webClient.UseDefaultCredentials = true;
            var json = webClient.DownloadString(url);

            JToken jtokens = JObject.Parse(json)["products"];
            foreach (JToken jtoken in jtokens)
            {
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
                
                if (!String.IsNullOrEmpty(product.product_name))
                {
                    m_list_products.Add(product);
                }
            }
        }

        public void GetAllCategories()
        {
            string url = "https://fr.openfoodfacts.org/categories.json";
            WebClient webClient = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            webClient.UseDefaultCredentials = true;
            var json = webClient.DownloadString(url);

            JToken jtokens = JObject.Parse(json)["tags"];
            foreach (JToken jtoken in jtokens)
            {
                string category = (string)jtoken["name"];
                if (!String.IsNullOrEmpty(category))
                {
                    m_list_categories.Add(category);
                }
            }
        }

        private void SearchNameClick(object sender, RoutedEventArgs e)
        {
            this.Box.ItemsSource = null;
            this.Box.Items.Clear();
            string name = ProductName.Text;

            string url = "https://fr.openfoodfacts.org/cgi/search.pl?search_terms=" + name + "&search_simple=1&action=process&json=1";
            WebClient webClient = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            webClient.UseDefaultCredentials = true;
            var json = webClient.DownloadString(url);

            JToken jtokens = JObject.Parse(json)["products"];
            foreach (JToken jtoken in jtokens)
            {
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

                if (!String.IsNullOrEmpty(product.product_name))
                {
                    m_list_products.Add(product);
                }
            }

            this.Box.ItemsSource = m_list_products;
        }

        private void SearchBarcodeClick(object sender, RoutedEventArgs e)
        {
            this.Box.ItemsSource = null;
            this.Box.Items.Clear();
        }

        private void SearchCategoryClick(object sender, RoutedEventArgs e)
        {
            this.Box.ItemsSource = null;
            this.Box.Items.Clear();
            string category = CategoryBox.Text;
            GetAllProducts(category);
            this.Box.ItemsSource = m_list_products;
        }
    }
}
