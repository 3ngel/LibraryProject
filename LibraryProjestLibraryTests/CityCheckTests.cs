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
    public class CityCheckTests
    {
        /// <summary>
        /// Проверка корректности введённого города
        /// </summary>
        /// <param>
        /// Екатеринбург
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void CityCheck_RightString_True()
        {
            //Accept
            string city = "Екатеринбург";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.CityCheck(city);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка корректности введённого города
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Expostion так как пустая строка
        /// </return>
        [TestMethod]
        public void CityCheck_StringEmpty_Expostion()
        {
            //Accept
            string city = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.CityCheck(city));
        }
        /// <summary>
        /// Проверка корректности введённого города
        /// </summary>
        /// <param>
        /// Ekaterunburg
        /// </param>
        /// <return>
        /// Expostion так как не корректные символы
        /// </return>
        [TestMethod]
        public void CityCheck_FalseString_Expostion()
        {
            //Accept
            string city = "Ekaterunburg";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.CityCheck(city));
        }
    }
}
