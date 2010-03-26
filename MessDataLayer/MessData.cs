using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagingDataDbLibrary;
using System.Collections;

namespace MessDataLayer
{
    public class MessData
    {
        #region enums
        public enum UsrState
        {
            aktivni,
            blokovany,
            neaktivni
        }

        public enum UsrStatus
        {
            online,
            offline,
            invisible
        }

        public enum MsgState
        {
            New,
            Old
        }
        #endregion

        /// <summary>
        /// Metoda vklada do DB noveho uzivatele s vychozim nastavenim
        /// </summary>
        /// <param name="nick">uzivatelske jmeno</param>
        /// <param name="password">heslo</param>
        /// <returns>identifikator prave pridaneho uzivatele</returns>
        public static int user_insertNewUser(string nick, string password)
        {
            int usr_id = 0;
            try
            {
                using (MessDataContext db = new MessDataContext())
                {
                    USER usr = new USER();
                    usr.C_USER = 0;
                    usr.C_DATE = DateTime.Now;
                    usr.USR_NICK = nick;
                    usr.USR_PASSWORD = password;
                    usr.USR_STATE = (int)UsrState.aktivni;
                    usr.USR_STATUS = (int)UsrStatus.offline;
                    db.USERs.InsertOnSubmit(usr);
                    db.SubmitChanges();

                    usr_id = db.USERs.Max(i => i.ID_USR);
                }
            }
            catch (Exception)
            {
                usr_id = 0;
            }
            return usr_id;
        }

        /// <summary>
        /// Vraci instanci objektu uzivatel pro dany nickname
        /// </summary>
        /// <param name="nick">uzivatelske jmeno</param>
        /// <returns></returns>
        public static USER user_getUser(string nick)
        {
            USER usr;
            try
            {
                using (MessDataContext db = new MessDataContext())
                {
                    usr = db.USERs.Where(i => i.USR_NICK.ToLower().Equals(nick.ToLower())).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
            return usr;
        }

        /// <summary>
        /// Vraci objekt uzivatele na zaklade jeho ID
        /// </summary>
        /// <param name="id_usr"></param>
        /// <returns></returns>
        public static USER user_getUser(int id_usr)
        {
            USER usr;
            try
            {
                using (MessDataContext db = new MessDataContext())
                {
                    usr = db.USERs.Where(i => i.ID_USR == id_usr).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
            return usr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_usr"></param>
        /// <param name="usr_status"></param>
        /// <returns></returns>
        public static bool user_SetStatus(int id_usr, UsrStatus usr_status)
        {
            try
            {
                using (MessDataContext db = new MessDataContext())
                {
                    USER usr = db.USERs.Where(i => i.ID_USR == id_usr).FirstOrDefault();
                    if (usr != null)
                    {
                        usr.USR_STATUS = (int)usr_status;
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static List<USER> contact_GetUserContacts(int id_usr)
        {
            try
            {
                using (MessDataContext db = new MessDataContext())
                {
                    var contacts = from i in db.CONTACTLISTs
                                   where i.USR_MAIN == id_usr
                                   join u in db.USERs on i.USR_CONTACT equals u.ID_USR
                                   select u;

                    return contacts.ToList<USER>();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<USER> contact_GetAllContacts()
        {
            try
            {
                using (MessDataContext db = new MessDataContext())
                {
                    return db.USERs.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<DlMessage> message_GetMessages(int id_usr)
        {
            try
            {
                using (MessDataContext db = new MessDataContext())
                {
                    var messages = from i in db.MESSTOUSRs
                                   where i.ID_USR == id_usr
                                   join m in db.MESSAGEs on i.ID_MESSAGE equals m.ID_MESSAGE
                                   select new
                                   {
                                       i.MSG_STATE,
                                       i.ID_SENDER,
                                       m.MSG_TYPE,
                                       m.MSG_BODY,
                                       m.C_DATE,
                                       m.ID_MESSAGE
                                   };
                    List<DlMessage> msg = new List<DlMessage>();
                    foreach (var mess in messages)
                    {
                        msg.Add(new DlMessage(mess.MSG_STATE, mess.ID_SENDER, mess.MSG_TYPE, mess.MSG_BODY, mess.C_DATE, mess.ID_MESSAGE));
                    }
                    return msg;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<DlMessage> message_GetNewMessages(int id_usr)
        {
            try
            {
                using (MessDataContext db = new MessDataContext())
                {
                    var messages = from i in db.MESSTOUSRs
                                   where i.ID_USR == id_usr && i.MSG_STATE == (int)MsgState.New
                                   join m in db.MESSAGEs on i.ID_MESSAGE equals m.ID_MESSAGE
                                   select new
                                   {
                                       i.MSG_STATE,
                                       i.ID_SENDER,
                                       m.MSG_TYPE,
                                       m.MSG_BODY,
                                       m.C_DATE,
                                       m.ID_MESSAGE
                                   };

                    List<DlMessage> msg = new List<DlMessage>();
                    foreach (var mess in messages)
                    {
                        msg.Add(new DlMessage(mess.MSG_STATE, mess.ID_SENDER, mess.MSG_TYPE, mess.MSG_BODY, mess.C_DATE, mess.ID_MESSAGE));
                    }
                    var messtousrs = from i in db.MESSTOUSRs
                                     where i.ID_USR == id_usr && i.MSG_STATE == (int)MsgState.New
                                     join m in db.MESSAGEs on i.ID_MESSAGE equals m.ID_MESSAGE
                                     select i;
                    foreach (var item in messtousrs)
                    {
                        item.MSG_STATE = (int)MsgState.Old;
                    }
                    db.SubmitChanges();
                    return msg;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool message_InsertMessage(int id_usr, string msg_body, int msg_type, int[] dest_users)
        {
            long id_message = 0;
            try
            {
                using (MessDataContext db = new MessDataContext())
                {
                    MESSAGE msg = new MESSAGE();
                    msg.MSG_TYPE = msg_type;
                    msg.MSG_BODY = msg_body;
                    msg.C_DATE = DateTime.Now;

                    db.MESSAGEs.InsertOnSubmit(msg);
                    db.SubmitChanges();
                    
                    id_message = db.MESSAGEs.Max(i => i.ID_MESSAGE);

                    foreach (var du in dest_users)
                    {
                        MESSTOUSR m2u = new MESSTOUSR();
                        m2u.MSG_STATE = (int)MsgState.New;
                        m2u.ID_MESSAGE = id_message;
                        m2u.ID_SENDER = id_usr;
                        m2u.ID_USR = du;

                        db.MESSTOUSRs.InsertOnSubmit(m2u);    
                    }
                    
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    #region DataItem Classes
    public class DlMessage
    {
        public int MSG_STATE { get; set; }
        public int ID_SENDER { get; set; }
        public int MSG_TYPE { get; set; }
        public long ID_MESSAGE { get; set; }
        public string MSG_BODY { get; set; }
        public DateTime C_DATE { get; set; }

        public DlMessage()
        {
        }

        public DlMessage(int _MSG_STATE, int _ID_SENDER, int _MSG_TYPE, string _MSG_BODY, DateTime _C_DATE, long _ID_MESSAGE)
        {
            MSG_BODY = _MSG_BODY;
            MSG_STATE = _MSG_STATE;
            MSG_TYPE = _MSG_TYPE;
            ID_SENDER = _ID_SENDER;
            C_DATE = _C_DATE;
            ID_MESSAGE = _ID_MESSAGE;
        }
    }
    #endregion
}
