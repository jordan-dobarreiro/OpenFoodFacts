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

namespace BOUTAKHOT_DO_BARREIRO_LANCMAN
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> m_list_categories;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchNameClick(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBarecodeClick(object sender, RoutedEventArgs e)
        {

        }

        private void SearchCategoryClick(object sender, RoutedEventArgs e)
        {

        }

        private void CategorySelectChange(object sender, SelectionChangedEventArgs e)
        {

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
    }
}
