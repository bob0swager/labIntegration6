using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Core;
using MongoDB.Driver.Core.Bindings;
using MongoDB.Driver.Core.Operations;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Xml;
using System.Xml.Linq;


namespace CommunicationWithDB
{

    class Connection
    {
       static string connectionString = "https://swagerapp.herokuapp.com";
       static WebClient client = new WebClient();
        static public void getAll(object type)
        {
            string url = @"/startups/all";
            writeData(url, type);
        }

        
            static public void getSpecFields(string flds, object type)
        {
            List<String> fields = flds.Split(' ').ToList();
            string url = @"/startups/getFields/" + flds;
            writeData(url, type, fields);
        }

        static public void getByIds(string ids, object type)
        {
            string url = @"/startups/ids/" + ids;
            writeData(url, type);
        }

        static public void getNameAndLink(object type)
        {
            List<String> fields = new List<String>(new string[] { "Name", "StartupLink" });           
            string url = @"/startups/nameAndLink/all";
            writeData(url, type, fields);
        }

        

        static public void getNameAndLinkById(string id, object type)
        {   
            List<String> fields = new List<String>(new string[] { "Name", "StartupLink" });
            string url =  @"/startups/nameAndLink/"+id;
            writeData(url, type, fields);
        }
        

        static public void getTop5(object type)
        {       
            string url = @"/startups/top5";
            writeData(url, type);
        }

        static public void getNewest(object type)
        {
           
            string url = @"/startups/getNewest";
            writeData(url, type);
        }

        static public void getOldest(object type)
        {

            string url = @"/startups/getOldest";
            writeData(url, type);
        }
        static public void getById(string id, object type)
        {

            string url = @"/startups/"+id;
            writeData(url, type);

        }

        static public void getByLocation(string location, object type)
        { 

           string url = @"/startups/location/"+ location;
            writeData(url, type);
        }

        static public void writeData(string url, object type, List<String> fields= null)
        {
            string retFile = null;
            bool isDesign = false;
            String xml = client.DownloadString(connectionString + url);
            switch (type.ToString())
            {
                case "XML":
                    retFile = xml;
                    break;
                case "JSON":
                    retFile = TypeConverter.returnJSON(xml);
                    break;
                case "YAML":
                    retFile = TypeConverter.returnYAML(xml, fields);
                    break;
                case "OGDL":
                    retFile = TypeConverter.returnOGDL(xml, fields);
                    break;
                case "XML with style":
                    retFile = TypeConverter.returnXMLDesign(xml);
                    isDesign = true;
                    type = "XML";
                    break;
                default:
                    retFile = xml;
                    break;
            }
            writeToFile(retFile, type.ToString().ToLower(), isDesign);
        }

        static public void writeToFile(string text, string ext, bool isDesign)
        {
            string css_s1 = @"startups {
    display: table;
        }

        startup {
    display: table-row-group;
    border: solid 2px;
}

    Id {
    display: table-cell;
    color: red;
    background-color: whitesmoke;
}

Name {
    display: table-cell;
    background: mistyrose;
}

StartupLink {
    display: table-cell;
    background-color: gray;
}

ImageUrl {
    display: table-cell;
    background-color: green;
}

DescriptionStartup {
    display: table-cell;
    background-color: whitesmoke;
}

Link {
    display: table-cell;
    background-color: mistyrose;
}

TwitterLink {
    display: table-cell;
    background-color: whitesmoke;
}

GithubLink {
    display: table-cell;
    background-color: mistyrose;
}

FacebookLink {
    display: table-cell;
    background-color: whitesmoke;
}

LinkedinLink {
    display: table-cell;
    background-color: mistyrose;
}

AngelLink {
    display: table-cell;
    background-color: whitesmoke;
}

DescriptionProduct {
    display: table-cell;
    background-color: white;

}

LinkVideo {
    display: table-cell;
    background-color: whitesmoke;
}

Founder {
    display: table-cell;
    background-color: mistyrose;
}

Location {
    display: table-cell;
    background-color: whitesmoke;
}
";
            string css_s2 = @"startups { font - size:80 %; margin: 0.5em; font - family: Verdana; display: block}
            startup { display: block; border: 1px solid silver; margin: 0.5em; padding: 0.5em; background - color:whitesmoke; }
            Id, Name, StartupLink,
StartupLink,
ImageUrl,
DescriptionStartup,
Link,
TwitterLink,
GithubLink,
FacebookLink,
LinkedinLink,
AngelLink,
DescriptionProduct,
LinkVideo,
Founder,
Location { display: block}
            Id { color: red; text - decoration: underline}
            Name { color: green; font - size: 23px}
            StartupLink,
TwitterLink,
GithubLink,
FacebookLink,
LinkedinLink { color: blue}
            ImageUrl { color: gray}
            DescriptionProduct { color: brown}";
            //object obj = MainWindow.selDesign.SelectedItem;
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = DateTime.Now.ToString("yyyyMMddHHmmss"); // Default file name
            dlg.DefaultExt = "."+ext; // Default file extension
            dlg.Filter = "Text documents (."+ext+")|*."+ext; // Filter files by extension
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                string cssFileName = Path.GetDirectoryName(filename)+"\\style1.css";
                System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
                System.IO.StreamWriter cssFile = new System.IO.StreamWriter(cssFileName);
                file.WriteLine(text);
                file.Close();
                cssFile.WriteLine(css_s1);
                cssFile.Close();
                MessageBox.Show("File saved in " + filename);
            }
        }
    }
}
