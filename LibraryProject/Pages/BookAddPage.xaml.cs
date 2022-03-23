using LibraryProject.Models;
using LibraryProjestLibrary;
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
    /// Логика взаимодействия для BookAddPage.xaml
    /// </summary>
    public partial class BookAddPage : Page
    {
        Core db = new Core();
        List<BBK> arrayBBK;
        List<HousePublication> arrayHouse;
        List<City> arrayCity;
        List<Author> arrayAuthor;
        List<string> indexBBK;
        List<int> indexHouse;
        List<int> indexCity;
        List<int> indexAuthor;
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
            indexBBK = new List<string> { };
            arrayHouse = db.context.HousePublication.ToList();
            indexHouse = new List<int> { };
            arrayCity = db.context.City.ToList();
            indexCity = new List<int> { };
            arrayAuthor = db.context.Author.ToList();
            indexAuthor = new List<int> { };
            foreach (var item in arrayBBK)
            {
                BBKComboBox.Items.Add(item.TitleBBK);
                indexBBK.Add(item.IdBBK);
            }
            foreach (var item in arrayHouse)
            {
                HousePublicationComboBoxox.Items.Add(item.NameHouse);
                indexHouse.Add(item.IdHouse);
            }
            foreach (var item in arrayCity)
            {
                CityComboBox.Items.Add(item.NameCity);
                indexCity.Add(item.IdCity);
            }
            foreach (var item in arrayAuthor)
            {
                AuthorComboBox.Items.Add(item.FullNameAuthor);
                indexAuthor.Add(item.IdAuthor);
            }
        }
        /// <summary>
        /// Кнопка переноса на страницу "О нас"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutUsTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (AuthorComboBox.SelectedItem == null || TitleTextBox.Text!=String.Empty || 
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
            if (AuthorComboBox.SelectedItem == null || TitleTextBox.Text != String.Empty ||
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
            if (AuthorComboBox.SelectedItem == null || TitleTextBox.Text != String.Empty ||
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
            if (AuthorComboBox.SelectedItem == null || TitleTextBox.Text != String.Empty ||
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
            if (AuthorComboBox.SelectedItem == null || TitleTextBox.Text != String.Empty ||
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
            GenerationString obj = new GenerationString();
            CheckStringClass check = new CheckStringClass();
            string isbn = obj.ISBNGeneration();
            BookAddPage add = new BookAddPage();
            try
            {
                if (AuthorComboBox.SelectedItem!=null)
                {
                    if (check.TitleCheck(TitleTextBox.Text) == true)
                    {
                        if (check.YearCheck(YearOfPublicationTextBox.Text) == true)
                        {
                            if (check.PageCountsCheck(PageCountsTextBox.Text) == true)
                            {
                                if (BBKComboBox.SelectedItem != null)
                                {
                                    if (HousePublicationComboBoxox.SelectedItem != null)
                                    {
                                        if (isbn.Length == 13)
                                        {
                                            if (CityComboBox.SelectedItem != null)
                                            {
                                                Books book = new Books()
                                                {
                                                    ISBN = isbn,
                                                    Author = indexAuthor[AuthorComboBox.SelectedIndex],
                                                    Title = TitleTextBox.Text,
                                                    BBK = indexBBK[BBKComboBox.SelectedIndex],
                                                    HousePublication = indexHouse[HousePublicationComboBoxox.SelectedIndex],
                                                    IdCity = indexCity[CityComboBox.SelectedIndex],
                                                    PageCounts =Convert.ToInt32(PageCountsTextBox.Text),
                                                    YearOfPublication =Convert.ToInt32(YearOfPublicationTextBox.Text)
                                                };
                                                db.context.Books.Add(book);
                                                try
                                                {
                                                    db.context.SaveChanges();
                                                    if (db.context.SaveChanges() == 0)
                                                    {
                                                        MessageBox.Show("Вы успешно добавили книгу");
                                                        this.NavigationService.Navigate(new BookPage());
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
                                                MessageBox.Show("Вы не выбрали город");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show(isbn);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Вы не выбрали дом печати");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Вы не выбрали направление книги");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
