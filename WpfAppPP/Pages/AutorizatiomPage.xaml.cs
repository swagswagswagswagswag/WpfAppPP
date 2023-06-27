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

namespace WpfAppPP.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizatiomPage.xaml
    /// </summary>
    public partial class AutorizatiomPage : Page
    {
        public AutorizatiomPage()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmMain.Navigate(new RegistrationPage());
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e) 
        {
            if (Classes.CheckFields.CheckAuthorization(tbLogin.Text, pswPassword.Password))
            {
                try
                {
                    int password = pswPassword.Password.GetHashCode();//шифруем строку с паролем из поля для ввода
                    LoginTab logined = Classes.DataBase.connect.LoginTab.FirstOrDefault(x => x.Login == tbLogin.Text && x.Password == password);//строка для поиска объекта в базе данных по логину и паролю
                    if (logined != null)//если объект не нулевой то авторизация успешна
                    {
                        MessageBox.Show("Успешная авторизация", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        Classes.FrameClass.frmMain.Navigate(new MainPage(logined));
                    }
                    else
                    {
                        MessageBox.Show("Такого пользователя не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
