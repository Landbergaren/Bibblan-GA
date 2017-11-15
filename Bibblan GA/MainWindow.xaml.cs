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
        public event EventHandler SearchDel;

        public MainWindow()
        {
            InitializeComponent();
            InitializeLibraryList();

            //library = library.OrderBy(x => x.Author).ToList(); <-- Orders lists with a lambda. 

        }

        #region EventHandlers

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (SearchDel != null)
                SearchDel(this, EventArgs.Empty);
        }

        private void AllCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += AllChecked;
        }

        private void AllCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchDel -= AllChecked;
        }

        private void titelCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += TitelChecked;
        }

        private void titelCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchDel -= TitelChecked;
        }

        private void AuthorCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += AuthorChecked;
        }

        private void AuthorCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchDel -= AuthorChecked;
        }

        private void GenreCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += GenreChecked;
        }

        private void GenreCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchDel -= GenreChecked;
        }

        private void availableCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += AvailableChecked;
        }

        private void availableCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchDel -= AvailableChecked;
        }

        private void IsbnCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += IsbnChecked;
        }

        private void IsbnCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchDel -= IsbnChecked;
        }

        #endregion

        #region Methods


        public void InitializeLibraryList()
        {
            listView.ItemsSource = library;
        }

        public void AllChecked(object source, EventArgs args)
        {
            listView.ItemsSource = library.Where(x => (x.Title + x.Genre + x.Isbn + x.Author).Contains(searchField.Text)).ToList();
        }

        public void TitelChecked(object source, EventArgs args)
        {
            listView.ItemsSource = library.Where(x => x.Title.Contains(searchField.Text)).ToList();
        }

        public void AuthorChecked(object source, EventArgs args)
        {
            listView.ItemsSource = library.Where(x => x.Author.Contains(searchField.Text)).ToList();
        }

        public void GenreChecked(object source, EventArgs args)
        {
            listView.ItemsSource = library.Where(x => x.Genre.Contains(searchField.Text)).ToList();
        }

        public void AvailableChecked(object source, EventArgs args)
        {
            listView.ItemsSource = library.Where(x => x.Availability).ToList();
        }

        public void IsbnChecked(object source, EventArgs args)
        {
            listView.ItemsSource = library.Where(x => x.Isbn.ToString().Contains(searchField.Text)).ToList();
        }

        #endregion


    }
}
