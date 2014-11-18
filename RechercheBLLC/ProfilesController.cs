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

        public void UpdateProfile(Profile newprofile)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var response = client.Update<Profile, Profile>(u => u
                .Index("youp")
                .Id(newprofile.Id)
                .Doc(newprofile)
             );
        }

        public ISearchResponse<Profile> SimpleSearchProfile(string keyword, int from, int take)
        {
            // ¯\_(ツ)_/¯ PARSRTESTR !!
           // IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<Profile>(s => s
            .From(from)
            .Size(take)
            .Query(q => 
                q.QueryString(qs => qs
                .OnFields(p => p.Firstname, p => p.Lastname, p => p.Firstname)
                .Query(keyword)
                )))

            // Add OR LName - FName
            ;

            return searchResults;
        }

        public ISearchResponse<Profile> AdvancedSearchProfile(string from, string take, string keyword, string age, string town)
        {
            IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            var searchResults = client.Search<Profile>(body => 
                body.Filter(filter =>
                    filter.Term(x =>
                        x.Age, Int32.Parse(age))
                    && filter.Term(x =>
                        x.Town, town))
                    .Query(q =>
                        q.QueryString(qs => qs
                        .OnFields(p => p.Firstname, p => p.Lastname, p => p.Firstname)
                        .Query(keyword)
                        ))
            .From(ParsRtesR.Intfrom)
            .Take(ParsRtesR.Inttake));

            return searchResults;
        }

    }
}
