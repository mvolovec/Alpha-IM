using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MessagingDataDbLibrary;
using MessDataLayer;
using System.Collections;

namespace MyService1
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in Web.config and in the associated .svc file.
    public class MessagingService : IMessagingService
    {
        #region OLD IMessagingService Members

        //zde vytvářím LinqToSql objekt databáze zahrnující metody a objekty pro práci s databází
        //MessagingDbDataContext db = new MessagingDbDataContext();

        //public int ApiTest(int testNumber)
        //{
        //    return testNumber;
        //}

        //public int InsertMessage(Message messageItem)
        //{
        //    MessagingDataDbLibrary.Message dbMessage = new MessagingDataDbLibrary.Message();
        //    dbMessage.FromGuid = messageItem.FromId;
        //    dbMessage.FromNickName = db.LoggedUsers.Where(i => i.UserGuid == messageItem.FromId).Single().NickName;
        //    dbMessage.Sended = false;
        //    dbMessage.SendTime = DateTime.Now;
        //    dbMessage.ToGuid = messageItem.ToId;
        //    dbMessage.MessageBody = messageItem.MessageBody;
        //    db.Messages.InsertOnSubmit(dbMessage);
        //    db.SubmitChanges();
        //    return 0;
        //}

        //public List<Message> GetMessages(string userId)
        //{
        //    /* Vytvorime List (generickou kolekci) do niz 
        //     * ulozime vysledek naseho Linq dotazu a predame 
        //     * jako navratovou hodnotu metody
        //     */
        //    List<Message> messagesList = new List<Message>();
        //    var messages = from i in db.Messages
        //                   where i.ToGuid == userId && !i.Sended
        //                   select i;

        //    foreach (var m in messages)
        //    {
        //        Message mess = new Message();
        //        mess.FromId = m.FromGuid;
        //        mess.ToId = m.ToGuid;
        //        mess.MessageBody = m.MessageBody;
        //        mess.FromNickName = m.FromNickName;
        //        mess.SendTime = m.SendTime;
        //        messagesList.Add(mess);
        //        m.Sended = true;
        //    }
        //    db.SubmitChanges();
        //    return messagesList;

        //}

        //public string RegUser(string NickName)
        //{
        //    string UserGuid = Guid.NewGuid().ToString();
        //    MessagingDataDbLibrary.LoggedUser lUser = new MessagingDataDbLibrary.LoggedUser();
        //    lUser.NickName = NickName;
        //    lUser.UserGuid = UserGuid;
        //    db.LoggedUsers.InsertOnSubmit(lUser);
        //    db.SubmitChanges();

        //    return UserGuid;
        //}

        //public List<LoggedUser> GetLoggedUsers()
        //{
        //    List<LoggedUser> lUserList = new List<LoggedUser>();
        //    var loggedUser = from i in db.LoggedUsers
        //                     select i;
        //    foreach (var lu in loggedUser)
        //    {
        //        LoggedUser lUser = new LoggedUser();
        //        lUser.NickName = lu.NickName;
        //        lUser.UserGuid = lu.UserGuid;
        //        lUserList.Add(lUser);
        //    }
        //    return lUserList;
        //}

        //public void LogoutUser(string userId)
        //{
            
        //    db.LoggedUsers.DeleteOnSubmit(db.LoggedUsers.Where(i => i.UserGuid == userId).Single());
        //    db.SubmitChanges();
        //}

        #endregion

        #region IMessagingService Members

        public int User_RegisterNewContact(string nick, string password)
        {
            return MessData.user_insertNewUser(nick, password);
        }

        public bool User_Validate(int id_usr, string password)
        {
            USER usr = MessData.user_getUser(id_usr);
            if (usr != null && usr.USR_PASSWORD.Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool User_Login(int id_usr, string password)
        {
            if (User_Validate(id_usr, password))
            {
                return MessData.user_SetStatus(id_usr, MessData.UsrStatus.online);
            }
            return false;
        }

        public bool User_Logout(int id_usr, string password)
        {
            if (User_Validate(id_usr, password))
            {
                return MessData.user_SetStatus(id_usr, MessData.UsrStatus.offline);
            }
            return false;
        }

        public List<ImUser> Contact_GetMyContacts(int id_usr, string password)
        {
            List<ImUser> contacts = new List<ImUser>();
            if (User_Validate(id_usr, password))
            {
                List<USER> contacts_tmp = MessData.contact_GetUserContacts(id_usr);
                foreach (USER usr in contacts_tmp)
                {
                    ImUser iusr = new ImUser();
                    iusr.ID_USR = usr.ID_USR;
                    iusr.USR_NICK = usr.USR_NICK;
                    iusr.USR_STATUS = usr.USR_STATUS;
                    contacts.Add(iusr);
                }
            }
            return contacts;
        }

        public List<ImUser> Contact_GetAllContacts()
        {
            List<ImUser> contacts = new List<ImUser>();
            List<USER> contacts_tmp = MessData.contact_GetAllContacts();
            foreach (USER usr in contacts_tmp)
            {
                ImUser iusr = new ImUser();
                iusr.ID_USR = usr.ID_USR;
                iusr.USR_NICK = usr.USR_NICK;
                iusr.USR_STATUS = usr.USR_STATUS;
                contacts.Add(iusr);
            }
            return contacts;
        }

        public List<ImMessage> Message_GetMyMessages(int id_usr, string password)
        {
            if (User_Validate(id_usr, password))
            {
                List<ImMessage> messages = new List<ImMessage>();
                List<DlMessage> DlMessages = MessData.message_GetMessages(id_usr);
                foreach (var msg in DlMessages)
                {
                    ImMessage imsg = new ImMessage();
                    imsg.C_DATE = msg.C_DATE;
                    imsg.ID_SENDER = msg.ID_SENDER;
                    imsg.ID_USR = id_usr;
                    imsg.MSG_BODY = msg.MSG_BODY;
                    imsg.ID_MESSAGE = msg.ID_MESSAGE;
                    imsg.MSG_TYPE = msg.MSG_TYPE;
                    messages.Add(imsg);
                }
                return messages;
            }
            return null;
        }

        public List<ImMessage> Message_GetMyNewMessages(int id_usr, string password)
        {
            if (User_Validate(id_usr, password))
            {
                List<ImMessage> messages = new List<ImMessage>();
                List<DlMessage> DlMessages = MessData.message_GetNewMessages(id_usr);
                foreach (var msg in DlMessages)
                {
                    ImMessage imsg = new ImMessage();
                    imsg.C_DATE = msg.C_DATE;
                    imsg.ID_SENDER = msg.ID_SENDER;
                    imsg.ID_USR = id_usr;
                    imsg.MSG_BODY = msg.MSG_BODY;
                    imsg.ID_MESSAGE = msg.ID_MESSAGE;
                    imsg.MSG_TYPE = msg.MSG_TYPE;
                    messages.Add(imsg);
                }
                return messages;
            }
            return null;
        }

        /// <summary>
        /// Metoda vklada do systemu novou nedorucenou zpravu pro daneho adresata
        /// </summary>
        /// <param name="id_usr">jmeno</param>
        /// <param name="password">heslo</param>
        /// <param name="msg_body">obsah zpravy</param>
        /// <param name="msg_type">typ zpravy</param>
        /// <param name="dest_user">pole int[] adresatu zpravy</param>
        /// <returns></returns>
        public bool Message_InsertMessageForUser(int id_usr, string password, string msg_body, int msg_type, int[] dest_user)
        {
            if (User_Validate(id_usr, password))
            {
                return MessData.message_InsertMessage(id_usr, msg_body, msg_type, dest_user);
            }
            return false;
        }

        #endregion
    }
}


















