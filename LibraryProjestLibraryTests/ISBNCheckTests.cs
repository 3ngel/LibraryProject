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
            //
            string isbn = "5-7519-0485-0";
            //
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.ISBNcheck(isbn);
            //
            Assert.IsTrue(res);
        }
    }
}
