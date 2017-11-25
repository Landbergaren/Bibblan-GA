using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Windows.Controls;

namespace Bibblan_GA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //TODO respektabel, ej slampig kod, fixa bättre namn till alla datatyper, kommentera koden
        public event EventHandler SearchDel;

        List<Book> GlobalList = new List<Book>();

        public static bool UserOnline = false;

        public bool availabilityChecked = false;

        public MainWindow()
        {
            InitializeComponent();
            //InitializeLibraryList();

            CheckUserOnline(UserOnline);

            //library = library.OrderBy(x => x.Author).ToList(); <-- Orders lists with a lambda.
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
            LogOut(false);
            UsernameField.Clear();
            PasswordField.Clear();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            GlobalList.Clear();
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

        public void CheckUserOnline(bool matchfound)
        {
            if (matchfound == true)
            {
                LogInButton.IsEnabled = false;
                UsernameField.IsReadOnly = true;
                PasswordField.IsReadOnly = true;
                FindButton.IsEnabled = true;
                UserOnline = true;
            }
        }

        public void LogOut(bool x)
        {
            LogInButton.IsEnabled = true;
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
            var filteredList = Library.Books.Where(x => x.Isbn.ToString().Contains(searchField.Text));
            PrintToGlobalList(filteredList);
        }

        public void PrintToGlobalList(IEnumerable <Book> list)
        {
            foreach (var book in list)
            {
                GlobalList.Add(book);
            }
        }

        public void PrintToListView()
        {
           var ListqueryList = GlobalList.Distinct().ToList();
            foreach (var book in ListqueryList)
            {
                listView.Items.Add(book);
            }
        }

        //private void CheckMethod(IEnumerable<Book> x)
        //{
        //    foreach (var item in x)
        //    {
        //        if (availabilityChecked == false)
        //            if (!listView.Items.Contains(item))
        //                listView.Items.Add(item);

        //        if (availabilityChecked == true && item.Availability == true)
        //            if (!listView.Items.Contains(item))
        //                listView.Items.Add(item);
        //    }
        //}

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

                        if (item.TotalBooks < 1)
                        {
                            SelectedBook.Availability = false;
                            item.Availability = false;
                        }
                        MessageBox.Show("Book reserved");
                    }
            }
        }


        #endregion Methods

    }
}
