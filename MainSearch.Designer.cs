namespace VisualSearch
{
    partial class MainSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSearch));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFind = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSelDir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbRegex = new System.Windows.Forms.RadioButton();
            this.rbExtended = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSub = new System.Windows.Forms.CheckBox();
            this.chkCase = new System.Windows.Forms.CheckBox();
            this.chkWhole = new System.Windows.Forms.CheckBox();
            this.cmbDirectory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbExclude = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFilters = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.grdResults = new System.Windows.Forms.DataGridView();
            this.barSearch = new System.Windows.Forms.ProgressBar();
            this.wrkSearch = new System.ComponentModel.BackgroundWorker();
            this.fileSelDir = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Find What:";
            // 
            // cmbFind
            // 
            this.cmbFind.BackColor = System.Drawing.Color.Black;
            this.cmbFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFind.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cmbFind.FormattingEnabled = true;
            this.cmbFind.Location = new System.Drawing.Point(62, 7);
            this.cmbFind.Name = "cmbFind";
            this.cmbFind.Size = new System.Drawing.Size(223, 22);
            this.cmbFind.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.chkTopMost);
            this.panel1.Controls.Add(this.chkDebug);
            this.panel1.Controls.Add(this.txtDebug);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnSelDir);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cmbDirectory);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbExclude);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbFilters);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbFind);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 245);
            this.panel1.TabIndex = 0;
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTopMost.Location = new System.Drawing.Point(69, 215);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(65, 17);
            this.chkTopMost.TabIndex = 12;
            this.chkTopMost.Text = "TopMost";
            this.chkTopMost.UseVisualStyleBackColor = true;
            this.chkTopMost.CheckedChanged += new System.EventHandler(this.chkTopMost_CheckedChanged);
            // 
            // chkDebug
            // 
            this.chkDebug.AutoSize = true;
            this.chkDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDebug.Location = new System.Drawing.Point(7, 215);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(55, 17);
            this.chkDebug.TabIndex = 11;
            this.chkDebug.Text = "Debug";
            this.chkDebug.UseVisualStyleBackColor = true;
            // 
            // txtDebug
            // 
            this.txtDebug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDebug.BackColor = System.Drawing.Color.Black;
            this.txtDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDebug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtDebug.Location = new System.Drawing.Point(291, 7);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(309, 235);
            this.txtDebug.TabIndex = 15;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(159, 213);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 21);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(225, 213);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 21);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSelDir
            // 
            this.btnSelDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelDir.Location = new System.Drawing.Point(258, 88);
            this.btnSelDir.Name = "btnSelDir";
            this.btnSelDir.Size = new System.Drawing.Size(27, 21);
            this.btnSelDir.TabIndex = 8;
            this.btnSelDir.Text = "...";
            this.btnSelDir.UseVisualStyleBackColor = true;
            this.btnSelDir.Click += new System.EventHandler(this.btnSelDir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbRegex);
            this.groupBox2.Controls.Add(this.rbExtended);
            this.groupBox2.Controls.Add(this.rbNormal);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(180, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(105, 92);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search mode";
            // 
            // rbRegex
            // 
            this.rbRegex.AutoSize = true;
            this.rbRegex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbRegex.Location = new System.Drawing.Point(7, 66);
            this.rbRegex.Name = "rbRegex";
            this.rbRegex.Size = new System.Drawing.Size(55, 17);
            this.rbRegex.TabIndex = 2;
            this.rbRegex.Text = "Re&gex";
            this.rbRegex.UseVisualStyleBackColor = true;
            // 
            // rbExtended
            // 
            this.rbExtended.AutoSize = true;
            this.rbExtended.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbExtended.Location = new System.Drawing.Point(7, 43);
            this.rbExtended.Name = "rbExtended";
            this.rbExtended.Size = new System.Drawing.Size(69, 17);
            this.rbExtended.TabIndex = 1;
            this.rbExtended.Text = "E&xtended";
            this.rbExtended.UseVisualStyleBackColor = true;
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbNormal.Location = new System.Drawing.Point(7, 20);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(57, 17);
            this.rbNormal.TabIndex = 0;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "&Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSub);
            this.groupBox1.Controls.Add(this.chkCase);
            this.groupBox1.Controls.Add(this.chkWhole);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(62, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(105, 92);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // chkSub
            // 
            this.chkSub.AutoSize = true;
            this.chkSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSub.Location = new System.Drawing.Point(7, 66);
            this.chkSub.Name = "chkSub";
            this.chkSub.Size = new System.Drawing.Size(88, 17);
            this.chkSub.TabIndex = 2;
            this.chkSub.Text = "All su&b-folders";
            this.chkSub.UseVisualStyleBackColor = true;
            // 
            // chkCase
            // 
            this.chkCase.AutoSize = true;
            this.chkCase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCase.Location = new System.Drawing.Point(7, 43);
            this.chkCase.Name = "chkCase";
            this.chkCase.Size = new System.Drawing.Size(91, 17);
            this.chkCase.TabIndex = 1;
            this.chkCase.Text = "&Case sensitive";
            this.chkCase.UseVisualStyleBackColor = true;
            // 
            // chkWhole
            // 
            this.chkWhole.AutoSize = true;
            this.chkWhole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkWhole.Location = new System.Drawing.Point(7, 20);
            this.chkWhole.Name = "chkWhole";
            this.chkWhole.Size = new System.Drawing.Size(80, 17);
            this.chkWhole.TabIndex = 0;
            this.chkWhole.Text = "&Whole word";
            this.chkWhole.UseVisualStyleBackColor = true;
            // 
            // cmbDirectory
            // 
            this.cmbDirectory.BackColor = System.Drawing.Color.Black;
            this.cmbDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDirectory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cmbDirectory.FormattingEnabled = true;
            this.cmbDirectory.Location = new System.Drawing.Point(62, 88);
            this.cmbDirectory.Name = "cmbDirectory";
            this.cmbDirectory.Size = new System.Drawing.Size(194, 22);
            this.cmbDirectory.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Directory:";
            // 
            // cmbExclude
            // 
            this.cmbExclude.BackColor = System.Drawing.Color.Black;
            this.cmbExclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbExclude.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExclude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cmbExclude.FormattingEnabled = true;
            this.cmbExclude.Location = new System.Drawing.Point(62, 61);
            this.cmbExclude.Name = "cmbExclude";
            this.cmbExclude.Size = new System.Drawing.Size(223, 22);
            this.cmbExclude.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Exclude:";
            // 
            // cmbFilters
            // 
            this.cmbFilters.BackColor = System.Drawing.Color.Black;
            this.cmbFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilters.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cmbFilters.FormattingEnabled = true;
            this.cmbFilters.Location = new System.Drawing.Point(62, 34);
            this.cmbFilters.Name = "cmbFilters";
            this.cmbFilters.Size = new System.Drawing.Size(223, 22);
            this.cmbFilters.TabIndex = 3;
            this.cmbFilters.Text = "*.*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filte&rs:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblSearch);
            this.panel2.Controls.Add(this.grdResults);
            this.panel2.Controls.Add(this.barSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 245);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(612, 197);
            this.panel2.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 37);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(19, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "-_-";
            // 
            // grdResults
            // 
            this.grdResults.AllowUserToAddRows = false;
            this.grdResults.AllowUserToDeleteRows = false;
            this.grdResults.AllowUserToOrderColumns = true;
            this.grdResults.AllowUserToResizeRows = false;
            this.grdResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdResults.BackgroundColor = System.Drawing.Color.Black;
            this.grdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResults.Location = new System.Drawing.Point(6, 61);
            this.grdResults.MultiSelect = false;
            this.grdResults.Name = "grdResults";
            this.grdResults.ReadOnly = true;
            this.grdResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdResults.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.grdResults.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResults.Size = new System.Drawing.Size(594, 124);
            this.grdResults.TabIndex = 2;
            this.grdResults.DoubleClick += new System.EventHandler(this.grdResults_DoubleClick);
            // 
            // barSearch
            // 
            this.barSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.barSearch.Location = new System.Drawing.Point(4, 7);
            this.barSearch.Name = "barSearch";
            this.barSearch.Size = new System.Drawing.Size(596, 23);
            this.barSearch.TabIndex = 0;
            // 
            // wrkSearch
            // 
            this.wrkSearch.WorkerReportsProgress = true;
            this.wrkSearch.WorkerSupportsCancellation = true;
            this.wrkSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wrkSearch_DoWork);
            this.wrkSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wrkSearch_RunWorkerCompleted);
            this.wrkSearch.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.wrkSearch_ProgressChanged);
            // 
            // fileSelDir
            // 
            this.fileSelDir.CheckFileExists = false;
            this.fileSelDir.CheckPathExists = false;
            this.fileSelDir.Filter = "folders|*.neverseenthisfile";
            this.fileSelDir.ValidateNames = false;
            // 
            // MainSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(612, 442);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Visual Search";
            this.Deactivate += new System.EventHandler(this.MainSearch_Deactivate);
            this.Load += new System.EventHandler(this.MainSearch_Load);
            this.Activated += new System.EventHandler(this.MainSearch_Activated);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFind;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbExclude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFilters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSub;
        private System.Windows.Forms.CheckBox chkCase;
        private System.Windows.Forms.CheckBox chkWhole;
        private System.Windows.Forms.Button btnSelDir;
        private System.Windows.Forms.RadioButton rbRegex;
        private System.Windows.Forms.RadioButton rbExtended;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar barSearch;
        private System.Windows.Forms.CheckBox chkDebug;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.DataGridView grdResults;
        private System.ComponentModel.BackgroundWorker wrkSearch;
        private System.Windows.Forms.OpenFileDialog fileSelDir;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.CheckBox chkTopMost;
    }
}