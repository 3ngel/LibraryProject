using LibraryProject.Pages;
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

namespace LibraryProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigatedFrame.Navigate(new AboutUsPage());
        }
        /// <summary>
        /// Выход из приложения 
        /// </summary>
        private void WindowClosed(object sender, EventArgs e)
        {
            Properties.Settings.Default.loginClient = String.Empty;
            Properties.Settings.Default.RoleClient = 1;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Логика появление кнопки "Войти"
        /// </summary>
        private void MainFrameNavigated(object sender, NavigationEventArgs e)
        {
            //Логика появление кнопок Назад, Выйти, Войти
            var activePage = e.Content;
            if (activePage is AutoPage)
            {
                EntranceButton.Visibility = Visibility.Hidden;
            }
            //Отображение кнопки "Войти", если пользователь авторизован
            //и не отображение кнопки "Выйти" при авторизованном пользователе
            else if (Properties.Settings.Default.loginClient == String.Empty)
            {
                EntranceButton.Visibility = Visibility.Visible;
                ExitButton.Visibility = Visibility.Hidden;
            }
            //Не отображение кнопки "Войти", если пользователь авторизован
            //и отображение кнопки "Выйти" при авторизованном пользователе
            if (Properties.Settings.Default.loginClient!=String.Empty)
            {
                EntranceButton.Visibility = Visibility.Hidden;
                ExitButton.Visibility = Visibility.Visible;
            }
            if (activePage is AboutUsPage)
            {
                BackButton.Visibility = Visibility.Hidden;
            }
            else 
            {
                BackButton.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Логика взаимодействия кнопки назад
        /// </summary>
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            if (NavigatedFrame.CanGoBack)
            {
                NavigatedFrame.GoBack();
            }
        }
        /// <summary>
        /// Логика взаимодействия кнопки Войти
        /// </summary>
        private void EntranceButonClick(object sender, RoutedEventArgs e)
        {
            this.NavigatedFrame.Navigate(new AutoPage());
        }

        /// <summary>
        /// Выход из приложения без закрытия приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.loginClient = String.Empty;
            Properties.Settings.Default.RoleClient = 1;
            Properties.Settings.Default.Save();
            this.NavigatedFrame.Navigate(new AboutUsPage());
        }
    }
}
