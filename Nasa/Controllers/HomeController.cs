using System.IO;
using System.Net;
using System.Web.Mvc;

namespace Nasa.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }

      public ActionResult LukeExoplanets()
      {
         return View("LukeExoplanets");
      }

      public ActionResult KitMaas()
      {
         return View("KitMaas");
      }

      public ActionResult MinaExoplanets()
      {
         return View("MinaExoplanets");
      }

      public ActionResult LukeGoogleEarth()
      {
         return View("LukeGoogleEarth");
      }

      public ActionResult LukeGoogleSky()
      {
         return View("LukeGoogleSky");
      }

      public string HttpRequestSync(string url)
      {
         using (var client = new WebClient())
         {
            using (var stream = client.OpenRead(url))
            {
               if (stream == null)
                  throw new WebException("Failed to connect to " + url);

               using (var streamReader = new StreamReader(stream))
               {
                  return streamReader.ReadToEnd();
               }
            }
         }
      }
   }
}
