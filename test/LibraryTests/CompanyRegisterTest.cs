using ClassLibrary;
using NUnit.Framework;
using Ucu.Poo.Locations.Client;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase del registro de empresas.
    /// </summary>
    [TestFixture]
    public class CompanyRegisterTest
    {
        private Company company;
        private LocationAdapter location;

        /// <summary>
        /// Set up del test de CompanyRegister.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.location = new LocationAdapter("address", "city", "department");
            this.company = new Company("nombre", this.location, "rubro");
        }

        /// <summary>
        /// Prueba que se agregue una empresa al registro.
        /// </summary>
        [Test]
        public void AddTest()
        {
            CompanyRegister.Instance.Add(this.company);
            Assert.IsTrue(CompanyRegister.Instance.CompanyList.Contains(this.company));
        }

        /// <summary>
        /// Prueba que se remueva una empresa del registro de empresas.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            CompanyRegister.Instance.Add(this.company);
            CompanyRegister.Instance.Remove(this.company);
            Assert.IsFalse(CompanyRegister.Instance.Contains(this.company));
        }

        /// <summary>
        /// Prueba que GetCompanyByUserId devuelva una empresa, y que sea la correcta.
        /// </summary>
        public void GetCompanyByUserIdTest()
        {
            Users user = new Users(1234567, new CompanyRole(this.company));
            company.CompanyUsers.Add(user);
            Company result = CompanyRegister.Instance.GetCompanyByUserId(1234567);
            Assert.AreEqual(this.company, result);
        }

        [Test]
        public void CompanyRegisterSerialize()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };
            CompanyRegister.Instance.CompanyList.Add(company);

            string json = CompanyRegister.Instance.ConvertToJson(options);

        }

        [Test]
        public void CompanyRegisterDeserialize()
        {
            string json = "{\r\n  \"$id\": \"1\",\r\n  \"CompanyList\": {\r\n    \"$id\": \"2\",\r\n    \"$values\": [\r\n      {\r\n        \"$id\": \"3\",\r\n        \"Id\": 0,\r\n        \"Name\": \"nombre\",\r\n        \"Locations\": {\r\n          \"$id\": \"4\",\r\n          \"$values\": [\r\n            {\r\n              \"$id\": \"5\",\r\n              \"Found\": false,\r\n              \"Latitude\": -33.37922,\r\n              \"Longitude\": -56.51478,\r\n              \"PostalCode\": \"97000\",\r\n              \"Address\": \"address\",\r\n              \"City\": \"city\",\r\n              \"Department\": \"department\"\r\n            }\r\n          ]\r\n        },\r\n        \"CompanyUsers\": {\r\n          \"$id\": \"6\",\r\n          \"$values\": []\r\n        },\r\n        \"InvitationToken\": \"85111-49145-68884\",\r\n        \"Headings\": \"rubro\",\r\n        \"OfferRegister\": {\r\n          \"$id\": \"7\",\r\n          \"$values\": []\r\n        },\r\n        \"ProducedMaterials\": {\r\n          \"$id\": \"8\",\r\n          \"$values\": []\r\n        }\r\n      }\r\n    ]\r\n  }\r\n}";
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };
            CompanyRegister.Instance.CompanyList.Add(company);
            CompanyRegister.Instance.LoadFromJson(json, options);
            Assert.AreEqual(this.company, json);
        }
    }
}