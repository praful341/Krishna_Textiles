using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BeginTranConnection
    {
        public InterfaceLayer Inter1 = new InterfaceLayer();
        public InterfaceLayer Inter2 = new InterfaceLayer();

        public BeginTranConnection(Boolean IsConn, Boolean IsDeveloperConn)
        {
            if (IsConn)
            {
                Inter1.BeginTransaction(BLL.DBConnections.ConnectionString);
            }
        }

        public BeginTranConnection(Boolean IsConn, Boolean IsDeveloperConn,Boolean IsIL)
        {
            if (IsConn)
            {
                Inter1.BeginTransaction(BLL.DBConnections.ConnectionString);
            }

            if (IsDeveloperConn)
            {
                Inter2.BeginTransaction(BLL.DBConnections.ConnectionDeveloper);
            }
        }

    }
}
