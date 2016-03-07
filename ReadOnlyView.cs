using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MVC_CountryFlags
{
	/// <summary>
	/// Summary description for ViewForm1.
	/// </summary>
    public class ReadOnlyView : System.Windows.Forms.Form, ICountryView
	{
		private CountryModel myModel;
		private System.Windows.Forms.Panel pnlDrawOn;
		private System.Windows.Forms.ComboBox cmbFilterDisplay;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ReadOnlyView()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();


			SetStyle(ControlStyles.AllPaintingInWmPaint|
				ControlStyles.UserPaint|ControlStyles.DoubleBuffer,true);			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.pnlDrawOn = new System.Windows.Forms.Panel();
            this.cmbFilterDisplay = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // pnlDrawOn
            // 
            this.pnlDrawOn.BackColor = System.Drawing.Color.White;
            this.pnlDrawOn.BackgroundImage = global::MVC_CountryFlags.Properties.Resources.worldMap;
            this.pnlDrawOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDrawOn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDrawOn.Location = new System.Drawing.Point(8, 8);
            this.pnlDrawOn.Name = "pnlDrawOn";
            this.pnlDrawOn.Size = new System.Drawing.Size(614, 380);
            this.pnlDrawOn.TabIndex = 0;
            // 
            // cmbFilterDisplay
            // 
            this.cmbFilterDisplay.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterDisplay.Items.AddRange(new object[] {
            "Select display.....",
            "All Countries",
            "Asia only",
            "North America only",
            "South America only",
            "Africa only",
            "Australia and Oceania only",
            "Europe only"});
            this.cmbFilterDisplay.Location = new System.Drawing.Point(180, 400);
            this.cmbFilterDisplay.Name = "cmbFilterDisplay";
            this.cmbFilterDisplay.Size = new System.Drawing.Size(240, 27);
            this.cmbFilterDisplay.TabIndex = 22;
            this.cmbFilterDisplay.SelectedIndexChanged += new System.EventHandler(this.cmbFilterDisplay_SelectedIndexChanged);
            // 
            // ReadOnlyView
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(623, 440);
            this.Controls.Add(this.cmbFilterDisplay);
            this.Controls.Add(this.pnlDrawOn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(520, 0);
            this.Name = "ReadOnlyView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ViewForm3";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ReadOnlyView_Load);
            this.ResumeLayout(false);

		}
		#endregion

		public void RefreshView()
		{
			// clear panel
			clearPanel();
			// create arraylist of flags from model and convery
			// to array of flags
            ArrayList theCountryList = myModel.CountryList;
            AnyCountry[] theCountry = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
			// graphics object to draw flags
			Graphics g = this.pnlDrawOn.CreateGraphics(); 
			// draw all flags in array
			foreach (AnyCountry sh in theCountry)
			{
				sh.Display(g);
			}
		}

		/// <summary>method: clearPanel
		/// clear all flags from display on panel
		/// </summary>
		private void clearPanel()
		{
            pnlDrawOn.Refresh();
            //this.DoubleBuffered = true;
            //this.UpdateStyles();
		}

		/// <summary>method: DisplayAsia
		/// display asia flags only
		/// </summary>
		public void DisplayAsia()
		{
			// clear panel
			clearPanel();
            // create arraylist of country from model and convery
            // to array of flags
			ArrayList theCountryList = myModel.CountryList;
            AnyCountry[] theCountry = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
			// graphics object to draw flags
			Graphics g = this.pnlDrawOn.CreateGraphics();

            foreach (AnyCountry sh in theCountry)
			{
				// redraw Asia flags only
				if((sh.name.Equals("SriLanka")) || (sh.name.Equals("India")))
					sh.Display(g);					
			}
		}

        /// <summary>method: DisplayNorthAmerica
        /// display north america flags only
        /// </summary>
        public void DisplayNorthAmerica()
        {
            // clear panel
            clearPanel();
            // create arraylist of country from model and convery
            // to array of flags
            ArrayList theCountryList = myModel.CountryList;
            AnyCountry[] theCountry = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
            // graphics object to draw flags
            Graphics g = this.pnlDrawOn.CreateGraphics();

            foreach (AnyCountry sh in theCountry)
            {
                //redraw North America
                if ((sh.name.Equals("USA")) || (sh.name.Equals("Canada")) ||
                    (sh.name.Equals("Mexico")))
                    sh.Display(g);
            }
        }


        /// <summary>method: DisplaySouthAmerica
        /// display south america flags only
        /// </summary>
        public void DisplaySouthAmerica()
        {
            // clear panel
            clearPanel();
            // create arraylist of country from model and convery
            // to array of flags
            ArrayList theCountryList = myModel.CountryList;
            AnyCountry[] theCountry = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
            // graphics object to draw flags
            Graphics g = this.pnlDrawOn.CreateGraphics();

            foreach (AnyCountry sh in theCountry)
            {
                //redraw North America
                if ((sh.name.Equals("Argentina")) || (sh.name.Equals("Brazil"))) 
                    sh.Display(g);
            }
        }

        /// <summary>method: DisplayEurope
        /// display Europe flags only
        /// </summary>
        public void DisplayEurope()
        {
            // clear panel
            clearPanel();
            // create arraylist of country from model and convery
            // to array of flags
            ArrayList theCountryList = myModel.CountryList;
            AnyCountry[] theCountry = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
            // graphics object to draw flags
            Graphics g = this.pnlDrawOn.CreateGraphics();

            foreach (AnyCountry sh in theCountry)
            {
                //redraw North America
                if ((sh.name.Equals("UK")) || (sh.name.Equals("France")))
                    sh.Display(g);
            }
        }


       
        /// <summary>method: DisplayAustraliaOceania
        /// display Europe flags only
        /// </summary>
        public void DisplayAustraliaOceania()
        {
            // clear panel
            clearPanel();
            // create arraylist of country from model and convery
            // to array of flags
            ArrayList theCountryList = myModel.CountryList;
            AnyCountry[] theCountry = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
            // graphics object to draw flags
            Graphics g = this.pnlDrawOn.CreateGraphics();

            foreach (AnyCountry sh in theCountry)
            {
                //redraw North America
                if ((sh.name.Equals("Australia")) || (sh.name.Equals("NewZealand")))
                    sh.Display(g);
            }
        }

        /// <summary>method: DisplayAfrica
        /// display Africa flags only
        /// </summary>
        public void DisplayAfrica()
        {
            // clear panel
            clearPanel();
            // create arraylist of country from model and convery
            // to array of flags
            ArrayList theCountryList = myModel.CountryList;
            AnyCountry[] theCountry = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
            // graphics object to draw flags
            Graphics g = this.pnlDrawOn.CreateGraphics();

            foreach (AnyCountry sh in theCountry)
            {
                //redraw North America
                if ((sh.name.Equals("SouthAfrica")) || (sh.name.Equals("Zimbabwe")))
                    sh.Display(g);
            }
        }
     

		/// <summary>method: cmbFilterDisplay_SelectedIndexChanged
		/// work out which display method to execute based on 
		/// value selected from combo box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmbFilterDisplay_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (cmbFilterDisplay.Text == "All Countries")
                RefreshView();
            else if (cmbFilterDisplay.Text == "Asia only")
                DisplayAsia();
            else if (cmbFilterDisplay.Text == "North America only")
                DisplayNorthAmerica();
            else if (cmbFilterDisplay.Text == "South America only")
                DisplaySouthAmerica();
            else if (cmbFilterDisplay.Text == "Europe only")
                DisplayEurope();
            else if (cmbFilterDisplay.Text == "Australia and Oceania only")
                DisplayAustraliaOceania();
            else if (cmbFilterDisplay.Text == "Africa only")
                DisplayAfrica();

		}


        /// <summary>method: ReadOnlyView_Load
		/// default comboFilter value to null
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void ReadOnlyView_Load(object sender, EventArgs e)
        {
            cmbFilterDisplay.SelectedIndex = 0;
        }

		// set value for myModel
		public CountryModel MyModel
		{
			set
			{
				myModel = value;
			}
		}
	}
}
