using System;
using System.Collections.Generic;
using System.Text;
 
namespace AmbiLEDd
{
    public class Utility
    {
        #region Basic Frame Counter
 
        private static int lastTick;
        private static int lastFrameRate;
        private static int frameRate;
 
        public static int CalculateFrameRate()
        {
            if (System.Environment.TickCount - lastTick >= 1000)
            {
                lastFrameRate = frameRate;
                frameRate = 0;
                lastTick = System.Environment.TickCount;
            }
            frameRate++;
            return lastFrameRate;
        }
        #endregion
 
    }
}

