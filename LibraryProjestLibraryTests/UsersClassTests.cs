using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.Assets.ViewModel;
using LibraryProjestLibrary;
using LibraryProjestLibraryTests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryProjestLibraryTests
{
    [TestClass]
    public class UsersClassTests
    {
        [TestClass]
        public class AutoUser
        {
            /// <summary>
            /// Проверка авторизации пользователя
            /// </summary>
            /// <param>
            /// 3ngel
            /// 1568493AbC*
            /// </param>
            /// <return>
            /// true
            /// </return>
            [TestMethod]
            public void AutoUser_RightString_True()
            {
                //Accept
                string login = "3ngel";
                string password = "1568493AbC*";
                //Act
                UsersClass obj = new UsersClass();
                bool res = obj.AutoUser(login, password);
                //Assert
                Assert.IsTrue(res);
            }
            /// <summary>
            /// Проверка авторизации пользователя
            /// </summary>
            /// <param>
            /// String.Empty
            /// 1568493AbC*
            /// </param>
            /// <return>
            /// Exposition так как не введён логин
            /// </return>
            [TestMethod]
            public void AutoUser_LoginEmpty_Exception()
            {
                //Accept
                string login = String.Empty;
                string password = "1568493AbC*";
                //Act
                UsersClass obj = new UsersClass();
                //Assert
                Assert.ThrowsException<Exception>(() => obj.AutoUser(login, password));
            }
            /// <summary>
            /// Проверка авторизации пользователя
            /// </summary>
            /// <param>
            /// ReeLune
            /// 1568493AbC*
            /// </param>
            /// <return>
            /// Exposition так как пароль от другого логина
            /// </return>
            [TestMethod]
            public void AutoUser_DifferentString_Exception()
            {
                //Accept
                string login = "ReeLune";
                string password = "1568493AbC*";
                //Act
                UsersClass obj = new UsersClass();
                //Assert
                Assert.ThrowsException<Exception>(() => obj.AutoUser(login, password));
            }
            /// <summary>
            /// Проверка авторизации пользователя
            /// </summary>
            /// <param>
            /// 3nge1
            /// 1568493AbC*
            /// </param>
            /// <return>
            /// Exposition так как не существует пользователя с таким логином
            /// </return>
            [TestMethod]
            public void AutoUser_NotExistLogin_Exception()
            {
                //Accept
                string login = "3nge1";
                string password = "1568493AbC*";
                //Act
                UsersClass obj = new UsersClass();
                //Assert
                Assert.ThrowsException<Exception>(() => obj.AutoUser(login, password));
            }
        }
        [TestClass]
        public class RegUser
        {
            /// <summary>
            /// Проверка метода регистрации пользователя
            /// </summary>
            /// <param>
            ///  Иван Иванович Иванов
            ///  89123456789
            ///  01.01.2000
            ///  Екатеринбург
            ///  ЕМК
            ///  Defik
            ///  1234Abb** 1234Abb**
            /// </param>
            /// <return>
            /// true
            /// </return>
            [TestMethod]
            public void RegUserTest_RightString_True()
            {
                //Accept
                GenerationString gen = new GenerationString();
                string lastname = "Иванов";
                string name = "Иван";
                string pathname = "Иванович";
                string phone = gen.NumberPhoneGeneration();
                DateTime birthday = new DateTime(2000,1,1,0,0,0);
                string adress = "Екатеринбург";
                string studyOrWork = "ЕМК";
                string login = gen.LoginGeneration();
                string password = "1234Abb**";
                string returnPassword = "1234Abb**";
                //Act
                UsersClass obj = new UsersClass();
                bool res = obj.RegUsers(lastname,name, pathname, phone, birthday, studyOrWork, adress, login, password, returnPassword);
                //Assert
                Assert.IsTrue(res);

            }
            /// <summary>
            /// Проверка метода регистрации пользователя
            /// </summary>
            /// <param>
            ///  Иван Иванович Иванов
            ///  89123456789
            ///  01.01.2000
            ///  Екатеринбург
            ///  ЕМК
            ///  Defik
            ///  1234Abb** 1234Abb*
            /// </param>
            /// <return>
            /// Expositionn так как пароли не совпадают
            /// </return>
            [TestMethod]
            public void RegUserTest_DefikPassword_Exception()
            {
                //Accept
                string lastname = "Иванов";
                string name = "Иван";
                string pathname = "Иванович";
                string phone = "89123456789";
                DateTime birthday = new DateTime(2000, 1, 1, 0, 0, 0);
                string adress = "Екатеринбург";
                string studyOrWork = "ЕМК";
                string login = "Defik";
                string password = "1234Abb**";
                string returnPassword = "1234Abb*";
                //Act
                UsersClass obj = new UsersClass();
                //Assert
                Assert.ThrowsException<Exception>(() => obj.RegUsers(lastname, name, pathname, phone, birthday, studyOrWork, adress, login, password, returnPassword));

            }
            /// <summary>
            /// Проверка метода регистрации пользователя
            /// </summary>
            /// <param>
            ///  Иван Иванович Иванов
            ///  89123456789
            ///  01.01.2000
            ///  Екатеринбург
            ///  ЕМК
            ///  Defik
            ///  1234Abb** 1234Abb**
            /// </param>
            /// <return>
            /// Expositionn так как пароли не совпадают
            /// </return>
            [TestMethod]
            public void RegUserTest_HaveLogin_Exception()
            {
                //Accept
                string lastname = "Иванов";
                string name = "Иван";
                string pathname = "Иванович";
                string phone = "89123456789";
                DateTime birthday = new DateTime(2000, 1, 1, 0, 0, 0);
                string adress = "Екатеринбург";
                string studyOrWork = "ЕМК";
                string login = "3ngel";
                string password = "1234Abb**";
                string returnPassword = "1234Abb**";
                //Act
                UsersClass obj = new UsersClass();
                //Assert
                Assert.ThrowsException<Exception>(() => obj.RegUsers(lastname, name, pathname, phone, birthday, studyOrWork, adress, login, password, returnPassword));

            }
        }
        [TestClass]
        public class ExitUser
        {
            /// <summary>
            /// Проверка метода редактирования пользователя
            /// </summary>
            /// <param>
            ///  Верный Виктор Владимирович
            ///  89123456788
            ///  01.01.2000
            ///  Екатеринбург
            ///  ЕМК
            ///  Vern
            ///  BGYp?6Sf
            /// </param>
            /// <return>
            /// true
            /// </return>
            [TestMethod]
            public void ExitUser_TrueString_True()
            {
                //Accept
                string lastname = "Верный";
                string name = "Виктор";
                string pathname = "Владимирович";
                string phone = "89123456788";
                string password = "BGYp?6Sf";
                string adress = "Екатеринбург";
                string studyOrWork = "ЕМК";
                string login = "Vern";
                int hall = 1;
                int rank = 2;
                //Act
                UsersClass obj = new UsersClass();
                bool res = obj.EditUser(lastname,name,pathname,phone,password,hall,rank,adress,studyOrWork,login);
                //Assert
                Assert.IsTrue(res);
            }
            /// <summary>
            /// Проверка метода редактирования пользователя
            /// </summary>
            /// <param>
            ///  Верный Виктор Владимирович
            ///  89123456788
            ///  01.01.2000
            ///  String.Empty
            ///  ЕМК
            ///  Vern
            ///  BGYp?6Sf
            /// </param>
            /// <return>
            /// Exposition так как пустая строка с адресом
            /// </return>
            [TestMethod]
            public void ExitUser_AdressEmpty_Exception()
            {
                //Accept
                string lastname = "Верный";
                string name = "Виктор";
                string pathname = "Владимирович";
                string phone = "89123456788";
                string password = "BGYp?6Sf";
                string adress = String.Empty;
                string studyOrWork = "ЕМК";
                string login = "Vern";
                int hall = 1;
                int rank = 2;
                //Act
                UsersClass obj = new UsersClass();
                //Assert
                Assert.ThrowsException<Exception>(() => obj.EditUser(lastname, name, pathname, phone, password, hall, rank, adress, studyOrWork, login));
            }
        }
    }
}
