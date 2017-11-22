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
using System.Windows.Shapes;

namespace Bibblan_GA
{
    /// <summary>
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        MainWindow mainWin = new MainWindow();
        private readonly Book selectedBook;

        public BookWindow(Book SelectedBook)
        {
            this.selectedBook = SelectedBook;
            InitializeComponent();
            InitializeStringsToFrames(selectedBook);
            ReserveButton.IsEnabled = MainWindow.match;

        }

        public void InitializeStringsToFrames(Book book)
        {


            bookAvailableTB.Text = "Available: " + book.StringAvailability + "      Total: " + book.TotalBooks;
            bookTitelTB.Text = book.Title;
            authorTB.Text = book.Author;
            genreTB.Text = book.Genre;
            bookInfoTB.Text = book.BookInfo;


        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainkWin = new MainWindow();
            mainkWin.Show();
            this.Close();
        }

        private void ReserveButton_Click(object sender, RoutedEventArgs e)
        {
            mainWin.Reserve(selectedBook);
            InitializeStringsToFrames(selectedBook);
        }
    }
}
