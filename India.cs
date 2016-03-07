using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace MVC_CountryFlags
{

    [Serializable()]
    class India : AnyCountry
    {
        // constructor	
        public India(string countryName, int x_at, int y_at, int flag_width, int flag_height)
            : base(countryName, x_at, y_at, flag_width, flag_height)
        {

        }

        // override method to display flag as text
        public override string ToString()
        {
            return "India: " +
                flag_width.ToString() + " cm width, " +
                flag_height.ToString() + " cm height at " +
                this.Position();
        }

        // override method to display flag as graphics
        public override void Display(Graphics g)
        {
            if (g != null)
            {
                Bitmap bitImage = new Bitmap(Properties.Resources.India);
                g.DrawImage(bitImage, x, y, flag_width, flag_height);
            }

            if (Highlight)
            {
                // add in border if flag selected
                // to define point and size
                Point pt = new Point(x + 1, y + 1); // to avoid shadow

                int borderSide = flag_width - 2; // make slightly smaller than flag to avoid shadow
                int borderTop = flag_height - 2;
                Size size = new Size(borderSide, borderTop);
                // draw border
                Pen p = new Pen(Color.Black, 2);
                p.DashStyle = DashStyle.Solid;
                g.DrawRectangle(p, new Rectangle(pt, size));
                p.Dispose();
            }
        }       

        //x_pos of the flag
        public override int x_pos //non abstract property
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        //y_pos of the flag
        public override int y_pos //non abstract property
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        //width of the flag
        public override int flag_width //non abstract property
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        //height of the flag
        public override int flag_height //non abstract property
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }       

        //name of the flag
        public override string name
        {
            get
            {
                return countryName;
            }
            set
            {
                countryName = value;
            }
        }

        /// <summary> method: HitTest
        /// used to create rectangle the same size as the flag if selected
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override bool HitTest(Point p)
        {
            GraphicsPath pth = new GraphicsPath();
            pth.AddRectangle(new Rectangle(x, y, width, height));

            bool retval = pth.IsVisible(p);
            pth.Dispose();
            return retval;
        }
    }
}

