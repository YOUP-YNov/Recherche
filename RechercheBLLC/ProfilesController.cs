using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tools;
using RechercheDal;
using Nest;
using System.Web;

namespace MvcApplication1.Controllers
{

    
    public class ProfilesController
    {
        //
        // GET: /Profiles/

        public void AddProfile(Profile profile)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(profile);
        }

        public void RemoveProfile(Profile profile)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<Profile>(profile.Id);
        }

        public void UpdateProfile(Profile oldprofile, Profile newprofile)
        {
            AddProfile(newprofile);
            RemoveProfile(oldprofile);
        }

        public IEnumerable<Profile> GetSimpleSearchProfile(string from, string take, string keyword)
        {
            int Intfrom, Inttake;

            //Test parameters FROM & SET if null
            if (from == null) { Intfrom = 0; }
            //Else GET parameter From
            else { Intfrom = Int32.Parse(from); }
            //Test parameters TAKE & SET if null
            if ((take == null) || (Int32.Parse(take) == 0)) { Inttake = 20; }
            //Else GET parameters From && TAKE from URL
            else { Inttake = Int32.Parse(take); }

            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<Profile>(s => s
            .Query(q => q
                .Term(p => p.Firstname, keyword)
                )
                .From(Intfrom)
                .Take(Inttake)

            // Add OR LName - FName
            );

            return searchResults.Documents;
        }

        public IEnumerable<Profile> GetAdvancedSearchProfile(string from, string take, string keyword, string age)
        {
            int Intfrom, Inttake;

            //Test parameters FROM & SET if null
            if (from == null) { Intfrom = 0; }
            //Else GET parameter From
            else { Intfrom = Int32.Parse(from); }
            //Test parameters TAKE & SET if null
            if ((take == null) || (Int32.Parse(take) == 0)) { Inttake = 20; }
            //Else GET parameters From && TAKE from URL
            else { Inttake = Int32.Parse(take); }

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            // Solution - Pas trop perf
            //Search per location
            var searchResults = client.Search<Profile>(body => 
                body.Filter(filter =>
                    filter.Term(x =>
                        x.Age, age))
                    .Query(q => q
                        .Term(p => p.Firstname, keyword)  
                        )
            .Take(100));

            /*
            //recherche avancée if all parameters != null
            var searchResults = client.Search<Profile>(body =>
                body.Query(query =>
                    query.ConstantScore(csq =>
                        csq.Filter(filter =>
                                filter.Term(x =>
                                    x.Lastname, nvc["lastname"]))
                            .Filter(filter =>
                                filter.Term(x =>
                                    x.Firstname, nvc["firstname"]))
                            .Filter(filter =>
                                filter.Term(x =>
                                    x.Age, nvc["age"]))
                           .Query(q =>
                                q.Term(p => p.Firstname, nvc["keyword"]))))
                .Take(take)
                .From(from));
            */

            return searchResults.Documents;
        }

    }
}
