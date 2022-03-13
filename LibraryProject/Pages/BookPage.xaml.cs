using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
        List<BBK> arrayBBK;
        public BookPage()
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
                BookAddButton.Visibility = Visibility.Hidden;
            }
            else
            {
                //Отображение вкладок в соотвествии с рангом пользователя 
                //(пользователь, библиотекарь, администратор)
                arrayReader = db.context.Reader.Where(x => x.Login == Properties.Settings.Default.loginClient).First();
                PersonalAreaTextBlock.Visibility = Visibility.Visible;
                int rank = arrayReader.IdRank;
                //Пользователь
                if (rank == 1)
                {
                    ReaderBilettsTextBlock.Visibility = Visibility.Hidden;
                    UsersTextBlock.Visibility = Visibility.Hidden;
                    BookAddButton.Visibility = Visibility.Hidden;
                }
                //Библиотекарь
                if (rank == 2)
                {
                    ReaderBilettsTextBlock.Visibility = Visibility.Visible;
                    UsersTextBlock.Visibility = Visibility.Hidden;
                    BookAddButton.Visibility = Visibility.Visible;
                }
                //Администратор
                else if (rank == 3)
                {
                    UsersTextBlock.Visibility = Visibility.Visible;
                    ReaderBilettsTextBlock.Visibility = Visibility.Visible;
                    BookAddButton.Visibility = Visibility.Visible;
                }
            }
            arrayBooks = db.context.Books.ToList();
            arrayBBK = db.context.BBK.ToList();
            BookListView.ItemsSource = arrayBooks;
            // отображения ListView
            ShowTable();
        }
        
        /// <summary>
        /// Отображение данных из таблицы "Books"
        /// </summary>
        private void ShowTable ()
        {   
            arrayBooks = db.context.Books.ToList();
            BookListView.ItemsSource = arrayBooks;
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
        /// Событие переноса на страницу "Читательские билеты"
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
        //Сортировка книг
        private void SortingComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortingComboBox.SelectedIndex==0)
            {
                arrayBooks = arrayBooks.OrderBy(x=>x.PageCounts).ToList();
            }
            else if (SortingComboBox.SelectedIndex==1)
            {
                arrayBooks = arrayBooks.OrderByDescending(x => x.PageCounts).ToList();
            }

            BookListView.ItemsSource = arrayBooks;
        }
        /// <summary>
        /// Логика перехода на старницу для добавления новой книги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BookAddButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BookAddPage());
        }
        //Добавление новой книги в читательский билет
        private void AddBookButtonClick(object sender, RoutedEventArgs e)
        {
            //Определить какая кнопку какой книги нажали
            Button activeButton = sender as Button;
            Books activeBook = activeButton.DataContext as Books;
            string ISBN = activeBook.ISBN;
            //Какой сегодня день и когда вернуть книгу
            DateTime today = DateTime.Now;
            DateTime returnDate = today.AddDays(14);
            //Подсчёт строк в таблице, потому что я дебил, который забыл поставить автозаполнение
            int count = db.context.Extradition.Count()+1;
            Reader activeReader = db.context.Reader.Where(x => x.Login == Properties.Settings.Default.loginClient).First();
            int ID = activeReader.IdReader;
            Extradition extr = new Extradition 
            {
                IdReaderBillet = count,
                IdBook = ISBN,
                DateOfIssue = today,
                ReturnDate = returnDate,
                IdReader = ID
            };
            db.context.Extradition.Add(extr);
            try
            {
                db.context.SaveChanges();
                if (db.context.SaveChanges() == 0)
                {
                    MessageBox.Show("Книга успешно добавлена");
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }
    }
}
