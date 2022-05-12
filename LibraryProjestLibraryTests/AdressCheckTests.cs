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
    public class AdressCheckTests
    {
        /// <summary>
        /// Проверка корректности введённого адреса
        /// </summary>
        /// <param>
        /// Екатеринбург, улица 8 марта 7/12
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void AdressCheck_RightString_True()
        {
            //Accept
            string adress = "Екатеринбург, улица 8 марта 7/12";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.AdressCheck(adress);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка корректности введённого адреса
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Expostion так как пустая строка
        /// </return>
        [TestMethod]
        public void AuthorCheck_StringEmpty_Exception()
        {
            //Accept
            string adress = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AdressCheck(adress));
        }
        /// <summary>
        /// Проверка корректности введённого адреса
        /// </summary>
        /// <param>
        /// Ekaterunburg
        /// </param>
        /// <return>
        /// Expostion так как не корректные символы
        /// </return>
        [TestMethod]
        public void AuthorCheck_FalseString_Exception()
        {
            //Accept
            string adress = "Ekaterunburg";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AdressCheck(adress));
        }
    }
}
