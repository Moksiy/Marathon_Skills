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
    /// Логика взаимодействия для RegistrationForMarathon.xaml
    /// </summary>
    public partial class RegistrationForMarathon : Page
    {
        public RegistrationForMarathon()
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

        /// <summary>
        /// Взнос
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Donation_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Donation.Text = "";
        }

        /// <summary>
        /// Выбор 42km
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void km42_Checked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Donation.Text) + 145);
        }

        /// <summary>
        /// Отмена выбора 42km
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void km42_Unchecked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Donation.Text) - 145);
        }

        /// <summary>
        /// Выбор 21 км
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void km21_Checked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Donation.Text) + 75);
        }

        /// <summary>
        /// Отмена выбора 21км
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void km21_Unchecked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Donation.Text) - 75);
        }

        /// <summary>
        /// Выбор 5км
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void km5_Checked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Donation.Text) + 20);
        }

        /// <summary>
        /// отмена выбора 5км
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void km5_Unchecked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Donation.Text) - 20);
        }

        /// <summary>
        /// Вариант А
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void A_Checked(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Вариант В
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Checked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Donation.Text) + 45);
        }

        /// <summary>
        /// Вариант С
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void C_Checked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Donation.Text) + 20);
        }

        /// <summary>
        /// Отмена выбора варианта А
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void A_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Отмена выбора варианта В
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Unchecked(object sender, RoutedEventArgs e)
        {            
            Summ.Text = Convert.ToString(Convert.ToInt32(Donation.Text) - 45);
        }

        /// <summary>
        /// отмена выбора варианта С
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void C_Unchecked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Donation.Text) - 20);
        }

        /// <summary>
        /// проверка и регистрация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool errorbool = false;
            string errors = "";
            int donation = default;
            if(int.TryParse(Donation.Text, out donation))
            {
                if(donation > 0)
                {}else { errorbool = true; errors += "Некорректная сумма взноса\n"; }
            }
            else { errorbool = true; errors += "Некорректная сумма взноса\n"; }
            if (km21.IsChecked != null || km42.IsChecked != null || km5.IsChecked != null)
            {
                //Ok
            }
            else
            {
                errorbool = true; errors += "Не выбран ни один вид марафонов\n";
            }
            if(errorbool)
            {
                MessageBox.Show(errors);
            }
            else
            {
                //регистрация
            }
        }

        /// <summary>
        /// Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Возврат на страницу назад
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Деавторизация

            //В главное меню
            Page1 mainPage = new Page1();
            this.NavigationService.Navigate(mainPage);
        }

        /// <summary>
        /// Смена введенной суммы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Donation_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
