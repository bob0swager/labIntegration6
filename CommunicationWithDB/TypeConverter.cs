using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using YamlDotNet.Serialization;

namespace CommunicationWithDB
{
    class TypeConverter
    {
        static public string returnJSON(string xml)
        {
            string clearXML = null;
                clearXML = xml.Substring(22, xml.Length - 22);  
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(clearXML);
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            return json;
        }

        static public string returnYAML(string xml, List<String> fields = null)
        {
            if (fields == null)
                fields = new List<String>();
            string n = xml.Substring(22, xml.Length - 22);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(n);
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            string b = json.Substring(23, json.Length - 23 - 2);
            string completecYaml = null;
            try
            {
                var startupObj = JsonConvert.DeserializeObject<Startup>(b);
                completecYaml = "---\nstartups:\n\tstartup:\n";
                if (fields.Count == 0)
                    completecYaml += fillStartupObjectYaml(startupObj);
                else
                    completecYaml += fillStartupObjectYamlSpec(startupObj, fields);

            }
            catch(Exception ex)
            {
                int c = 0;
                var startupsObjs = JsonConvert.DeserializeObject<List<Startup>>(b);
                foreach(var startupObj in startupsObjs)
                {
                    if (c == 0)
                        completecYaml = "---\nstartups:\n\tstartup:\n";
                    else
                    {
                        completecYaml += "\n\tstartup:\n";
                    }
                    if (fields.Count ==0)
                        completecYaml += fillStartupObjectYaml(startupObj);
                    else
                        completecYaml += fillStartupObjectYamlSpec(startupObj, fields);
                    c++;
                }
               
            } 
            return completecYaml;
        }
        static public string returnOGDL(string xml, List<String> fields = null)
        {
            if (fields == null)
                fields = new List<String>();
            string completedOgdl = null;
            string n = xml.Substring(22, xml.Length - 22);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(n);
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            string b = json.Substring(23, json.Length - 23 - 2);
            string s = null;
            try
            {
                var startupObj = JsonConvert.DeserializeObject<Startup>(b);
                completedOgdl = "startups\n\tstartup\n";
                if (fields.Count==0)
                    completedOgdl += fillStartupObjectOgdl(startupObj);
                else
                    completedOgdl += fillStartupObjectOgdlSpec(startupObj, fields);
            }
            catch(Exception ex)
            {
                int c = 0;
                var startupsObjs = JsonConvert.DeserializeObject<List<Startup>>(b);
                foreach (var startupObj in startupsObjs)
                {
                    if (c == 0)
                        completedOgdl = "startups\n\tstartup\n";
                    else
                    {
                        completedOgdl += "\n\tstartup\n";
                    }
                    if (fields.Count == 0)
                        completedOgdl += fillStartupObjectOgdl(startupObj);
                    else
                        completedOgdl += fillStartupObjectOgdlSpec(startupObj, fields);
                    c++;
                }
            }
            return completedOgdl;
        }

            static public string returnXMLDesign(string xml)
        {
            string xmlDesign = xml.Insert(22, "<?xml-stylesheet type='text/css' href='style1.css'?>");     
            return xmlDesign;
        }

        static public string fillStartupObjectYaml(Startup startup)
        {
            string ret = null;
            ret = "\t\tId: " + startup.Id +"\n";
            ret += "\t\tName: " + startup.Name +"\n";
            ret += "\t\tImageUrl: " + startup.ImageUrl + "\n";
            ret += "\t\tStartupLink: " + startup.StartupLink + "\n";
            ret += "\t\tDescriptionStartup: " + startup.DescriptionStartup + "\n";
            ret += "\t\tLink: " + startup.Link + "\n";
            ret += "\t\tTwitterLink: " + startup.TwitterLink + "\n";
            ret += "\t\tGithubLink: " + startup.GithubLink + "\n";
            ret += "\t\tFacebookLink: " + startup.FacebookLink + "\n";
            ret += "\t\tLinkedinLink: " + startup.LinkedinLink + "\n";
            ret += "\t\tAngelLink: " + startup.AngelLink + "\n";
            ret += "\t\tDescriptionProduct: " + startup.DescriptionProduct + "\n";
            ret += "\t\tLinkVideo: " + startup.LinkVideo + "\n";
            ret += "\t\tFounder: " + startup.Founder + "\n";
            ret += "\t\tLocation: " + startup.Location;

            return ret;
    }
        static public string fillStartupObjectYamlSpec(Startup startup, List<String> fields)
        {
            string ret = null;
           if(fields.Contains("Id"))
                ret = "\t\tId: " + startup.Id + "\n";      
          if (fields.Contains("Name"))
                ret += "\t\tName: " + startup.Name + "\n";
             if (fields.Contains("ImageUrl"))
                ret += "\t\tImageUrl: " + startup.ImageUrl + "\n";
             if (fields.Contains("StartupLink"))
                ret += "\t\tStartupLink: " + startup.StartupLink + "\n";
            if (fields.Contains("DescriptionStartup"))
                ret += "\t\tDescriptionStartup: " + startup.DescriptionStartup + "\n";
             if (fields.Contains("Link"))
                ret += "\t\tLink: " + startup.Link + "\n";
           if (fields.Contains("TwitterLink"))
                ret += "\t\tTwitterLink: " + startup.TwitterLink + "\n";
             if (fields.Contains("GithubLink"))
                ret += "\t\tGithubLink: " + startup.GithubLink + "\n";
         if (fields.Contains("FacebookLink"))
                ret += "\t\tFacebookLink: " + startup.FacebookLink + "\n";
            if (fields.Contains("LinkedinLink"))
                ret += "\t\tLinkedinLink: " + startup.LinkedinLink + "\n";
            if (fields.Contains("AngelLink"))
                ret += "\t\tAngelLink: " + startup.AngelLink + "\n";
            if (fields.Contains("DescriptionProduct"))
                ret += "\t\tDescriptionProduct: " + startup.DescriptionProduct + "\n";
            if (fields.Contains("LinkVideo"))
                ret += "\t\tLinkVideo: " + startup.LinkVideo + "\n";
            if (fields.Contains("Founder"))
                ret += "\t\tFounder: " + startup.Founder + "\n";
           if (fields.Contains("Location"))
                ret += "\t\tLocation: " + startup.Location;
            return ret;
        }

        static public string fillStartupObjectOgdl(Startup startup)
        {
            string ret = null;
            ret = "\t\tId\n" + "\t\t\t" + startup.Id + "\n";
            ret += "\t\tName\n" + "\t\t\t" + startup.Name + "\n";
            ret += "\t\tImageUrl\n" + "\t\t\t" + startup.ImageUrl + "\n";
            ret += "\t\tStartupLink\n" + "\t\t\t" + startup.StartupLink + "\n";
            ret += "\t\tDescriptionStartup\n" + "\t\t\t" + startup.DescriptionStartup + "\n";
            ret += "\t\tLink\n" + "\t\t\t" + startup.Link + "\n";
            ret += "\t\tTwitterLink\n" + "\t\t\t" + startup.TwitterLink + "\n";
            ret += "\t\tGithubLink\n" + "\t\t\t" + startup.GithubLink + "\n";
            ret += "\t\tFacebookLink\n" + "\t\t\t" + startup.FacebookLink + "\n";
            ret += "\t\tLinkedinLink\n" + "\t\t\t" + startup.LinkedinLink + "\n";
            ret += "\t\tAngelLink\n" + "\t\t\t" + startup.AngelLink + "\n";
            ret += "\t\tDescriptionProduct\n" + "\t\t\t" + startup.DescriptionProduct + "\n";
            ret += "\t\tLinkVideo\n" + "\t\t\t" + startup.LinkVideo + "\n";
            ret += "\t\tFounder\n" + "\t\t\t" + startup.Founder + "\n";
            ret += "\t\tLocation\n" + "\t\t\t" + startup.Location;

            return ret;
        }
        static public string fillStartupObjectOgdlSpec(Startup startup, List<String> fields)
        {
            string ret = null;
            if (fields.Contains("Id"))
                ret = "\t\tId\n" + "\t\t\t" + startup.Id + "\n";
            if (fields.Contains("Name"))
                ret += "\t\tName\n" + "\t\t\t" + startup.Name + "\n";
            if (fields.Contains("ImageUrl"))
                ret += "\t\tImageUrl\n" + "\t\t\t" + startup.ImageUrl + "\n";
             if (fields.Contains("Link"))
                ret += "\t\tLink\n" + "\t\t\t" + startup.Link + "\n";
            if (fields.Contains("StartupLink"))
                ret += "\t\tStartupLink\n" + "\t\t\t" + startup.StartupLink + "\n";
            if (fields.Contains("DescriptionStartup"))
                ret += "\t\tDescriptionStartup\n" + "\t\t\t" + startup.DescriptionStartup + "\n";        
            if (fields.Contains("TwitterLink"))
                ret += "\t\tTwitterLink\n" + "\t\t\t" + startup.TwitterLink + "\n";
            if (fields.Contains("GithubLink"))
                ret += "\t\tGithubLink\n" + "\t\t\t" + startup.GithubLink + "\n";
            if (fields.Contains("FacebookLink"))
                ret += "\t\tFacebookLink\n" + "\t\t\t" + startup.FacebookLink + "\n";
            if (fields.Contains("LinkedinLink"))
                ret += "\t\tLinkedinLink\n" + "\t\t\t" + startup.LinkedinLink + "\n";
            if (fields.Contains("AngelLink"))
                ret += "\t\tAngelLink\n" + "\t\t\t" + startup.AngelLink + "\n";
            if (fields.Contains("DescriptionProduct"))
                ret += "\t\tDescriptionProduct\n" + "\t\t\t" + startup.DescriptionProduct + "\n";
            if (fields.Contains("LinkVideo"))
                ret += "\t\tLinkVideo\n" + "\t\t\t" + startup.LinkVideo + "\n";
            if (fields.Contains("Founder"))
                ret += "\t\tFounder\n" + "\t\t\t" + startup.Founder + "\n";
            if (fields.Contains("Location"))
                ret += "\t\tLocation\n" + "\t\t\t" + startup.Location;

            return ret;
        }
    }
}
