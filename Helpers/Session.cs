using EZBank.Helpers;
using EZBank.Interfaces;

namespace EZBank.Classes
{
    public class Session
    {
        //There will probably be only one implementation of a session, so creating an Interface is unnecessary
        //Well just keep it as a helper class to aid with data-transfer
         
        public string userName { get; }

        public string password { get; }


        public string dataBase = Constants.dbName; //TODO Remove Hardcode

        public string serverName { get; }

        public Session(string SQLServer, string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            this.serverName = SQLServer;
        }
    }
}
