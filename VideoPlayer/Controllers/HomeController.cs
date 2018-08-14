using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using VideoPlayer.Models;
using System.Net;

namespace VideoPlayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string video)
        {
            VideoList vl = new VideoList
            {
                Parents = new List<Models.File>(),
                Videos = new List<Models.File>()
            };
            string[] parents = Directory.GetDirectories(@Server.MapPath("~/Content/Training Videos"));
            string firstvideo = "";
            for (int i = 0; i < parents.Length; i++)
            {
                Models.File p = new Models.File
                {
                    Path = parents[i],
                    Name = parents[i].Split('\\')[parents[i].Split('\\').Length - 1],
                    Parent = ""
                };
                vl.Parents.Add(p);
                string[] files = Directory.GetFiles(parents[i]);
                for(int j = 0; j < files.Length; j++)
                {
                    if(i == 0 && j == 0)
                    {
                        firstvideo = files[j];
                    }
                    Models.File f = new Models.File
                    {
                        Path = files[j],
                        Name = files[j].Split('\\')[files[j].Split('\\').Length - 1],
                        Parent = p.Name
                    };
                    vl.Videos.Add(f);
                }
            }
            MainPageModel model = new MainPageModel();
            model.VideoList = vl;
            model.Video = new Models.File();
            if(string.IsNullOrEmpty(video))
            {
                model.Video.Path = firstvideo;
            }
            else
            {
                model.Video.Path = video;
            }
            string[] temp = model.Video.Path.Split('\\');
            model.Video.Name = temp[temp.Length - 1];
            model.Video.Parent = temp[temp.Length - 2];
            model.VideoTitle = model.Video.Parent + " - " + model.Video.Name.Replace(".mp4", "");

            return View(model);
        }
    }
}