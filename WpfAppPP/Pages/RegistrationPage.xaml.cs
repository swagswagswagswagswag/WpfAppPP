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
using WpfAppPP.Classes;

namespace WpfAppPP.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.CheckFields.CheckUser(tbSurname.Text, tbName.Text, tbLogin.Text, pswPassword.Password))
            {
                try //обработка исключения
                {
                    LoginTab logined = new LoginTab()//создаем новый объект класса для входа
                    {
                        Login = tbLogin.Text,
                        Password = pswPassword.Password.GetHashCode()//пароль берется из поля для ввода, а метод шифрует его
                    };
                    UserTable user = new UserTable()//создаем новый объект класса пользователя
                    {
                        ID = logined.ID,
                        Surname = tbSurname.Text,
                        Name = tbName.Text
                    };
                    DataBase.connect.LoginTab.Add(logined);//добавляем новый объект в базу данных
                    DataBase.connect.UserTable.Add(user);//добавляем новый объект в базу данных
                    DataBase.connect.SaveChanges();//сохраняем изменения в базе данных
                    MessageBox.Show("Пользователь успешно зарегистрирован!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameClass.frmMain.Navigate(new AutorizatiomPage());//переходим на страницу авторизации
                }
                catch
                {
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmMain.Navigate(new AutorizatiomPage());
        }
    }
}

