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
            Core db = new Core();
            List<Reader> arrayReader;
            arrayReader = db.context.Reader.ToList();
            int acount = arrayReader.Where(x=>x.Login==LoginTextBox.Text).Count();
            int countRecord = 0;
            try
            {
                //Проверка на наличие логина
                if (acount==1)
                {
                    arrayReader = db.context.Reader.Where(x => x.Login == LoginTextBox.Text).ToList();
                    //Если есть данный логин, проверка пароля при этом логине 
                    countRecord = arrayReader.Where(x => x.Login == LoginTextBox.Text && x.Password == PasswordTextBox.Password).Count();
                }
                //При совпдании занесение логина в запись приложения и переход на главную страницу
                if (countRecord==1)
                {
                    Properties.Settings.Default.loginClient = LoginTextBox.Text;
                    Properties.Settings.Default.RoleClient = db.context.Reader.Where(x => x.Login == LoginTextBox.Text).First().IdRank;
                    Properties.Settings.Default.Save();
                    this.NavigationService.Navigate(new AboutUsPage());
                }
                else
                {
                    MessageBox.Show("Неверный пароль или логин");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
