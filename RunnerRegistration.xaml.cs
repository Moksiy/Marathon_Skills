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
    /// Логика взаимодействия для RunnerRegistration.xaml
    /// </summary>
    public partial class RunnerRegistration : Page
    {
        SqlConnection connection = new SqlConnection();

        public RunnerRegistration()
        {
            InitializeComponent();

            //Добавление стран из БД
            AddCountries();
        }

        /// <summary>
        /// Добавление стран из БД
        /// </summary>
        private async void AddCountries()
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
                command.CommandText = "SELECT CountryName FROM Country";

                command.Connection = connection;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Country.Items.Add(dataReader[0]);
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
                AddGenders();
            }
        }

        /// <summary>
        /// Добавление стран из БД
        /// </summary>
        private async void AddGenders()
        {
            //Строка подключения            
            try
            {
                //Открываем подключение
                await connection.OpenAsync();

                //Работа с бд
                SqlCommand command = new SqlCommand();

                //Получаем страны из БД
                command.CommandText = "SELECT Gender FROM Gender";

                command.Connection = connection;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                { SEX.Items.Add(dataReader[0]); }


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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page1 mainPage = new Page1();
            this.NavigationService.Navigate(mainPage);
        }


        /// <summary>
        /// Email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailAdress_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EmailAdress.Text = "";
        }

        /// <summary>
        /// Пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Password.Text = "";
        }

        /// <summary>
        /// Повторите пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordRepeat_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PasswordRepeat.Text = "";
        }

        /// <summary>
        /// Имя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Name_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Name.Text = "";
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastName_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LastName.Text = "";
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool errorbool = false;
            string errors = "";
            string countryCode = "";
            int runnerId = 0;
            //Проверка введенных значений
            //проверка Email
            if (EmailAdress.Text.Length > 4 && EmailAdress.Text.Contains("@") && EmailAdress.Text.Contains("."))
            {

            }
            else
            {
                errorbool = true; errors += "Некорректный ввод Email\n";
            }
            //Проверка Пароля
            if (Password.Text.Length >= 6)
            {
                bool numberinpassword = false;
                bool charinpassword = false;
                bool symbolsinpassword = false;
                foreach (char c in Password.Text)
                {
                    if (char.IsLetter(c))
                        charinpassword = true;
                    if (!char.IsLetter(c))
                        numberinpassword = true;
                    //! @ # $ % ^
                    if (c == '!' || c == '@' || c == '#' || c == '$' || c == '%' || c == '^')
                        symbolsinpassword = true;
                }
                if (numberinpassword && charinpassword && symbolsinpassword)
                { }
                else { errorbool = true; errors += "Небезопасный пароль\n"; }
            }
            else
            {
                errorbool = true;
                errors += "Слишком короткий пароль🌚\n";
            }
            //проверка повторного пароля
            if (Password.Text == PasswordRepeat.Text)
            {
                //ок
            }
            else
            {
                errorbool = true;
                errors += "Пароли не совпадают\n";
            }
            //проверка имени
            if (Name.Text.Length > 3)
            {
                bool check = false;
                foreach (char c in Name.Text)
                {
                    if (!char.IsLetter(c))
                        check = true;
                }
                if (check)
                {
                    errorbool = true;
                    errors += "Некорректный ввод имени\n";
                }
            }
            else
            {
                errorbool = true;
                errors += "Некорректный ввод имени\n";
            }
            //Проверка фамилии
            if (LastName.Text.Length > 3)
            {
                bool check = false;
                foreach (char c in LastName.Text)
                {
                    if (!char.IsLetter(c))
                        check = true;
                }
                if (check)
                {
                    errorbool = true;
                    errors += "Некорректный ввод фамилии\n";
                }
            }
            else
            {
                errorbool = true;
                errors += "Некорректный ввод фамилии\n";
            }
            //проверка пола🌚
            if (SEX.SelectedItem != null)
            {
                //Ок
            }
            else
            {
                errorbool = true;
                errors += "Не выбран пол\n";
            }
            //проверка даты рождения
            DateTime date = new DateTime();
            if (DateTime.TryParse(BirthDate.Text, out date))
            {

            }
            else
            {
                errorbool = true;
                errors += "Некорректный ввод даты\n";
            }
            //проверка страны
            if (Country.SelectedItem != null)
            {                
                try
                {
                    //Открываем подключение
                    connection.OpenAsync();

                    //Работа с бд
                    SqlCommand command = new SqlCommand();

                    string com = "SELECT CountryCode FROM Country WHERE CountryName = '" + Country.Text + "'";

                    //Получаем страны из БД
                    command.CommandText = com;

                    command.Connection = connection;

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        countryCode = Convert.ToString(dataReader[0]);
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
                        runnerId = Convert.ToInt32(dataReader[0]);
                        runnerId++;
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
                    runnerId++;
                }
            }
            else
            {
                errorbool = true;
                errors += "Не выбрана страна\n";
            }
            //Вывод ошибок (если есть)
            if (errorbool)
            {
                MessageBox.Show(errors);
            }
            else
            {
                //нормалды
                //Регистрация
                try
                {
                    //Открываем подключение
                    connection.OpenAsync();

                    //Работа с бд
                    SqlCommand command = new SqlCommand();

                    //Отправляем строки в бд
                    //-------------------------------------------------------------------------------
                    //Работа с таблицей USER
                    string com = String.Format("INSERT INTO [User]" +
                        "(Email, Password, FirstName, LastName, RoleId) Values(@Email, @Password, @FirstName, @LastName, @RoleId)");

                    //Добавляем параметры
                    SqlCommand cmd = new SqlCommand(com, this.connection);
                    cmd.Parameters.AddWithValue("@Email", EmailAdress.Text);
                    cmd.Parameters.AddWithValue("@Password", Password.Text);
                    cmd.Parameters.AddWithValue("@FirstName", Name.Text);
                    cmd.Parameters.AddWithValue("@LastName", LastName.Text);
                    cmd.Parameters.AddWithValue("@RoleId", "R");

                    //Отправка
                    cmd.ExecuteNonQuery();

                    //----------------------------------------------------------------------------------
                    //Работа с таблицей Runner
                    com = String.Format("SET IDENTITY_INSERT Runner ON " +
                        "INSERT INTO Runner " +
                        "(RunnerId, Email, Gender, DateOfBirth, CountryCode) " +
                        "Values(@RunnerId , @Email, @Gender, @DateOfBirth, @CountryCode)" +
                        "SET IDENTITY_INSERT Runner OFF ");

                    //Добавляем параметры
                    cmd = new SqlCommand(com, this.connection);
                    cmd.Parameters.AddWithValue("@RunnerId", runnerId);
                    cmd.Parameters.AddWithValue("@Email", EmailAdress.Text);
                    cmd.Parameters.AddWithValue("@Gender", SEX.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", BirthDate.Text);
                    cmd.Parameters.AddWithValue("@CountryCode", countryCode);

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

                if (!errorbool)
                {
                    RegistrationForMarathon mainPage = new RegistrationForMarathon();
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
            RunnerMain info = new RunnerMain();
            this.NavigationService.Navigate(info);
        }

        /// <summary>
        /// Имя файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SponsorName_Copy4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PhotoPath.Text = "";
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BirthDate_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BirthDate.Text = "";
        }

        /// <summary>
        /// Просмотр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Text documents (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(dialog.FileName);
                img.EndInit();
                Photo.Source = img;
            }
        }
    }
}
