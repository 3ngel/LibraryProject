using LibraryProject.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        Core db = new Core();
        List<Books> arrayBooks;
        public BookPage()
        {
            InitializeComponent();
            Reader arrayReader;
            if (Properties.Settings.Default.loginClient == String.Empty)
            {
                ReaderBilettsTextBlock.Visibility = Visibility.Hidden;
                UsersTextBlock.Visibility = Visibility.Hidden;
                PersonalAreaTextBlock.Visibility = Visibility.Hidden;
            }
            else
            {

                arrayReader = db.context.Reader.Where(x => x.Login == Properties.Settings.Default.loginClient).First();
                PersonalAreaTextBlock.Visibility = Visibility.Visible;
                int rank = arrayReader.IdRank;
                if (rank == 1)
                {
                    ReaderBilettsTextBlock.Visibility = Visibility.Hidden;
                    UsersTextBlock.Visibility = Visibility.Hidden;
                }
                if (rank == 2)
                {
                    ReaderBilettsTextBlock.Visibility = Visibility.Visible;
                    UsersTextBlock.Visibility = Visibility.Hidden;
                }
                else if (rank == 3)
                {
                    UsersTextBlock.Visibility = Visibility.Visible;
                    ReaderBilettsTextBlock.Visibility = Visibility.Visible;
                }
            }
            ShowTable();
        }
        private void ShowTable ()
        {   
            arrayBooks = db.context.Books.ToList();
            BookListView.ItemsSource = arrayBooks;
        }
        private void AboutUsTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new AboutUsPage());
        }

        private void PersonalAreaTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new PersonalAreaPage());
        }

        private void ReaderBilletsTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new ReaderBilletsPage());
        }

        private void UsersTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new UsersPage());
        }
    }
}
