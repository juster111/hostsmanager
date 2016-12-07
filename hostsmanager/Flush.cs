using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace hostsmanager
{
    public class Flush
    {
        public Flush() { }

        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCache")]
        private static extern UInt32 DnsFlushResolverCache();

        public static void FlushMyCache() 
        {
            try
            {
                UInt32 result = DnsFlushResolverCache();
                 
              
            }
            catch { }

        }

    }
}
