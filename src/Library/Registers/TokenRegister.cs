using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary 
{
    /// <summary>
    /// Esta clase  representa un registro de tokens.
    /// Se utiliza el patrón de diseño creacional Singleton para crear esta clase ya que mos permite asegurarnos que
    /// habrá  una solo una instancia de esta clase.
    /// </summary>
    public class TokenRegister : IJsonConvertible
    {   
        /// <summary>
        /// Diccionario con nombre de empresas y sus respectivos tokens habilitados.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Dictionary<string , Company> TokenList;

        private static TokenRegister instance;

        private TokenRegister()
        {
            Initialize();
        }
        /// <summary>
        /// Se crea un Singelton de la clase TokenRegister.
        /// </summary>
        /// <value></value>
        public static TokenRegister Instance
        {
            get{
                if (instance == null)
                {
                    instance = new TokenRegister();
                }

                return instance;
            }
        }
        /// <summary>
        /// Se crea diccionario para asociar un token con su respectiva empresa.
        /// </summary>
        public void Initialize()
        {
            this.TokenList = new Dictionary<string, Company>();
        }

        /// <summary>
        /// Devuelve la empresa a la cual le pertenece un codigo.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Company GetCompany(string codigo)
        {
            if (!TokenList.ContainsKey(codigo))
            {
                throw new InvalidInputException("No se encontro ninguna empresa con ese Id.");
            }
            return TokenList[codigo];
        }

        /// <summary>
        /// Metodo para añadir un token al diccionario de tokens.  Por la ley de demeter y para evitar el alto acoplamiento 
        /// se crea el Metodo Add para añadir token y su empresa al registro  de tokens
        ///  y que otro objeto no deba de conocer todas la conexiones internas.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="company"></param>
        public void Add(string token,Company company)
        {
            this.TokenList.Add(token,company);
        }

        /// <summary>
        /// Metodo para remover un token del diccionario de tokens.  Por la ley de demeter y para evitar el alto acoplamiento 
        /// se crea el Metodo Remove para remover un token del registro  de tokens
        ///  y que otro objeto no deba de conocer todas la conexiones internas.
        /// </summary>
        /// <param name="token"></param>
        public void Remove(string token)
        {
            this.TokenList.Remove(token);
        }

        /// <summary>
        /// Devuelve verdadero o falso  si el token existe en la lista de tokens.
        /// Por la ley de demeter y para evitar el alto acoplamiento se crea el Metodo Contains para verificar si un token 
        /// pertence a el registro de tokens  y además que otro objeto no deba de conocer todas la conexiones internas.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public bool IsValid(string codigo)
        {
            if(this.TokenList.ContainsKey(codigo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Convierte el objeto a texto en formato Json. El objeto puede ser reconstruido a partir del texto en formato
        /// Json utilizando JsonSerializer.Deserialize.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson(JsonSerializerOptions options)
        {
            JsonSerializerOptions option = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };
            return JsonSerializer.Serialize(this, option);
        }
        /// <summary>
        /// Convierte el texto en formato Json a objeto.
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            this.Initialize();
            string token = JsonSerializer.Deserialize<string>(json);
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            token = JsonSerializer.Deserialize<string>(json, options);
        }

        /// /// <summary>
        /// Se genera un  token para una nueva empresa y se lo añade al diccionario.
        /// Por el patrón Expert se agregó este método ya que es el experto en los tokens, contiene un diccionario con todos 
        /// los tokens y sus respectivas empresas.
        /// </summary>
        /// <returns></returns>
        public string GenerateToken() // TODO se genera dentro de la company y se le psas una emrpresa. Ver si es mejor aca o en TokenRegister
        {
            Random rnd = new Random();
            StringBuilder token = new StringBuilder("");
            while (token.ToString() == "")        //Me fijo si ya existe token y de ser asi le añado el Token y su empresa a el diccionario
            {
                for (int i = 0; i < 3; i++)         //En este for se crea un nuevo token
                {
                    int num = rnd.Next(10000, 100000);
                    token.Append(num.ToString());
                    if (i != 2) token.Append("-");
                }
                if (this.IsValid(token.ToString()))
                {
                    token = new StringBuilder("");
                }
            }
            return token.ToString();
        }
    }
}