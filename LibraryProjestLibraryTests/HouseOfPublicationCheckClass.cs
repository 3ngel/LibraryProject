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
    public class HouseOfPublicationCheckClass
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
        public void HousePublicationCheck_RightString_True()
        {
            //Accert
            string house = "Росмэн";
            //Act
            CheckStringClass obj = new CheckStringClass();
            bool res = obj.HousePublicationCheck(house);
            //Assert
            Assert.IsTrue(res);
        }
    }
}
