﻿using System;
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
        public static Book SelectedBook { get; set; }
        List<Book> library = Library.BuildLibrary();
        public event EventHandler SearchDel;


        public bool availabilityChecked = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeLibraryList();
            
            //library = library.OrderBy(x => x.Author).ToList(); <-- Orders lists with a lambda. 
        }



        #region EventHandlers

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            
            // lägg publisher i en OnClick metod.. (protected virutal)
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

         private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BookWindow bookWin = new BookWindow();
            SelectedBook = (Book)listView.SelectedValue;


            bookWin.Show();
            this.Close();
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

        #endregion


    }

}
