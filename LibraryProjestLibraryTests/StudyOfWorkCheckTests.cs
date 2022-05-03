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
    public class StudyOfWorkCheckTests
    {
        /// <summary>
        /// Проверка корректности введённого места учёбы или работы
        /// </summary>
        /// <param>
        /// Екатеринбург, улица 8 марта 7/12 'ЕЭТК'
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void StudyOrWorkCheck_RightString_True()
        {
            //Accept
            string adress = "Екатеринбург, улица 8 марта 7/12 'ЕЭТК'";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.StudyOrWorkCheck(adress);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка корректности введённого места учёбы или работы
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Expostion так как пустая строка
        /// </return>
        [TestMethod]
        public void StudyOrWorkCheck_StringEmpty_Expostion()
        {
            //Accept
            string adress = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.StudyOrWorkCheck(adress));
        }
        /// <summary>
        /// Проверка корректности введённого места учёбы или работы
        /// </summary>
        /// <param>
        /// Ekaterunburg
        /// </param>
        /// <return>
        /// Expostion так как не корректные символы
        /// </return>
        [TestMethod]
        public void StudyOrWorkCheck_FalseString_Expostion()
        {
            //Accept
            string adress = "Ekaterunburg";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.StudyOrWorkCheck(adress));
        }
    }
}
