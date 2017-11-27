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
        public event EventHandler SearchDel;
        List<Book> listToBePrinted = new List<Book>();
        public static bool UserOnline = false;

        public MainWindow()
        {
            InitializeComponent();
            CheckUserOnline(UserOnline);
        }

        #region EventHandlers

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            bool matchfound = Account.LogIn(UsernameField.Text, PasswordField.Text);
            CheckUserOnline(matchfound);
            UsernameField.Clear();
            PasswordField.Clear();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            SetWindowElementsOnLogOut();
            UsernameField.Clear();
            PasswordField.Clear();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            listToBePrinted.Clear();
            OnClick();
            PrintToListView();
        }

        private void AllCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += AllChecked;
        }

        private void AllCB_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchDel -= AllChecked;
        }

        private void TitelCB_Checked(object sender, RoutedEventArgs e)
        {
            SearchDel += TitelChecked;
        }

        private void TitelCB_Unchecked(object sender, RoutedEventArgs e)
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

        public void SetWindowElementsOnLogOut()
        {
            LogInButton.IsEnabled = true;
            LogOutButton.IsEnabled = false;
            UsernameField.IsReadOnly = false;
            PasswordField.IsReadOnly = false;
            UserOnline = false;
            MessageBox.Show("User has logged out");
        }

        public void AllChecked(object source, EventArgs args)
        {
            var filteredList = Library.Books.Where(x => (x.Title + x.Genre + x.Isbn + x.Author).ToLower().Contains(searchField.Text.ToLower()));
            PrintToGlobalList(filteredList);
        }

        public void TitelChecked(object source, EventArgs args)
        {
            var filteredList = Library.Books.Where(x => x.Title.ToLower().Contains(searchField.Text.ToLower()));
            PrintToGlobalList(filteredList);
        }

        public void AuthorChecked(object source, EventArgs args)
        {
            var filteredList = Library.Books.Where(x => x.Author.ToLower().Contains(searchField.Text.ToLower()));
            PrintToGlobalList(filteredList);
        }

        public void GenreChecked(object source, EventArgs args)
        {
            var filteredList = Library.Books.Where(x => x.Genre.ToLower().Contains(searchField.Text.ToLower()));
            PrintToGlobalList(filteredList);
        }

        public void AvailableChecked()
        {
            var temp = listToBePrinted.Where(x => x.Availability);

            foreach (var item in temp)
            {
                listView.Items.Add(item);
            }
        }

        public void IsbnChecked(object source, EventArgs args)
        {
            var filteredList = Library.Books.Where(x => x.Isbn.ToString().Contains(searchField.Text));
            PrintToGlobalList(filteredList);
        }

        public void PrintToGlobalList(IEnumerable<Book> list)
        {
            foreach (var book in list)
            {
                listToBePrinted.Add(book);
            }
        }

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

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedBook = (Book)listView.SelectedValue;
            BookWindow bookWin = new BookWindow(selectedBook);

            bookWin.Show();
            this.Close();
        }

        private void OnClick()
        {
            {
                SearchDel?.Invoke(this, EventArgs.Empty);
            }
        }

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
