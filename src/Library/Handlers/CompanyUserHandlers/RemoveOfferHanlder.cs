using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Handler encargado de delegar la accion de retirar una oferta
    /// </summary>
    public class RemoveOfferHandler: AbstractHandler
    {   
        /// <summary>
        /// Constructor de objetos RemoveOfferHandler
        /// </summary>
        /// <param name="channel"></param>
        public RemoveOfferHandler(IMessageChannel channel)
        {
            this.Command = "/retiraroferta";            
            this.messageChannel = channel ;
        }
        /// <summary>
        /// Se encarga de pasar por pantalla la lista de ofertas actuales y luego de recibir un Id
        /// de una oferta delega la accion de eliminarla.
        /// De no existir la oferta le avisa por pantalla al usuario.
        /// </summary>
        /// <param name="input"></param>
        public override bool InternalHandle(IMessage input)
        {
            if(CanHandle(input))
            {
                Company company =CompanyRegister.Instance.GetCompanyByUserId(input.Id);

                if(company.OfferRegister != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"Estas son tus ofertas actuales:\n");
                    foreach (Offer item in Market.Instance.ActualOfferList)
                    {
                        sb.Append($"Id de la oferta: {item.Id}\n")
                            .Append($"Material de la oferta: {item.Material}\n")
                            .Append($"Cantidad: {item.QuantityMaterial}\n")
                            .Append($"Fecha de publicacion: {item.PublicationDate}\n")
                            .Append($"\n-----------------------------------------------\n\n");
                    }
                    sb.Append("¿Cual es el Id de la que quiere retirar?");
                    this.messageChannel.SendMessage(sb.ToString());
                    int id = Convert.ToInt32(this.messageChannel.ReceiveMessage().Text);
                    Market.Instance.RemoveOffer(id);
                    this.messageChannel.SendMessage($"La oferta Oferta se retiro del mercado");
                    return true;
                }
                else 
                {
                    this.messageChannel.SendMessage("No hay ninguna oferta publicada bajo el nombre de esta empresa");
                }
            }
            return false;
        }
    }
}