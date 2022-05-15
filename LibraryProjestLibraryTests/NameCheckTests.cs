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
    public class NameCheckTests
    {
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// Александр 
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void NameCheck_RightString_True()
        {
            //Accept
            string author = "Александр";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.NameCheck(author);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Expostion так как пустая строка
        /// </return>
        [TestMethod]
        public void NameCheck_StringEmpty_Exception()
        {
            //Accept
            string author = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.NameCheck(author));
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// александр сергеевич пушкин
        /// </param>
        /// <return>
        /// Expostion так как ввод со строчной буквы
        /// </return>
        [TestMethod]
        public void NameCheck_LowerString_Exception()
        {
            //Accept
            string author = "александр";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.NameCheck(author));
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// Александp
        /// </param>
        /// <return>
        /// Expostion так как "p" из латинского алфавита
        /// </return>
        [TestMethod]
        public void NameCheck_FalseString_Exception()
        {
            //Accept
            string author = "Александp";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.NameCheck(author));
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        /// <param>
        /// -Александp
        /// </param>
        /// <return>
        /// Expostion так как начинается с дефис
        /// </return>
        [TestMethod]
        public void NameCheck_StartDefis_Exception()
        {
            //Accept
            string author = "-Александр";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.NameCheck(author));
        }
    }
}
