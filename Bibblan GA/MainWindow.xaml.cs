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
        private List<Book> library = Library.BuildLibrary();
        private List<Account> memberList = Library.BuildMemberList();

        public event EventHandler SearchDel;

        public bool availabilityChecked = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeLibraryList();
            //library = library.OrderBy(x => x.Author).ToList(); <-- Orders lists with a lambda.
        }


        #region EventHandlers

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            LogIn();
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

        private void AgeCB_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void AgeCB_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        #endregion EventHandlers

        #region Methods

        public void InitializeLibraryList()
        {
            foreach (var books in library)
                listView.Items.Add(books);
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
                    FindButton.IsEnabled = true;
                }
            }

            if (match == false)
                MessageBox.Show("Error");

            return match;
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


        //TODO ASDFDGFHRSAESYDHTFJTSERD
        public void AgeChecked(object source, EventArgs args)
        {
            var temp = library.Where(x => x.minorAllowed = false && x.Title.ToLower().Contains(searchField.Text.ToLower()));

            foreach (var item in temp)
            {
                if (!listView.Items.Contains(item))
                {
                    if (item.minorAllowed == false)
                        if (!listView.Items.Contains(item))
                            listView.Items.Add(item);

                }
            }
        }

        public void AvailableChecked(object source, EventArgs args)
        {
            var temp = library.Where(x => x.Availability.ToString().Contains(searchField.Text.ToLower()));
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
                foreach (var item in library)
                    if (ReservedBook.Title.Equals(item.Title))
                    {
                        item.TotalBooks--;
                        MessageBox.Show(item.TotalBooks.ToString());

                        if (item.TotalBooks < 1)
                        {
                            ReservedBook.Availability = false;
                            item.Availability = false;
                        }
                        MessageBox.Show("Book reserved");
                    }

            }
        }

        private void CheckAge(int age)
        {
            if (age >= 18)
                AgeCB.IsEnabled = true;
        }

        #endregion Methods


    }
}
