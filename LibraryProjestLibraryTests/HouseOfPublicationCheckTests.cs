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
    public class HouseOfPublicationCheckTests
    {
        /// <summary>
        /// Проверка ввода дома публикации
        /// </summary>
        /// <param>
        /// Росмэн
        /// </param>
        /// <retutn>
        /// true
        /// </retutn>
        [TestMethod]
        public void HousePublicationCheck_RightKirString_True()
        {
            //Accert
            string house = "Росмэн";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.HousePublicationCheck(house);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка ввода дома публикации
        /// </summary>
        /// <param>
        /// New Time
        /// </param>
        /// <retutn>
        /// true
        /// </retutn>
        [TestMethod]
        public void HousePublicationCheck_RightLatString_True()
        {
            //Accert
            string house = "New Time";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.HousePublicationCheck(house);
            //Assert
            Assert.IsTrue(res);
        }
        /// <summary>
        /// Проверка ввода дома публикации
        /// </summary>
        /// <param>
        /// String.Empty
        /// </param>
        /// <return>
        /// Expostion так как пустая строка
        /// </return>
        [TestMethod]
        public void HousePublicationCheck_StringEmpty_Expostion()
        {
            //Accept
            string house = String.Empty;
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AuthorCheck(house));
        }
        /// <summary>
        /// Проверка ввода дома публикации
        /// </summary>
        /// <param>
        /// House Романовых
        /// </param>
        /// <return>
        /// Expostion так как использованы два альфавита вместе
        /// </return>
        [TestMethod]
        public void HousePublicationCheck_KirAndLat_Expostion()
        {
            //Accept
            string house = "House Романовых";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AuthorCheck(house));
        }
        /// <summary>
        /// Проверка ввода дома публикации
        /// </summary>
        /// <param>
        /// Романовых123
        /// </param>
        /// <return>
        /// Expostion так как неккоректные символы
        /// </return>
        [TestMethod]
        public void HousePublicationCheck_FalseString_Expostion()
        {
            //Accept
            string house = "Романовых123";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AuthorCheck(house));
        }
        /// <summary>
        /// Проверка ввода дома публикации
        /// </summary>
        /// <param>
        /// романовых
        /// </param>
        /// <return>
        /// Expostion так как написано со строчной буквы
        /// </return>
        [TestMethod]
        public void HousePublicationCheck_LowerStart_Expostion()
        {
            //Accept
            string house = "романовых";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AuthorCheck(house));
        }
        /// <summary>
        /// Проверка ввода дома публикации
        /// </summary>
        /// <param>
        /// -Романовых
        /// </param>
        /// <return>
        /// Expostion так как дефис в начале
        /// </return>
        [TestMethod]
        public void HousePublicationCheck_DefisStart_Expostion()
        {
            //Accept
            string house = "-Романовых";
            //Act
            CheckStringClass obj = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => obj.AuthorCheck(house));
        }
    }
}
