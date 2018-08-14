using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoPlayer.Models
{
    public class File
    {
        public string Path, Name, Parent;
    }

    public class VideoList
    {
        public List<File> Videos { get; set; }
        public List<File> Parents { get; set; }
    }

    public class MainPageModel
    {
        public VideoList VideoList { get; set; }
        public string VideoTitle { get; set; }
        public File Video { get; set; }
    }
}