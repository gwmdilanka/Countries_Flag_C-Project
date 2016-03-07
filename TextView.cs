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
    public class TextView : System.Windows.Forms.Form, ICountryView
	{
		private CountryModel myModel;
		// variables for max values of parameters input by user
		int max_X = 425;
		int max_Y = 325;
		int max_width = 50;
		int max_height = 50;

        private System.Windows.Forms.Panel pnlDrawOn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtXpos;
		private System.Windows.Forms.TextBox txtYpos;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnAddFlag;
		private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
		private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnClearInput;
        private Label label8;
        private ComboBox cmboCountry2;
        private Button btnDeleteFlag;
		private System.ComponentModel.IContainer components;

		public TextView()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();


			// sets drawing style to remove blinking 
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
            this.components = new System.ComponentModel.Container();
            this.pnlDrawOn = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtXpos = new System.Windows.Forms.TextBox();
            this.txtYpos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddFlag = new System.Windows.Forms.Button();
            this.btnClearInput = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cmboCountry2 = new System.Windows.Forms.ComboBox();
            this.btnDeleteFlag = new System.Windows.Forms.Button();
            this.pnlDrawOn.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDrawOn
            // 
            this.pnlDrawOn.BackColor = System.Drawing.Color.White;
            this.pnlDrawOn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDrawOn.Controls.Add(this.listBox1);
            this.pnlDrawOn.Location = new System.Drawing.Point(8, 8);
            this.pnlDrawOn.Name = "pnlDrawOn";
            this.pnlDrawOn.Size = new System.Drawing.Size(500, 380);
            this.pnlDrawOn.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(24, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(440, 327);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Position";
            // 
            // txtXpos
            // 
            this.txtXpos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXpos.Location = new System.Drawing.Point(168, 432);
            this.txtXpos.Name = "txtXpos";
            this.txtXpos.Size = new System.Drawing.Size(40, 27);
            this.txtXpos.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtXpos, "Maximum value for X is 425");
            this.txtXpos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXpos_KeyPress);
            // 
            // txtYpos
            // 
            this.txtYpos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYpos.Location = new System.Drawing.Point(168, 464);
            this.txtYpos.Name = "txtYpos";
            this.txtYpos.Size = new System.Drawing.Size(40, 27);
            this.txtYpos.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtYpos, "Maximum value for Y is 325");
            this.txtYpos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXpos_KeyPress);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(136, 464);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Y:";
            // 
            // lblHeight
            // 
            this.lblHeight.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.Location = new System.Drawing.Point(224, 464);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(66, 24);
            this.lblHeight.TabIndex = 14;
            this.lblHeight.Text = "Heigth:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(224, 432);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Width:";
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(296, 464);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(40, 27);
            this.txtHeight.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtHeight, "Maximum Height is 50");
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXpos_KeyPress);
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(296, 432);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(40, 27);
            this.txtWidth.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtWidth, "Maximum Width is 50");
            this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXpos_KeyPress);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(248, 400);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "Size";
            // 
            // btnAddFlag
            // 
            this.btnAddFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddFlag.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFlag.Location = new System.Drawing.Point(360, 438);
            this.btnAddFlag.Name = "btnAddFlag";
            this.btnAddFlag.Size = new System.Drawing.Size(136, 32);
            this.btnAddFlag.TabIndex = 19;
            this.btnAddFlag.Text = "Add Flag";
            this.btnAddFlag.UseVisualStyleBackColor = false;
            this.btnAddFlag.Click += new System.EventHandler(this.btnAddFlag_Click);
            // 
            // btnClearInput
            // 
            this.btnClearInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClearInput.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearInput.Location = new System.Drawing.Point(360, 400);
            this.btnClearInput.Name = "btnClearInput";
            this.btnClearInput.Size = new System.Drawing.Size(136, 32);
            this.btnClearInput.TabIndex = 20;
            this.btnClearInput.Text = "Clear Input";
            this.btnClearInput.UseVisualStyleBackColor = false;
            this.btnClearInput.Click += new System.EventHandler(this.btnClearInput_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 24);
            this.label8.TabIndex = 27;
            this.label8.Text = "Country:";
            // 
            // cmboCountry2
            // 
            this.cmboCountry2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboCountry2.FormattingEnabled = true;
            this.cmboCountry2.Items.AddRange(new object[] {
            "SriLanka",
            "India",
            "USA",
            "Canda",
            "Mexico",
            "Argentina",
            "Brazil",
            "UK",
            "France",
            "Australia",
            "NewZealand",
            "SouthAfrica",
            "Zimbabwe"});
            this.cmboCountry2.Location = new System.Drawing.Point(9, 432);
            this.cmboCountry2.Name = "cmboCountry2";
            this.cmboCountry2.Size = new System.Drawing.Size(121, 27);
            this.cmboCountry2.TabIndex = 26;
            // 
            // btnDeleteFlag
            // 
            this.btnDeleteFlag.BackColor = System.Drawing.Color.Red;
            this.btnDeleteFlag.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFlag.Location = new System.Drawing.Point(360, 476);
            this.btnDeleteFlag.Name = "btnDeleteFlag";
            this.btnDeleteFlag.Size = new System.Drawing.Size(136, 31);
            this.btnDeleteFlag.TabIndex = 28;
            this.btnDeleteFlag.Text = "Delete Flag";
            this.btnDeleteFlag.UseVisualStyleBackColor = false;
            this.btnDeleteFlag.Click += new System.EventHandler(this.btnDeleteFlag_Click);
            // 
            // TextView
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(514, 513);
            this.Controls.Add(this.btnDeleteFlag);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmboCountry2);
            this.Controls.Add(this.btnClearInput);
            this.Controls.Add(this.btnAddFlag);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtYpos);
            this.Controls.Add(this.txtXpos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlDrawOn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(520, 0);
            this.Name = "TextView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ViewForm2";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TextView_Load);
            this.pnlDrawOn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		// set method for myModel
		public CountryModel MyModel
		{
			set
			{
				myModel = value;
			}
		}
		
		/// <summary>method: isInputValid
		/// method to check user input is valid
		/// </summary>
		/// <param name="txtXpos"></param>
		/// <param name="txtYpos"></param>
		/// <param name="txtWidth"></param>
		/// <param name="txtHeight"></param>
		/// <returns></returns>
		private bool InputValid(string txtXpos, string txtYpos, 
			string txtWidth, string txtHeight)
		{
			
			int X,Y, Width;
			int Height = 0;
			bool validInput = false;
			// required fields populated 
			if (txtHeight.Length > 0)
				Height = Convert.ToInt32(txtHeight);
							
			// convert user inputs to variables				
			X = Convert.ToInt32(txtXpos);
			Y = Convert.ToInt32(txtYpos);
			Width = Convert.ToInt32(txtWidth);	

			// validate data entry is within limits
			if ((X > max_X) || (Y > max_Y) || (Width > max_width) || 
				(Height > max_height))
				MessageBox.Show("Maximum value for X is " + max_X 
					+ "\r\n" + 	"Maximum value for Y is " + max_Y + "\r\n"
					+ "\r\n" +	"Maximum value for Width is " + max_width 
					+ "\r\n" +	"Maximum value for Height is " + max_height,
					"Please Check the Values Entered", 
					MessageBoxButtons.OK,MessageBoxIcon.Error);
			else
				validInput = true;
			return validInput;
		}		



		/// <summary> method: RefreshView
		/// clears the listBox displays all the flags in the flagsModel
		/// </summary>
		public void RefreshView()
		{
			// clear listBox
			listBox1.Items.Clear();
			// create arrayList from flags in model
            ArrayList theCountryList = myModel.CountryList;
			//Convert arrayList to array of flags
            AnyCountry[] theCountries = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
			// graphics object to draw flags
			Graphics g = this.pnlDrawOn.CreateGraphics(); 
			// add each flag in the array to the listBox
            foreach (AnyCountry sh in theCountries)
			{
				listBox1.Items.Add(sh);
                
			}
		}
        

		/// <summary>method: CheckForNumeric
		/// check for only numbers and backspace key
		/// </summary>
		/// <param name="ch"></param>
		/// <returns></returns>
		static bool CheckForNumeric(char ch)
		{			
			int keyInt = (int)ch ;
			if (( keyInt < 48 || keyInt > 57) &&  keyInt != 8)
				return false;
			else
				return true ;
		}
		
		/// <summary> method: txtXpos_KeyPress
		/// allow only numbers and backspace key
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtXpos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (CheckForNumeric(e.KeyChar) == false)
				e.Handled = true ;	
		}	
	
		/// <summary>method: btnClearInput_Click
		/// clear user input fields
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClearInput_Click(object sender, System.EventArgs e)
		{
			txtXpos.Text = "";
			txtYpos.Text = "";
			txtWidth.Text = "";
			txtHeight.Text = "";		
		}
        
        //Add flag to the panel
        private void btnAddFlag_Click(object sender, EventArgs e)
        {

            // variables required for anyCountry object
            int X, Y, Width;
            int Height = 0;
            
            AnyCountry aCountry;

            bool heightRequired = true; // variable to aid validation of txtHeight field
            bool validInput = false;

            try
            {
                
                // if heightRequired check all fields populated
                if (heightRequired)
                {
                    if ((txtXpos.Text.ToString() == "") ||
                        (txtYpos.Text.ToString() == "") ||
                        (txtWidth.Text.ToString() == "") ||
                        (txtHeight.Text.ToString() == ""))

                        // display error message
                        MessageBox.Show
                            ("Please enter Position and Size", "Required Data Missing",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        // fields populated, if valid input create flag
                        validInput = InputValid(txtXpos.Text.ToString(), txtYpos.Text.ToString(),
                            txtWidth.Text.ToString(), txtHeight.Text.ToString());


                        if (validInput)
                        {
                            X = Convert.ToInt32(txtXpos.Text);
                            Y = Convert.ToInt32(txtYpos.Text);
                            Width = Convert.ToInt32(txtWidth.Text);
                            Height = Convert.ToInt32(txtHeight.Text);

                            
                            if (cmboCountry2.Text.Equals("SriLanka"))
                            {
                                aCountry = new SriLanka("SriLanka", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry2.Text.Equals("India"))
                            {
                                aCountry = new India("India", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry2.Text.Equals("USA"))
                            {
                                aCountry = new USA("USA", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry2.Text.Equals("Canada"))
                            {
                                aCountry = new Canada("Canada", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry2.Text.Equals("Mexico"))
                            {
                                aCountry = new Mexico("Mexico", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry2.Text.Equals("Argentina"))
                            {
                                aCountry = new Argentina("Argentina", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry2.Text.Equals("Brazil"))
                            {
                                aCountry = new Brazil("Brazil", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry2.Text.Equals("UK"))
                            {
                                aCountry = new UK("UK", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }

                            else if (cmboCountry2.Text.Equals("France"))
                            {
                                aCountry = new France("France", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry2.Text.Equals("Australia"))
                            {
                                aCountry = new Australia("Australia", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry2.Text.Equals("NewZealand"))
                            {
                                aCountry = new NewZealand("NewZealand", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry2.Text.Equals("SouthAfrica"))
                            {
                                aCountry = new SouthAfrica("SouthAfrica", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry2.Text.Equals("Zimbabwe"))
                            {
                                aCountry = new Zimbabwe("Zimbabwe", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            } 
                        }
                    }
                }                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "\r\n" + ex.ToString(),
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }			
        }
        //Load the TextView form with selected index zero
        private void TextView_Load(object sender, EventArgs e)
        {
            cmboCountry2.SelectedIndex = 0;
        }

        

        //Method for delete selected flag from the list
        private void deleteSelectedFlag(int x_Position, int y_Position)
        {
            // create arraylist of flags from model and convery
            // to array of flags
            ArrayList theCountryList = myModel.CountryList;
            AnyCountry[] theCountry = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
            // graphics object to draw flags
            Graphics g = this.pnlDrawOn.CreateGraphics();
            // draw all flags in array
            foreach (AnyCountry sh in theCountry)
            {                
                if ((sh.name == "SriLanka") && (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
                else if ((sh.name =="India")&& (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
               
                else if ((sh.name == "USA") && (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
                 
                else if ((sh.name == "Canada") && (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
               
                else if ((sh.name == "Mexico") && (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
                
                else if ((sh.name == "Argentina") && (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
                
                else if ((sh.name == "Brazil") && (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
                
                else if ((sh.name == "UK") && (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
                
                else if ((sh.name == "France") && (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
                
                else if ((sh.name == "Australia") && (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
                
                else if ((sh.name == "NewZealand") && (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
                
                else if ((sh.name == "SouthAfrica") && (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
                
                else if((sh.name == "Zimbabwe") && (sh.x_pos == x_Position) && (sh.y_pos == y_Position))
                {
                    myModel.DeleteCountry(sh);
                    sh.Display(g);
                }
            }
        }

        //Delete button function
        private void btnDeleteFlag_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int index = 0;

                string value = listBox1.GetItemText(listBox1.SelectedItem);

                char[] charArray = value.ToCharArray(); //Convert the list item into char array
                for (int i = 0; i < charArray.Length; i++)
                {
                    //Find the x and y starting position
                    if (charArray[i] == '(')
                    {
                        index = i;
                    }

                }
                string x = value.Substring(index + 1, 3).ToString();
                string y = value.Substring(index + 5, 3).ToString();

                int X_Point = Convert.ToInt32(x);
                int Y_Point = Convert.ToInt32(y);

                if ((value.Contains("Sri Lanka")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }
                else if ((value.Contains("India")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }
                else if ((value.Contains("USA")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }
                else if ((value.Contains("Canada")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }
                else if ((value.Contains("Mexico")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }
                else if ((value.Contains("Argentina")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }
                else if ((value.Contains("Brazil")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }
                else if ((value.Contains("UK")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }
                else if ((value.Contains("France")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }
                else if ((value.Contains("Australia")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }
                else if ((value.Contains("New Zealand")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }
                else if ((value.Contains("South Africa")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }

                else if ((value.Contains("Zimbabwe")) == true)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    deleteSelectedFlag(X_Point, Y_Point);//Delete selected flag                
                }
            }
        }
	}
}
