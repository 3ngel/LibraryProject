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
using LibraryProjestLibrary;

namespace LibraryProject.Pages
{
   
    /// <summary>
    /// Логика взаимодействия для PersonalAreaPage.xaml
    /// </summary>
    public partial class PersonalAreaPage : Page
    {
        public PersonalAreaPage()
        {
            InitializeComponent();
            Core db = new Core();
            Reader arrayReader;
            arrayReader = db.context.Reader.Where(x => x.Login == Properties.Settings.Default.loginClient).First();
            //Логика отображения вкладок в меню
            //Если пользователь не авторизован, то ему не видны страницы:
            //Читательский билет, Пользователи, Личный кабинет
            if (Properties.Settings.Default.loginClient == String.Empty)
            {
                ReaderBilettsTextBlock.Visibility = Visibility.Hidden;
                UsersTextBlock.Visibility = Visibility.Hidden;
            }
            else
            {
                //Отображение вкладок в соотвествии с рангом пользователя 
                //(пользователь, библиотекарь, администратор)
                
                int rank = arrayReader.IdRank;
                //Пользователь
                if (rank == 1)
                {
                    ReaderBilettsTextBlock.Visibility = Visibility.Hidden;
                    UsersTextBlock.Visibility = Visibility.Hidden;
                }
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
            //Отображение персональных данных пользователя
            arrayReader = db.context.Reader.Where(x => x.Login == Properties.Settings.Default.loginClient).First();
            LastNameTextBlock.Text = arrayReader.LastName; //Фамилия
            NameTextBlock.Text = arrayReader.Name; //Имя
            PatronymicNameTextBlock.Text = arrayReader.PatronymicName; //Отчество
            BirthDayTextBlock.Text = arrayReader.Birthday.ToString().Substring(0,10); //Дата рождения
            AdressTextBlock.Text = arrayReader.Adress; //Адресс проживания
            StudyOrWorkTextBlock.Text = arrayReader.StudyOrWork; //Место учёбы или работы
            NumberPhoneTextBlock.Text = arrayReader.NumberPhone; //Номер телефона
            //Вывод взятых книг
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
        /// Событие переноса на страницу "Книги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new BookPage());
        }
        /// <summary>
        /// Событие переноса на страницу "Читательский билет"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReaderBilletsTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new ReaderBilletsPage());
        }
        /// <summary>
        /// Событие переноса на страницу "Пользователи"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new UsersPage());
        }
        //Заполнение таблицы с читательскими билетамии активного пользователя с использованием смежных таблиц
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Core db = new Core();
            Reader arrayReader;            
            arrayReader = db.context.Reader.Where(x => x.Login == Properties.Settings.Default.loginClient).First();
            LibraryEntities obj = new LibraryEntities();
            GenerationString generation = new GenerationString();
            var billet =
                from Extradition in obj.Extradition
                join Reader in obj.Reader on Extradition.IdReader equals Reader.IdReader
                join Books in obj.Books on Extradition.IdBook equals Books.ISBN
                join Author in obj.Author on Books.Author equals Author.IdAuthor
                where Extradition.IdReader == arrayReader.IdReader
                select new
                {
                    Books.Title,
                    Author.FullNameAuthor,
                    Extradition.IdReaderBillet,
                    Extradition.DateOfIssue,
                    Extradition.ReturnDate
                };
            if (billet.Count() != 0)
            { 
                foreach (var item in billet)
                {
                    ReaderBillets readerBillets = new ReaderBillets
                    {
                        IdReaderBillet = item.IdReaderBillet,
                        Title = item.Title,
                        Author = item.FullNameAuthor,
                        DateOfIssue = item.DateOfIssue,
                        ReturnDate = item.ReturnDate
                    };
                    ReaderBilletsListView.Items.Add(readerBillets);
                }
            }
        }
    }
    //Таблица с читательскими билетамии активного пользователя с использованием смежных таблиц
    public class ReaderBilletsUser
    {
        List<Extradition> extraditions = new List<Extradition> { };
        public string IdReaderBillet { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
