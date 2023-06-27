using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppPP.Classes
{
    public class CheckFields
    {
        /// <summary>
        /// Проверка полей для регистрации пользователя
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckUser(string surname, string name, string login, string password)
        {
            if (!string.IsNullOrWhiteSpace(surname))
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (!string.IsNullOrWhiteSpace(login))
                    {
                        if (!string.IsNullOrWhiteSpace(password))
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Заполните поле Пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните поле Логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поле Имя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Заполните поле Фамилия!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка полей при авторизации
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public static bool CheckAuthorization(string login, string password)
        {
            if (!string.IsNullOrWhiteSpace(login))
            {
                if (!string.IsNullOrWhiteSpace(password))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Заполните поле Пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Заполните поле Логин!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        /// <summary>
        /// Проверка наличия логина в базе данных
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckLogin(string login, LoginTab loginedTable)
        {
            LoginTab logined;
            //если мы задали пустой объект то просто ищем такой логин в базе, а если задали не пустой объект то ищем совпадаения с другими пользователями
            if (loginedTable == null)
            {
                logined = Classes.DataBase.connect.LoginTab.FirstOrDefault(x => x.Login == login);//по логину ищем объект в базе данных
            }
            else
            {
                logined = Classes.DataBase.connect.LoginTab.FirstOrDefault(x => x.Login == login && x.ID != loginedTable.ID);//по логину ищем объект в базе данных
            }
            if (logined == null)//если объект нулевой то возвращаем true
            {
                return true;
            }
            else
            {
                MessageBox.Show("Такой логин уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

    }


}

