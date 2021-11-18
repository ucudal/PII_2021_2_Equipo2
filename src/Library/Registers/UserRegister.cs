using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ucu.Poo.Locations.Client;

namespace ClassLibrary
{   
    /// <summary>
    /// Esta clase representa un registro de usuarios
    /// </summary>
    public class UserRegister : IJsonConvertible
    {   
        private List<User> dataUsers = new List<User>();
        /// <summary>
        /// Lista de usuarios registrados
        /// </summary>
        /// <value></value>
        public List<User> DataUsers 
        { 
            get
            {
                return this.dataUsers;
            } 
            private set{} //CARGAR DE JSON LISTA DE USUARIOS REGISTRADOS
        }

        
        private UserRegister()
        {
            Initialize();
        }

        private static UserRegister instance;

        /// <summary>
        /// Instancia de UserRegister (COMENTAR SINGLETON)
        /// </summary>
        /// <value></value>
        public static UserRegister Instance
        {
            get{
                if (instance == null)
                {
                    instance = new UserRegister();
                }

                return instance;
            }
        }

        public void Initialize()
        {
           this.DataUsers = new List<User>();
        }


        /// <summary>
        /// Crea un usuario empresa
        /// </summary>
        /// <param name="input"></param>
        /// <param name="company"></param>
        public  void CreateCompanyUser(IMessage input,Company company)
        {
            company.AddUser(input.Id);
        }
        
        /// <summary>
        /// Crea un usuario emprendedor
        /// </summary>
        /// <param name="input"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="headings"></param>
        /// <param name="habilitations"></param>
        public void CreateEntrepreneurUser(IMessage input,string name , Location location, string headings, string habilitations)
        {
            IRole rol = new EntrepreneurRole(name , location, headings, habilitations);
            User usuario = new User(input.Id, rol);
        }

        /// <summary>
        /// Esto se hace por la ley de demeter
        /// </summary>
        /// <param name="item"></param>
        public void Add(User item)
        {
            this.DataUsers.Add(item);
        }

        /// <summary>
        /// Remueve un user de la lista. Por la ley de demeter
        /// </summary>
        /// <param name="item"></param>
        public void Remove(User item)
        {
            if (!this.DataUsers.Contains(item))
            {
                throw new Exception(); //CAMBIAR
            }
            this.DataUsers.Remove(item);
        }

        /// <summary>
        /// Por la ley de demeter se crea Contains
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool ContainsUser(User user)
        {
            if(this.DataUsers.Contains(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve  un objeto user segun la id dada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            User result = null;
            int index = 0;
            while (result == null && index < this.DataUsers.Count)
            {
                if (this.DataUsers[index].Id == id)
                {
                    result = this.DataUsers[index];
                }
            }

            return result;
        }

        public string ConvertToJson()
        {
            string result = "{\"Items\":[";

            foreach (var item in this.DataUsers)
            {
                result = result + item.ConvertToJson() + ",";
            }

            result = result.Remove(result.Length - 1);
            result = result + "]}";

            string temp = JsonSerializer.Serialize(this.DataUsers);
            return result;
            
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this.DataUsers, options);            
        }

        public void LoadFromJson(string json)
        {
            this.Initialize();
            User user = JsonSerializer.Deserialize<User>(json);
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            user = JsonSerializer.Deserialize<User>(json, options);
        }
    }
}