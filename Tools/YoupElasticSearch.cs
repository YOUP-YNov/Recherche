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
                //Getting node
                string uri = System.IO.File.ReadAllText(@"elasticsearchUri.txt");

                //Saving Node
                var node = new Uri(uri);
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
