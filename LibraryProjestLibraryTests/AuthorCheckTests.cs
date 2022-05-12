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
    public class AuthorCheckTests
    {
        /// <summary>
        /// Проверка корректности автора
        /// </summary>
        /// <param>
        /// Александр Сергеевич Пушкин
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void AuthorCheck_RightString_True()
        {
            //Accept
            string author = "Александр Сергеевич Пушкин";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.AuthorCheck(author);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка корректности автора
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
            string author = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AuthorCheck(author));
        }
        /// <summary>
        /// Проверка корректности автора
        /// </summary>
        /// <param>
        /// александр сергеевич пушкин
        /// </param>
        /// <return>
        /// Expostion так как ввод со строчной буквы
        /// </return>
        [TestMethod]
        public void AuthorCheck_LowerString_Exception()
        {
            //Accept
            string author = "александр сергеевич пушкин";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AuthorCheck(author));
        }
        /// <summary>
        /// Проверка корректности автора
        /// </summary>
        /// <param>
        /// Александp
        /// </param>
        /// <return>
        /// Expostion так как "p" из латинского алфавита
        /// </return>
        [TestMethod]
        public void AuthorCheck_FalseString_Exception()
        {
            //Accept
            string author = "Александp";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AuthorCheck(author));
        }
        /// <summary>
        /// Проверка корректности автора
        /// </summary>
        /// <param>
        /// -Александp
        /// </param>
        /// <return>
        /// Expostion так как начинается с дефис
        /// </return>
        [TestMethod]
        public void AuthorCheck_StartDefis_Exception()
        {
            //Accept
            string author = "-Александр";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AuthorCheck(author));
        }
    }
}
