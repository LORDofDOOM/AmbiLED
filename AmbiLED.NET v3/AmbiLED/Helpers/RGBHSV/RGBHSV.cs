using System;
using System.Drawing;

namespace AmbiLED
{
    public class RGBHSV
    {
        public class HSV
        {
            public HSV()
            {
                _h = 0;
                _s = 0;
                _v = 0;
            }

            double _h;
            double _s;
            double _v;

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

            public double V
            {
                get { return _v; }
                set
                {
                    _v = value;
                    _v = _v > 1 ? 1 : _v < 0 ? 0 : _v;
                }
            }
        }

        public RGBHSV()
        {
        }

        public static HSV GetHSV(Color color)
        {
            HSV hsv = new HSV();

            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hsv.H = color.GetHue();
            hsv.S = (max == 0) ? 0 : 1d - (1d * min / max);
            hsv.V = max / 255d;

            return hsv;
        }

        public static Color GetRGB(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        } 
    }
}