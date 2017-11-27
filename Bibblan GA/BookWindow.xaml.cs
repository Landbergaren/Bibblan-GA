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

        public BookWindow(Book SelectedBook)
        {
            this.selectedBook = SelectedBook;
            InitializeComponent();
            InitializeStringsToFrames(selectedBook);
            ReserveButton.IsEnabled = MainWindow.UserOnline;

        }

        public void InitializeStringsToFrames(Book book)
        {
            BookAvailableTB.Text = "Available: " + book.StringAvailability + "      Total: " + book.TotalBooks;
            BookTitelTB.Text = book.Title;
            authorTB.Text = book.Author;
            genreTB.Text = book.Genre;
            BookInfoTB.Text = book.BookInfo;


        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
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
