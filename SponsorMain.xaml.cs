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
    /// Логика взаимодействия для SponsorMain.xaml
    /// </summary>
    public partial class SponsorMain : Page
    {
        public SponsorMain()
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
        /// Декремент суммы пожертвования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string check = SumBox.Text;
            int summ;
            if (int.TryParse(check, out summ))
            {
                summ = Convert.ToInt32(SumBox.Text);
                if (summ - 10 >= 50)
                {
                    summ -= 10;
                    SumBox.Text = Convert.ToString(summ);
                    SumBlock.Text = Convert.ToString(summ);
                }
            }
        }

        /// <summary>
        /// Инкремент суммы пожертвования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string check = SumBox.Text;
            int summ;
            if (int.TryParse(check, out summ))
            {
                if (summ >= 50)
                {
                    summ += 10;
                    SumBox.Text = Convert.ToString(summ);
                    SumBlock.Text = Convert.ToString(summ);
                }
            }
        }

        /// <summary>
        /// Заплатить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(true)
            {
                Thanks thanks = new Thanks();
                this.NavigationService.Navigate(thanks);
            }
        }

        /// <summary>
        /// Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SponsorName.Text = "";
        }

        private void CardOwner_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CardOwner.Text = "";
        }

        private void CardNumber_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CardNumber.Text = "";
        }

        private void Month_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Month.Text = "";
        }

        private void Year_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Year.Text = "";
        }

        private void CVC_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CVC.Text = "";
        }
    }
}
