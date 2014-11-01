using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using MvcApplication1;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Tools
{
    class MigrationScript
    {
        static void Main(string[] args)
        {
            ElasticClient elastic = YoupElasticSearch.InitializeConnection();
            using (var context = new YoupDEVEntities())
            {
                var test = context.BLOG_Blog.SqlQuery("Select * from BLOG_Blog").ToList<BLOG_Blog>();

                foreach (var blog in test)
                {
                    Console.WriteLine(blog.TitreBlog);
                }
                Console.ReadLine();
            }
        }
    }
}
