﻿using System;
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
using LibraryProject.Assets.Models;
using LibraryProject.Models;
using LibraryProject.Assets.View.Pages;

namespace LibraryProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        Core db = new Core();
        public BookPage()
        {
            InitializeComponent();
            Reader arrayReader;
            Console.WriteLine(Properties.Settings.Default.RoleClient);
            //Логика отображения вкладок в меню
            //Если пользователь не авторизован, то ему не видны страницы:
            //Читательский билет, Пользователи, Личный кабинет
            if (Properties.Settings.Default.loginClient == String.Empty)
            {
                ReaderBilettsTextBlock.Visibility = Visibility.Hidden;
                UsersTextBlock.Visibility = Visibility.Hidden;
                PersonalAreaTextBlock.Visibility = Visibility.Hidden;
                BookAddButton.Visibility = Visibility.Hidden;
                NewBookAddButton.Visibility = Visibility.Hidden;
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
                    NewBookAddButton.Visibility = Visibility.Hidden;
                }
                //Библиотекарь
                if (rank == 2)
                {
                    ReaderBilettsTextBlock.Visibility = Visibility.Visible;
                    UsersTextBlock.Visibility = Visibility.Hidden;
                    BookAddButton.Visibility = Visibility.Visible;
                    NewBookAddButton.Visibility = Visibility.Visible;
                }
                //Администратор
                else if (rank == 3)
                {
                    UsersTextBlock.Visibility = Visibility.Visible;
                    ReaderBilettsTextBlock.Visibility = Visibility.Visible;
                    BookAddButton.Visibility = Visibility.Visible;
                    NewBookAddButton.Visibility = Visibility.Visible;
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
            //Сортировка по году выпуска (возрастание)
            else if (SortingComboBox.SelectedIndex==2)
            {
                LibraryEntities obj = new LibraryEntities();
                var sorting =
                    from Books in obj.Books
                    join BBK in obj.BBK on Books.BBK equals BBK.IdBBK
                    join HousePublication in obj.HousePublication on Books.HousePublication equals HousePublication.IdHouse
                    join City in obj.City on Books.IdCity equals City.IdCity
                    join Author in obj.Author on Books.Author equals Author.IdAuthor
                    orderby Books.YearOfPublication
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
            //Сортировка по году выпуска (убывание)
            else if (SortingComboBox.SelectedIndex==3)
            {
                LibraryEntities obj = new LibraryEntities();
                var sorting =
                    from Books in obj.Books
                    join BBK in obj.BBK on Books.BBK equals BBK.IdBBK
                    join HousePublication in obj.HousePublication on Books.HousePublication equals HousePublication.IdHouse
                    join City in obj.City on Books.IdCity equals City.IdCity
                    join Author in obj.Author on Books.Author equals Author.IdAuthor
                    orderby Books.YearOfPublication descending
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

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            LibraryEntities obj = new LibraryEntities();
            var questy =
                from Books in obj.Books
                join BBK in obj.BBK on Books.BBK equals BBK.IdBBK
                join HousePublication in obj.HousePublication on Books.HousePublication equals HousePublication.IdHouse
                join City in obj.City on Books.IdCity equals City.IdCity
                join Author in obj.Author on Books.Author equals Author.IdAuthor
                select new {Books.ISBN, Author.FullNameAuthor, Books.Title, BBK.TitleBBK, HousePublication.NameHouse, City.NameCity, Books.YearOfPublication, Books.PageCounts, Books.BooksCount};
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
                        PageCounts = item.PageCounts,
                        BooksCount = item.BooksCount
                    };
                    BookListView.Items.Add(books);
                }
            }
        }

        private void NewBookAddButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NewBookAddPage());
        }

        private void ReaderBilletBookAddButtonClick(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            BooksList activeBook = activeButton.DataContext as BooksList;
            string ISBN = activeBook.ISBN;
            Properties.Settings.Default.IdBook = ISBN;
            Books book = db.context.Books.Where(x => x.ISBN == ISBN).First();
            if (book.BooksCount!=0)
            {
                this.NavigationService.Navigate(new NewReaderBilletPage());
            }
            else
            {
                MessageBox.Show($"Данной книги пока нет в библиотеке. Подождите, когда другие дочитают");
            }
        }

        /// <summary>
        /// Поиск на странице "Книги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            BookListView.Items.Clear();
            string search = SearchTextBox.Text;
            LibraryEntities obj = new LibraryEntities();
            var questy =
                from Books in obj.Books
                join BBK in obj.BBK on Books.BBK equals BBK.IdBBK
                join HousePublication in obj.HousePublication on Books.HousePublication equals HousePublication.IdHouse
                join City in obj.City on Books.IdCity equals City.IdCity
                join Author in obj.Author on Books.Author equals Author.IdAuthor
                where Books.ISBN.Contains(search) || Author.FullNameAuthor.Contains(search) || Books.Title.Contains(search) || BBK.TitleBBK.Contains(search) || 
                    HousePublication.NameHouse.Contains(search) || City.NameCity.Contains(search) || Books.YearOfPublication.ToString().Contains(search) || Books.PageCounts.ToString().Contains(search) 
                select new { Books.ISBN, Author.FullNameAuthor, Books.Title, BBK.TitleBBK, HousePublication.NameHouse, City.NameCity, Books.YearOfPublication, Books.PageCounts, Books.BooksCount };
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
                        PageCounts = item.PageCounts,
                        BooksCount = item.BooksCount
                    };
                    BookListView.Items.Add(books);
                }
            }
        }

        private void DeleteBookButtonClick(object sender, RoutedEventArgs e)
        {
            string message = "Вы уверены, что хотите удалить книгу?";
            string title = "Удаление книги";
            MessageBoxResult res = MessageBox.Show(message, title, MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                Button activeButton = sender as Button;
                BooksList activeBook = activeButton.DataContext as BooksList;
                string ISBN = activeBook.ISBN;
                Books book = db.context.Books.Where(x => x.ISBN == ISBN).First();
                db.context.Books.Remove(book);
                db.context.SaveChanges();
                if (db.context.SaveChanges() == 0)
                    MessageBox.Show("Вы успешно удалили книгу");
                BookListView.Items.Clear();
                LibraryEntities obj = new LibraryEntities();
                var questy =
                    from Books in obj.Books
                    join BBK in obj.BBK on Books.BBK equals BBK.IdBBK
                    join HousePublication in obj.HousePublication on Books.HousePublication equals HousePublication.IdHouse
                    join City in obj.City on Books.IdCity equals City.IdCity
                    join Author in obj.Author on Books.Author equals Author.IdAuthor
                    select new { Books.ISBN, Author.FullNameAuthor, Books.Title, BBK.TitleBBK, HousePublication.NameHouse, City.NameCity, Books.YearOfPublication, Books.PageCounts, Books.BooksCount };
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
                            PageCounts = item.PageCounts,
                            BooksCount = item.BooksCount
                        };
                        BookListView.Items.Add(books);
                    }
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
        public int BooksCount { get; set; }
        public Visibility AdminControlVisibility
        {
            get
            {
                if (Properties.Settings.Default.RoleClient != 1)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
    }
}