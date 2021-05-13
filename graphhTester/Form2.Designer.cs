namespace graphhTester
{
    partial class Form2
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.yesBtn = new System.Windows.Forms.Button();
            this.noBtn = new System.Windows.Forms.Button();
            this.newElementBtn = new System.Windows.Forms.Button();
            this.elementInput = new System.Windows.Forms.TextBox();
            this.newNodeqst = new System.Windows.Forms.Label();
            this.testBtn = new System.Windows.Forms.Button();
            this.listShowCase = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.isEqualToBtn = new System.Windows.Forms.Button();
            this.isPartOfBtn = new System.Windows.Forms.Button();
            this.includeBtn = new System.Windows.Forms.Button();
            this.noRelationToBtn = new System.Windows.Forms.Button();
            this.currentElement = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.newNodeQstPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.hierarchyPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.insertAsChildBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.newNodeQstPanel.SuspendLayout();
            this.hierarchyPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // yesBtn
            // 
            this.yesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(196)))), ((int)(((byte)(221)))));
            this.yesBtn.FlatAppearance.BorderSize = 0;
            this.yesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yesBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.yesBtn.Location = new System.Drawing.Point(548, 47);
            this.yesBtn.Name = "yesBtn";
            this.yesBtn.Size = new System.Drawing.Size(244, 50);
            this.yesBtn.TabIndex = 0;
            this.yesBtn.Text = "Yes";
            this.yesBtn.UseVisualStyleBackColor = false;
            this.yesBtn.Click += new System.EventHandler(this.yesBtn_Click);
            // 
            // noBtn
            // 
            this.noBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(196)))), ((int)(((byte)(221)))));
            this.noBtn.FlatAppearance.BorderSize = 0;
            this.noBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.noBtn.Location = new System.Drawing.Point(301, 47);
            this.noBtn.Margin = new System.Windows.Forms.Padding(0);
            this.noBtn.Name = "noBtn";
            this.noBtn.Size = new System.Drawing.Size(244, 50);
            this.noBtn.TabIndex = 1;
            this.noBtn.Text = "No";
            this.noBtn.UseVisualStyleBackColor = false;
            this.noBtn.Click += new System.EventHandler(this.noBtn_Click);
            // 
            // newElementBtn
            // 
            this.newElementBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(103)))), ((int)(((byte)(104)))));
            this.newElementBtn.FlatAppearance.BorderSize = 0;
            this.newElementBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newElementBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.newElementBtn.Location = new System.Drawing.Point(0, 100);
            this.newElementBtn.Margin = new System.Windows.Forms.Padding(0);
            this.newElementBtn.Name = "newElementBtn";
            this.newElementBtn.Size = new System.Drawing.Size(244, 50);
            this.newElementBtn.TabIndex = 2;
            this.newElementBtn.Text = "Add new Element";
            this.newElementBtn.UseVisualStyleBackColor = false;
            this.newElementBtn.Click += new System.EventHandler(this.newElementBtn_Click);
            // 
            // elementInput
            // 
            this.elementInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(191)))), ((int)(((byte)(226)))));
            this.elementInput.Location = new System.Drawing.Point(0, 77);
            this.elementInput.Margin = new System.Windows.Forms.Padding(0);
            this.elementInput.Name = "elementInput";
            this.elementInput.Size = new System.Drawing.Size(244, 23);
            this.elementInput.TabIndex = 3;
            this.elementInput.Text = "Write Element here";
            // 
            // newNodeqst
            // 
            this.newNodeqst.AutoSize = true;
            this.newNodeqst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(196)))), ((int)(((byte)(221)))));
            this.newNodeqst.Location = new System.Drawing.Point(3, 0);
            this.newNodeqst.Name = "newNodeqst";
            this.newNodeqst.Size = new System.Drawing.Size(32, 15);
            this.newNodeqst.TabIndex = 4;
            this.newNodeqst.Text = "-----";
            // 
            // testBtn
            // 
            this.testBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(56)))), ((int)(((byte)(89)))));
            this.testBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testBtn.Location = new System.Drawing.Point(0, 0);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(75, 23);
            this.testBtn.TabIndex = 5;
            this.testBtn.Text = "Test";
            this.testBtn.UseVisualStyleBackColor = false;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click_1);
            // 
            // listShowCase
            // 
            this.listShowCase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(196)))), ((int)(((byte)(221)))));
            this.listShowCase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listShowCase.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listShowCase.HideSelection = false;
            this.listShowCase.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listShowCase.Location = new System.Drawing.Point(0, 450);
            this.listShowCase.Name = "listShowCase";
            this.listShowCase.Size = new System.Drawing.Size(244, 400);
            this.listShowCase.TabIndex = 6;
            this.listShowCase.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 470;
            // 
            // isEqualToBtn
            // 
            this.isEqualToBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(102)))));
            this.isEqualToBtn.FlatAppearance.BorderSize = 0;
            this.isEqualToBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.isEqualToBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.isEqualToBtn.Location = new System.Drawing.Point(0, 300);
            this.isEqualToBtn.Margin = new System.Windows.Forms.Padding(0);
            this.isEqualToBtn.Name = "isEqualToBtn";
            this.isEqualToBtn.Size = new System.Drawing.Size(244, 50);
            this.isEqualToBtn.TabIndex = 8;
            this.isEqualToBtn.Text = "Is Equal To";
            this.isEqualToBtn.UseVisualStyleBackColor = false;
            this.isEqualToBtn.Click += new System.EventHandler(this.isEqualToBtn_Click);
            // 
            // isPartOfBtn
            // 
            this.isPartOfBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(102)))));
            this.isPartOfBtn.FlatAppearance.BorderSize = 0;
            this.isPartOfBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.isPartOfBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.isPartOfBtn.Location = new System.Drawing.Point(0, 350);
            this.isPartOfBtn.Name = "isPartOfBtn";
            this.isPartOfBtn.Size = new System.Drawing.Size(244, 50);
            this.isPartOfBtn.TabIndex = 8;
            this.isPartOfBtn.TabStop = false;
            this.isPartOfBtn.Text = "Is Part Of";
            this.isPartOfBtn.UseVisualStyleBackColor = false;
            this.isPartOfBtn.Click += new System.EventHandler(this.isPartOfBtn_Click);
            // 
            // includeBtn
            // 
            this.includeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.includeBtn.FlatAppearance.BorderSize = 0;
            this.includeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.includeBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.includeBtn.Location = new System.Drawing.Point(0, 400);
            this.includeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.includeBtn.Name = "includeBtn";
            this.includeBtn.Size = new System.Drawing.Size(244, 50);
            this.includeBtn.TabIndex = 8;
            this.includeBtn.Text = "Includes";
            this.includeBtn.UseVisualStyleBackColor = false;
            this.includeBtn.Click += new System.EventHandler(this.includeBtn_Click);
            // 
            // noRelationToBtn
            // 
            this.noRelationToBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(178)))), ((int)(((byte)(102)))));
            this.noRelationToBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.noRelationToBtn.FlatAppearance.BorderSize = 0;
            this.noRelationToBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noRelationToBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.noRelationToBtn.Location = new System.Drawing.Point(0, 250);
            this.noRelationToBtn.Margin = new System.Windows.Forms.Padding(0);
            this.noRelationToBtn.Name = "noRelationToBtn";
            this.noRelationToBtn.Size = new System.Drawing.Size(244, 50);
            this.noRelationToBtn.TabIndex = 8;
            this.noRelationToBtn.Text = "No Relation To";
            this.noRelationToBtn.UseVisualStyleBackColor = false;
            this.noRelationToBtn.Click += new System.EventHandler(this.noRelationToBtn_Click);
            // 
            // currentElement
            // 
            this.currentElement.AutoSize = true;
            this.currentElement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(196)))), ((int)(((byte)(221)))));
            this.currentElement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currentElement.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.currentElement.Location = new System.Drawing.Point(0, 225);
            this.currentElement.Margin = new System.Windows.Forms.Padding(3, 130, 3, 0);
            this.currentElement.Name = "currentElement";
            this.currentElement.Size = new System.Drawing.Size(44, 25);
            this.currentElement.TabIndex = 9;
            this.currentElement.Text = "----";
            this.currentElement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(196)))), ((int)(((byte)(221)))));
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exitBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(103)))), ((int)(((byte)(104)))));
            this.exitBtn.Location = new System.Drawing.Point(181, 12);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(51, 42);
            this.exitBtn.TabIndex = 10;
            this.exitBtn.Text = "X";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 848);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(228, 848);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // newNodeQstPanel
            // 
            this.newNodeQstPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(196)))), ((int)(((byte)(221)))));
            this.newNodeQstPanel.Controls.Add(this.newNodeqst);
            this.newNodeQstPanel.Location = new System.Drawing.Point(301, 12);
            this.newNodeQstPanel.Name = "newNodeQstPanel";
            this.newNodeQstPanel.Size = new System.Drawing.Size(491, 29);
            this.newNodeQstPanel.TabIndex = 11;
            this.newNodeQstPanel.Visible = false;
            // 
            // hierarchyPanel
            // 
            this.hierarchyPanel.AutoScroll = true;
            this.hierarchyPanel.Controls.Add(this.testBtn);
            this.hierarchyPanel.Location = new System.Drawing.Point(234, 112);
            this.hierarchyPanel.Name = "hierarchyPanel";
            this.hierarchyPanel.Size = new System.Drawing.Size(929, 724);
            this.hierarchyPanel.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(196)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.insertAsChildBtn);
            this.panel1.Controls.Add(this.currentElement);
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Controls.Add(this.listShowCase);
            this.panel1.Controls.Add(this.elementInput);
            this.panel1.Controls.Add(this.newElementBtn);
            this.panel1.Controls.Add(this.noRelationToBtn);
            this.panel1.Controls.Add(this.isEqualToBtn);
            this.panel1.Controls.Add(this.isPartOfBtn);
            this.panel1.Controls.Add(this.includeBtn);
            this.panel1.Location = new System.Drawing.Point(1167, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 848);
            this.panel1.TabIndex = 11;
            // 
            // insertAsChildBtn
            // 
            this.insertAsChildBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(103)))), ((int)(((byte)(104)))));
            this.insertAsChildBtn.FlatAppearance.BorderSize = 0;
            this.insertAsChildBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertAsChildBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.insertAsChildBtn.Location = new System.Drawing.Point(0, 166);
            this.insertAsChildBtn.Name = "insertAsChildBtn";
            this.insertAsChildBtn.Size = new System.Drawing.Size(244, 50);
            this.insertAsChildBtn.TabIndex = 6;
            this.insertAsChildBtn.Text = "Insert as Child of";
            this.insertAsChildBtn.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(34)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1411, 848);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hierarchyPanel);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.noBtn);
            this.Controls.Add(this.yesBtn);
            this.Controls.Add(this.newNodeQstPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.newNodeQstPanel.ResumeLayout(false);
            this.newNodeQstPanel.PerformLayout();
            this.hierarchyPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button yesBtn;
        private System.Windows.Forms.Button noBtn;
        private System.Windows.Forms.Button newElementBtn;
        private System.Windows.Forms.TextBox elementInput;
        private System.Windows.Forms.Label newNodeqst;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.ListView listShowCase;
        private System.Windows.Forms.Button isEqualToBtn;
        private System.Windows.Forms.Button isPartOfBtn;
        private System.Windows.Forms.Button includeBtn;
        private System.Windows.Forms.Button noRelationToBtn;
        private System.Windows.Forms.Label currentElement;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel newNodeQstPanel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel hierarchyPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button insertAsChildBtn;

        #endregion

        /*
        private System.Windows.Forms.Button newElementBtn;
        private System.Windows.Forms.TextBox elementInput;
        private System.Windows.Forms.Button yesBtn;
        private System.Windows.Forms.Button noBtn;
        private System.Windows.Forms.Label newNodeqst;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        */
    }
}

