using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CrashNSTLoadRemover
{
    /*
     * This class is in charge of the whole video analysis process. It contains both a VideoManager and a OCRManager.
     */
    public class VideoAnalyse
    {

        public void run(string videopath, string textpath, bool debugmode)
        {
            VideoManager vm = new VideoManager();
            vm.LoadVideo(videopath);

            long test = vm.GetLengthOfVideoInFrames();

            for(long i = 0; i < vm.GetLengthOfVideoInFrames()-1; i++)
            {
                Bitmap image = vm.getFrame(i);
                image.Dispose();
            }
        }

    }
}
