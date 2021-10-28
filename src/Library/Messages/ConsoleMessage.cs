using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa los mensajes.
    /// </summary>
    public class ConsoleMessage : IMessage
    {
        private string id;
        /// <summary>
        /// Devuelve el Id
        /// </summary>
        /// <value></value>
        public string Id{get;}
        private string text;
        /// <summary>
        /// Devuelve el Message
        /// </summary>
        /// <value></value>
        public string Text{
            get
            {
                return this.text;
            }
            }
        /// <summary>
        /// Constructor de ConsoleMessage
        /// </summary>
        /// <param name="mensaje"></param>
        public ConsoleMessage(string mensaje)
        {
            this.text = mensaje;
            this.id = "0";
        }
    }
}