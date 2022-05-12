using LibraryProjestLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LibraryProjestLibraryTests
{
    [TestClass]
    public class ISBNCheckTests
    {
        /// <summary>
        /// Проверка ISBN номера
        /// </summary>
        /// <param>
        /// 5-7519-0485-0
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void ISBNCheck_ReghtString_True()
        {
            //Accept
            string isbn = "5-7519-0485-0";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.ISBNcheck(isbn);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка ISBN номера
        /// </summary>
        /// <param>
        /// 5-7519-0485-1
        /// </param>
        /// <return>
        /// Expostion так как неверная контрольная цифра
        /// </return>
        [TestMethod]
        public void ISBNCheck_ContrlNumberFalse_Exception()
        {
            //Accept
            string isbn = "5-7519-0485-1";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.ISBNcheck(isbn));
        }
        /// <summary>
        /// Проверка ISBN номера
        /// </summary>
        /// <param>
        /// 5-7519-0485-12
        /// </param>
        /// <return>
        /// Expostion так как длина больше нужной
        /// </return>
        [TestMethod]
        public void ISBNCheck_LongString_Exception()
        {
            //Accept
            string isbn = "5-7519-0485-12";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.ISBNcheck(isbn));
        }
        /// <summary>
        /// Проверка ISBN номера
        /// </summary>
        /// <param>
        /// 5-7519-0485-
        /// </param>
        /// <return>
        /// Expostion так как длина меньше нужной
        /// </return>
        [TestMethod]
        public void ISBNCheck_ChortString_Exception()
        {
            //Accept
            string isbn = "5-7519-0485-";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.ISBNcheck(isbn));
        }
        /// <summary>
        /// Проверка ISBN номера
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Expostion так как пустая строка
        /// </return>
        [TestMethod]
        public void ISBNCheck_StringEmpty_Exception()
        {
            //Accept
            string isbn = "";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.ISBNcheck(isbn));
        }
        /// <summary>
        /// Проверка ISBN номера
        /// </summary>
        /// <param>
        /// Asdfgegrhfygt
        /// </param>
        /// <return>
        /// Expostion так как неверные символы
        /// </return>
        [TestMethod]
        public void ISBNCheck_FalseString_Exception()
        {
            //Accept
            string isbn = "Asdfgegrhfygt";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.ISBNcheck(isbn));
        }
    }
}
