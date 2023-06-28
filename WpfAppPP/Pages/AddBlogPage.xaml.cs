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
    /// Логика взаимодействия для AddBlogPage.xaml
    /// </summary>
    public partial class AddBlogPage : Page
    {
        LoginTab loginTab;
        public AddBlogPage(LoginTab logined)
        {
            InitializeComponent();
            loginTab = logined;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbText.Text))//если поле не пустое и не содержит пустых пробелов
            {
                try
                {
                    RecordOfInformation blog = new RecordOfInformation()//создаем новый объект таблицы блогов
                    {
                        idUser = loginTab.ID,
                        Entry = tbText.Text,
                        Date = DateTime.Now//сегодняшняя дата
                    };
                    Classes.DataBase.connect.RecordOfInformation.Add(blog);//добавление новой записи в базу данных
                    Classes.DataBase.connect.SaveChanges();//сохранение изменений в базе данных
                    MessageBox.Show("Запись добавлена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    Classes.FrameClass.frmMain.Navigate(new MainPage(loginTab));//переход на страницу главного меню
                }
                catch
                {
                    MessageBox.Show("Ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Введите запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmMain.Navigate(new MainPage(loginTab));
        }
    }
}
