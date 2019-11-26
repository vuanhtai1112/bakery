using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BakeryWindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            int PORT = 8080;
            //đăng ký port
            ChannelServices.RegisterChannel(new TcpChannel(PORT), false);
            //đăng ký Remoting, host lớp WarehouseBLL với tên là Warehouse
            //-------/
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(BLL), "Bakery", WellKnownObjectMode.SingleCall);
        }

        protected override void OnStop()
        {
        }
    }
}
