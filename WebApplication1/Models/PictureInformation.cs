using System;
using System.Collections.Generic;

namespace MyWebAppGit.Models
{
    public partial class PictureInformation
    {
        public PictureInformation()
        {
            Log = new HashSet<Log>();
        }

        public int Id { get; set; }
        public string PicturePath { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Log> Log { get; set; }
    }
}
