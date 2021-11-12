using System;
using System.Collections.Generic;
using Ucu.Poo.Locations.Client;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase 
    /// </summary>
    public class Offer
    {
        private int id;
        /// <summary>
        /// Id de la Oferta
        /// </summary>
        /// <value></value>
        public int Id{
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }
        private string material;
        /// <summary>
        /// Material que se vende en la oferta
        /// </summary>
        /// <value></value>
        public string Material
        {
            get
            {
                return this.material;
            }
            private set
            {
                if (value != null)
                {
                    this.Material = value;
                }
                else
                {
                    //EXCEPCION OBJETO NULO
                }
            }
        }

        private string habilitation;
        /// <summary>
        /// Habilitaciones necesarias para poder manejar el producto en venta
        /// </summary>
        /// <value></value>
        public string Habilitation
        {
            get
            {
                return this.habilitation;
            }
            private set
            {
                if (value != null)
                {
                    this.habilitation = value;
                }
                else
                {
                    //EXCEPCION link invalido???????
                }
            }
        }
        private Location location;
        /// <summary>
        /// Ubicacion en donde se encuentran el producto a vender
        /// </summary>
        /// <value></value>
        public Location Location
        {
            get
            {
                return this.location;
            }
            private set
            {
                if (value != null)
                {
                    this.Location = value;
                }
                else
                {
                    //EXCEPCION OBJETO NULO
                }
            }
        }        
        private int quantityMaterial;
        /// <summary>
        /// Cantidad de material a vender
        /// </summary>
        /// <value></value>
        public int QuantityMaterial{
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }
        private double totalPrice;
        /// <summary>
        /// Precio total del producto
        /// </summary>
        /// <value></value>
        public double TotalPrice{
            get
            {
                return this.totalPrice;
            }
            private set
            {
                this.totalPrice = value;
            }
        }

        private Company company;    
        /// <summary>
        /// Empresa que vende el producto
        /// </summary>
        /// <value></value>
        public Company Company{
            get
            {
                return this.company;
            }
            private set
            {
                if (value != null)
                {
                    this.company = value;
                }
                else
                {
                    //EXCEPCION OBJETO NULO
                }
            }
        }

        private List<string> keywords = new List<string>();
        /// <summary>
        /// Palabras claves asignadas
        /// </summary>
        /// <value></value>
        public List<string> Keywords{
            get
            {
                return this.keywords;
            }
            private set
            {
                if (value != null)
                {
                    this.keywords = value;
                }
                else
                {
                    //EXCEPCION DE NOMBRE VACIO O NULO
                }
            }
        }

        private bool availability;
        /// <summary>
        /// Disponibilidad de la oferta
        /// </summary>
        /// <value></value>
        public bool Availability{
            get
            {
                return this.availability;
            }
            private set
            {
                this.availability = value;
            }
        }

        private DateTime publicationDate;
        /// <summary>
        /// Fecha de publicacion
        /// </summary>
        /// <value></value>
        public DateTime PublicationDate{
            get
            {
                return this.publicationDate;
            }
            private set
            {
                if (value != null)
                {
                    this.publicationDate = value;
                }
                else
                {
                    //EXCEPCION DE NOMBRE VACIO O NULO
                }
            }
        }

        /// <summary>
        /// Constructor de Offer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="material"></param>
        /// <param name="habilitation"></param>
        /// <param name="location"></param>
        /// <param name="quantityMaterial"></param>
        /// <param name="totalPrice"></param>
        /// <param name="company"></param>
        /// <param name="availability"></param>
        /// <param name="publicationDate"></param>
        public Offer(int id, string material, string habilitation, Location location,int quantityMaterial, double totalPrice, Company company,bool availability, DateTime publicationDate)
        {
        this.Id = id;
        this.Material=material;
        this.Habilitation=habilitation;
        this.Location=location;
        this.QuantityMaterial=quantityMaterial;
        this.Company=company;
        this.Availability=availability;
        this.PublicationDate=publicationDate;
        this.TotalPrice = totalPrice;
        }
  }
}
