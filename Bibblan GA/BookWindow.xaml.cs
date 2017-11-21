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

        public BookWindow()
        {
            InitializeComponent();
            
            InitializeStringsToFrames();

        }

        async public void InitializeStringsToFrames()
        {
            await Task.Delay(100);

            bookAvailableTB.Text +=  ": " + MainWindow.SelectedBook.StringAvailability;
            bookTitelTB.Text = MainWindow.SelectedBook.Title;
            authorTB.Text = MainWindow.SelectedBook.Author;
            genreTB.Text = MainWindow.SelectedBook.Genre;
            bookInfoTB.Text = MainWindow.SelectedBook.BookInfo;


        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainkWin = new MainWindow();

            mainkWin.Show();
            this.Close();
        }
    }
}
