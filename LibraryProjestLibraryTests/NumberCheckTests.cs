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
    public class NumberCheckTests
    {
        /// <summary>
        /// Ввод пустой строки
        /// </summary>
        [TestMethod]
        public void NumberCheck_EmptyString_ThrowReturnd()
        {
            //Arrange
            string inputText = String.Empty;
            // Act
            CheckStringClass newObject = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.NumberCheck(inputText));
        }
        /// <summary>
        /// Ввод строки отличную от допустимых
        /// </summary>
        [TestMethod]
        public void NumberCheck_RandomString_ThrowReturnd()
        {
            //Arrange
            string inputText = "Andf1239999";
            // Act
            CheckStringClass newObject = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.NumberCheck(inputText));
        }
        /// <summary>
        /// Ввод номера с кол-вом чисел меньше 11
        /// </summary>
        [TestMethod]
        public void NumberCheck_4NumberString_ThrowReturnd()
        {
            //Arrange
            string inputText = "8982";
            // Act
            CheckStringClass newObject = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.NumberCheck(inputText));
        }

        /// <summary>
        /// Ввод номера с кол-вом чисел больше 13
        /// </summary>
        [TestMethod]
        public void NumberCheck_13NumberString_ThrowReturnd()
        {
            //Arrange
            string inputText = "8982263540283";
            // Act
            CheckStringClass newObject = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.NumberCheck(inputText));
        }
        /// <summary>
        /// Ввод номера с цифры не равное 8
        /// </summary>
        [TestMethod]
        public void NumberCheck_StartNotEightString_ThrowReturnd()
        {
            //Arrange
            string inputText = "23456789123";
            // Act
            CheckStringClass newObject = new CheckStringClass();
            //Assert
            Assert.ThrowsException<Exception>(() => newObject.NumberCheck(inputText));
        }
        /// <summary>
        /// Ввод верной строки
        /// </summary>
        [TestMethod]
        public void NumberCheck_TrueString_TrueReturnd()
        {
            //Arrange
            string inputText = "+7 (982) 739-62-50";
            // Act
            CheckStringClass newObject = new CheckStringClass();
            bool result = newObject.NumberCheck(inputText);
            //Assert
            Assert.IsTrue(result);
        }
    }
}
