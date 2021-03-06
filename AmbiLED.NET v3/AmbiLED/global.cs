using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
/*
Copyright 2011 Mariusz Grzybacz

This file is part of AmbiLED.

AmbiLED is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

AmbiLED is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Foobar; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

namespace AmbiLED
{
    public static class global //A public static class to store global variables
    {
        //An int to store the average colors in the following pattern:
        //Red = L, Green = G, Blue = B
        //Left = L, Top = T, Right = R
        //{RL,RT,RR,GL,GT,GR,BL,BT,BR}
        //This is because the microcontroller receives the data in this order
        public static int[] PreviousColor10 = new int[9];
        public static int[] PreviousColor9 = new int[9];
        public static int[] PreviousColor8 = new int[9];
        public static int[] PreviousColor7 = new int[9];
        public static int[] PreviousColor6 = new int[9];
        public static int[] PreviousColor5 = new int[9];
        public static int[] PreviousColor4 = new int[9];
        public static int[] PreviousColor3 = new int[9];
        public static int[] PreviousColor2 = new int[9];
        public static int[] PreviousColor = new int[9];
        public static int[] CurrentColor = new int[9];

        public static int[] tempReceivedRGB = new int[9];
        public static int[] ReceivedRGB = new int[9];
        public static int[] RealByte = new int[9];
        public static byte[] SendByte = new byte[9];
        public static byte[] OldSendByte = new byte[9];

        public static Color[] cReceivedRGB = new Color[3];
        public static int[] dynamicValue = new int[3];

        public static byte[] SendData = new byte[12];

        public static int[] Cycles = new int[3];
        public static int[] temp_Cycles = new int[3];
        public static int[] CycleCounter = new int[3];
        public static int in_DynamicControl;
        public static int var_MaxSmoothRadius = 32;
        public static int var_MinSmoothRadius = 4;
        public static int var_AggressiveThreshold = 128;
        public static int[] _tmp_diff = new int[3];
        public static bool DynamicRadius = false;
        public static int var_SlideDelay = 1;
        public static int[] __slidecounter =  new int[3];
        public static int var_DarknessLimit = 0;
        public static int in_DarknessLimitMethod;

        //An int to count: 0 = left, 1 = top, 2 = right
        //Values to determine what region control what lights
        //From top left to bottom right in the following way:
        //Top,Left,Bottom,Right


        public static bool Enabled = false;
        public static bool TriggeredRun = false;
        public static bool ReadyToGet = true;

        public static bool trg_Received = false;

        public static int var_Interval;

        public static int Mode; //0 = movie, 1 = gaming
        public static int Controller = 0; //0 = old, 1 = v3
        public static int Counter = 0;

        public static byte var_ExpandMode = 1;
        public static int var_QuantizeLevel = 1;
        public static int var_DarknessThreshold = 0;
        public static bool _ProgressiveThreshold = false;
        public static int var_MaxMultiply;

        public static int var_ColorSlider;
        public static bool ShowOutput = false;

        public static bool __serial_open = false;

//        public static string __progresschars = "-\\|/";
        public static string __progresschars = "˹  ˺ ˼˻ ";
        public static int __progress = 0;
        public static int __aggressivecount = 0;

        public static bool _listening = false;
        public static bool _net_socket_debug = false;

        public static string _receiveddata = "";
        public static byte _data_length = 10 - 1;

        public static byte v3_ident = 36;

        public static byte[] GammaArray = new byte[256];
        public static float var_GammaValue;
        public static int var_GammaValueInt;
        public static byte var_GammaEvent;
    }
}
