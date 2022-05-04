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
    public class PasswordCheckTests
    {
        /// <summary>
        /// Ввод пустой строки
        /// </summary>
        [TestMethod]
        public void PasswordCheck_EmptyString_ThrowReturnd()
        {
            //Arrange
            string inputText = String.Empty;
            // Act
            CheckStringClass newObject = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.ReliabilityPassword(inputText));
        }
        /// <summary>
        /// Ввод строки отличную от допустимых
        /// </summary>
        [TestMethod]
        public void PasswordCheck_RandomString_ThrowReturnd()
        {
            //Arrange
            string inputText = "Фторник";
            // Act
            CheckStringClass newObject = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.ReliabilityPassword(inputText));
        }
        /// <summary>
        /// Ввод строки с точкой на конце
        /// </summary>
        [TestMethod]
        public void PasswordCheck_PontEndString_ThrowReturnd()
        {
            //Arrange
            string inputText = "Angel.";
            // Act
            CheckStringClass newObject = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.ReliabilityPassword(inputText));
        }
        /// <summary>
        /// Ввод короткого пароля
        /// </summary>
        [TestMethod]
        public void PasswordCheck_ShortLenghtString_ThrowReturnd()
        {
            //Arrange
            string inputText = "Ab*1";
            // Act
            CheckStringClass newObject = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.ReliabilityPassword(inputText));
        }
        /// <summary>
        /// Ввод Верной строки
        /// </summary>
        [TestMethod]
        public void PasswordCheck_TrueString_TrueReturnd()
        {
            //Arrange
            string inputText = "1568493AbC*";
            // Act
            CheckStringClass newObject = new CheckStringClass();
            bool result = newObject.ReliabilityPassword(inputText);
            //Assert
            Assert.IsTrue(result);
        }
    }
}
