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
    public class PageCountsCheckTests
    {
        /// <summary>
        /// Проверка кол-ва страниц в книге
        /// </summary>
        /// <param>
        /// 123
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void PageCountsCheck_RightString_True()
        {
            //Accept
            string count = "123";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.PageCountsCheck(count);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка кол-ва страниц в книге
        /// </summary>
        /// <param>
        /// 123f
        /// </param>
        /// <return>
        /// Exposition так как не корректные символы
        /// </return>
        [TestMethod]
        public void PageCountsCheck_FalseString_Exception()
        {
            //Accept
            string count = "123f";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.PageCountsCheck(count));
        }
        /// <summary>
        /// Проверка кол-ва страниц в книге
        /// </summary>
        /// <param>
        /// 3
        /// </param>
        /// <return>
        /// Exposition так как мало страниц
        /// </return>
        [TestMethod]
        public void PageCountsCheck_ShortString_Exception()
        {
            //Accept
            string count = "3";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.PageCountsCheck(count));
        }
        /// <summary>
        /// Проверка кол-ва страниц в книге
        /// </summary>
        /// <param>
        /// StringEmprt
        /// </param>
        /// <return>
        /// Exposition так как пустая строка
        /// </return>
        [TestMethod]
        public void PageCountsCheck_StringEmpty_Exception()
        {
            //Accept
            string count = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.PageCountsCheck(count));
        }
    }
}
