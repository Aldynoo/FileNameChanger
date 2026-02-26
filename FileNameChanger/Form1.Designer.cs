namespace FileNameChanger
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnClick = new Button();
            label1 = new Label();
            txtPath = new TextBox();
            label2 = new Label();
            txtRename = new TextBox();
            label3 = new Label();
            chkRename = new CheckBox();
            btnRename = new Button();
            btnSave = new Button();
            dgvFormat = new DataGridView();
            fbd = new FolderBrowserDialog();
            lblIf = new Label();
            txtIf = new TextBox();
            btnSaveAll = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFormat).BeginInit();
            SuspendLayout();
            // 
            // btnClick
            // 
            btnClick.Location = new Point(344, 52);
            btnClick.Name = "btnClick";
            btnClick.Size = new Size(71, 23);
            btnClick.TabIndex = 0;
            btnClick.Text = "Click here!";
            btnClick.UseVisualStyleBackColor = true;
            btnClick.Click += btnClick_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 22);
            label1.Name = "label1";
            label1.Size = new Size(163, 15);
            label1.TabIndex = 1;
            label1.Text = "Specify the path to the folder:";
            // 
            // txtPath
            // 
            txtPath.BackColor = SystemColors.ControlLightLight;
            txtPath.Location = new Point(61, 52);
            txtPath.Name = "txtPath";
            txtPath.ReadOnly = true;
            txtPath.Size = new Size(277, 23);
            txtPath.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(631, 22);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 3;
            label2.Text = "Rename to:";
            // 
            // txtRename
            // 
            txtRename.BackColor = SystemColors.ControlLightLight;
            txtRename.Location = new Point(704, 19);
            txtRename.Name = "txtRename";
            txtRename.Size = new Size(304, 23);
            txtRename.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(631, 55);
            label3.Name = "label3";
            label3.Size = new Size(163, 15);
            label3.TabIndex = 5;
            label3.Text = "Rename all in current format?";
            // 
            // chkRename
            // 
            chkRename.AutoSize = true;
            chkRename.Location = new Point(809, 54);
            chkRename.Name = "chkRename";
            chkRename.Size = new Size(81, 19);
            chkRename.TabIndex = 6;
            chkRename.Text = "Tick if Yes!";
            chkRename.UseVisualStyleBackColor = true;
            chkRename.CheckedChanged += chkRename_CheckedChanged;
            // 
            // btnRename
            // 
            btnRename.Location = new Point(330, 415);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(113, 23);
            btnRename.TabIndex = 7;
            btnRename.Text = "Rename / Preview";
            btnRename.UseVisualStyleBackColor = true;
            btnRename.Click += btnRename_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(498, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(113, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save all";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dgvFormat
            // 
            dgvFormat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormat.Location = new Point(61, 109);
            dgvFormat.Name = "dgvFormat";
            dgvFormat.Size = new Size(947, 300);
            dgvFormat.TabIndex = 9;
            // 
            // lblIf
            // 
            lblIf.AutoSize = true;
            lblIf.Location = new Point(631, 83);
            lblIf.Name = "lblIf";
            lblIf.Size = new Size(195, 15);
            lblIf.TabIndex = 10;
            lblIf.Text = "Which part do you want to change?";
            lblIf.Visible = false;
            // 
            // txtIf
            // 
            txtIf.BackColor = SystemColors.ControlLightLight;
            txtIf.Location = new Point(832, 80);
            txtIf.Name = "txtIf";
            txtIf.Size = new Size(176, 23);
            txtIf.TabIndex = 11;
            txtIf.Visible = false;
            // 
            // btnSaveAll
            // 
            btnSaveAll.Location = new Point(665, 415);
            btnSaveAll.Name = "btnSaveAll";
            btnSaveAll.Size = new Size(113, 23);
            btnSaveAll.TabIndex = 12;
            btnSaveAll.Text = "Save all";
            btnSaveAll.UseVisualStyleBackColor = true;
            btnSaveAll.Click += btnSaveAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 450);
            Controls.Add(btnSaveAll);
            Controls.Add(txtIf);
            Controls.Add(lblIf);
            Controls.Add(dgvFormat);
            Controls.Add(btnSave);
            Controls.Add(btnRename);
            Controls.Add(chkRename);
            Controls.Add(label3);
            Controls.Add(txtRename);
            Controls.Add(label2);
            Controls.Add(txtPath);
            Controls.Add(label1);
            Controls.Add(btnClick);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvFormat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClick;
        private Label label1;
        private TextBox txtPath;
        private Label label2;
        private TextBox txtRename;
        private Label label3;
        private CheckBox chkRename;
        private Button btnRename;
        private Button btnSave;
        private DataGridView dgvFormat;
        private FolderBrowserDialog fbd;
        private Label lblIf;
        private TextBox txtIf;
        private Button btnSaveAll;
    }
}
