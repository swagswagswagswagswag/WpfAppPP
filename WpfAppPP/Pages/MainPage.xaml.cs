﻿using System;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        LoginTab loginedTable;
        public MainPage(LoginTab logined)
        {
            InitializeComponent();
            loginedTable = logined;
            tbName.Text = logined.UserTable.Surname + " " + logined.UserTable.Name;
            List<RecordOfInformation> blogs = Classes.DataBase.connect.RecordOfInformation.Where(x => x.idUser == loginedTable.ID).OrderByDescending(x => x.Date).ToList();//запись в лист блогов записи пользователя
            if (blogs.Count > 0)//если есть записи
            {
                listBlogs.ItemsSource = blogs;//помещение в лист записей
            }
            else
            {
                listBlogs.Visibility = Visibility.Collapsed;//скрываем лист
                //tbEmptyBlog.Visibility = Visibility.Visible;//показываем сообщение
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmMain.Navigate(new AutorizatiomPage());
        }

        private void btnAddBlog_Click(object sender, RoutedEventArgs e)
        {
            Classes.FrameClass.frmMain.Navigate(new AddBlogPage(loginedTable));//переход на страницу добавления записи блога
        }
    }
}
