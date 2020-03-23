using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace FullMediaPlayer.Models
{
    public class Video
    {

        public int Id { get; set; }
        public string Videotitle { get; set; }
        public StorageFile Videofile { get; set; }


    }
}
