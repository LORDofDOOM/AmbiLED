using System;
using System.Collections.Generic;
using System.Text;
 
namespace AmbiLED
{
    public class Utility
    {
        #region Basic Frame Counter
 
        private static int lastTick_1;
        private static int lastFrameRate_1;
        private static int frameRate_1;

        private static int lastTick_2;
        private static int lastFrameRate_2;
        private static int frameRate_2;
 
        public static int CalculateFrameRate_1()
        {
            if (System.Environment.TickCount - lastTick_1 >= 1000)
            {
                lastFrameRate_1 = frameRate_1;
                frameRate_1 = 0;
                lastTick_1 = System.Environment.TickCount;
            }
            frameRate_1++;
            return lastFrameRate_1;
        }

        public static int CalculateFrameRate_2()
        {
            if (System.Environment.TickCount - lastTick_2 >= 1000)
            {
                lastFrameRate_2 = frameRate_2;
                frameRate_2 = 0;
                lastTick_2 = System.Environment.TickCount;
            }
            frameRate_2++;
            return lastFrameRate_2;
        }
        #endregion
 
    }
}

