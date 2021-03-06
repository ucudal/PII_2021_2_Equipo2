using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase del registro de empresas.
    /// </summary>
    [TestFixture]
    public class TokenRegisterTests
    {
        private LocationAdapter location;

        /// <summary>
        /// Prueba que se agregue un token  al registro.
        /// </summary>
        [Test]
        public void AddTest()
        {
            location = new LocationAdapter("address", "city", "department");
            Company company = new Company("empresa", location, "rubro", "company@gmail.com", "091919191");
            string token = "145789";
            TokenRegister.Instance.Add(token, company);
            Assert.IsNotNull(TokenRegister.Instance.TokenList);
        }

        /// <summary>
        /// Prueba que se remueva un token  del registro de tokens.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            Company company = new Company("empresa", location, "rubro", "company@gmail.com", "091919191");
            string token = "123459";
            TokenRegister.Instance.Add(token, company);
            TokenRegister.Instance.Remove(token);
            Assert.IsFalse(TokenRegister.Instance.IsValid(token));
        }

        /// <summary>
        /// Prueba que un token sea valido y devuelva la empresa correcta.
        /// </summary>
        [Test]
        public void IsValidTest()
        {
            Company company = new Company("empresa", location, "rubro", "company@gmail.com", "091919191");
            string token = "245789";
            TokenRegister.Instance.Add(token, company);
            Assert.AreEqual(TokenRegister.Instance.GetCompany(token), company);
        }

        /// <summary>
        /// Prueba de que el token este en la lista de tokens.
        /// </summary>
        [Test]
        public void ContainsTest()
        {
            Company company = new Company("empresa", location, "rubro", "company@gmail.com", "091919191");
            string token = "548796";
            TokenRegister.Instance.Add(token, company);
            Assert.True(TokenRegister.Instance.IsValid(token));
            Assert.False(TokenRegister.Instance.IsValid("54854456"));
        }
    }
}