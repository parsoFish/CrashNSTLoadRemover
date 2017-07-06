using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Accord.Video.FFMPEG;

namespace CrashNSTLoadRemover
{
    /*
     * This class is in charge of loading and sending data related to the video that is during analysed.
     */
    public class VideoManager
    {
        private VideoFileReader vfr;
        private int currentFrameCounter;

        public VideoManager()
        {
            vfr = new VideoFileReader();
            currentFrameCounter = 0;
        }

        public void LoadVideo(string filepath)
        {
            vfr.Open(filepath);
        }

        public long GetLengthOfVideoInFrames()
        {
            return vfr.FrameCount;
        }

        public Bitmap getFrame(long frameNumber)
        {
            while(frameNumber > currentFrameCounter)
            {
                currentFrameCounter++;
                vfr.ReadVideoFrame();
            }
            if(frameNumber == currentFrameCounter)
            {
                currentFrameCounter++;
                return vfr.ReadVideoFrame();
            }
            else
            {
                return null;
            }

        }

    }
}
