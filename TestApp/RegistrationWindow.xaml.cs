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

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public int roleID;
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationComplete_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text == null)
            {
                MessageBox.Show("Поле логина не должно быть пустым");
                return;
            }
            if (PasswordBox.Password == null)
            {
                MessageBox.Show("Поле пароль не должно быть пустым");
                return;
            }
            if (surnameBox.Text == null)
            {
                MessageBox.Show("Поле фамилии не должно быть пустым");
                return;
            }
            if (nameBox.Text == null)
            {
                MessageBox.Show("Поле имени не должно быть пустым");
                return;
            }
            if (patronicBox.Text == null)
            {
                MessageBox.Show("Поле отчества не должно быть пустым");
                return;
            }


            int userNumber = DataBase1Entities.GetContext().Данные_пользователя.Max(d => d.ID_Пользователя).GetValueOrDefault();

            if (userNumber == 0)
            {
                userNumber = 1;
            }
            else
            {
                userNumber++;
            }

            Данные_пользователя userdata = new Данные_пользователя()
            {
                ID_Пользователя = userNumber,
                Логин = LoginBox.Text,
                Пароль = PasswordBox.Password,

            };
            DataBase1Entities.GetContext().Данные_пользователя.Add(userdata);

            Пользователь userInfo = new Пользователь()
            {
                Фамилия = surnameBox.Text,
                Имя = nameBox.Text,
                Отчество = patronicBox.Text,
                Роль = 3
            };
            DataBase1Entities.GetContext().Пользователь.Add(userInfo);
            try
            {
                DataBase1Entities.GetContext().SaveChanges();
                MessageBox.Show("Успешная регистрация");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
