﻿/* This tool is part of the xRay Toolkit and is provided free of charge by Bob Powell. 
 * This code is not guaranteed to be free from defects or fit for merchantability in any way. 
 * By using this tool in your own programs you agree to hold Robert W. Powell free from all 
 * damages direct or incidental that arise from such use. 
 * You may use this code free of charge in your own projects on condition that you place the 
 * following paragraph (enclosed in quotes below) in your applications help or about dialog. 
 * "Portions of this code provided by Bob Powell. http://www.bobpowell.net" 
 */

using System;
using System.Drawing;

namespace AmbiLED
{
    public class RGBHSL
    {

        public class HSL
        {
            public HSL()
            {
                _h = 0;
                _s = 0;
                _l = 0;
            }

            double _h;
            double _s;
            double _l;

            public double H
            {
                get { return _h; }
                set
                {
                    _h = value;
                    _h = _h > 1 ? 1 : _h < 0 ? 0 : _h;
                }
            }

            public double S
            {
                get { return _s; }
                set
                {
                    _s = value;
                    _s = _s > 1 ? 1 : _s < 0 ? 0 : _s;
                }
            }

            public double L
            {
                get { return _l; }
                set
                {
                    _l = value;
                    _l = _l > 1 ? 1 : _l < 0 ? 0 : _l;
                }
            }
        }

        public RGBHSL()
        {
        }

        /// <summary> 
        /// Sets the absolute brightness of a colour 
        /// </summary> 
        /// <param name="c">Original colour</param> 
        /// <param name="brightness">The luminance level to impose</param> 
        /// <returns>an adjusted colour</returns> 
        public static Color SetBrightness(Color c, double brightness)
        {
            HSL hsl = GetHSL(c);
            hsl.L = brightness;
            return GetRGB(hsl);
        }

        /// <summary> 
        /// Modifies an existing brightness level 
        /// </summary> 
        /// <remarks> 
        /// To reduce brightness use a number smaller than 1. To increase brightness use a number larger tnan 1 
        /// </remarks> 
        /// <param name="c">The original colour</param> 
        /// <param name="brightness">The luminance delta</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color ModifyBrightness(Color c, double brightness)
        {
            HSL hsl = GetHSL(c);
            hsl.L *= brightness;
            return GetRGB(hsl);
        }

        /// <summary> 
        /// Sets the absolute saturation level 
        /// </summary> 
        /// <remarks>Accepted values 0-1</remarks> 
        /// <param name="c">An original colour</param> 
        /// <param name="Saturation">The saturation value to impose</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color SetSaturation(Color c, double Saturation)
        {
            HSL hsl = GetHSL(c);
            hsl.S = Saturation;
            return GetRGB(hsl);
        }

        /// <summary> 
        /// Modifies an existing Saturation level 
        /// </summary> 
        /// <remarks> 
        /// To reduce Saturation use a number smaller than 1. To increase Saturation use a number larger tnan 1 
        /// </remarks> 
        /// <param name="c">The original colour</param> 
        /// <param name="Saturation">The saturation delta</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color ModifySaturation(Color c, double Saturation)
        {
            HSL hsl = GetHSL(c);
            hsl.S *= Saturation;
            return GetRGB(hsl);
        }

        /// <summary> 
        /// Sets the absolute Hue level 
        /// </summary> 
        /// <remarks>Accepted values 0-1</remarks> 
        /// <param name="c">An original colour</param> 
        /// <param name="Hue">The Hue value to impose</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color SetHue(Color c, double Hue)
        {
            HSL hsl = GetHSL(c);
            hsl.H = Hue;
            return GetRGB(hsl);
        }

        /// <summary> 
        /// Modifies an existing Hue level 
        /// </summary> 
        /// <remarks> 
        /// To reduce Hue use a number smaller than 1. To increase Hue use a number larger tnan 1 
        /// </remarks> 
        /// <param name="c">The original colour</param> 
        /// <param name="Hue">The Hue delta</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color ModifyHue(Color c, double Hue)
        {
            HSL hsl = GetHSL(c);
            hsl.H *= Hue;
            return GetRGB(hsl);
        }

        /// <summary> 
        /// Converts a colour from HSL to RGB 
        /// </summary> 
        /// <remarks>Adapted from the algoritm in Foley and Van-Dam</remarks> 
        /// <param name="hsl">The HSL value</param> 
        /// <returns>A Color structure containing the equivalent RGB values</returns> 
        public static Color GetRGB(HSL hsl)
        {
            double r = 0, g = 0, b = 0;
            double temp1, temp2;

            if (hsl.L == 0)
            {
                r = g = b = 0;
            }
            else
            {
                if (hsl.S == 0)
                {
                    r = g = b = hsl.L;
                }
                else
                {
                    temp2 = ((hsl.L <= 0.5) ? hsl.L * (1.0 + hsl.S) : hsl.L + hsl.S - (hsl.L * hsl.S));
                    temp1 = 2.0 * hsl.L - temp2;

                    double[] t3 = new double[] { hsl.H + 1.0 / 3.0, hsl.H, hsl.H - 1.0 / 3.0 };
                    double[] clr = new double[] { 0, 0, 0 };
                    for (int i = 0; i < 3; i++)
                    {
                        if (t3[i] < 0)
                            t3[i] += 1.0;
                        if (t3[i] > 1)
                            t3[i] -= 1.0;

                        if (6.0 * t3[i] < 1.0)
                            clr[i] = temp1 + (temp2 - temp1) * t3[i] * 6.0;
                        else if (2.0 * t3[i] < 1.0)
                            clr[i] = temp2;
                        else if (3.0 * t3[i] < 2.0)
                            clr[i] = (temp1 + (temp2 - temp1) * ((2.0 / 3.0) - t3[i]) * 6.0);
                        else
                            clr[i] = temp1;
                    }
                    r = clr[0];
                    g = clr[1];
                    b = clr[2];
                }
            }

            return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));

        }


        // 
        /// <summary> 
        /// Converts RGB to HSL 
        /// </summary> 
        /// <remarks>Takes advantage of whats already built in to .NET by using the Color.GetHue, Color.GetSaturation and Color.GetBrightness methods</remarks> 
        /// <param name="c">A Color to convert</param> 
        /// <returns>An HSL value</returns> 
        public static HSL GetHSL(Color c)
        {
            HSL hsl = new HSL();

            hsl.H = c.GetHue() / 360.0; // we store hue as 0-1 as opposed to 0-360 
            hsl.L = c.GetBrightness();
            hsl.S = c.GetSaturation();

            return hsl;
        }
    }
}