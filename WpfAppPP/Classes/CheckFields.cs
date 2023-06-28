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
        /// <summary>
        /// Проверка повтора пароля
        /// </summary>
        /// <param name="password">Новый пароль</param>
        /// <param name="repeat">Старый пароль</param>
        /// <returns>Пароли совпадают (true), пароли не совпадают (false)</returns>
        public static bool CheckRepeatePassword(string password, string repeat)
        {
            if (password == repeat)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка пароля в базе данных
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <param name="logined">Объект пользователя</param>
        /// <returns>Пароль совпадает (true), пароль не совпадает (false)</returns>
        public static bool CheckOldPassword(string password, LoginTab logined)
        {
            int passw = password.GetHashCode();//шифрование введенного пароля
            if (passw == logined.Password)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Неверно введенный старый пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверка полей для изменения данных пользователя
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="login">Логин</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckUpdateUser(string surname, string name, string login)
        {
            if (!string.IsNullOrWhiteSpace(surname))
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (!string.IsNullOrWhiteSpace(login))
                    {
                        return true;
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
        /// Проверка полей для смены пароля
        /// </summary>
        /// <param name="oldPassword">Старый пароль</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <param name="repeatePassword">Повтор пароля</param>
        /// <returns>Поля заполнены (true), поля не заполнены (false)</returns>
        public static bool CheckUpdatePassword(string oldPassword, string newPassword, string repeatePassword)
        {
            if (!string.IsNullOrWhiteSpace(oldPassword))
            {
                if (!string.IsNullOrWhiteSpace(newPassword))
                {
                    if (!string.IsNullOrWhiteSpace(repeatePassword))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Повторите новый пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Введите новый пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Введите старый пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }


    }


}

