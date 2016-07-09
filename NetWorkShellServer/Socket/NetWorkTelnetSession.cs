using System;
using System.Threading.Tasks;
using SuperSocket.SocketBase;

using NetWorkShellServer.CommandFactory;

namespace NetWorkShellServer.Socket
{

    /// <summary>
    /// this Network client session which from AppSession 
    /// this session's IrequestInfo is stringRequestInfo
    /// </summary>
    public class NetWorkTelnetSession:AppSession<NetWorkTelnetSession>
    {
        /// <summary>
        /// the client id
        /// </summary>
        public string ClientId = string.Empty;

        /// <summary>
        /// the client password
        /// </summary>
        public string ClientPassword = string.Empty;


        /// <summary>
        /// auth method
        /// </summary>
        public Func<string, string, bool> AuthMethodFuc = null;


        /// <summary>
        /// the seesion will call a method to analysis the network
        /// </summary>
        public ICommandMethod CommandMethod = null;

        /// <summary>
        /// the Command method factory will set the command method according to the Command 
        /// </summary>
        public ICommandMethodFactory CommandMethodFactory = null;

        /// <summary>
        /// Network telnet session
        /// </summary>
        public NetWorkTelnetSession():base(false)
        {                        
        }


        /// <summary>
        /// AuthenticationTask for authentication for client
        /// </summary>
        /// <param name="authMethodTask">the method for authentitication</param>
        /// <param name="clientId">session's id</param>
        /// <param name="passWord">session's password</param>
        /// <returns>if password's passed return true , else retrun false</returns>
        public async Task<bool> AuthenticationTask(Func<string,string,bool> authMethodTask,string clientId, string passWord)
        {
            return await Task.Run(() => authMethodTask != null && authMethodTask(clientId, passWord));
        }

        /// <summary>
        /// set client id from client send data
        /// </summary>
        /// <param name="clientId"></param>
        public void SetClientId(string clientId)
        {
            ClientId = clientId;
        }

        /// <summary>
        /// set password from client send data
        /// </summary>
        /// <param name="password"></param>
        public void SetPassword(string password)
        {
            ClientPassword = password;
        }

        /// <summary>
        /// set auth methond for verify client password
        /// </summary>
        /// <param name="authFunc">auth method</param>
        public void SetAuthMethodFuc(Func<string, string, bool> authFunc)
        {
            AuthMethodFuc = authFunc;
        }



        /// <summary>
        /// override the method when session is started
        /// </summary>
        protected override void OnSessionStarted()
        {
            this.Send("this session is start");
            //do it
            base.OnSessionStarted();
        }

        /// <summary>
        /// override the method when session is closed
        /// </summary>
        /// <param name="reason">close's reason</param>
        protected override void OnSessionClosed(CloseReason reason)
        {
            this.Send("this session is closed");
            //do it
            base.OnSessionClosed(reason);
        }

        /// <summary>
        /// set the command method
        /// </summary>
        /// <param name="cmMethod"></param>
        public void SetCommandMethod(ICommandMethod cmMethod )
        {
            CommandMethod = cmMethod;
        }


        /// <summary>
        /// set the command method factory
        /// </summary>
        /// <param name="cmMethodFactory"></param>
        public void SetCommandMethodFactory(ICommandMethodFactory cmMethodFactory)
        {
            CommandMethodFactory = cmMethodFactory;
        }






    }
}