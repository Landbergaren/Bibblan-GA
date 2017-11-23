using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace Bibblan_GA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //TODO Sätt ihop log-out knapp med inbygga LogOut metoden, göra gui-et snyggare, respektabel, ej slampig kod, fixa bättre namn till alla datatyper, kommentera koden

        private List<Account> memberList = Account.BuildMemberList();

        public event EventHandler SearchDel;

        public static bool match = false;

        public bool availabilityChecked = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeLibraryList();

            LoggedIn(match);
            
            //library = library.OrderBy(x => x.Author).ToList(); <-- Orders lists with a lambda.
        }


        #region EventHandlers

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            LogIn();
            UsernameField.Clear();
            PasswordField.Clear();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            LogOut(false);
            UsernameField.Clear();
            PasswordField.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();

            OnClick();
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

        #endregion EventHandlers

        #region Methods

        public void InitializeLibraryList()
        {
            foreach (var book in Library.Books)
                listView.Items.Add(book);
        }

        public bool LogIn()
        {
            List<Account> list = Account.BuildMemberList();

            foreach (var members in list)
            {
                if (members.Username == UsernameField.Text && members.Password == PasswordField.Text)
                {
                    match = true;
                    LoggedIn(match);
                    MessageBox.Show("Successfully logged in");

                }
            }

            if (match == false)
                MessageBox.Show("Error");

            return match;
        }

        public void LoggedIn(bool x)
        {
            if (x == true)
            {
                LogInButton.IsEnabled = false;
                UsernameField.IsReadOnly = true;
                PasswordField.IsReadOnly = true;
                FindButton.IsEnabled = true;
            }
        }

        public void LogOut(bool x)
        {
            LogInButton.IsEnabled = true;
            UsernameField.IsReadOnly = false;
            PasswordField.IsReadOnly = false;
            match = false;
            MessageBox.Show("User has logged out");
        }

        public void AllChecked(object source, EventArgs args)
        {
            var temp = Library.Books.Where(x => (x.Title + x.Genre + x.Isbn + x.Author).ToLower().Contains(searchField.Text.ToLower()));
            CheckMethod(temp);
        }

        public void TitelChecked(object source, EventArgs args)
        {
            var temp = Library.Books.Where(x => x.Title.ToLower().Contains(searchField.Text.ToLower()));
            CheckMethod(temp);
        }

        public void AuthorChecked(object source, EventArgs args)
        {
            var temp = Library.Books.Where(x => x.Author.ToLower().Contains(searchField.Text.ToLower()));
            CheckMethod(temp);
        }

        public void GenreChecked(object source, EventArgs args)
        {
            var temp = Library.Books.Where(x => x.Genre.ToLower().Contains(searchField.Text.ToLower()));
            CheckMethod(temp);
        }

        public void AvailableChecked(object source, EventArgs args)
        {
            var temp = Library.Books.Where(x => x.Availability.ToString().Contains(searchField.Text.ToLower()));
            foreach (var item in temp)
            {
                if (!listView.Items.Contains(item))
                {
                    if (availabilityChecked == false)
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
            var temp = Library.Books.Where(x => x.Isbn.ToString().Contains(searchField.Text));
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

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedBook = (Book)listView.SelectedValue;
            BookWindow bookWin = new BookWindow(selectedBook);



            bookWin.Show();
            this.Close();
        }

        private void OnClick()
        {
            {
                if (SearchDel != null)
                    SearchDel(this, EventArgs.Empty);
            }
        }

        public void Reserve(Book ReservedBook)
        {
            if (ReservedBook.Availability == false)
                MessageBox.Show("No books in storage");

            else
            {
                foreach (var item in Library.Books)
                    if (ReservedBook.Title.Equals(item.Title))
                    {
                        item.TotalBooks--;

                        if (item.TotalBooks < 1)
                        {
                            ReservedBook.Availability = false;
                            item.Availability = false;
                        }
                        MessageBox.Show("Book reserved");
                    }
            }
        }


        #endregion Methods

    }
}
