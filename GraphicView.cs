using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace MVC_CountryFlags
{
	/// <summary>
	/// Summary description for ViewForm1.
	/// </summary>
    public class GraphicView : System.Windows.Forms.Form, ICountryView
	{
		private CountryModel myModel;

		bool dragging;
		AnyCountry topCountry; //  variable for selected country flag
		AnyCountry editCountry; // variable for country flag to edit
        BinaryFormatter binFor;

        

		// variables for max values of parameters input by user
		int max_X = 425;
		int max_Y = 325;
		int max_width = 50;
		int max_height = 50;		
		
		// variables for mouse position
		Point lastPosition = new Point (0,0);
		Point currentPosition = new Point (0,0);

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
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem mnuDelete;
		private System.Windows.Forms.MenuItem mnuFront;
		private System.Windows.Forms.MenuItem mnuBack;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mnuCancel;
		private System.Windows.Forms.Panel pnlUpdate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox txtUpdateHeight;
        private System.Windows.Forms.TextBox txtUpdateWidth;
		private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label lblSelectedFlag;
		private System.Windows.Forms.Button btnClearInput;
        private System.Windows.Forms.MenuItem menuItem2;
        private ComboBox cmboCountry;
        private Label label8;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem newToolStripMenuItem1;
        private ToolStripMenuItem openToolStripMenuItem1;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private MenuStrip mainMenu;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuItemNew;
        private ToolStripMenuItem mnuItemOpen;
        private ToolStripMenuItem mnuItemSave;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem mnuItemExit;
		private System.ComponentModel.IContainer components;

		public GraphicView()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            //Form size
            this.Width = 634;
            this.Height = 587;

            //Update panel position
            pnlUpdate.Top = 420;
            pnlUpdate.Left = 35;

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
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mnuEdit = new System.Windows.Forms.MenuItem();
            this.mnuDelete = new System.Windows.Forms.MenuItem();
            this.mnuFront = new System.Windows.Forms.MenuItem();
            this.mnuBack = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuCancel = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.pnlUpdate = new System.Windows.Forms.Panel();
            this.lblSelectedFlag = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtUpdateHeight = new System.Windows.Forms.TextBox();
            this.txtUpdateWidth = new System.Windows.Forms.TextBox();
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
            this.cmboCountry = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDrawOn = new System.Windows.Forms.Panel();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlUpdate.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuEdit,
            this.mnuDelete,
            this.mnuFront,
            this.mnuBack,
            this.menuItem1,
            this.mnuCancel,
            this.menuItem2});
            // 
            // mnuEdit
            // 
            this.mnuEdit.Index = 0;
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Index = 1;
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuFront
            // 
            this.mnuFront.Index = 2;
            this.mnuFront.Text = "Bring to Front";
            this.mnuFront.Click += new System.EventHandler(this.mnuFront_Click);
            // 
            // mnuBack
            // 
            this.mnuBack.Index = 3;
            this.mnuBack.Text = "Send to Back";
            this.mnuBack.Click += new System.EventHandler(this.mnuBack_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 4;
            this.menuItem1.Text = "----------------";
            // 
            // mnuCancel
            // 
            this.mnuCancel.Index = 5;
            this.mnuCancel.Text = "Cancel";
            this.mnuCancel.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 6;
            this.menuItem2.Text = "Refresh";
            this.menuItem2.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // pnlUpdate
            // 
            this.pnlUpdate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlUpdate.Controls.Add(this.lblSelectedFlag);
            this.pnlUpdate.Controls.Add(this.btnCancel);
            this.pnlUpdate.Controls.Add(this.btnUpdate);
            this.pnlUpdate.Controls.Add(this.label4);
            this.pnlUpdate.Controls.Add(this.label18);
            this.pnlUpdate.Controls.Add(this.label19);
            this.pnlUpdate.Controls.Add(this.txtUpdateHeight);
            this.pnlUpdate.Controls.Add(this.txtUpdateWidth);
            this.pnlUpdate.Location = new System.Drawing.Point(35, 528);
            this.pnlUpdate.Name = "pnlUpdate";
            this.pnlUpdate.Size = new System.Drawing.Size(542, 128);
            this.pnlUpdate.TabIndex = 21;
            this.pnlUpdate.Visible = false;
            // 
            // lblSelectedFlag
            // 
            this.lblSelectedFlag.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFlag.Location = new System.Drawing.Point(0, 14);
            this.lblSelectedFlag.Name = "lblSelectedFlag";
            this.lblSelectedFlag.Size = new System.Drawing.Size(539, 24);
            this.lblSelectedFlag.TabIndex = 26;
            this.lblSelectedFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(399, 46);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 32);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(399, 84);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(136, 32);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Update Flag";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "Size:-";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(255, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 24);
            this.label18.TabIndex = 19;
            this.label18.Text = "Heigth:";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(106, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 24);
            this.label19.TabIndex = 18;
            this.label19.Text = "Width:";
            // 
            // txtUpdateHeight
            // 
            this.txtUpdateHeight.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpdateHeight.Location = new System.Drawing.Point(327, 43);
            this.txtUpdateHeight.Name = "txtUpdateHeight";
            this.txtUpdateHeight.Size = new System.Drawing.Size(40, 27);
            this.txtUpdateHeight.TabIndex = 17;
            this.txtUpdateHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtUpdateHeight, "Maximum Height is 50");
            this.txtUpdateHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXpos_KeyPress);
            // 
            // txtUpdateWidth
            // 
            this.txtUpdateWidth.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpdateWidth.Location = new System.Drawing.Point(178, 43);
            this.txtUpdateWidth.Name = "txtUpdateWidth";
            this.txtUpdateWidth.Size = new System.Drawing.Size(40, 27);
            this.txtUpdateWidth.TabIndex = 16;
            this.toolTip1.SetToolTip(this.txtUpdateWidth, "Maximum Width is 50");
            this.txtUpdateWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXpos_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(162, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Position";
            // 
            // txtXpos
            // 
            this.txtXpos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXpos.Location = new System.Drawing.Point(194, 452);
            this.txtXpos.Name = "txtXpos";
            this.txtXpos.Size = new System.Drawing.Size(40, 27);
            this.txtXpos.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtXpos, "Maximum value for X is 425");
            this.txtXpos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXpos_KeyPress);
            // 
            // txtYpos
            // 
            this.txtYpos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYpos.Location = new System.Drawing.Point(194, 484);
            this.txtYpos.Name = "txtYpos";
            this.txtYpos.Size = new System.Drawing.Size(40, 27);
            this.txtYpos.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtYpos, "Maximum value for Y is 325");
            this.txtYpos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXpos_KeyPress);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(162, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(162, 484);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Y:";
            // 
            // lblHeight
            // 
            this.lblHeight.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.Location = new System.Drawing.Point(262, 489);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(80, 24);
            this.lblHeight.TabIndex = 14;
            this.lblHeight.Text = "Heigth:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(262, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Width:";
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(348, 487);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(40, 27);
            this.txtHeight.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtHeight, "Maximum Height is 50");
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXpos_KeyPress);
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(348, 448);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(40, 27);
            this.txtWidth.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtWidth, "Maximum Width is 50");
            this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXpos_KeyPress);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(262, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "Size";
            // 
            // btnAddFlag
            // 
            this.btnAddFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddFlag.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFlag.Location = new System.Drawing.Point(433, 482);
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
            this.btnClearInput.Location = new System.Drawing.Point(433, 444);
            this.btnClearInput.Name = "btnClearInput";
            this.btnClearInput.Size = new System.Drawing.Size(136, 32);
            this.btnClearInput.TabIndex = 20;
            this.btnClearInput.Text = "Clear Input";
            this.btnClearInput.UseVisualStyleBackColor = false;
            this.btnClearInput.Click += new System.EventHandler(this.btnClearInput_Click);
            // 
            // cmboCountry
            // 
            this.cmboCountry.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboCountry.FormattingEnabled = true;
            this.cmboCountry.Location = new System.Drawing.Point(35, 452);
            this.cmboCountry.Name = "cmboCountry";
            this.cmboCountry.Size = new System.Drawing.Size(121, 27);
            this.cmboCountry.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(38, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 24);
            this.label8.TabIndex = 25;
            this.label8.Text = "Country";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "dat";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "\"Dat files (*.dat)|*.dat|All files (*.*)|*.*\"";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "dat";
            this.openFileDialog1.Filter = "\"Dat files (*.dat)|*.dat|All files (*.*)|*.*\"";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // pnlDrawOn
            // 
            this.pnlDrawOn.BackColor = System.Drawing.Color.White;
            this.pnlDrawOn.BackgroundImage = global::MVC_CountryFlags.Properties.Resources.worldMap;
            this.pnlDrawOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlDrawOn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDrawOn.ContextMenu = this.contextMenu1;
            this.pnlDrawOn.Location = new System.Drawing.Point(12, 27);
            this.pnlDrawOn.Name = "pnlDrawOn";
            this.pnlDrawOn.Size = new System.Drawing.Size(614, 380);
            this.pnlDrawOn.TabIndex = 0;
            this.pnlDrawOn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDrawOn__MouseDown);
            this.pnlDrawOn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDrawOn_MouseMove);
            this.pnlDrawOn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDrawOn__MouseUp);
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem1.Text = "New";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem1.Text = "Open";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem1.Text = "Exits";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(628, 24);
            this.mainMenu.TabIndex = 26;
            this.mainMenu.Text = "mainMenu";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemNew,
            this.mnuItemOpen,
            this.mnuItemSave,
            this.toolStripSeparator3,
            this.mnuItemExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuItemNew
            // 
            this.mnuItemNew.Name = "mnuItemNew";
            this.mnuItemNew.Size = new System.Drawing.Size(103, 22);
            this.mnuItemNew.Text = "New";
            this.mnuItemNew.Click += new System.EventHandler(this.mnuItemNew_Click);
            // 
            // mnuItemOpen
            // 
            this.mnuItemOpen.Name = "mnuItemOpen";
            this.mnuItemOpen.Size = new System.Drawing.Size(103, 22);
            this.mnuItemOpen.Text = "Open";
            this.mnuItemOpen.Click += new System.EventHandler(this.mnuItemOpen_Click);
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.Size = new System.Drawing.Size(103, 22);
            this.mnuItemSave.Text = "Save";
            this.mnuItemSave.Click += new System.EventHandler(this.mnuItemSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(100, 6);
            // 
            // mnuItemExit
            // 
            this.mnuItemExit.Name = "mnuItemExit";
            this.mnuItemExit.Size = new System.Drawing.Size(103, 22);
            this.mnuItemExit.Text = "Exit";
            this.mnuItemExit.Click += new System.EventHandler(this.mnuItemExit_Click);
            // 
            // GraphicView
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(628, 668);
            this.Controls.Add(this.pnlUpdate);
            this.Controls.Add(this.pnlDrawOn);
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
            this.Controls.Add(this.cmboCountry);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "GraphicView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ViewForm1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GraphicView_Load);
            this.pnlUpdate.ResumeLayout(false);
            this.pnlUpdate.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
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

		
		/// <summary> method: RefreshView
		/// clears the listBox displays all the countries in the countryModel
		/// </summary>
		public void RefreshView()
		{
			// clear drawOn panel
			clearPanel();
			// create arrayList from model and convert to array of country
            ArrayList theCountryList = myModel.CountryList;
            AnyCountry[] theCountries = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
			Graphics g = this.pnlDrawOn.CreateGraphics(); 
			// draw all countries in array
            foreach (AnyCountry sh in theCountries)
			{				
				sh.Display(g);
                
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


		/// <summary>method: pnlDrawOn__MouseDown
		/// check if mouse is over flag and sets sets variable to 
		/// enable flag to be moved
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pnlDrawOn__MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(topCountry!= null)	
				dragging = true;			
		}

		/// <summary>method: pnlDrawOn__MouseUp
		/// method to stop dragging of flag
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pnlDrawOn__MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dragging = false;
			// clear drawOn panel
			clearPanel();
			// create arrayList of countries from model and convert to array of countries
            ArrayList theCountryList = myModel.CountryList;
            AnyCountry[] theCountries = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));			
			// graphics object to draw selected country
			Graphics g = this.pnlDrawOn.CreateGraphics(); 

			// check if flag is selected and if so display
			if (topCountry !=null)
			{
                theCountries[0] = topCountry;
                topCountry.Display(g);
                
			}
			myModel.UpdateViews();
		}

		/// <summary> method: pnlDrawOn_MouseMove
		/// when mouse moves it checks if mouse is down and/or over flag 
		/// If mouse is down and over flag draws border around flag and 
		/// sets new position for flag based on how far mouse has moved.
		/// If mouse is up and over flag, draw border around flag.
		/// If mouse if down and not over flag, do nothing.		
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pnlDrawOn_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// set last position to current position
			lastPosition = currentPosition;
			// set current position to mouse position
			currentPosition = new Point (e.X, e.Y);	
			// calculate how far mouse has moved 
			int xMove = currentPosition.X - lastPosition.X;		
			int yMove = currentPosition.Y - lastPosition.Y;
                                                     
			if (!dragging) // mouse not down 
			{				
				// reset variables 
                topCountry = null; 
				bool needsDisplay = false; 

				// create arrayList of countries from myModel
				ArrayList theCountryList = myModel.CountryList;
				// create array of countries from array list
                AnyCountry[] theCountries = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
				// graphics object to draw countries when required
				Graphics g = this.pnlDrawOn.CreateGraphics(); 
				
				// loop through array checking if mouse is over country
				foreach (AnyCountry s in theCountries)
				{
					// check if mouse is over country
					if (s.HitTest(new Point(e.X, e.Y)))
					{
						// if so make flag topCountry
						topCountry = s; 
					}

					if(s.Highlight == true) 
					{
						// country to be redrawn
						needsDisplay = true;
						// redraw country
						s.Display(g);
                        
						s.Highlight = false;
					}
					
				}
				
				if(topCountry != null) // if there is a topCountry
				{
					needsDisplay = true; // need to redisplay
                    topCountry.Display(g); // redisplay topCountry		

                    topCountry.Highlight = true;
				}

				if (needsDisplay)
				{
					// redisplay model
					myModel.UpdateViews();
				}
			}
			else // mouse is down
			{
				// reset position of selected flag by value of mouse move 
                topCountry.x_pos = topCountry.x_pos + xMove;
                topCountry.y_pos = topCountry.y_pos + yMove;

				myModel.UpdateViews();
			}	
		}

		/// <summary>method: mnuEdit_Click
		/// displays the update panel and prompts the user to 
		/// enter new values
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuEdit_Click(object sender, System.EventArgs e)
		{
            if (topCountry != null)
			{
				// message to user to enter new size and colour
                MessageBox.Show("You May Update Flag Size only" + "\r\n",
                    "Enter new values and click the Update button", 
					MessageBoxButtons.OK,MessageBoxIcon.Information);				

				// make editCountry the current topCountry 
                editCountry = topCountry;

				// update values in update panel to selected flag
				lblSelectedFlag.Text = topCountry.ToString();

                txtUpdateWidth.Text = topCountry.flag_width.ToString();
                txtUpdateHeight.Text = topCountry.flag_height.ToString();

				
				txtUpdateHeight.Enabled = true;
                txtUpdateHeight.Text = topCountry.flag_height.ToString();

				pnlUpdate.Show();	
	
			}
			myModel.UpdateViews();
		}

		/// <summary>method: mnuDelete_Click
		/// delete selected flag and redisplay flags remaiing in model
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuDelete_Click(object sender, System.EventArgs e)
		{
			// check is topCountry has a value, if so delete
            if (topCountry != null)
			{
				// clear panel
				clearPanel();
				// delete selected flag and redisplay remaining flags
                myModel.DeleteCountry(topCountry);
			}
			myModel.UpdateViews();
		}

		/// <summary>  method: mnuBack_Click
		/// get selected flag displayed behind other flags  
		/// all flags
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuBack_Click(object sender, System.EventArgs e)
		{
            if (topCountry != null) // if flag selcted
			{
				clearPanel();
				// resort arrayList to get selected flag drawn first and redisplay
                myModel.SendToBack(topCountry);				
			}	
			myModel.UpdateViews();
		}

		/// <summary>method: mnuFront_Click
		/// get selected flag displayed in front of other flags
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuFront_Click(object sender, System.EventArgs e)
		{
            if (topCountry != null) // if flag selcted
			{
				clearPanel();
				// resort arrayList to get selected flag drawn last and rdisplay
                myModel.BringToFront(topCountry);
			}	
			myModel.UpdateViews();
		}

		/// <summary> method: mnuCancel_Click
		/// do nothing when user selects cancel menu option
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuCancel_Click(object sender, System.EventArgs e)
		{
			// refresh view
			myModel.UpdateViews();
		}

		/// <summary>method: btnCancel_Click
		/// hide the update panel without updating flag
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			pnlUpdate.Hide();
		}

		/// <summary>method: clearPanel
		/// clear all flags from display on panel
		/// </summary>
		private void clearPanel()
		{
			//This code help to redraw the panel without flickering the image  
            pnlDrawOn.Refresh();                    
		}

		/// <summary>method: btnUpdate_Click
		/// update selected flag with values entered by user 
		/// and redisplay all flags
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			// clear draw on panel
			clearPanel();

			// local variables for updates to selected flag
			int Width;
			int Height = 0;		

			// get updated attributes for selected flag						
			Width = Convert.ToInt32(txtUpdateWidth.Text);
			if (txtUpdateHeight.Text.Length > 0)
				Height = Convert.ToInt32(txtUpdateHeight.Text);				
			// check new values are within limits
			if ((Width > max_width)||(Height > max_height))
				MessageBox.Show("Maximum value for Width is " + max_width 
					+ "\r\n" +	"Maximum value for Height is " + max_height,
					"Please Check the Values Entered", 
					MessageBoxButtons.OK,MessageBoxIcon.Error);
			else
			{
				// update flag attributes
				editCountry.flag_width = Width;	
				if (txtUpdateHeight.Text.Length > 0)
				{					
					editCountry.flag_height = Height;
				}			
			
				// redisplay
				myModel.UpdateViews();
				pnlUpdate.Hide();
			}
		}

		/// <summary>method: reDisplay
		/// redraws all the flags in the model
		/// </summary>
		public void reDisplay()
		{
			ArrayList theCountryList = myModel.CountryList;
            AnyCountry[] theCountries = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
			Graphics g = this.pnlDrawOn.CreateGraphics();			
			foreach (AnyCountry sh in theCountries)
			{					
				sh.Display(g);
               
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

        //Graphic view load the all the countries to the drop down list
        private void GraphicView_Load(object sender, EventArgs e)
        {
            cmboCountry.Items.Add("SriLanka");
            cmboCountry.Items.Add("India");
            cmboCountry.Items.Add("USA");
            cmboCountry.Items.Add("Canada");
            cmboCountry.Items.Add("Mexico");
            cmboCountry.Items.Add("Argentina");
            cmboCountry.Items.Add("Brazil");
            cmboCountry.Items.Add("UK");
            cmboCountry.Items.Add("France");
            cmboCountry.Items.Add("Australia");
            cmboCountry.Items.Add("NewZealand");
            cmboCountry.Items.Add("SouthAfrica");
            cmboCountry.Items.Add("Zimbabwe");

            binFor = new BinaryFormatter();
          
        }

        //Add flag button click listener
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

                            if (cmboCountry.Text.Equals("SriLanka"))
                            {
                                aCountry = new SriLanka("SriLanka", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);

                            }
                            else if (cmboCountry.Text.Equals("India"))
                            {
                                aCountry = new India("India", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }

                            else if (cmboCountry.Text.Equals("USA"))
                            {
                                aCountry = new USA("USA", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry.Text.Equals("Canada"))
                            {
                                aCountry = new Canada("Canada", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry.Text.Equals("Mexico"))
                            {
                                aCountry = new Mexico("Mexico", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry.Text.Equals("Argentina"))
                            {
                                aCountry = new Argentina("Argentina", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry.Text.Equals("Brazil"))
                            {
                                aCountry = new Brazil("Brazil", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry.Text.Equals("UK"))
                            {
                                aCountry = new UK("UK", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry.Text.Equals("France"))
                            {
                                aCountry = new France("France", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry.Text.Equals("Australia"))
                            {
                                aCountry = new Australia("Australia", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }

                            else if (cmboCountry.Text.Equals("NewZealand"))
                            {
                                aCountry = new NewZealand("NewZealand", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry.Text.Equals("SouthAfrica"))
                            {
                                aCountry = new SouthAfrica("SouthAfrica", X, Y, Width, Height);
                                myModel.AddCountry(aCountry);
                            }
                            else if (cmboCountry.Text.Equals("Zimbabwe"))
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

        //Save flag as binary file
        private void mnuItemSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Thread thread = new Thread(new ThreadStart(ThreadJob));            
                thread.Start();
            }

        }

        //Thread job method
        void ThreadJob()
        {
           
                FileInfo finfo = new FileInfo(saveFileDialog1.FileName);
                Stream strm;
                strm = finfo.Open(FileMode.Create, FileAccess.ReadWrite);
                ArrayList theCountryList = myModel.CountryList;
                AnyCountry[] theCountries = (AnyCountry[])theCountryList.ToArray(typeof(AnyCountry));
                foreach (AnyCountry cp in theCountries)
                {
                    binFor.Serialize(strm, cp);
                }

                strm.Close();            

        }



        //Open saved binary file
        private void mnuItemOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ArrayList theCountryList = myModel.CountryList;
                theCountryList.Clear(); //should really ask if they want to save first
                FileInfo finfo = new FileInfo(openFileDialog1.FileName);
                Stream strm = finfo.Open(FileMode.Open);
                while (strm.Position != strm.Length)
                {
                    theCountryList.Add(binFor.Deserialize(strm));
                }
                strm.Close();
                this.Invalidate();
            }
        }

        //Open new one
        private void mnuItemNew_Click(object sender, EventArgs e)
        {
            ArrayList theCountryList = myModel.CountryList;
            theCountryList.Clear();
            this.Invalidate();
        }

        //Close the window from the menu
        private void mnuItemExit_Click(object sender, EventArgs e)
        {
            Close();            
        }       
    }
}
