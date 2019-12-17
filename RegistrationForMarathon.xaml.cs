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
using System.Data.SqlClient;
using System.Data;

namespace WS
{
    /// <summary>
    /// Логика взаимодействия для RegistrationForMarathon.xaml
    /// </summary>
    public partial class RegistrationForMarathon : Page
    {
        SqlConnection connection = new SqlConnection();

        string option = "A";

        public RegistrationForMarathon()
        {
            InitializeComponent();
            AddCharities();
        }

        private async void AddCharities()
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
                command.CommandText = "SELECT CharityName FROM Charity";

                command.Connection = connection;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    CharityList.Items.Add(dataReader[0]);
                }
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
            Summ.Text = Convert.ToString(Convert.ToInt32(Summ.Text) + 145);
        }

        /// <summary>
        /// Отмена выбора 42km
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void km42_Unchecked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Summ.Text) - 145);
        }

        /// <summary>
        /// Выбор 21 км
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void km21_Checked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Summ.Text) + 75);
        }

        /// <summary>
        /// Отмена выбора 21км
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void km21_Unchecked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Summ.Text) - 75);
        }

        /// <summary>
        /// Выбор 5км
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void km5_Checked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Summ.Text) + 20);
        }

        /// <summary>
        /// отмена выбора 5км
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void km5_Unchecked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Summ.Text) - 20);
        }

        /// <summary>
        /// Вариант А
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void A_Checked(object sender, RoutedEventArgs e)
        {
            option = "A";
        }

        /// <summary>
        /// Вариант В
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Checked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Summ.Text) + 45);
            option = "B";
        }

        /// <summary>
        /// Вариант С
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void C_Checked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Summ.Text) + 20);
            option = "C";
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
            Summ.Text = Convert.ToString(Convert.ToInt32(Summ.Text) - 45);
        }

        /// <summary>
        /// отмена выбора варианта С
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void C_Unchecked(object sender, RoutedEventArgs e)
        {
            Summ.Text = Convert.ToString(Convert.ToInt32(Summ.Text) - 20);
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
            int regId = 0;
            int runId = 0;
            DateTime curDate = DateTime.Now;
            int charityId = 0;

            //Получение номера регистрации
            try
            {
                //Открываем подключение
                connection.OpenAsync();

                //Работа с бд
                SqlCommand command = new SqlCommand();

                //Получаем страны из БД
                command.CommandText = "SELECT MAX(RegistrationId) FROM RegistrationNew";

                command.Connection = connection;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    regId = Convert.ToInt32(dataReader[0]);
                    regId++;
                }
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

            //Получение номера нового бегуна
            try
            {
                //Открываем подключение
                connection.OpenAsync();

                //Работа с бд
                SqlCommand command = new SqlCommand();

                //Получаем страны из БД
                command.CommandText = "SELECT MAX(RunnerId) FROM Runner";

                command.Connection = connection;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    runId = Convert.ToInt32(dataReader[0]);
                }
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

            if (int.TryParse(Donation.Text, out donation))
            {
                if (donation > 0)
                { }
                else { errorbool = true; errors += "Некорректная сумма взноса\n"; }
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
            if (CharityList.Text != "" || CharityList.Text != " ")
            {
                //Получение id благотворительной организации
                try
                {
                    //Открываем подключение
                    connection.OpenAsync();

                    //Работа с бд
                    SqlCommand command = new SqlCommand();

                    //Получаем страны из БД
                    command.CommandText = "SELECT CharityId FROM Charity WHERE CharityName = '" + CharityList.Text + "'";

                    command.Connection = connection;

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    { charityId = Convert.ToInt32(dataReader[0]); }
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
            else
            {
                errorbool = true; errors += "Не выбрана благотворительная организация\n";
            }
            if (errorbool)
            {
                MessageBox.Show(errors);
            }
            else
            {
                //регистрация

                try
                {
                    //Открываем подключение
                    connection.OpenAsync();

                    //Работа с бд
                    SqlCommand command = new SqlCommand();

                    //Отправляем строки в бд
                    //-------------------------------------------------------------------------------
                    //Работа с таблицей RegistrationNew
                    string com = String.Format("SET IDENTITY_INSERT Runner ON " +
                        "INSERT INTO [RegistrationNew]" +
                        "(RegistrationId, RunnerId, RegistrationDateTime, RaceKitOptionId, RegistrationStatusId, Cost, " +
                        "CharityId, Sponsorshiptarget) " +
                        "Values(@RegistrationId, @RunnerId, @RegistrationDateTime, @RaceKitOptionId, " +
                        "@RegistrationStatusId, @Cost, @CharityId, @Sponsorshiptarget)" +
                        " SET IDENTITY_INSERT Runner OFF ");

                    //Добавляем параметры
                    SqlCommand cmd = new SqlCommand(com, this.connection);
                    cmd.Parameters.AddWithValue("@RegistrationId", regId);
                    cmd.Parameters.AddWithValue("@RunnerId", runId);
                    cmd.Parameters.AddWithValue("@RegistrationDateTime", curDate);
                    cmd.Parameters.AddWithValue("@RaceKitOptionId", option);
                    cmd.Parameters.AddWithValue("@RegistrationStatusId", 2);
                    cmd.Parameters.AddWithValue("@Cost", 1);
                    cmd.Parameters.AddWithValue("@CharityId", charityId);
                    cmd.Parameters.AddWithValue("@Sponsorshiptarget", Convert.ToInt32(Summ.Text));

                    //Отправка
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    //Выводим сообщение об ошибке
                    MessageBox.Show(Convert.ToString(ex));
                    errorbool = true;
                }
                finally
                {
                    //В любом случае закрываем подключение
                    connection.Close();
                }

                //Подтверждение регистрации
                if (!errorbool)
                {
                    RegConfirm mainPage = new RegConfirm();
                    this.NavigationService.Navigate(mainPage);
                }
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
            //Popozhe...
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
