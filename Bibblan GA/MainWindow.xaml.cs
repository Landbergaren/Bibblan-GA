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

        #endregion

        #region Methods

        public void InitializeLibraryList()
        {
            listView.ItemsSource = library;
        }

        public void TitelChecked(object source, EventArgs args)
        {
            listView.ItemsSource = library.Where(x => x.Title.Contains(searchField.Text)).ToList();
        }

        public void AuthorChecked(object source, EventArgs args)
        {
            listView.ItemsSource = library.Where(x => x.Author.Contains(searchField.Text)).ToList();
        }

        #endregion


    }
}
