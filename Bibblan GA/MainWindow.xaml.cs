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

namespace Bibblan_GA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Book> library = Library.BuildLibrary();        

        public MainWindow()
        {
            InitializeComponent();
            InitializeLibraryList();

            //library = library.OrderBy(x => x.Author).ToList(); <-- Orders lists with a lambda. 

        }

        public void InitializeLibraryList()
        {
            listView.ItemsSource = library;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = library.Where(x => x.Title.Contains(searchField.Text)).ToList();
        }

        private void availableCB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void titelCB_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
