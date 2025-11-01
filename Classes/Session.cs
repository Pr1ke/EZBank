using EZBank.Helpers;
using EZBank.Interfaces;

namespace EZBank.Classes
{
    internal class Session : ISession
    {
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
