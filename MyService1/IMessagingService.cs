using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MessagingDataDbLibrary;

namespace MyService1
{
    [ServiceContract]
    public interface IMessagingService
    {
        /// <summary>
        /// Registrace noveho uzivatele
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        int User_RegisterNewContact(string nick, string password);

        /// <summary>
        /// Overeni uzivatele
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        bool User_Validate(int id_usr, string password);

        /// <summary>
        /// Prihlaseni uzivatele
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        bool User_Login(int id_usr, string password);

        /// <summary>
        /// Odhlaseni uzivatele
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        bool User_Logout(int id_usr, string password);

        /// <summary>
        /// Ziskani osobnich kontaktu daneho uzivatele
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        List<ImUser> Contact_GetMyContacts(int id_usr, string password);

        /// <summary>
        /// Ziskani vsech kontaktu v systemu
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<ImUser> Contact_GetAllContacts();

        /// <summary>
        /// Metoda vraci vsechny uzivatelovy zpravy
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        List<ImMessage> Message_GetMyMessages(int id_usr, string password);

        /// <summary>
        /// Metoda vraci pouze nove neprectene (nedorucene) zpravy
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        List<ImMessage> Message_GetMyNewMessages(int id_usr, string password);

        /// <summary>
        /// Odeslani nove zpravy pro uzivatele
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        [OperationContract]
        bool Message_InsertMessageForUser(int id_usr, string password, string msg_body, int msg_type, int[] dest_user);

    }

    [DataContract]
    public class ImUser
    {
        [DataMember]
        public string USR_NICK { get; set; }
        [DataMember]
        public int ID_USR { get; set; }
        [DataMember]
        public string USR_FIRSTNAME { get; set; }
        [DataMember]
        public string USR_LASTNAME { get; set; }
        [DataMember]
        public int USR_STATUS { get; set; }
    }

    [DataContract]
    public class ImMessage
    {
        [DataMember]
        public int ID_SENDER { get; set; }
        [DataMember]
        public int ID_USR { get; set; }
        [DataMember]
        public long ID_MESSAGE { get; set; }
        [DataMember]
        public string MSG_BODY { get; set; }
        [DataMember]
        public int MSG_TYPE { get; set; }
        [DataMember]
        public DateTime C_DATE { get; set; }
    }

}
