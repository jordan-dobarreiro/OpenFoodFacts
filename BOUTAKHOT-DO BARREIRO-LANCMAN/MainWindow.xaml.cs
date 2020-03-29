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
        public List<string> m_list_categories;
        public List<Product> m_list_products;
        public MainWindow()
        {
            InitializeComponent();
        }

        //public void GetAllProducts(string url)
        public void GetAllProducts()
        {
            string url = "https://fr.openfoodfacts.org/categorie/pains.json";
            WebClient webClient = new WebClient();
            var json = webClient.DownloadString(url);
            JToken jtokens = JObject.Parse(json);
            //list<JToken> jtokens = JObject.Parse(json).Children().ToList();
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

        /*public void PrintAllProducts()
        {
            foreach (Product prod in m_list_products)
            {
                Console.WriteLine("oui");
                Console.WriteLine(prod);
            }
        }*/

        private void SearchNameClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("bite");
        }

        private void SearchBarecodeClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("bite");
        }

        private void SearchCategoryClick(object sender, RoutedEventArgs e)
        {
            GetAllProducts();
        }

        private void CategorySelectChange(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("bite");
        }

        public List<string> ListCategories
        {
            get { return m_list_categories; }
            set
            {
                m_list_categories = value;
                /// OnPropertyChanged("ListCategories");
            }
        }
        public List<Product> ListProducts
        {
            get { return m_list_products; }
            set
            {
                m_list_products = value;
                /// OnPropertyChanged("ListProducts");
            }
        }
    }
}
