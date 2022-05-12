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
    public class YearOfPublicationCheckTests
    {
        /// <summary>
        /// Проверка года выхода книги
        /// </summary>
        /// <param>
        /// 123
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void YearOfPublicationCheck_RightString_True()
        {
            //Accept
            string count = "123";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.YearCheck(count);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка года выхода книги
        /// </summary>
        /// <param>
        /// 123f
        /// </param>
        /// <return>
        /// Exposition так как не корректные символы
        /// </return>
        [TestMethod]
        public void YearOfPublicationCheck_FalseString_Exception()
        {
            //Accept
            string count = "123f";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.YearCheck(count));
        }
        /// <summary>
        /// Проверка года выхода книги
        /// </summary>
        /// <param>
        /// 3000
        /// </param>
        /// <return>
        /// Exposition так как не может быть книгу такого года выпсука
        /// </return>
        [TestMethod]
        public void YearOfPublicationCheck_OldString_Exception()
        {
            //Accept
            string count = "3000";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.YearCheck(count));
        }
        /// <summary>
        /// Проверка года выхода книги
        /// </summary>
        /// <param>
        /// StringEmprt
        /// </param>
        /// <return>
        /// Exposition так как пустая строка
        /// </return>
        [TestMethod]
        public void YearOfPublicationCheck_StringEmpty_Exception()
        {
            //Accept
            string count = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.YearCheck(count));
        }
    }
}
