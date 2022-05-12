using LibraryProject.Assets.Models;
using LibraryProject.Assets.ViewModel;
using LibraryProject.Models;
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
using System.Windows.Shapes;

namespace LibraryProject.Assets.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        Reader read;
        Core db = new Core();
        public UserWindow()
        {
            InitializeComponent();
            read = db.context.Reader.Where(x => x.Login == Properties.Settings.Default.loginUser).First();
            LastNameTextBox.Text = read.LastName;
            NameTextBox.Text = read.Name;
            PatronymicNameTextBox.Text = read.PatronymicName;
            LoginTextBox.Text = read.Login;
            PasswordTextBox.Text = read.Password;
            NumberPhoneTextBox.Text = read.NumberPhone;
            AdressTextBox.Text = read.Adress;
            StudyOrWorkTextBox.Text = read.StudyOrWork;
            HallComboBox.SelectedIndex = read.Hall - 1;
            RankComboBox.SelectedIndex = read.IdRank - 1;
        }
        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            UsersClass obj = new UsersClass();
            try
            {
                if (obj.EditUser(LastNameTextBox.Text, NameTextBox.Text, PatronymicNameTextBox.Text, NumberPhoneTextBox.Text, 
                    PasswordTextBox.Text, HallComboBox.SelectedIndex+1, RankComboBox.SelectedIndex+1, AdressTextBox.Text, StudyOrWorkTextBox.Text, LoginTextBox.Text)==true)
                {
                    MessageBox.Show("Изменения успешно сохранены");
                    Properties.Settings.Default.loginUser = String.Empty;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
