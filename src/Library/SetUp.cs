using System;

namespace ClassLibrary
{   
    /// <summary>
    /// Esta clase solo se encarga de crear la chain of responsability correspondiente para cada usuario
    /// por lo tanto cumple con el patron SRP. Tambien comple con el patron Creator porque utiliza, necesariamente, ya que es la encargada
    /// de construir los Handler para crear la CoR.
    /// </summary>
    public class Setup
    {
        

        /*public IHandler Start(IMessageChannel channel, IMessage input)
        {
            if(!this.Registro.IsRegistered(input.Id) )
            {
                //Chain of Responsability de unregistered
                IHandler respuesta =  new UnregisteredUserHandler(channel);
                respuesta.SetNext(new UnregisteredCompanyUserHandler(channel)
                        .SetNext(new UnregisteredEntrepeneurUserHandler(channel)
                        .SetNext(new EndHandler(channel, respuesta))));
                return respuesta;
            }
            else if(this.Registro.IsAdmin(input.Id))
            {
                IHandler respuesta =  new AdminStartHandler(channel);
                respuesta.SetNext(new AddCompanyHandler(channel)
                        .SetNext(new InviteTokenGeneratorHandler(channel)
                        .SetNext(new RemoveUserHandler(channel)
                        .SetNext(new RemoveCompanyHandler(channel)
                        .SetNext(new EndHandler(channel, respuesta))))));
                return respuesta;
            }
            else if (this.Registro.IsCompany(input.Id))
            {

            }
            else
            {
                
            }
        }*/



    }
}
