using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Administration;
using NewTab.Models;

namespace NewTab.Controllers {
    public class HomeController : Controller {

        /// <summary>
        /// Home Controller strongly typed action names
        /// </summary>
        public static class ActionNames {
            /// <summary>
            /// Controller name
            /// </summary>
            public const string ControllerName = "Home";

            /// <summary>
            /// Index Home action
            /// </summary>
            public const string Index = "Index";
        }

        public ActionResult Index() {
            var model = new IndexModel();
            model.Apps = new List<Thumbnail>();
            var iisServer = new ServerManager();
            foreach (var s in iisServer.Sites) {
                foreach (var b in s.Bindings) {
                    if (!s.Name.Contains("New-Tab") && !s.Name.Contains("Default Web Site")) {
                        model.Apps.Add(new Thumbnail() {
                            Application = s.Name,
                            Link = "http://" + b.Host
                        });
                    }
                }
            }

            model.Apps.Add(new Thumbnail() {
                Application = "Oxxa",
                Link = "http://mijn.oxxa.com/login.php"
            });
            model.Apps.Add(new Thumbnail() {
                Application = "StatusCake",
                Link = "https://www.statuscake.com/App/Login/"
            });
            model.Apps.Add(new Thumbnail() {
                Application = "Google",
                Link = "http://google.com/"
            });
            model.Apps.Add(new Thumbnail() {
                Application = "Facebook",
                Link = "http://fb.com/"
            });
            model.Apps.Add(new Thumbnail() {
                Application = "Spotify",
                Link = "http://play.spotify.com/"
            });

            return View(model);
        }
    }
}

