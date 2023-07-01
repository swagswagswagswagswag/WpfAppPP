using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.ObjectModel;
using WpfAppPP;
using WpfAppPP.Classes;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        /// <summary>
        /// Положительный тест на проверку полей для регистрации пользователя
        /// </summary>
        public void CheckUser_IsTrue()
        {
            Assert.IsTrue(CheckFields.CheckUser("Лобанов", "Семён", "admin", "admin"));
        }

        /// <summary>
        /// Негативный тест на проверку полей для регистрации пользователя
        /// </summary>
        [TestMethod]
        public void CheckUser_IsFalse()
        {
            Assert.IsFalse(CheckFields.CheckUser("Лобанов", "Семён", "admin", ""));
        }

        /// <summary>
        /// Положительный тест на проверку авторизации
        /// </summary>
        [TestMethod]
        public void CheckAuthorization_IsTrue()
        {
            Assert.IsTrue(CheckFields.CheckAuthorization("admin", "admin"));
        }

        /// <summary>
        /// Негативный тест на проверку авторизации
        /// </summary>
        [TestMethod]
        public void CheckAuthorization_IsFalse()
        {
            Assert.IsFalse(CheckFields.CheckAuthorization("admin", ""));
        }

        /// <summary>
        /// Положительный тест на проверку повтора пароля
        /// </summary>
        [TestMethod]
        public void CheckRepeatePassword_IsTrue()
        {
            Assert.IsTrue(CheckFields.CheckRepeatePassword("admin", "admin"));
        }

        /// <summary>
        /// Негативный тест на проверку повтора пароля
        /// </summary>
        [TestMethod]
        public void CheckRepeatePassword_IsFalse()
        {
            Assert.IsFalse(CheckFields.CheckRepeatePassword("admin", "aadmin"));
        }

        /// <summary>
        /// Положительный тест на проверку старого пароля
        /// </summary>
        [TestMethod]
        public void CheckOldPassword_IsTrue()
        {
            Assert.IsTrue(CheckFields.CheckOldPassword("admin", new LoginTab() { ID = 1, Login = "admin", Password = "admin".GetHashCode() }));
        }

        /// <summary>
        /// Негативный тест на проверку старого пароля
        /// </summary>
        [TestMethod]
        public void CheckOldPassword_IsFalse()
        {
            Assert.IsFalse(CheckFields.CheckOldPassword("admin", new LoginTab() { ID = 1, Login = "admin", Password = "aadmin".GetHashCode() }));
        }
    }
}
