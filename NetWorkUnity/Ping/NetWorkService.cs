using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetWorkUnity.Ping
{
    public class NetWorkService
    {
        public string SendPing()
        {
            return "Success : Ping Sent !";
        }
        public int PingTimeOut(int a , int b)
        {
            return a + b;
        }
        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }
        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl=1
            };

        }
        public IEnumerable<PingOptions> GetRecentPings()
        {
            IEnumerable<PingOptions> pings = new[]
            {
            new PingOptions()
            {
                DontFragment = true,
                Ttl=1
            },
            new PingOptions()
            {
                DontFragment = true,
                Ttl=1
            },
            new PingOptions()
            {
                DontFragment = true,
                Ttl=1
            } 
            
           };
            return pings;
        }

        }
         
        }

    

