using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurEuroViewModelTests
    {
        /// <summary>
        /// Test constructeur
        /// </summary>
        [TestMethod()]
        public void ConvertisseurEuroViewModelTest()
        {
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            Assert.IsNotNull(convertisseurEuro);
        }


        /// <summary>
        /// Test GetDataOnLoadAync OK
        /// </summary>
        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            // Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();

            // Act
            convertisseurEuro.GetDataOnLoadAsync();
            Thread.Sleep(1000);

            // Assert
            Assert.IsNotNull(convertisseurEuro.LesDevises, "Erreur, la liste des devises est null");
        }
        
        /// <summary>
        /// Test Conversion OK
        /// </summary>
        [TestMethod()]
        public void ActionSetConversionTest()
        {
            // Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            convertisseurEuro.MontantEuros = 100;
            Devise devise = new Devise(1, "Dollar", 1.07);
            convertisseurEuro.Devise = devise;

            // Act
            convertisseurEuro.ActionSetConversion();

            // Assert
            Assert.AreEqual(107, convertisseurEuro.MontantDevise, "Erreur lors de la conversion");

        }
    }
}