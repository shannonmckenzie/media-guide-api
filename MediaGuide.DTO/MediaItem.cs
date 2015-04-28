using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MediaGuide.DTO
{
    public class MediaItem
    {
        public Int32 Id { get; set; }
        public Int32 Channel_Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Url { get; set; }
    }
}
