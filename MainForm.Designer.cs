namespace KBM_88
{
    sealed partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbDcsInstance = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCallsign = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAirframe = new System.Windows.Forms.ComboBox();
            this.cbMap = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbMap = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbAirframe = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbCommon = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbDcsInstance
            // 
            this.cbDcsInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDcsInstance.FormattingEnabled = true;
            this.cbDcsInstance.Location = new System.Drawing.Point(15, 47);
            this.cbDcsInstance.Name = "cbDcsInstance";
            this.cbDcsInstance.Size = new System.Drawing.Size(235, 24);
            this.cbDcsInstance.TabIndex = 0;
            this.cbDcsInstance.SelectedIndexChanged += new System.EventHandler(this.cbDcsInstance_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "DCS Instance:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCallsign);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbAirframe);
            this.groupBox1.Controls.Add(this.cbMap);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbDcsInstance);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 316);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "What and Where";
            // 
            // cbCallsign
            // 
            this.cbCallsign.FormattingEnabled = true;
            this.cbCallsign.Location = new System.Drawing.Point(15, 235);
            this.cbCallsign.Name = "cbCallsign";
            this.cbCallsign.Size = new System.Drawing.Size(235, 24);
            this.cbCallsign.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Callsign:";
            // 
            // cbAirframe
            // 
            this.cbAirframe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAirframe.FormattingEnabled = true;
            this.cbAirframe.Location = new System.Drawing.Point(15, 172);
            this.cbAirframe.Name = "cbAirframe";
            this.cbAirframe.Size = new System.Drawing.Size(235, 24);
            this.cbAirframe.TabIndex = 5;
            this.cbAirframe.SelectedIndexChanged += new System.EventHandler(this.cbAirframe_SelectedIndexChanged);
            // 
            // cbMap
            // 
            this.cbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMap.FormattingEnabled = true;
            this.cbMap.Location = new System.Drawing.Point(15, 109);
            this.cbMap.Name = "cbMap";
            this.cbMap.Size = new System.Drawing.Size(235, 24);
            this.cbMap.TabIndex = 4;
            this.cbMap.SelectedIndexChanged += new System.EventHandler(this.cbMap_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Airframe:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Map:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbMap);
            this.groupBox2.Location = new System.Drawing.Point(274, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 316);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Map Kneeboards";
            // 
            // lbMap
            // 
            this.lbMap.CheckOnClick = true;
            this.lbMap.FormattingEnabled = true;
            this.lbMap.Location = new System.Drawing.Point(6, 21);
            this.lbMap.Name = "lbMap";
            this.lbMap.Size = new System.Drawing.Size(160, 293);
            this.lbMap.TabIndex = 0;
            this.lbMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbMap_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbAirframe);
            this.groupBox3.Location = new System.Drawing.Point(452, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 316);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Airframe Kneeboards";
            // 
            // lbAirframe
            // 
            this.lbAirframe.CheckOnClick = true;
            this.lbAirframe.FormattingEnabled = true;
            this.lbAirframe.Location = new System.Drawing.Point(6, 21);
            this.lbAirframe.Name = "lbAirframe";
            this.lbAirframe.Size = new System.Drawing.Size(160, 293);
            this.lbAirframe.TabIndex = 1;
            this.lbAirframe.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbAirframe_MouseUp);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe Script", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button1.Location = new System.Drawing.Point(274, 331);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(528, 41);
            this.button1.TabIndex = 5;
            this.button1.Text = "Launch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "DCS.EXE|dcs.exe";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.ReadOnlyChecked = true;
            this.openFileDialog1.Title = "Select DCS Installation";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.openFolderToolStripMenuItem, this.toolStripSeparator1, this.renameToolStripMenuItem, this.toolStripSeparator2, this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 88);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.newCategoryToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(181, 28);
            // 
            // newCategoryToolStripMenuItem
            // 
            this.newCategoryToolStripMenuItem.Name = "newCategoryToolStripMenuItem";
            this.newCategoryToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.newCategoryToolStripMenuItem.Text = "New Category...";
            this.newCategoryToolStripMenuItem.Click += new System.EventHandler(this.newCategoryToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbCommon);
            this.groupBox4.Location = new System.Drawing.Point(630, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(172, 316);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Common Kneeboards";
            // 
            // lbCommon
            // 
            this.lbCommon.CheckOnClick = true;
            this.lbCommon.FormattingEnabled = true;
            this.lbCommon.Location = new System.Drawing.Point(6, 21);
            this.lbCommon.Name = "lbCommon";
            this.lbCommon.Size = new System.Drawing.Size(160, 293);
            this.lbCommon.TabIndex = 1;
            this.lbCommon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbCommon_MouseUp);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe Script", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button2.Location = new System.Drawing.Point(12, 331);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(256, 41);
            this.button2.TabIndex = 6;
            this.button2.Text = "Apply Without Launch";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 375);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Kneeboard Manager";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox lbCommon;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem newCategoryToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private System.Windows.Forms.ComboBox cbCallsign;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox lbAirframe;
        private System.Windows.Forms.CheckedListBox lbMap;

        private System.Windows.Forms.ComboBox cbAirframe;
        private System.Windows.Forms.ComboBox cbMap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.ComboBox cbDcsInstance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}