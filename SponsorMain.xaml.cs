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
using System.Data;
using System.Data.SqlClient;

namespace WS
{
    /// <summary>
    /// Логика взаимодействия для SponsorMain.xaml
    /// </summary>
    public partial class SponsorMain : Page
    {
        SqlConnection connection = new SqlConnection();

        public SponsorMain()
        {
            InitializeComponent();

            //Добавление бегунов из БД
            AddRunners();
        }

        /// <summary>
        /// Добавление стран из БД
        /// </summary>
        private async void AddRunners()
        {
            //Строка подключения            
            connection.ConnectionString = @"Data Source=DESKTOP-SJE2N6P\SQLEXPRESS;Initial Catalog=Marathon;Integrated Security=True";

            try
            {
                //Открываем подключение
                await connection.OpenAsync();

                //Работа с бд
                SqlCommand command = new SqlCommand();

                //Получаем страны из БД
                command.CommandText = "SELECT DISTINCT FirstName, LastName FROM dbo.Runner INNER JOIN dbo.[User] ON dbo.Runner.Email = dbo.[User].Email";

                command.Connection = connection;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                { Runners.Items.Add($"{dataReader[0]} {dataReader[1]}"); }


            }
            catch (SqlException ex)
            {
                //Выводим сообщение об ошибке
                MessageBox.Show(Convert.ToString(ex));
            }
            finally
            {
                //В любом случае закрываем подключение
                connection.Close();
            }
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
            bool errors = false;
            string error = "";
            //Проверка на корректность введенного имени
            if (SponsorName.Text.Length > 3)
            {
                bool check = false;
                foreach (char c in SponsorName.Text)
                {
                    if (!Char.IsLetter(c)) { check = true; errors = true; }
                }
                if (check) { error += "Некорректное Имя\n"; }
            }
            else { errors = true; error += "Некорректное Имя\n"; }

            //Проверка на корректность введенного Имени Владельца Карты
            if (CardOwner.Text.Length > 5)
            {
                bool check = false;
                foreach (char c in CardOwner.Text)
                {

                    if (!Char.IsLetter(c)) { errors = true; check = true; }
                }
                if (check) { error += "Некорректное Имя Владельца Карты\n"; }
            }
            else { errors = true; error += "Некорректное Имя Владельца Карты\n"; }

            //Проверка на корректность номера введенного номера карты
            if (CardNumber.Text.Length == 16)
            {
                bool check = false;
                foreach (char c in CardNumber.Text)
                {
                    if (Char.IsLetter(c)) { errors = true; check = true; }
                }
                if(check) { error += "Некорректный Номер Карты\n"; }
            }
            else
            {
                errors = true; error += "Некорректный Номер Карты\n";
            }

            //проверка на корректность срока действия карты
            int month = default;
            //Проверка месяца
            if (Month.Text.Length > 0 && Month.Text.Length < 3 && int.TryParse(Month.Text, out month))
            {
                if (month > 0 && month <= 12)
                {
                    //ok
                }
                else
                {
                    errors = true; error += "Некорректный срок действия карты (месяц)\n";
                }
            }
            else { errors = true; error += "Некорректный срок действия карты (месяц)\n"; }
            //Проверка года
            int year = default;
            int.TryParse(Year.Text, out year);
            int currentYear = DateTime.Now.Year;
            int diff = Math.Abs(year - currentYear);
            if (Year.Text.Length > 0 && Year.Text.Length <= 4 && int.TryParse(Year.Text, out year))
            {
                if (diff < 5)
                {
                    //Ok
                }
                else { errors = true; error += "Некорректный срок действия карты (год)\n"; }

            }
            else { errors = true; error += "Некорректный срок действия карты (год)\n"; }

            int cvc = default;
            //Проверка CVC карты
            if (CVC.Text.Length == 3 && int.TryParse(CVC.Text, out cvc))
            {
                //Ok
            }
            else
            {
                errors = true; error += "Некорректный CVC карты\n";
            }

            int donation = default;
            //Проверка пожертвования
            if (int.TryParse(SumBlock.Text, out donation))
            {
                //Ok
            }
            else
            {
                errors = true; error += "Некорректная сумма пожертвования\n";
            }

            //Регистрация
            if (!errors)
            {
                Thanks thanks = new Thanks();
                this.NavigationService.Navigate(thanks);
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        /// <summary>
        /// Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Page1 mainPage = new Page1();
            this.NavigationService.Navigate(mainPage);
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
