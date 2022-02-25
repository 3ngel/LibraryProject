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
    /// Логика взаимодействия для ReaderBilletsPage.xaml
    /// </summary>
    public partial class ReaderBilletsPage : Page
    {
        public ReaderBilletsPage()
        {
            InitializeComponent();
            Core db = new Core();
            Reader arrayReader;
            arrayReader = db.context.Reader.Where(x => x.Login == Properties.Settings.Default.loginClient).First();
            int rank = arrayReader.IdRank;
            if (rank < 2)
            {
                ReaderBilettsTextBlock.Visibility = Visibility.Hidden;
                UsersTextBlock.Visibility = Visibility.Hidden;
            }
            else if (rank < 3)
            {
                UsersTextBlock.Visibility = Visibility.Hidden;
            }
        }

        private void AboutUsTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new AboutUsPage());
        }

        private void PersonalAreaTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new PersonalAreaPage());
        }

        private void BookTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new BookPage());
        }

        private void UsersTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new UsersPage());
        }
    }
}
