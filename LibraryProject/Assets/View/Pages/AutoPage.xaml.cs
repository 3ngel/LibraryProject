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
using LibraryProject.Assets.Models;
using LibraryProject.Assets.ViewModel;

namespace LibraryProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка перехода на страницу "Регестрация"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegPage());
        }

        /// <summary>
        /// Кнопка входа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntranceButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                UsersClass obj = new UsersClass();
                if (obj.AutoUser(LoginTextBox.Text, PasswordTextBox.Password)==true)
                {
                    this.NavigationService.Navigate(new AboutUsPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
