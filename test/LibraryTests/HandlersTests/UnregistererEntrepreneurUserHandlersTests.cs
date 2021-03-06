using System;
using System.Text;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    /// <summary>
    /// Prueba el handler <see cref="UnregisteredEntrepreneurUserHandler"/>
    /// </summary>
    public class UnregisteredEntrepreneurUserHandlerTests 
    {
        private UnregisteredEntrepreneurUserHandler handler;
        private IMessage message;

        /// <summary>
        /// Se setea el usuario Entrepreneur.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.message = new TelegramBotMessage(1234, "/emprendedornoregistrado");
            handler = new UnregisteredEntrepreneurUserHandler();
        }

        /// <summary>
        /// Prueba que el InternalHandle se haga correctamente y cambie el estado del handler.
        /// </summary>
        [Test]
        public void HandleStartTest()
        {
            string response;
            bool result = this.handler.InternalHandle(this.message, out response);
            StringBuilder datos = new StringBuilder("¡Así que eres un Emprendedor!\n")
                                                .Append("Para poder registrarte vamos a necesitar algunos datos personales.\n")
                                                .Append("Ingrese su nombre completo.");
            Assert.IsTrue(result);
            Assert.That(response, Is.EqualTo(datos.ToString())); 
            Assert.That(this.handler.State, Is.EqualTo(UnregisteredEntrepreneurUserHandler.UnregisteredEntrepreneurUserState.Name));
        }

        /// <summary>
        /// Prueba que el InternalHandle se haga correctamente y cambie el estado del handler.
        /// </summary>
        [Test]
        public void HandleNameTest()
        {
            string response;
            bool result = handler.InternalHandle(message, out response);
            message.Text = "Nombre del emprendedor";
            result = handler.InternalHandle(message, out response);
            Assert.IsTrue(result);
            Assert.That(response, Is.EqualTo("Ingrese su numero de teléfono.")); 
            Assert.That(handler.State, Is.EqualTo(UnregisteredEntrepreneurUserHandler.UnregisteredEntrepreneurUserState.Phone));
        }

        /// <summary>
        /// Prueba que se procese el mensaje y que le pida la dirección.
        /// </summary>
        [Test]
        public void HandlePhoneTest()
        {
            string response;
            bool result = handler.InternalHandle(message, out response);
            this.message.Text = "Nombre del emprendedor";
            result = handler.InternalHandle(message, out response);
            message.Text = "098789456";
            result = handler.InternalHandle(message, out response);
            Assert.IsTrue(result);
            Assert.That(response, Is.EqualTo("Ingrese su dirección.")); 
            Assert.That(handler.State, Is.EqualTo(UnregisteredEntrepreneurUserHandler.UnregisteredEntrepreneurUserState.Address));
        }

        /// <summary>
        /// Prueba que el InternalHandle se haga correctamente y cambie el estado del handler.
        /// </summary>
         [Test]
        public void HandleAddressTest()
        {
            string response;
            bool result = handler.InternalHandle(message, out response);
            this.message.Text = "Nombre del emprendedor";
            result = handler.InternalHandle(message, out response);
            this. message.Text = "098789456";
            result = handler.InternalHandle(message, out response);
            this.message.Text = "Av. 8 de Octubre 2738";
            result = handler.InternalHandle(message, out response);
            Assert.IsTrue(result);
            Assert.That(response, Is.EqualTo("Ingrese la ciudad.")); 
            Assert.That(handler.State, Is.EqualTo(UnregisteredEntrepreneurUserHandler.UnregisteredEntrepreneurUserState.City));
        }

        /// <summary>
        /// Prueba que el InternalHandle se haga correctamente y cambie el estado del handler.
        /// </summary>
        [Test]
        public void HandleCityTest()
        {
            string response;
            bool result = handler.InternalHandle(message, out response);
            this.message.Text = "Nombre del emprendedor";
            result = handler.InternalHandle(message, out response);
            this.message.Text = "098789456";
            result = handler.InternalHandle(message, out response);
            this.message.Text = "Av. 8 de Octubre 2738";
            result = handler.InternalHandle(message, out response);
            this.message.Text = "Montevideo";
            result = handler.InternalHandle(message, out response);
            Assert.IsTrue(result);
            Assert.That(response, Is.EqualTo("Ingrese el departamento.")); 
            Assert.That(handler.State, Is.EqualTo(UnregisteredEntrepreneurUserHandler.UnregisteredEntrepreneurUserState.Department));
        }

        /// <summary>
        /// Prueba que el InternalHandle se haga correctamente y cambie el estado del handler.
        /// </summary>
         [Test]
        public void HandleDepartmentTest()
        {
            string response;
            bool result = handler.InternalHandle(message, out response);
            this.message.Text = "Nombre del emprendedor";
            result = handler.InternalHandle(message, out response);
            this.message.Text = "098789456";
            result = handler.InternalHandle(message, out response);
            this.message.Text = "Av. 8 de Octubre 2738";
            result = handler.InternalHandle(message, out response);
            this.message.Text = "Montevideo";
            result = handler.InternalHandle(message, out response);
            this.message.Text = "Montevideo";
            result = handler.InternalHandle(message, out response);
            Assert.IsTrue(result);
            Assert.That(response, Is.EqualTo("Ingrese sus habilitaciones.")); 
            Assert.That(handler.State, Is.EqualTo(UnregisteredEntrepreneurUserHandler.UnregisteredEntrepreneurUserState.Habilitations));
        }
        
        /// <summary>
        /// Prueba que el InternalHandle se haga correctamente y cambie el estado del handler.
        /// </summary>
        public void HandleHabilitationsTest()
        {
            string response;
            bool result = handler.InternalHandle(this.message, out response);
            this.message.Text = "Nombre del emprendedor";
            result = handler.InternalHandle(this.message, out response);
            this.message.Text = "098789456";
            result = handler.InternalHandle(this.message, out response);
            this.message.Text = "Av. 8 de Octubre 2738";
            result = handler.InternalHandle(this.message, out response);
            this.message.Text = "Montevideo";
            result = handler.InternalHandle(this.message, out response);
            this.message.Text = "Montevideo";
            result = handler.InternalHandle(this.message, out response);
            this.message.Text = "Link";
            result = handler.InternalHandle(this.message, out response);
            Assert.IsTrue(result);
            Assert.That(response, Is.EqualTo("Ingrese su rubro.")); 
            Assert.That(this.handler.State, Is.EqualTo(UnregisteredEntrepreneurUserHandler.UnregisteredEntrepreneurUserState.Headings));
        }

        /// <summary>
        /// Prueba que el InternalHandle se haga correctamente y cambie el estado del handler.
        /// </summary>
        public void HandleHeadingsTest()
        {
            string response;
            bool result = handler.InternalHandle(this.message, out response);
            this.message.Text = "Nombre del emprendedor";
            result = handler.InternalHandle(this.message, out response);
            this.message.Text = "098789456";
            result = handler.InternalHandle(this.message, out response);
            this.message.Text = "Av. 8 de Octubre 2738";
            result = handler.InternalHandle(this.message, out response);
            this.message.Text = "Montevideo";
            result = handler.InternalHandle(this.message, out response);
            this.message.Text = "Montevideo";
            result = handler.InternalHandle(this.message, out response);
            this.message.Text = "Link";
            result = handler.InternalHandle(this.message, out response);
            this.message.Text = "Rubro";
            result = handler.InternalHandle(this.message, out response);
            Assert.IsTrue(result);
            Assert.That(response, Is.EqualTo("Gracias por sus datos, ya se ha creado su usuario\n")); 
            Assert.IsTrue(UserRegister.Instance.DataUsers.Contains(UserRegister.Instance.GetUserById(1234)));
            Assert.That(handler.State, Is.EqualTo(UnregisteredEntrepreneurUserHandler.UnregisteredEntrepreneurUserState.Start));
        }


        /// <summary>
        /// Prueba que no se realice el handler.
        /// </summary>
        [Test]
        public void InternalNotHandleTest()
        {
            string response;
            IHandler result = handler.Handle(new ConsoleMessage("/modificarprecio"),out response);
            Assert.IsNull(result);
            Assert.IsEmpty(response);
        }
    }
}