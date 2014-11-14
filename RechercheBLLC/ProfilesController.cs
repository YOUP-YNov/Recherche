using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tools;
using RechercheDal;
using Nest;

namespace MvcApplication1.Controllers
{

    
    public class profilesController
    {

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

        public ISearchResponse<Profile> SimpleSearchProfile(string keyword, string from, string take)
        {
            // ¯\_(ツ)_/¯ PARSRTESTR !!
            IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<Profile>(s => s
            .From(ParsRtesR.Intfrom)
            .Size(ParsRtesR.Inttake)
            .Query(q => q
                .Term(p => p.Pseudo, keyword)

                )

            // Add OR LName - FName
            );

            return searchResults;
        }

        public ISearchResponse<Profile> AdvancedSearchProfile(string from, string take, string keyword, string age)
        {
            IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //Solution - Pas trop perf
            //Search per location TODO
            var searchResults = client.Search<Profile>(body => 
                body.Filter(filter =>
                    filter.Term(x =>
                        x.Age, age))
                    .Query(q => q
                        .Term(p => p.Firstname, keyword)  
                        )
            .From(ParsRtesR.Intfrom)
            .Take(ParsRtesR.Inttake));

            return searchResults;
        }

    }
}
