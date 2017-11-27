using System.Windows;

namespace Bibblan_GA
{
    /// <summary>
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        MainWindow mainWin = new MainWindow();
        private readonly Book selectedBook;

        /// <summary>
        /// Brings and sets choosen book-values from Mainwindow
        /// </summary>
        /// <param name="SelectedBook">The book that user choosed in Mainwindow</param>
        public BookWindow(Book SelectedBook)
        {
            this.selectedBook = SelectedBook;
            InitializeComponent();
            InitializeStringsToFrames(selectedBook);
            ReserveButton.IsEnabled = MainWindow.UserOnline;

        }

        /// <summary>
        /// Inserts correct values in the window elements
        /// </summary>
        /// <param name="book">Currently choosen book</param>
        public void InitializeStringsToFrames(Book book)
        {
            BookAvailableTB.Text = "Available: " + book.StringAvailability + "      Total: " + book.TotalBooks;
            BookTitelTB.Text = book.Title;
            authorTB.Text = book.Author;
            genreTB.Text = book.Genre;
            BookInfoTB.Text = book.BookInfo;


        }

        /// <summary>
        /// Takes user back to mainwindow and closes current
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainkWin = new MainWindow();
            mainkWin.Show();
            this.Close();
        }

        /// <summary>
        /// Reserves current book for the user and updates window-elements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReserveButton_Click(object sender, RoutedEventArgs e)
        {
            mainWin.Reserve(selectedBook);
            InitializeStringsToFrames(selectedBook);
        }
    }
}
