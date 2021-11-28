using System;
using System.Collections.Generic;
using System.Text;
using Ucu.Poo.Locations.Client;

namespace ClassLibrary
{
    /// <summary>
    /// Handler encargado de crear un usuario emprendedor.
    /// </summary>
    public class UnregisteredEntrepreneurUserHandler : AbstractHandler
    {   
        /// <summary>
        /// Estado para el handler de UnregisteredEntrepreneurUserHandler.
        /// </summary>
        /// <value></value>
        public UnregisteredEntrepreneurUserState State { get; set; }
        /// <summary>
        /// Guarda la información que pasa el usuario por el chat cuando se utiliza el comando UnregisteredEntrepreneurUserHandler.
        /// </summary>
        /// <value></value>
        public UnregisteredEntrepreneurUserData Data{ get; set; }

        /// <summary>
        /// Constructor de objetos UnregistredEntrepreneurUserHandler.
        /// </summary>
        public UnregisteredEntrepreneurUserHandler()
        {
            this.Command = "/emprendedornoregistrado";
            this.State = UnregisteredEntrepreneurUserState.Start;
            this.Data = new UnregisteredEntrepreneurUserData();
        }
        /// <summary>
        /// Pregunta por los datos del emprendedor y delega la tarea de crear un usuario emprendedor.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="response"></param>
        public override bool InternalHandle(IMessage input, out string response)
        {
            if ((this.State == UnregisteredEntrepreneurUserState.Start) && (CanHandle(input)))
            {
                StringBuilder datos = new StringBuilder("Asi que eres un Emprendedor!\n")
                                                .Append("Para poder registrarte vamos a necesitar algunos datos personales\n")
                                                .Append("Ingrese su nombre completo\n");
                this.State = UnregisteredEntrepreneurUserState.Name;
                response = datos.ToString();
                return true;
            }
            else if(this.State == UnregisteredEntrepreneurUserState.Name)
            {
                this.Data.Name =  input.Text;
                this.State = UnregisteredEntrepreneurUserState.Address;
                response = "Ingrese su dirección:\n";
                return true;
            }
            else if (this.State == UnregisteredEntrepreneurUserState.Address)
            {
                this.Data.Address =  input.Text;
                this.State = UnregisteredEntrepreneurUserState.City;
                response = "Ingrese la ciudad:\n";
                return true;
            }
            else if(this.State == UnregisteredEntrepreneurUserState.City)
            {
                this.Data.City = input.Text;
                this.State = UnregisteredEntrepreneurUserState.Department;
                response = "Ingrese el departamento:\n";
                return true;
            }
            else if (this.State == UnregisteredEntrepreneurUserState.Department)
            {
                this.Data.Department = input.Text;
                this.State = UnregisteredEntrepreneurUserState.Habilitations;
                this.Data.LocationResult = new LocationAdapter(this.Data.Address,this.Data.City,this.Data.Department);
                response = "Ingrese sus habilitaciones\n";
                return true;
            }
            else if (this.State == UnregisteredEntrepreneurUserState.Habilitations)
            {
                string habilitaciones =  input.Text;
                this.State = UnregisteredEntrepreneurUserState.Headings;
                response = "Ingrese su rubro\n";
                return true;
            }
            else if (this.State == UnregisteredEntrepreneurUserState.Headings)
            {
                string rubro = input.Text;
                this.State = UnregisteredEntrepreneurUserState.Start;
                UserRegister.Instance.CreateEntrepreneurUser(input.Id, this.Data.Name, this.Data.LocationResult, this.Data.Headings,this.Data.Habilitations);
                response = "Gracias por sus datos, se esta creando su usuario\n";
                return true;

            }
            else
            {
                response = "";
                return false;
            } 
        }

        /// <summary>
        /// Estados para el handler de un emprendedor no registrado
        /// </summary>
        public enum UnregisteredEntrepreneurUserState
        {
            Start,
            Name,
            Address,
            City,
            Department,
            Habilitations,
            Headings,
        }

        /// <summary>
        /// Se guardan los datos que el usuario pasa por el chat.
        /// </summary>
        public class UnregisteredEntrepreneurUserData
        {
            /// <summary>
            /// El nombre que se ingresó en el estado UnregisteredCompanyUserState.Name.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// se guarda la dirección que se ingresó en el estado UnregisteredEntrepreneurUserState.Addres .
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// Se guarda la ciudad que se ingresó en el estado UnregisteredEntrepreneurUserState.City .
            /// </summary>
            /// <value></value>
            public string City{get;set;}

            /// <summary>
            /// Se guarda eL departamento que se ingresó en el estado UnregisteredEntrepreneurUserState.Department .
            /// </summary>
            /// <value></value>
            public string Department {get;set;}

            /// <summary>
            /// El resultado de la búsqueda de la dirección ingresada.
            /// </summary>
            public LocationAdapter LocationResult { get; set; }
            
            /// <summary>
            /// El link a las habilitaciones que se ingresó en el estado UnregisteredCompanyUserState.Habilitations.
            /// </summary>
            public string Habilitations { get; set; }

            /// <summary>
            /// El rubro que se ingresó en el estado UnregisteredCompanyUserState.Headings.
            /// </summary>
            public string Headings { get; set; }
        }
    }
}