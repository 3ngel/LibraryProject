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

namespace LibraryProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            CheckStringClass obj = new CheckStringClass();
            try
            {
                if (obj.NameCheck(LastNameTextBox.Text)==true && obj.NameCheck(NameTextBox.Text)==true && obj.NameCheck(FastNameTextBox.Text)==true)
                {
                    if (obj.NumberCheck(NumberPhoneTextBox.Text)==true)
                    {
                        if (true)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerationPasswordButtonClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
