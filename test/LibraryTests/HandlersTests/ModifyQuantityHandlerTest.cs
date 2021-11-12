using System;
using NUnit.Framework;
using ClassLibrary;
using Ucu.Poo.Locations.Client;

namespace Tests
{
    /// <summary>
    /// Prueba el handler para modificar la cantidad en una oferta 
    /// </summary>
    [TestFixture]
    public class ModifyQuantityHandlerTest
    {
        private Offer oferta;
        private Material material;
        private DateTime dateTime;
        private IHandler handler;
        private Location location;

        [SetUp]
        public void Setup()
        {
            
            this.oferta = new Offer(1234567,"material", "habilitation", location,3,3000, new Company(),true,dateTime);
            this.material = new Material("material","type","clasificacion");
            IMessageChannel messageChannel = new ConsoleMessageChannel();
            this.handler = new ModifyQuantityHandler(messageChannel);
        }
        [Test]

        public void HandleTest()
        {
            handler.Handle(new ConsoleMessage("/modificarcantidad"));
            int cantidad = 4;
            Assert.AreEqual(cantidad, this.oferta.QuantityMaterial);
            
        }

    }
}