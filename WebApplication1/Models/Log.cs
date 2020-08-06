using System;
using System.Collections.Generic;

namespace MyWebAppGit.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public int PictureReferenceId { get; set; }
        public string LogText { get; set; }
        public DateTime LogDateTime { get; set; }

        public virtual PictureInformation PictureReference { get; set; }
    }
}
