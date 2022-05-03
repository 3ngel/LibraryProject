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
using LibraryProject.Assets.Models;
using LibraryProject.Assets.ViewModel;

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
            try
            {
                UsersClass obj = new UsersClass();
                if (BirthdayDatePicker.SelectedDate!=null)
                {
                    bool res = obj.RegUsers(LastNameTextBox.Text, NameTextBox.Text, FastNameTextBox.Text, NumberPhoneTextBox.Text, BirthdayDatePicker.DisplayDate, StudyOrWorkTextBox.Text, AdressTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text, ReturnPasswordTextBox.Text);
                    if (res == true)
                    {
                        MessageBox.Show("Вы успешно зарегистрировались");
                        this.NavigationService.Navigate(new AboutUsPage());
                    }
                }
                else
                {
                    MessageBox.Show("Вы не ввели дату рождения");
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
