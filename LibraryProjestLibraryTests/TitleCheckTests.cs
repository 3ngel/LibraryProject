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
    public class TitleCheckTests
    {
        /// <summary>
        /// Проверка корректности названия
        /// </summary>
        /// <param>
        /// Тарас Бульба
        /// </param>
        /// <return>
        /// true
        /// </return>
        [TestMethod]
        public void TitleCheck_RightString_True()
        {
            //Accept
            string author = "Тарас Бульба";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.TitleCheck(author);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка корректности названия
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Expostion так как пустая строка
        /// </return>
        [TestMethod]
        public void TitleCheck_StringEmpty_Expostion()
        {
            //Accept
            string author = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.TitleCheck(author));
        }
        /// <summary>
        /// Проверка корректности названия
        /// </summary>
        /// <param>
        /// горе от ума
        /// </param>
        /// <return>
        /// Expostion так как ввод со строчной буквы
        /// </return>
        [TestMethod]
        public void TitleCheck_LowerString_Expostion()
        {
            //Accept
            string author = "горе от ума";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.TitleCheck(author));
        }
        /// <summary>
        /// Проверка корректности автора
        /// </summary>
        /// <param>
        /// Мёpтвые души
        /// </param>
        /// <return>
        /// Expostion так как "p" из латинского алфавита
        /// </return>
        [TestMethod]
        public void TitleCheck_FalseString_Expostion()
        {
            //Accept
            string author = "Мёpтвые души";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.TitleCheck(author));
        }
        /// <summary>
        /// Проверка корректности автора
        /// </summary>
        /// <param>
        /// -Му-му
        /// </param>
        /// <return>
        /// Expostion так как начинается с дефис
        /// </return>
        [TestMethod]
        public void TitleCheck_StartDefis_Expostion()
        {
            //Accept
            string author = "-Му-му";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.TitleCheck(author));
        }
    }
}
