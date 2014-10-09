using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbizServer
{
    static class SbizServerModel
    {
        static SbizSocket sbiz_socket = new SbizSocket();
        public static void Run(){
            sbiz_socket.SetUpConnection();
        }
 
    }
}
