using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Core;
using MongoDB.Driver.Core.Bindings;
using MongoDB.Driver.Core.Operations;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
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
                default:
                    retFile = xml;
                    break;
            }
            writeToFile(retFile, type.ToString().ToLower());
        }



        static public void writeToFile(string text, string ext)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = DateTime.Now.ToString("yyyyMMddHHmmss"); // Default file name
            dlg.DefaultExt = "."+ext; // Default file extension
            dlg.Filter = "Text documents (."+ext+")|*."+ext; // Filter files by extension
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
                file.WriteLine(text);
                file.Close();
                MessageBox.Show("File saved in " + filename);
            }
        }
    }
}
