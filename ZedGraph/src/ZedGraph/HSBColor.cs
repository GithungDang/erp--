namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct HSBColor
    {
        public byte H;
        public byte S;
        public byte B;
        public byte A;
        public HSBColor(int h, int s, int b)
        {
            this.H = (byte) h;
            this.S = (byte) s;
            this.B = (byte) b;
            this.A = 0xff;
        }

        public HSBColor(int a, int h, int s, int b) : this(h, s, b)
        {
            this.A = (byte) a;
        }

        public HSBColor(Color color)
        {
            this = FromRGB(color);
        }

        public static implicit operator Color(HSBColor hsbColor) => 
            ToRGB(hsbColor);

        public static Color ToRGB(HSBColor hsbColor)
        {
            Color black = Color.Black;
            int num = (int) Math.Floor((double) (((double) hsbColor.H) / 42.5));
            double num2 = (((double) hsbColor.H) / 42.5) - num;
            double num3 = ((double) hsbColor.S) / 255.0;
            byte blue = (byte) ((hsbColor.B * (1.0 - num3)) + 0.5);
            byte red = (byte) ((hsbColor.B * (1.0 - (num3 * num2))) + 0.5);
            byte green = (byte) ((hsbColor.B * (1.0 - (num3 * (1.0 - num2)))) + 0.5);
            switch (num)
            {
                case 0:
                    black = Color.FromArgb(hsbColor.A, hsbColor.B, green, blue);
                    break;

                case 1:
                    black = Color.FromArgb(hsbColor.A, red, hsbColor.B, blue);
                    break;

                case 2:
                    black = Color.FromArgb(hsbColor.A, blue, hsbColor.B, green);
                    break;

                case 3:
                    black = Color.FromArgb(hsbColor.A, blue, red, hsbColor.B);
                    break;

                case 4:
                    black = Color.FromArgb(hsbColor.A, green, blue, hsbColor.B);
                    break;

                default:
                    black = Color.FromArgb(hsbColor.A, hsbColor.B, blue, red);
                    break;
            }
            return black;
        }

        public Color ToRGB() => 
            ToRGB(this);

        public unsafe HSBColor FromRGB() => 
            FromRGB(*((Color*) this));

        public static unsafe HSBColor FromRGB(Color rgbColor)
        {
            double num = ((double) rgbColor.R) / 255.0;
            double num2 = ((double) rgbColor.G) / 255.0;
            double num3 = ((double) rgbColor.B) / 255.0;
            double num5 = Math.Max(Math.Max(num, num2), num3);
            HSBColor color = new HSBColor(rgbColor.A, 0, 0, 0) {
                B = (byte) ((num5 * 255.0) + 0.5)
            };
            double num6 = num5 - Math.Min(Math.Min(num, num2), num3);
            if (num5 == 0.0)
            {
                color.S = 0;
                color.H = 0;
                return color;
            }
            color.S = (byte) (((num6 / num5) * 255.0) + 0.5);
            double num7 = (num != num5) ? ((num2 != num5) ? (4.0 + ((num - num2) / num6)) : (2.0 + ((num3 - num) / num6))) : ((num2 - num3) / num6);
            color.H = (byte) (num7 * 42.5);
            if (color.H < 0)
            {
                HSBColor* colorPtr1 = &color;
                colorPtr1->H = (byte) (colorPtr1->H + 0xff);
            }
            return color;
        }
    }
}

