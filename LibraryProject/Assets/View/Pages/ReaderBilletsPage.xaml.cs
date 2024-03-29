﻿using LibraryProject.Models;
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
    /// Логика взаимодействия для ReaderBilletsPage.xaml
    /// </summary>
    public partial class ReaderBilletsPage : Page
    {
        Core db = new Core();
        public ReaderBilletsPage()
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
            }
            else
            {
                //Отображение вкладок в соотвествии с рангом пользователя 
                //(пользователь, библиотекарь, администратор)
                arrayReader = db.context.Reader.Where(x => x.Login == Properties.Settings.Default.loginClient).First();
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
        /// Событие переноса на страницу "Пользователи"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new UsersPage());
        }

        /// <summary>
        /// Отображение Таблицы с читательскими билетами в ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            LibraryEntities obj = new LibraryEntities();
            GenerationString generation = new GenerationString(); 
            var billet =
                from Extradition in obj.Extradition
                join Reader in obj.Reader on Extradition.IdReader equals Reader.IdReader
                join Books in obj.Books on Extradition.IdBook equals Books.ISBN
                join Author in obj.Author on Books.Author equals Author.IdAuthor
                select new { Books.Title, Author.FullNameAuthor,
                    Reader.LastName, Reader.Name, Reader.PatronymicName, Extradition.IdReaderBillet,
                    Extradition.DateOfIssue, Extradition.ReturnDate};
            if (billet.Count()!=0)
                foreach (var item in billet)
                {
                    ReaderBillets readerBillets = new ReaderBillets
                    {
                        IdReaderBillet = item.IdReaderBillet,
                        Title = item.Title,
                        Author = item.FullNameAuthor,
                        LastName = item.LastName,
                        Name = item.Name,
                        PatronymicName = item.PatronymicName,
                        DateOfIssue = item.DateOfIssue,
                        ReturnDate = item.ReturnDate
                    };
                    ReaderBilletsListView.Items.Add(readerBillets);
                }
        }

        /// <summary>
        /// Удаление читательского билета по мере возращения книги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBilletButtonClick(object sender, RoutedEventArgs e)
        {
            Core db = new Core();
            Button activebutton = sender as Button;
            ReaderBillets activeBillet = activebutton.DataContext as ReaderBillets;
            string idBillet = activeBillet.IdReaderBillet;
            Extradition extradition = db.context.Extradition.Where(x => x.IdReaderBillet == idBillet).First();
            Books book = db.context.Books.Where(x => x.ISBN == extradition.IdBook).First();
            db.context.Extradition.Remove(extradition);
            db.context.SaveChanges();
            if (db.context.SaveChanges() == 0)
            {
                MessageBox.Show("Читатель вернул книгу");
                book.BooksCount += 1;
            }
            ReaderBilletsListView.Items.Clear();
            LibraryEntities obj = new LibraryEntities();
            var billet =
                from Extradition in obj.Extradition
                join Reader in obj.Reader on Extradition.IdReader equals Reader.IdReader
                join Books in obj.Books on Extradition.IdBook equals Books.ISBN
                join Author in obj.Author on Books.Author equals Author.IdAuthor
                select new
                {
                    Extradition.IdReaderBillet,
                    Books.Title,
                    Author.FullNameAuthor,
                    Reader.LastName,
                    Reader.Name,
                    Reader.PatronymicName,
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
                        LastName = item.LastName,
                        Name = item.Name,
                        PatronymicName = item.PatronymicName,
                        DateOfIssue = item.DateOfIssue,
                        ReturnDate = item.ReturnDate
                    };
                    ReaderBilletsListView.Items.Add(readerBillets);
                }
            }
        }
        /// <summary>
        /// ComboBox сортирующий читательские билеты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortingComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReaderBilletsListView.Items.Clear();
            //Сортировка по просроченнным читательским билетам
            if (SortingComboBox.SelectedIndex==0)
            {
                
                LibraryEntities obj = new LibraryEntities();
                GenerationString generation = new GenerationString();
                var billet =
                    from Extradition in obj.Extradition
                    join Reader in obj.Reader on Extradition.IdReader equals Reader.IdReader
                    join Books in obj.Books on Extradition.IdBook equals Books.ISBN
                    join Author in obj.Author on Books.Author equals Author.IdAuthor
                    where Extradition.ReturnDate<DateTime.Now
                    select new
                    {
                        Books.Title,
                        Author.FullNameAuthor,
                        Reader.LastName,
                        Reader.Name,
                        Reader.PatronymicName,
                        Extradition.IdReaderBillet,
                        Extradition.DateOfIssue,
                        Extradition.ReturnDate
                    };
                if (billet.Count() != 0)
                    foreach (var item in billet)
                    {
                        ReaderBillets readerBillets = new ReaderBillets
                        {
                            IdReaderBillet = item.IdReaderBillet,
                            Title = item.Title,
                            Author = item.FullNameAuthor,
                            LastName = item.LastName,
                            Name = item.Name,
                            PatronymicName = item.PatronymicName,
                            DateOfIssue = item.DateOfIssue,
                            ReturnDate = item.ReturnDate
                        };
                        ReaderBilletsListView.Items.Add(readerBillets);
                    }
            }
            //Сортировка по не просроченнным читательским билетам
            if (SortingComboBox.SelectedIndex == 1)
            {
                
                LibraryEntities obj = new LibraryEntities();
                GenerationString generation = new GenerationString();
                var billet =
                    from Extradition in obj.Extradition
                    join Reader in obj.Reader on Extradition.IdReader equals Reader.IdReader
                    join Books in obj.Books on Extradition.IdBook equals Books.ISBN
                    join Author in obj.Author on Books.Author equals Author.IdAuthor
                    where Extradition.ReturnDate > DateTime.Now
                    select new
                    {
                        Books.Title,
                        Author.FullNameAuthor,
                        Reader.LastName,
                        Reader.Name,
                        Reader.PatronymicName,
                        Extradition.IdReaderBillet,
                        Extradition.DateOfIssue,
                        Extradition.ReturnDate
                    };
                if (billet.Count() != 0)
                    foreach (var item in billet)
                    {
                        ReaderBillets readerBillets = new ReaderBillets
                        {
                            IdReaderBillet = item.IdReaderBillet,
                            Title = item.Title,
                            Author = item.FullNameAuthor,
                            LastName = item.LastName,
                            Name = item.Name,
                            PatronymicName = item.PatronymicName,
                            DateOfIssue = item.DateOfIssue,
                            ReturnDate = item.ReturnDate
                        };
                        ReaderBilletsListView.Items.Add(readerBillets);
                    }
            }
            //Обнуляет сортировку
            if (SortingComboBox.SelectedIndex == 2)
            {
                
                LibraryEntities obj = new LibraryEntities();
                GenerationString generation = new GenerationString();
                var billet =
                    from Extradition in obj.Extradition
                    join Reader in obj.Reader on Extradition.IdReader equals Reader.IdReader
                    join Books in obj.Books on Extradition.IdBook equals Books.ISBN
                    join Author in obj.Author on Books.Author equals Author.IdAuthor
                    select new
                    {
                        Books.Title,
                        Author.FullNameAuthor,
                        Reader.LastName,
                        Reader.Name,
                        Reader.PatronymicName,
                        Extradition.IdReaderBillet,
                        Extradition.DateOfIssue,
                        Extradition.ReturnDate
                    };
                if (billet.Count() != 0)
                    foreach (var item in billet)
                    {
                        ReaderBillets readerBillets = new ReaderBillets
                        {
                            IdReaderBillet = item.IdReaderBillet,
                            Title = item.Title,
                            Author = item.FullNameAuthor,
                            LastName = item.LastName,
                            Name = item.Name,
                            PatronymicName = item.PatronymicName,
                            DateOfIssue = item.DateOfIssue,
                            ReturnDate = item.ReturnDate
                        };
                        ReaderBilletsListView.Items.Add(readerBillets);
                    }
            }
        }
        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            ReaderBilletsListView.Items.Clear();
            LibraryEntities obj = new LibraryEntities();
            GenerationString generation = new GenerationString();
            string search = SearchTextBox.Text;
            var billet =
                from Extradition in obj.Extradition
                join Reader in obj.Reader on Extradition.IdReader equals Reader.IdReader
                join Books in obj.Books on Extradition.IdBook equals Books.ISBN
                join Author in obj.Author on Books.Author equals Author.IdAuthor
                where Books.Title.Contains(search) || Author.FullNameAuthor.Contains(search) || Reader.LastName.Contains(search) || Reader.Name.Contains(search)
                    || Reader.PatronymicName.Contains(search) || Extradition.IdReaderBillet.Contains(search)
                select new
                {
                    Books.Title,
                    Author.FullNameAuthor,
                    Reader.LastName,
                    Reader.Name,
                    Reader.PatronymicName,
                    Extradition.IdReaderBillet,
                    Extradition.DateOfIssue,
                    Extradition.ReturnDate
                };
            if (billet.Count() != 0)
                foreach (var item in billet)
                {
                    ReaderBillets readerBillets = new ReaderBillets
                    {
                        IdReaderBillet = item.IdReaderBillet,
                        Title = item.Title,
                        Author = item.FullNameAuthor,
                        LastName = item.LastName,
                        Name = item.Name,
                        PatronymicName = item.PatronymicName,
                        DateOfIssue = item.DateOfIssue,
                        ReturnDate = item.ReturnDate
                    };
                    ReaderBilletsListView.Items.Add(readerBillets);
                }
        }
    }
    public class ReaderBillets 
    {
        List<Extradition> extraditions = new List<Extradition> { };
        public string IdReaderBillet { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string PatronymicName { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
        public Visibility ReaderBilletsCheck
        {
            get
            {
                if (ReturnDate<DateTime.Now)
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
