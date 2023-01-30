using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurDeviseViewModelTests
    {
        [TestMethod()]
        public void ConvertisseurDeviseViewModelTest()
        {
            ConvertisseurDeviseViewModel convertisseurDevise = new ConvertisseurDeviseViewModel();
            Assert.IsNotNull(convertisseurDevise);
        }

        [TestMethod()]
        public void ActionSetConversionTest()
        {
            // Arrange
            ConvertisseurDeviseViewModel ConvertisseurDevise = new ConvertisseurDeviseViewModel();

            // Act
            ConvertisseurDevise.GetDataOnLoadAsync();
            Thread.Sleep(1000);

            // Assert
            Assert.IsNotNull(ConvertisseurDevise.LesDevises, "Erreur, la liste des devises est null");
        }

        [TestMethod()]
        public void GetDataOnLoadAsyncTest()
        {
            // Arrange
            ConvertisseurDeviseViewModel ConvertisseurDevise = new ConvertisseurDeviseViewModel();
            ConvertisseurDevise.MontantEuros = 107;
            Devise devise = new Devise(1, "Dollar", 1.07);
            ConvertisseurDevise.Devise = devise;

            // Act
            ConvertisseurDevise.ActionSetConversion();

            // Assert
            Assert.AreEqual(100, ConvertisseurDevise.MontantDevise, "Erreur lors de la conversion");
        }
    }
}