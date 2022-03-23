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
using System.Data.SqlClient;
using LibraryProject.Models;

namespace LibraryProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        Core db = new Core();
        List<Books> arrayBooks;
        List<Books> books;
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
            //Сортировка по возрастанию кол-ва страниц
            if (SortingComboBox.SelectedIndex == 0)
            {
                LibraryEntities obj = new LibraryEntities();
                var sorting =
                    from Books in obj.Books
                    join BBK in obj.BBK on Books.BBK equals BBK.IdBBK
                    join HousePublication in obj.HousePublication on Books.HousePublication equals HousePublication.IdHouse
                    join City in obj.City on Books.IdCity equals City.IdCity
                    join Author in obj.Author on Books.Author equals Author.IdAuthor
                    orderby Books.PageCounts
                    select new { Books.ISBN, Author.FullNameAuthor, Books.Title, BBK.TitleBBK, HousePublication.NameHouse, City.NameCity, Books.YearOfPublication, Books.PageCounts };
                BookListView.Items.Clear();
                if (sorting.Count() != 0)
                {
                    foreach (var item in sorting)
                    {
                        BooksList books = new BooksList()
                        {
                            ISBN = item.ISBN,
                            Title = item.Title,
                            Author = item.FullNameAuthor,
                            TitleBBK = item.TitleBBK,
                            NameHouse = item.NameHouse,
                            NameCity = item.NameCity,
                            YearOfPublication = item.YearOfPublication,
                            PageCounts = item.PageCounts
                        };
                        BookListView.Items.Add(books);
                    }
                }
            }
            //Сортировка по убыванию кол-ва страниц
            else if (SortingComboBox.SelectedIndex == 1)
            {
                LibraryEntities obj = new LibraryEntities();
                var sorting =
                    from Books in obj.Books
                    join BBK in obj.BBK on Books.BBK equals BBK.IdBBK
                    join HousePublication in obj.HousePublication on Books.HousePublication equals HousePublication.IdHouse
                    join City in obj.City on Books.IdCity equals City.IdCity
                    join Author in obj.Author on Books.Author equals Author.IdAuthor
                    orderby Books.PageCounts descending
                    select new { Books.ISBN, Author.FullNameAuthor, Books.Title, BBK.TitleBBK, HousePublication.NameHouse, City.NameCity, Books.YearOfPublication, Books.PageCounts };
                BookListView.Items.Clear();
                if (sorting.Count() != 0)
                {
                    foreach (var item in sorting)
                    {
                        BooksList books = new BooksList()
                        {
                            ISBN = item.ISBN,
                            Title = item.Title,
                            Author = item.FullNameAuthor,
                            TitleBBK = item.TitleBBK,
                            NameHouse = item.NameHouse,
                            NameCity = item.NameCity,
                            YearOfPublication = item.YearOfPublication,
                            PageCounts = item.PageCounts
                        };
                        BookListView.Items.Add(books);
                    }
                }
            }
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
            if (Properties.Settings.Default.loginClient!=String.Empty)
            {
                //Определить какая кнопку какой книги нажали
                Button activeButton = sender as Button;
                BooksList activeBook = activeButton.DataContext as BooksList;
                string ISBN = activeBook.ISBN;
                Reader activeReader = db.context.Reader.Where(x => x.Login == Properties.Settings.Default.loginClient).First();
                int ID = activeReader.IdReader;
                if (db.context.Extradition.Where(x=>x.IdReader==ID).Count()==0)
                {
                    //Какой сегодня день и когда вернуть книгу
                    DateTime today = DateTime.Now;
                    DateTime returnDate = today.AddDays(14);
                    //Подсчёт строк в таблице, потому что я дебил, который забыл поставить автозаполнение
                    int count = db.context.Extradition.Count() + 1;
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
                else
                {
                    MessageBox.Show("Вы уже читаете данную книгу");
                }
            }
            else
            {
                MessageBox.Show("Чтобы добавить книгу, авторизуйтесь");
            }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            LibraryEntities obj = new LibraryEntities();
            var questy =
                from Books in obj.Books
                join BBK in obj.BBK on Books.BBK equals BBK.IdBBK
                join HousePublication in obj.HousePublication on Books.HousePublication equals HousePublication.IdHouse
                join City in obj.City on Books.IdCity equals City.IdCity
                join Author in obj.Author on Books.Author equals Author.IdAuthor
                select new {Books.ISBN, Author.FullNameAuthor, Books.Title, BBK.TitleBBK, HousePublication.NameHouse, City.NameCity, Books.YearOfPublication, Books.PageCounts};
            if (questy.Count() != 0) 
            { 
                foreach (var item in questy)
                {
                    BooksList books = new BooksList()
                    {
                        ISBN = item.ISBN,
                        Title = item.Title,
                        Author = item.FullNameAuthor,
                        TitleBBK = item.TitleBBK,
                        NameHouse = item.NameHouse,
                        NameCity = item.NameCity,
                        YearOfPublication = item.YearOfPublication,
                        PageCounts = item.PageCounts
                    };
                    BookListView.Items.Add(books);
                }
            }
        }
    }

    public class BooksList
    {
        List<Books> books = new List<Books> { };
        public string ISBN { get; set;}
        public string Title { get; set;}
        public string Author { get; set;}
        public string TitleBBK { get; set;}
        public string NameHouse { get; set;}
        public string NameCity {get; set;}
        public int YearOfPublication { get; set;}
        public int PageCounts { get; set;}
    }
}