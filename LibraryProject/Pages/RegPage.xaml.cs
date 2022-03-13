using LibraryProject.Controlers;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public System.Collections.Generic.IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> EntityValidationErrors { get; }
        public RegPage()
        {
            InitializeComponent();
        }

        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            CheckStringClass obj = new CheckStringClass();
            Core db = new Core();
            try
            {
                if (obj.NameCheck(LastNameTextBox.Text)==true && obj.NameCheck(NameTextBox.Text)==true && obj.NameCheck(FastNameTextBox.Text)==true)
                {
                    if (obj.NumberCheck(NumberPhoneTextBox.Text)==true)
                    {
                        if (obj.BirthdayCheck(BirthdayDatePicker.DisplayDate)==true)
                        {
                            if (obj.StudyOrWorkCheck(StudyOrWorkTextBox.Text)==true)
                            {
                                if (obj.AdressCheck(AdressTextBox.Text)==true)
                                {
                                    //Проверка на отсутсвие подобного логина в БД
                                    int control = db.context.Reader.Where(x => x.Login == LoginTextBox.Text).Count();
                                    if (control == 0)
                                    {
                                        //Тот же ли пароль при повторном вводе
                                        if (PasswordTextBox.Text == ReturnPasswordTextBox.Text)
                                        {
                                            if (obj.ReliabilityPassword(PasswordTextBox.Text) == true)
                                            {
                                                int count = db.context.Reader.Count() + 1;
                                                Reader red = new Reader
                                                {
                                                    IdReader = count,
                                                    LastName = LastNameTextBox.Text,
                                                    Name = NameTextBox.Text,
                                                    PatronymicName = FastNameTextBox.Text,
                                                    NumberPhone = NumberPhoneTextBox.Text,
                                                    Birthday = BirthdayDatePicker.DisplayDate,
                                                    StudyOrWork = StudyOrWorkTextBox.Text,
                                                    Adress = AdressTextBox.Text,
                                                    Login = LoginTextBox.Text,
                                                    Password = PasswordTextBox.Text,
                                                    IdRank = 1
                                                };
                                                db.context.Reader.Add(red);
                                                try
                                                {
                                                    db.context.SaveChanges();
                                                    if (db.context.SaveChanges() == 0)
                                                    {
                                                        MessageBox.Show("Вы успешно зарегистрировались");
                                                        this.NavigationService.Navigate(new AutoPage());
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
                                                //ClientContolers clientContolers = new ClientContolers();
                                                //bool result = clientContolers.AddReader(count, LastNameTextBox.Text, NameTextBox.Text, FastNameTextBox.Text,
                                                //    NumberPhoneTextBox.Text, BirthdayDatePicker.DisplayDate, StudyOrWorkTextBox.Text, AdressTextBox.Text, LoginTextBox.Text,
                                                //    PasswordPasswordTextBox.Password);
                                                //if (result == true)
                                                //{
                                                //    MessageBox.Show("Вы успешно зарегистрировались");
                                                //    this.NavigationService.Navigate(new AutoPage());
                                                //}
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Пароли не совпадают");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Данный логин уже занят");
                                    }
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

        //Генерация пароля
        private void GenerationPasswordButtonClick(object sender, RoutedEventArgs e)
        {
            GenerationString obj = new GenerationString();
            PasswordTextBox.Text = obj.RandomPassword();
        }
    }
}
