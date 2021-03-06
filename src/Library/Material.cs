using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un material.
    /// por el principio de responsabilidad única (SRP), esta clase es la encargada de conocer los datos de los materiales.
    /// </summary>
    public class Material
    {   
        private string name;
        /// <summary>
        /// Obtiene el tipo de objeto.
        /// </summary>
        /// <value></value>
        public string Name{
            get
            {
                return this.name;
            }
            private set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    this.name = value;
                }
            }
        }
        private string type;
        /// <summary>
        /// Obtiene el tipo de material.
        /// </summary>
        /// <value></value>
        public string Type{
            get
            {
                return this.type;
            }
            private set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    this.type = value;
                }
            }
        }
        private string classification;
        /// <summary>
        /// Obtiene la clasificacion del material.
        /// </summary>
        /// <value></value>
        public string Classification{
            get
            {
                return this.classification;
            }
            private set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    this.classification = value;
                }
            }
        }
        /// <summary>
        /// JsonConstructor para objetos Material.
        /// </summary>
        [JsonConstructor]
        public Material()
        {
            
        }

        /// <summary>
        /// Constructor de objetos Material.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="classification"></param>
        public Material (string name, string type ,string classification )
        {
            this.Name = name;
            this.Type = type;
            this.Classification = classification;
        }

        /// <summary>
        /// Convierte un objeto a texto en formato Json. El objeto puede ser reconstruido a partir del texto en formato
        /// Json utilizando JsonSerializer.Deserialize.
        /// </summary>
        /// <returns>El objeto convertido a texto en formato Json.</returns>
        public string ConvertToJson()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this, options);
        }  
    }
}