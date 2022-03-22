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
    /// Логика взаимодействия для BookAddPage.xaml
    /// </summary>
    public partial class BookAddPage : Page
    {
        Core db = new Core();
        List<BBK> arrayBBK;
        List<HousePublication> arrayHouse;
        List<City> arrayCity;
        public BookAddPage()
        {
            InitializeComponent();
            Reader arrayReader;
            //Логика отображения вкладок в меню
            //Если пользователь не авторизован, то ему не видны страницы:
            //Читательский билет, Пользователи, Личный кабинет
            if (Properties.Settings.Default.loginClient == String.Empty)
            {
                ReaderBilettsTextBlock.Visibility = Visibility.Hidden;
                UsersTextBlock.Visibility = Visibility.Hidden;
                PersonalAreaTextBlock.Visibility = Visibility.Hidden;
            }
            else
            {
                //Отображение вкладок в соотвествии с рангом пользователя 
                //(библиотекарь, администратор)
                arrayReader = db.context.Reader.Where(x => x.Login == Properties.Settings.Default.loginClient).First();
                PersonalAreaTextBlock.Visibility = Visibility.Visible;
                int rank = arrayReader.IdRank;
                //Библиотекарь
                if (rank == 2)
                {
                    ReaderBilettsTextBlock.Visibility = Visibility.Visible;
                    UsersTextBlock.Visibility = Visibility.Hidden;
                }
                //Администратор
                else if (rank == 3)
                {
                    UsersTextBlock.Visibility = Visibility.Visible;
                    ReaderBilettsTextBlock.Visibility = Visibility.Visible;
                }
            }
            int count = db.context.BBK.Count();
            //Вывод ComboBox
            arrayBBK = db.context.BBK.ToList();
            List<string> indexBBK = new List<string> { };
            arrayHouse = db.context.HousePublication.ToList();
            List<int> indexHouse = new List<int> { };
            arrayCity = db.context.City.ToList();
            List<int> indexCity = new List<int> { };
            foreach (var item in arrayBBK)
            {
                int i = 0;
                BBKComboBoxox.Items.Add(item.TitleBBK);
                indexBBK.Add(item.IdBBK);
                i++;
            }
            foreach (var item in arrayHouse)
            {
                int i = 0;
                HousePublicationComboBoxox.Items.Add(item.NameHouse);
                indexHouse.Add(item.IdHouse);
                i++;
            }
            foreach (var item in arrayCity)
            {
                int i = 0;
                CityComboBox.Items.Add(item.NameCity);
                indexCity.Add(item.IdCity);
                i++;
            }
        }
        /// <summary>
        /// Кнопка переноса на страницу "О нас"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutUsTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (AuthorTextBox.Text != String.Empty || TitleTextBox.Text!=String.Empty || 
                YearOfPublicationTextBox.Text!=String.Empty || PageCountsTextBox.Text!=String.Empty)
            {
                string message = "Вы уверены, что хотите покинуть страницу?";
                string title = "Заполненные поля";
                MessageBoxResult res = MessageBox.Show(message,title, MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new AboutUsPage());
                }
            }
            else
            {
                this.NavigationService.Navigate(new AboutUsPage());
            }
        }
        /// <summary>
        /// Кнопка переноса на страницу "Личный кабинет"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PersonalAreaTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (AuthorTextBox.Text != String.Empty || TitleTextBox.Text != String.Empty ||
                YearOfPublicationTextBox.Text != String.Empty || PageCountsTextBox.Text != String.Empty)
            {
                string message = "Вы уверены, что хотите покинуть страницу?";
                string title = "Заполненные поля";
                MessageBoxResult res = MessageBox.Show(message, title, MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new PersonalAreaPage());
                }
            }
            else
            {
                this.NavigationService.Navigate(new PersonalAreaPage());
            }
        }
        /// <summary>
        /// Кнопка переноса на страницу "Книги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (AuthorTextBox.Text != String.Empty || TitleTextBox.Text != String.Empty ||
                YearOfPublicationTextBox.Text != String.Empty || PageCountsTextBox.Text != String.Empty)
            {
                string message = "Вы уверены, что хотите покинуть страницу?";
                string title = "Заполненные поля";
                MessageBoxResult res = MessageBox.Show(message, title, MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new BookPage());
                }
            }
            else
            {
                this.NavigationService.Navigate(new BookPage());
            }
        }
        /// <summary>
        /// Кнопка переноса на страницу "Читательские билеты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReaderBilletsTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (AuthorTextBox.Text != String.Empty || TitleTextBox.Text != String.Empty ||
                YearOfPublicationTextBox.Text != String.Empty || PageCountsTextBox.Text != String.Empty)
            {
                string message = "Вы уверены, что хотите покинуть страницу?";
                string title = "Заполненные поля";
                MessageBoxResult res = MessageBox.Show(message, title, MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new ReaderBilletsPage());
                }
            }
            else
            {
                this.NavigationService.Navigate(new ReaderBilletsPage());
            }
        }
        /// <summary>
        /// Кнопка переноса на страницу "Пользоватлеи"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (AuthorTextBox.Text != String.Empty || TitleTextBox.Text != String.Empty ||
                YearOfPublicationTextBox.Text != String.Empty || PageCountsTextBox.Text != String.Empty)
            {
                string message = "Вы уверены, что хотите покинуть страницу?";
                string title = "Заполненные поля";
                MessageBoxResult res = MessageBox.Show(message, title, MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new UsersPage());
                }
            }
            else
            {
                this.NavigationService.Navigate(new UsersPage());
            }
        }

        /// <summary>
        /// Кнопка добавления новой книги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookAddButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
