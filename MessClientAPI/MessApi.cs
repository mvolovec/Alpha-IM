using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessClientAPI.MessServiceApi;

namespace MessClientAPI
{
    public class MessApi
    {
        

        /// <summary>
        /// Registrace noveho uzivatele do systemu
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int User_RegisterNewContact(string nick, string password)
        {
            try
            {
                using (MessagingServiceClient api = new MessagingServiceClient())
                {
                    return api.User_RegisterNewContact(nick, password);
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// Overeni spravnosti zdali jmeno souhlasi s heslem
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool User_Validate(int id_usr, string password)
        {
            try
            {
                using (MessagingServiceClient api = new MessagingServiceClient())
                {
                    return api.User_Validate(id_usr, password);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Prihlaseni do systemu
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool User_Login(int id_usr, string password)
        {
            try
            {
                using (MessagingServiceClient api = new MessagingServiceClient())
                {
                    if (api.User_Validate(id_usr, password))
                    {
                        return api.User_Login(id_usr, password);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Odhlaseni ze systemu
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool User_Logout(int id_usr, string password)
        {
            try
            {
                using (MessagingServiceClient api = new MessagingServiceClient())
                {
                    if (api.User_Validate(id_usr, password))
                    {
                        return api.User_Logout(id_usr, password);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Vrati osobni kontakty daneho uzivatele
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static List<ImUser> Contact_GetMyContacts(int id_usr, string password)
        {
            try
            {
                using (MessagingServiceClient api = new MessagingServiceClient())
                {
                    if (api.User_Validate(id_usr, password))
                    {
                        List<ImUser> users = new List<ImUser>(api.Contact_GetMyContacts(id_usr, password).ToList());
                        return users;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Vrati vsechny kontakty systemu
        /// </summary>
        /// <returns></returns>
        public static List<ImUser> Contact_GetAllContacts()
        {
            try
            {
                using (MessagingServiceClient api = new MessagingServiceClient())
                {
                    List<ImUser> users = new List<ImUser>(api.Contact_GetAllContacts().ToList());
                    api.Close();
                    return users;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Vraci objekt uzivatele dle jeho ID
        /// </summary>
        /// <param name="id_usr"></param>
        /// <returns></returns>
        public static ImUser Contact_GetContactById(int id_usr)
        {
            try
            {
                using (MessagingServiceClient api = new MessagingServiceClient())
                {
                    ImUser user = api.Contact_GetAllContacts().Where(c => c.ID_USR.Equals(id_usr)).FirstOrDefault();
                    api.Close();
                    return user;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Vrati vsechny uzivatelske zpravy
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static List<ImMessage> Message_GetMyMessages(int id_usr, string password)
        {
            try
            {
                using (MessagingServiceClient api = new MessagingServiceClient())
                {
                    if (api.User_Validate(id_usr, password))
                    {
                        List<ImMessage> messages = new List<ImMessage>(api.Message_GetMyMessages(id_usr, password));
                        return messages;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Vrati vsechny nove uzivatelske zpravy
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static List<ImMessage> Message_GetMyNewMessages(int id_usr, string password)
        {
            try
            {
                using (MessagingServiceClient api = new MessagingServiceClient())
                {
                    if (api.User_Validate(id_usr, password))
                    {
                        List<ImMessage> messages = new List<ImMessage>(api.Message_GetMyNewMessages(id_usr, password));
                        return messages;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Odeslani(vlozeni) zpravy do systemu
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="password"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool Message_InsertMessageForUser(int id_usr, string password, string msg_body, int msg_type, int[] dest_users)
        {
            try
            {
                using (MessagingServiceClient api = new MessagingServiceClient())
                {
                    if (api.User_Validate(id_usr, password))
                    {
                        return api.Message_InsertMessageForUser(id_usr, password, msg_body, msg_type, dest_users);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
