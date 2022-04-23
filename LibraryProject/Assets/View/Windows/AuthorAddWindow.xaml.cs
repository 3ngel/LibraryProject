using LibraryProject.Assets.Models;
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
    /// Логика взаимодействия для AuthorAddWindow.xaml
    /// </summary>
    public partial class AuthorAddWindow : Window
    {
        CheckStringClass check = new CheckStringClass();
        Core db = new Core();
        public AuthorAddWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка добавления нового автора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthorAddButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (check.AuthorCheck(AuthorAddTextBox.Text) == true)
                {
                    Author author = new Author()
                    {
                        FullNameAuthor = AuthorAddTextBox.Text
                    };
                    db.context.Author.Add(author);
                    db.context.SaveChanges();
                    if (db.context.SaveChanges() == 0)
                    {
                        MessageBox.Show("Вы добавили автора");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Кнопка добавления нового города
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CityAddButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CityAddTextBox.Text!=String.Empty)
                {

                    City city = new City()
                    {
                        NameCity = CityAddTextBox.Text
                    };
                    db.context.City.Add(city);
                    db.context.SaveChanges();
                    if (db.context.SaveChanges() == 0)
                    {
                        MessageBox.Show("Вы добавили город");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HouseAddButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HouseAddTextBox.Text != String.Empty)
                {
                    HousePublication house = new HousePublication()
                    {
                        NameHouse = HouseAddTextBox.Text
                    };
                    db.context.HousePublication.Add(house);
                    db.context.SaveChanges();
                    if (db.context.SaveChanges() == 0)
                    {
                        MessageBox.Show("Вы добавили дом публикации");
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
