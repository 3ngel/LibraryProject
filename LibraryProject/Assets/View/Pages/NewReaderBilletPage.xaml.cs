using LibraryProject.Assets.Models;
using LibraryProject.Models;
using LibraryProject.Pages;
using LibraryProjestLibrary;
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

namespace LibraryProject.Assets.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewReaderBilletPage.xaml
    /// </summary>
    public partial class NewReaderBilletPage : Page
    {
        Core db = new Core();
        public NewReaderBilletPage()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            LibraryEntities obj = new LibraryEntities();
            var quer =
                from Reader in obj.Reader
                join Halls in obj.Halls on Reader.Hall equals Halls.IdHall
                where Reader.Login!=Properties.Settings.Default.loginClient
                select new { Reader.LastName, Reader.Name, Reader.PatronymicName, Reader.NumberPhone, Halls.NameHall, Halls.IdHall, Reader.IdReader };
            if (quer.Count() != 0)
            {
                foreach (var item in quer)
                {
                    UserList user = new UserList()
                    {
                        Role = item.IdReader,
                        LastName = item.LastName,
                        Name = item.Name,
                        PatronymicName = item.PatronymicName,
                        Number = item.NumberPhone,
                        Hall = item.NameHall,
                        IdHall = item.IdHall
                    };
                    UsersListView.Items.Add(user);
                }
            }
        }

        /// <summary>
        /// Добавление выбраннай книги читателю
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoiceUserButtonClick(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            UserList activeUser = activeButton.DataContext as UserList;
            int IdUser = activeUser.Role;
            int hall = activeUser.IdHall;
            int y = DateTime.Now.Year;
            int count = db.context.Extradition.ToList().Count();
            GenerationString generation = new GenerationString();
            string IdBook = Properties.Settings.Default.IdBook;
            Extradition extradition = new Extradition
            {
                IdReaderBillet = generation.NumberBilletGeneration(hall, Convert.ToString(y).Substring(2, 2), count),
                IdBook = Properties.Settings.Default.IdBook,
                IdReader = IdUser,
                DateOfIssue = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(14)
            };
            //Избежание повтора первичного ключа, если удалялись билеты
            int ext = db.context.Extradition.Where(x => x.IdReaderBillet == extradition.IdReaderBillet).ToList().Count(); ;
            while (ext!=0)
            {
                count++;
                extradition.IdReaderBillet = generation.NumberBilletGeneration(hall, Convert.ToString(y).Substring(2, 2), count);
                ext = db.context.Extradition.Where(x => x.IdReaderBillet == extradition.IdReaderBillet).ToList().Count();
            }
            db.context.Extradition.Add(extradition);
            db.context.SaveChanges();
            if (db.context.SaveChanges() == 0)
            {
                MessageBox.Show("Вы добавили книгу этому пользователю");
                Books book = db.context.Books.Where(x => x.ISBN == Properties.Settings.Default.IdBook).First();
                book.BooksCount -= 1;
                Properties.Settings.Default.IdBook = String.Empty;
                Properties.Settings.Default.Save();
                this.NavigationService.Navigate(new BookPage());
            }
        }
    }
    public class UserList
    {
        public int Role { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string PatronymicName { get; set; }
        public string Number { get; set; }
        public int IdHall { get; set; }
        public string Hall { get; set; }
    }
}
