using LibraryProjestLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjestLibraryTests
{
    [TestClass]
    public class LoginCheckTests
    {
        /// <summary>
        /// Проверка корректности логина
        /// </summary>
        /// <param>
        /// Login
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void AdressCheck_RightString_True()
        {
            //Accept
            string adress = "Login";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.LoginCheck(adress);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка корректности логина
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Expostion так как пустая строка
        /// </return>
        [TestMethod]
        public void AuthorCheck_StringEmpty_Expostion()
        {
            //Accept
            string adress = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.LoginCheck(adress));
        }
        /// <summary>
        /// Проверка корректности логина
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Expostion так как неккоректные символы "о" взята из кириллицы
        /// </return>
        [TestMethod]
        public void AuthorCheck_FalseString_Expostion()
        {
            //Accept
            string adress = "Lоgin";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.LoginCheck(adress));
        }
        /// <summary>
        /// Проверка корректности логина
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Expostion так как точка на конце
        /// </return>
        [TestMethod]
        public void AuthorCheck_PointEnd_Expostion()
        {
            //Accept
            string adress = "Login.";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.LoginCheck(adress));
        }
    }
}
