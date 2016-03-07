using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MVC_CountryFlags
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private CountryModel theModel;
		private CountryController theController;			
		private GraphicView myViewForm1;
		private TextView myViewForm2;
		private ReadOnlyView myViewForm3;
		private System.Windows.Forms.Button btnMakeController;
		private System.Windows.Forms.Button btnMakeModel;
		private System.Windows.Forms.Button btnMakeViews;
		private System.Windows.Forms.Button btnShowViews;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.btnMakeController = new System.Windows.Forms.Button();
            this.btnMakeModel = new System.Windows.Forms.Button();
            this.btnMakeViews = new System.Windows.Forms.Button();
            this.btnShowViews = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMakeController
            // 
            this.btnMakeController.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeController.Location = new System.Drawing.Point(31, 10);
            this.btnMakeController.Name = "btnMakeController";
            this.btnMakeController.Size = new System.Drawing.Size(155, 32);
            this.btnMakeController.TabIndex = 0;
            this.btnMakeController.Text = "Make Controller";
            this.btnMakeController.Click += new System.EventHandler(this.btnMakeController_Click);
            // 
            // btnMakeModel
            // 
            this.btnMakeModel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeModel.Location = new System.Drawing.Point(31, 48);
            this.btnMakeModel.Name = "btnMakeModel";
            this.btnMakeModel.Size = new System.Drawing.Size(155, 32);
            this.btnMakeModel.TabIndex = 1;
            this.btnMakeModel.Text = "Make Model";
            this.btnMakeModel.Click += new System.EventHandler(this.btnMakeModel_Click);
            // 
            // btnMakeViews
            // 
            this.btnMakeViews.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeViews.Location = new System.Drawing.Point(31, 86);
            this.btnMakeViews.Name = "btnMakeViews";
            this.btnMakeViews.Size = new System.Drawing.Size(155, 32);
            this.btnMakeViews.TabIndex = 2;
            this.btnMakeViews.Text = "Make Views";
            this.btnMakeViews.Click += new System.EventHandler(this.btnMakeViews_Click);
            // 
            // btnShowViews
            // 
            this.btnShowViews.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowViews.Location = new System.Drawing.Point(31, 124);
            this.btnShowViews.Name = "btnShowViews";
            this.btnShowViews.Size = new System.Drawing.Size(155, 32);
            this.btnShowViews.TabIndex = 3;
            this.btnShowViews.Text = "Show Views";
            this.btnShowViews.Click += new System.EventHandler(this.btnShowViews_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(219, 174);
            this.Controls.Add(this.btnShowViews);
            this.Controls.Add(this.btnMakeViews);
            this.Controls.Add(this.btnMakeModel);
            this.Controls.Add(this.btnMakeController);
            this.Name = "Form1";
            this.Text = "CountryFlags";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		#region Code for Button Clicks on Form now redundant

/// this block of code for button clicks is redundant as it is all included
/// in the completeSetUp method which runs when the form loads.

		private void btnMakeController_Click(object sender, System.EventArgs e)
		{
			theController = new CountryController();
		}

		private void btnMakeModel_Click(object sender, System.EventArgs e)
		{
			theModel = new CountryModel(theController);
		}

		private void btnMakeViews_Click(object sender, System.EventArgs e)
		{
			myViewForm1 = new GraphicView();
			myViewForm2 = new TextView();
			myViewForm3 = new ReadOnlyView();
			myViewForm1.MyModel = theModel;
			myViewForm2.MyModel = theModel;
			myViewForm3.MyModel = theModel;            
			theController.AddView(myViewForm1);			
			theController.AddView(myViewForm2);			
			theController.AddView(myViewForm3);			
		}

		private void btnShowViews_Click(object sender, System.EventArgs e)
		{
			myViewForm1.Show();
			myViewForm2.Show();
			myViewForm3.Show();
		}

		#endregion


		/// <summary>method: completeSetUp
		/// make controller
		/// make model
		/// make views and 
		/// show views
		/// </summary>
		private void completeSetUp()
		{
			// make controller
			theController = new CountryController();
			// make model
			theModel = new CountryModel(theController);
			// make views
			myViewForm1 = new GraphicView();
			myViewForm2 = new TextView();
			myViewForm3 = new ReadOnlyView();
			myViewForm1.MyModel = theModel;
			myViewForm2.MyModel = theModel;
			myViewForm3.MyModel = theModel;

			theController.AddView(myViewForm1);			
			theController.AddView(myViewForm2);			
			theController.AddView(myViewForm3);	

			//show views
			myViewForm3.Show();
			myViewForm2.Show();
			myViewForm1.Show();
		}

		/// <summary> method: Form1_Load
		/// executes completeSetUp method when form loads to 
		/// make controller
		/// make model
		/// make views and 
		/// show views
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			this.completeSetUp();				
		}
	}
}
