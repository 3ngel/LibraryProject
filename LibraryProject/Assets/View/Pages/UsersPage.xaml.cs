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
using LibraryProject.Assets.View.Windows;

namespace LibraryProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        Core db = new Core();
        public UsersPage()
        {
            InitializeComponent();
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
            Users activeReader = activeButton.DataContext as Users;
            string fio = $"{activeReader.LastName} {activeReader.Name} {activeReader.PatronymicName}";
            string message = $"Вы хотите удалить пользователя {fio}?";
            string title = "Удаление пользователя";
            Reader reader = db.context.Reader.Where(x=>x.Login==activeReader.Login).First();
            MessageBoxResult res = MessageBox.Show(message, title, MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                db.context.Reader.Remove(reader);
                db.context.SaveChanges();
                if (db.context.SaveChanges()==0)
                {
                    MessageBox.Show("Удаление пользователя произошло успешно");
                    UsersListView.Items.Clear();
                    LibraryEntities obj = new LibraryEntities();
                    var qery =
                        from Reader in obj.Reader
                        join Halls in obj.Halls on Reader.Hall equals Halls.IdHall
                        join Rank in obj.Rank on Reader.IdRank equals Rank.IdRank
                        where Reader.Login !=Properties.Settings.Default.loginClient
                        select new { Reader.IdReader, Reader.LastName, Reader.Name, Reader.PatronymicName, Reader.Birthday, Reader.NumberPhone, Reader.Login, Reader.Password, Rank.NameRank, Halls.NameHall };
                    if (qery.Count() != 0)
                        foreach (var item in qery)
                        {
                            Users user = new Users()
                            {
                                IdReader = item.IdReader,
                                LastName = item.LastName,
                                Name = item.Name,
                                PatronymicName = item.PatronymicName,
                                Birthday = item.Birthday,
                                NumberPhone = item.NumberPhone,
                                Login = item.Login,
                                Password = item.Password,
                                Rank = item.NameRank,
                                Hall = item.NameHall
                            };
                            UsersListView.Items.Add(user);
                        }
                }
            }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            LibraryEntities obj = new LibraryEntities();
            var qery =
                from Reader in obj.Reader
                join Halls in obj.Halls on Reader.Hall equals Halls.IdHall
                join Rank in obj.Rank on Reader.IdRank equals Rank.IdRank
                where Reader.Login != Properties.Settings.Default.loginClient
                select new {Reader.IdReader, Reader.LastName, Reader.Name, Reader.PatronymicName, Reader.Birthday, Reader.NumberPhone, Reader.Login, Reader.Password, Rank.NameRank, Halls.NameHall};
            if (qery.Count()!=0)
                foreach (var item in qery)
                {
                    Users user = new Users()
                    {
                        IdReader = item.IdReader,
                        LastName = item.LastName,
                        Name = item.Name,
                        PatronymicName = item.PatronymicName,
                        Birthday = item.Birthday,
                        NumberPhone = item.NumberPhone,
                        Login = item.Login,
                        Password = item.Password,
                        Rank = item.NameRank,
                        Hall = item.NameHall
                    };
                    UsersListView.Items.Add(user);
                }
        }
        /// <summary>
        /// Поиск на странице Пользователи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            UsersListView.Items.Clear();
            string search = SearchTextBox.Text;
            LibraryEntities obj = new LibraryEntities();
            var qery =
                from Reader in obj.Reader
                join Halls in obj.Halls on Reader.Hall equals Halls.IdHall
                join Rank in obj.Rank on Reader.IdRank equals Rank.IdRank
                where Reader.Login != Properties.Settings.Default.loginClient
                where Reader.IdReader.ToString().Contains(search) || Reader.LastName.Contains(search) || Reader.Name.Contains(search) || Reader.PatronymicName.Contains(search) 
                    || Reader.Birthday.ToString().Contains(search) || Reader.NumberPhone.Contains(search) || Reader.Login.Contains(search) 
                    || Reader.Password.Contains(search) || Rank.NameRank.Contains(search) || Halls.NameHall.Contains(search)
                select new { Reader.IdReader, Reader.LastName, Reader.Name, Reader.PatronymicName, Reader.Birthday, Reader.NumberPhone, Reader.Login, Reader.Password, Rank.NameRank, Halls.NameHall };
            if (qery.Count() != 0)
                foreach (var item in qery)
                {
                    Users user = new Users()
                    {
                        IdReader = item.IdReader,
                        LastName = item.LastName,
                        Name = item.Name,
                        PatronymicName = item.PatronymicName,
                        Birthday = item.Birthday,
                        NumberPhone = item.NumberPhone,
                        Login = item.Login,
                        Password = item.Password,
                        Rank = item.NameRank,
                        Hall = item.NameHall
                    };
                    UsersListView.Items.Add(user);
                }
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            Users activeUsers = activeButton.DataContext as Users;
            Properties.Settings.Default.idUser = activeUsers.IdReader;
            new UserWindow().ShowDialog();
        }
    }
    public class Users
    {
        public int IdReader { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string PatronymicName { get; set;}
        public DateTime Birthday { get; set;}
        public string NumberPhone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Rank { get; set; }
        public string Hall { get; set; }


    }
}
