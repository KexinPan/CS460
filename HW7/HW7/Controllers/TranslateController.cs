using HW7.DAL;
using HW7.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace HW7.Controllers
{
    public class TranslateController : Controller
    {
        private RequestContext database = new RequestContext();
        // GET: Translate
        public JsonResult TransLang(string id)
        {
 
            string api = "http://api.giphy.com/v1/stickers/translate?";
            string apikey = "&api_key="+System.Web.Configuration.WebConfigurationManager.AppSettings["CS460ApiKey"];
            string query = "&s=" + id;
            string url = api + apikey + query;

            //var giphyData = new WebClient().DownloadString(url);

            // same result but transfer to json format
            Stream giphyStream = WebRequest.Create(url).GetResponse().GetResponseStream();

            
            var giphyData = new System.Web.Script.Serialization.JavaScriptSerializer()
                                  .Deserialize<Object>(new StreamReader(giphyStream)
                                  .ReadToEnd());

            

            // working on database
            // the request can help a lot, use a object based on model
            Request item = new Request();
            item.IPAddress = Request.UserHostAddress;
            item.Description = id;
            item.Type = Request.UserAgent;
            database.Requests.Add(item);
            database.SaveChanges();

            //giphyStream.Close();

            return Json(giphyData, JsonRequestBehavior.AllowGet);
        }
    }
}