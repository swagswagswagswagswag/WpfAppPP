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

    }
}
