using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace Tools
{
        public static class YoupElasticSearch
        {
            //Method InitializeConnection : Explicit
            public static ElasticClient InitializeConnection()
            {
                //Saving Node
                var node = new Uri("http://martinleguillou.fr:1194/");
                //Saving Settings
                var settings = new ConnectionSettings(
                    node,
                    defaultIndex: "youp"
                );
                //Starting Client
                var client = new ElasticClient(settings);
                return client;
            }
        }
}
