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
        List<Account> memberList = Library.BuildMemberList();
        public event EventHandler SearchDel;

        public bool availabilityChecked = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeLibraryList();
            
            //library = library.OrderBy(x => x.Author).ToList(); <-- Orders lists with a lambda. 
        }

        public bool LogIn()
        {
            bool match = false;
            List<Account> list = Library.BuildMemberList();

            foreach (var members in list)
            {

                if (members.Username == UsernameField.Text && members.Password == PasswordField.Text)
                {
                    match = true;
                    CheckAge(members.Age);
                    MessageBox.Show("Successfully logged in");
                    LogInButton.IsEnabled = false;
                    UsernameField.IsReadOnly = true;
                    PasswordField.IsReadOnly = true;
                }
            }
            
            if (match == false)
            MessageBox.Show("Error");

            return match;
        }

        #region EventHandlers

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            LogIn();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            
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
            availabilityChecked = true;
        }

        private void availableCB_Unchecked(object sender, RoutedEventArgs e)
        {

            availabilityChecked = false;
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
            foreach (var books in library)
                listView.Items.Add(books);
        }

        public void AllChecked(object source, EventArgs args)
        {
            var temp = library.Where(x => (x.Title + x.Genre + x.Isbn + x.Author).ToLower().Contains(searchField.Text.ToLower()));
            CheckMethod(temp);
        }

        public void TitelChecked(object source, EventArgs args)
        {
            var temp = library.Where(x => x.Title.ToLower().Contains(searchField.Text.ToLower()));
            CheckMethod(temp);
        }

        public void AuthorChecked(object source, EventArgs args)
        {
            var temp = library.Where(x => x.Author.ToLower().Contains(searchField.Text.ToLower()));
            CheckMethod(temp);
        }

        public void GenreChecked(object source, EventArgs args)
        {
            var temp = library.Where(x => x.Genre.ToLower().Contains(searchField.Text.ToLower()));
            CheckMethod(temp);
        }

        public void AvailableChecked(object source, EventArgs args)
        {
            var temp = library.Where(x => x.Availability.ToString().Contains(searchField.Text.ToLower()));
            foreach (var item in temp)
            {
                if (!listView.Items.Contains(item))
                {
                    if(availabilityChecked == false)
                       if (!listView.Items.Contains(item))
                        listView.Items.Add(item);

                    if (availabilityChecked == true && item.Availability == true)
                        if (!listView.Items.Contains(item))
                            listView.Items.Add(item);
                }                
            }
        }              

        public void IsbnChecked(object source, EventArgs args)
        {
            var temp = library.Where(x => x.Isbn.ToString().Contains(searchField.Text));
            CheckMethod(temp);
        }

        private void CheckMethod(IEnumerable<Book> x)
        {
            foreach (var item in x)
            {
                if (availabilityChecked == false)
                    if (!listView.Items.Contains(item))
                        listView.Items.Add(item);

                if (availabilityChecked == true && item.Availability == true)
                    if (!listView.Items.Contains(item))
                        listView.Items.Add(item);
            }
        }

        private void OnClick ()
        {
            {
                if (SearchDel != null)
                    SearchDel(this, EventArgs.Empty);
            }
        }

        private void CheckAge(int age)
        {
            if (age >= 18)
                AgeCB.IsEnabled = true;
        }

        #endregion
    }
}
