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

namespace WS
{
    /// <summary>
    /// Логика взаимодействия для AutorisationForm.xaml
    /// </summary>
    public partial class AutorisationForm : Page
    {
        public AutorisationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page1 mainPage = new Page1();
            this.NavigationService.Navigate(mainPage);
        }

        private void Email_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Email.Text = "";
        }

        private void Password_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Password.Text = "";
        }

        /// <summary>
        /// Логин, проверка введенных данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string error = "";
            bool errorb = false;
            if (Email.Text.Length > 3 && Email.Text.Contains("@"))
            {
                //Проверка на содержание в БД
            }
            else { error += "       Некорректный ввод \n адреса электронной почты\n"; errorb = true; }
            if (Password.Text.Length < 1 || Password.Text == "Enter your password")
            {
                error += "       Некорректный ввод \n                 пароля          \n"; errorb = true;
            }
            else
            {
                //Проверка на содержание в БД

            }
            if(errorb) { MessageBox.Show(error); }
        }

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Password.Text = "";
            Email.Text = "";
        }
    }
}
