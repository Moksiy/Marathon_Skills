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
    /// Логика взаимодействия для DonationOrganisationsList.xaml
    /// </summary>
    public partial class DonationOrganisationsList : Page
    {

        SqlConnection connection = new SqlConnection();


        public DonationOrganisationsList()
        {
            InitializeComponent();
            AddCharity();
        }

        private async void AddCharity()
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
                    Charity.Items.Add(dataReader[0]);
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
            MoreInfo info = new MoreInfo();
            this.NavigationService.Navigate(info);
        }
    }
}
