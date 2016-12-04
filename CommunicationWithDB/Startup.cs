using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationWithDB
{
  
        public class Startup
        {
            [BsonId]
            public int Id { get; set; }
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public string StartupLink { get; set; }
            public string DescriptionStartup { get; set; }
            public string Link { get; set; }
            public string TwitterLink { get; set; }
            public string GithubLink { get; set; }
            public string FacebookLink { get; set; }
            public string LinkedinLink { get; set; }
            public string AngelLink { get; set; }
            public string DescriptionProduct { get; set; }
            public string LinkVideo { get; set; }
            public string Founder { get; set; }
            public string Location { get; set; }
        }
    

}
