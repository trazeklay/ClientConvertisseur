using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.Services;
using ClientConvertisseurV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.ViewModels;
using System.Collections.ObjectModel;

namespace ClientConvertisseurV2.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        [TestMethod()]
        public void GetDevisesAsyncTest()
        {
            // Arrange
            WSService ws = new WSService("localhost");

            // Act
            var result = ws.GetDevisesAsync("devises").Result;
            Thread.Sleep(1000);

            // Assert
            Assert.IsNotNull(result, "Erreur, la liste des devises est null");
            Assert.IsInstanceOfType(result, typeof(ObservableCollection<Devise>), "Erreur, la fonction doit retourner une ObservalbleCollection de devises");
            Assert.AreEqual(
                result,
                new ObservableCollection<Devise> {
                    new Devise(1, "Dollar", 1.08),
                    new Devise(2, "Franc Suisse", 1.07),
                    new Devise(3, "Yen", 120),
                },
                "Erreur, les listes ne sont pas identiques."
            );
        }

        [TestMethod()]
        public void WSServiceTest()
        {
            Assert.Fail();
        }
    }
}