using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

namespace MVC_CountryFlags
{
	/// <summary>
	/// Summary description for AnyCountry.
	/// </summary>
    [Serializable()]
	public abstract class AnyCountry
	{
        protected string countryName;
		protected int x;
		protected int y;
		protected int width;
		protected int height;

		// added for hittest and highlight
		bool highlight;

		// constructor
		public AnyCountry(string countryN, int x_at, int y_at, int flagWidth, 
			int flagHeight)
		{
            countryName = countryN;
			x = x_at;
			y = y_at;
			width = flagWidth;
			height = flagHeight;            
		}		

        //Display flag
		public abstract void Display(Graphics g); // abstract method       

        //Highlight flag when hover the flag
		public bool Highlight 
		{
			get
			{
				return highlight;
			}
			set
			{
				highlight = value;
			}
		}

        //x and y position write to the text view
		public string Position()  //non abstract method
		{
			return "(" + x.ToString().PadLeft(3,'0') + "," + y.ToString().PadLeft(3,'0') + ")"; //PedLeft make the number always 3 digit
		}

        //X_pos of the flag
		public abstract int x_pos //abstract property
		{
			get;
			set;
		}

        //Y_pos of the flag
		public abstract int y_pos //abstract property
		{
			get;
			set;
		}

        //Width of the flag
		public abstract int flag_width //abstract property
		{
			get;
			set;
		}

        //Height of the flag
		public abstract int flag_height //abstract property
		{
			get;
			set;
		}

        //Flag/country name
		public abstract string name //abstract property
		{
			get;
			set;
		}
       

		// virtual method
		public virtual bool HitTest(Point p)
		{
			Point pt = new Point(x, y);
			Size size = new Size(100,100);
			//default behaviour
			return new Rectangle(pt, size).Contains(p);
            
		}
	}
}
