using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Bibblan_GA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Keeps an eye on all checkboxes subscribing to the searchbutton
        /// </summary>
        public event EventHandler SearchDel;
        /// <summary>
        /// Builds a temporary global list that gets managed and then printed to ListView
        /// </summary>
        List<Book> listToBePrinted = new List<Book>();
        /// <summary>
        /// Helps all windows to keep check on if user is online.
        /// </summary>
        public static bool UserOnline = false;

        public MainWindow()
        {
            InitializeComponent();
            CheckUserOnline(UserOnline);
        }

        #region Events
        /// <summary>
        /// Modifies window-elements and sets user to online if user gives correct input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            bool matchfound = Account.LogIn(UsernameField.Text, PasswordField.Text);
            CheckUserOnline(matchfound);
            UsernameField.Clear();
            PasswordField.Clear();
        }
        /// <summary>
        /// Modifies window-elements and logs out user
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            LogoutUser();
            UsernameField.Clear();
            PasswordField.Clear();
        }

        /// <summary>
        /// Manages Search-input and prints out to listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            listToBePrinted.Clear();
            OnClick();
            PrintToListView();
        }
        /// <summary>
        /// Subscribes "AllChecked" to eventhandler SearchDel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += AllChecked;
        }

        /// <summary>
        /// Unsubscribes to eventhandler SearchDel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchDel -= AllChecked;
        }

        /// <summary>
        /// Subscribes "TitelChecked" to eventhandler SearchDel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitelCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += TitelChecked;
        }

        /// <summary>
        /// Unsubscribes "TitelChecked" to eventhandler SearchDel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitelCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchDel -= TitelChecked;
        }

        /// <summary>
        /// Subscribes "AuthorChecked" to eventhandler SearchDel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthorCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += AuthorChecked;
        }

        /// <summary>
        /// Unsubscribes "AuthorChecked" to eventhandler SearchDel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthorCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchDel -= AuthorChecked;
        }

        /// <summary>
        /// Subscribes "GenreChecked" to eventhandler SearchDel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenreCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += GenreChecked;
        }

        /// <summary>
        /// Unsubscribes "GenreChecked" to eventhandler SearchDel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenreCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchDel -= GenreChecked;
        }

        /// <summary>
        /// Subscribes "IsbnChecked" to eventhandler SearchDel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsbnCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += IsbnChecked;
        }

        /// <summary>
        /// Unsubscribes "IsbnChecked" to eventhandler SearchDel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsbnCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchDel -= IsbnChecked;
        }

        /// <summary>
        /// Event that Adds user-selected book to selected book and opens new window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedBook = (Book)listView.SelectedValue;
            BookWindow bookWin = new BookWindow(selectedBook);

            bookWin.Show();
            this.Close();
        }

        #endregion EventHandlers

        #region Methods
        /// <summary>
        /// Sets all properties to fit a logged in user
        /// </summary>
        /// <param name="matchfound"></param>
        public void CheckUserOnline(bool matchfound)
        {
            if (matchfound == true)
            {
                LogInButton.IsEnabled = false;
                LogOutButton.IsEnabled = true;
                UsernameField.IsReadOnly = true;
                PasswordField.IsReadOnly = true;
                FindButton.IsEnabled = true;
                UserOnline = true;
            }
        }

        /// <summary>
        /// Sets all properties to fit a logged out user
        /// </summary>
        public void LogoutUser()
        {
            LogInButton.IsEnabled = true;
            LogOutButton.IsEnabled = false;
            UsernameField.IsReadOnly = false;
            PasswordField.IsReadOnly = false;
            UserOnline = false;
            MessageBox.Show("User has logged out");
        }

        /// <summary>
        /// Adds ALL Books to listToBePrinted
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void AllChecked(object source, EventArgs args)
        {
            var filteredList = Library.Books.Where(x => (x.Title + x.Genre + x.Isbn + x.Author).ToLower().Contains(searchField.Text.ToLower()));
            PrintToGlobalList(filteredList);
        }

        /// <summary>
        /// Adds all books where searchfield-input matches booktitel to listToBePrinted
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void TitelChecked(object source, EventArgs args)
        {
            var filteredList = Library.Books.Where(x => x.Title.ToLower().Contains(searchField.Text.ToLower()));
            PrintToGlobalList(filteredList);
        }

        /// <summary>
        /// Adds all books where searchfield-input matches book author to listToBePrinted
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void AuthorChecked(object source, EventArgs args)
        {
            var filteredList = Library.Books.Where(x => x.Author.ToLower().Contains(searchField.Text.ToLower()));
            PrintToGlobalList(filteredList);
        }

        /// <summary>
        /// Adds all books where searchfield-input matches book-genre to listToBePrinted
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void GenreChecked(object source, EventArgs args)
        {
            var filteredList = Library.Books.Where(x => x.Genre.ToLower().Contains(searchField.Text.ToLower()));
            PrintToGlobalList(filteredList);
        }

        /// <summary>
        /// Filters out all the available books from listToBePrinted and adds to ListView
        /// </summary>
        public void AvailableChecked()
        {
            var temp = listToBePrinted.Where(x => x.Availability);

            foreach (var item in temp)
            {
                listView.Items.Add(item);
            }
        }

        /// <summary>
        /// Adds all books where searchfield-input matches book-Isbn to listToBePrinted
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void IsbnChecked(object source, EventArgs args)
        {
            var filteredList = Library.Books.Where(x => x.Isbn.ToString().Contains(searchField.Text));
            PrintToGlobalList(filteredList);
        }
        
        /// <summary>
        /// Adds list to listToBePrinted
        /// </summary>
        /// <param name="list">List to be added in</param>
        public void PrintToGlobalList(IEnumerable<Book> list)
        {
            foreach (var book in list)
            {
                listToBePrinted.Add(book);
            }
        }

        /// <summary>
        /// Prints listToBePrinted to ListView without duplicates
        /// </summary>
        public void PrintToListView()
        {
            var ListqueryList = listToBePrinted.Distinct().ToList();

            if ((bool)!availableCB.IsChecked)
            {
                foreach (var book in ListqueryList)
                    listView.Items.Add(book);
            }
            else
                AvailableChecked();
        }

        /// <summary>
        /// publisher for the applications Search-button
        /// </summary>
        private void OnClick()
        {
            {
                SearchDel?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Reserves book for user if available
        /// </summary>
        /// <param name="SelectedBook">Current choosen book by user</param>
        public void Reserve(Book SelectedBook)
        {
            if (SelectedBook.Availability == false)
                MessageBox.Show("No books in storage");

            else
            {
                foreach (var item in Library.Books)
                    if (SelectedBook.Title.Equals(item.Title))
                    {
                        item.TotalBooks--;
                        MessageBox.Show("Book reserved");
                    }
            }
        }
        #endregion Methods
    }
}
