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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        Core db = new Core();
        List<Reader> arrayUsers; 
        public UsersPage()
        {
            InitializeComponent();
            ShowTable();
        }
        /// <summary>
        /// Отображение данных из таблицы "Books"
        /// </summary>
        private void ShowTable()
        {
            arrayUsers = db.context.Reader.Where(x=>x.Login!=Properties.Settings.Default.loginClient).ToList();
            UsersListView.ItemsSource = arrayUsers;
        }
        /// <summary>
        /// Событие переноса на страницу "О нас"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutUsTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new AboutUsPage());
        }
        /// <summary>
        /// Событие переноса на страницу "Личный кабинет"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PersonalAreaTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new PersonalAreaPage());
        }
        /// <summary>
        /// Событие переноса на страницу "Книги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new BookPage());
        }
        /// <summary>
        /// Событие переноса на страницу "Читательские билеты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReaderBilletsTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new ReaderBilletsPage());
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteUserButtonClick(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            Reader activeReader = activeButton.DataContext as Reader;
            string fio = $"{activeReader.LastName} {activeReader.Name} {activeReader.PatronymicName}";
            string message = $"Вы хотите удалить пользователя {fio}?";
            string title = "Удаление пользователя";
            MessageBoxResult res = MessageBox.Show(message, title, MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                db.context.Reader.Remove(activeReader);
                db.context.SaveChanges();
                if (db.context.SaveChanges()==0)
                {
                    MessageBox.Show("Удаление пользователя произошло успешно");
                    ShowTable();
                }
            }
        }
    }
}
