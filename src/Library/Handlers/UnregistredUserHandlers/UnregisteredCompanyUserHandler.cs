using System;
using System.Collections.Generic;
using System.Text;
namespace ClassLibrary
{
    /// <summary>
    /// Marcamos el formato del resto de handlers
    /// </summary>
    public class UnregisteredCompanyUserHandler : AbstractHandler
    {
        
        /// <summary>
        /// Handler para los usuarios empresa no registrados.
        /// </summary>
        public UnregisteredCompanyUserHandler(IMessageChannel channel)
        {
            this.Command = "empresa";
            this.messageChannel = channel;
        }
        public override void Handle(IMessage input)
        {
            if (this.nextHandler != null && (CanHandle(input)) )
            {
                StringBuilder datos = new StringBuilder("Asi que eres usuario de una empresa!\n")
                                                .Append("Para poder registrarte vamos a necesitar el codigo de invitacion y algunos datos personales\n")
                                                .Append("Ingrese el codigo de invitacion\n");
                string codigo = this.messageChannel.ReceiveMessage().Text;
                TokenRegisterServiceProvider trsp = new TokenRegisterServiceProvider();
                Company response;

                // if (trsp.IsValidToken(codigo, out response)      //FALTA CREAR out response para que devuelva la empresa para crear el CompanyUser
                // {
                //     CreateUserServiceProvider.CreateCompanyUser(input, response );       //FALTA CREAR
                // }
                // else
                // {
                //    Excepcion?????? 
                // }
               
            }
            else
            {
                this.nextHandler.Handle(input);
            }
        }
    }
}