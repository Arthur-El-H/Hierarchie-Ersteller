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
            this.yesBtn = new System.Windows.Forms.Button();
            this.noBtn = new System.Windows.Forms.Button();
            this.newElementBtn = new System.Windows.Forms.Button();
            this.elementInput = new System.Windows.Forms.TextBox();
            this.newNodeqst = new System.Windows.Forms.Label();
            this.testBtn = new System.Windows.Forms.Button();
            this.listShowCase = new System.Windows.Forms.ListView();
            this.isEqualToBtn = new System.Windows.Forms.Button();
            this.isPartOfBtn = new System.Windows.Forms.Button();
            this.includeBtn = new System.Windows.Forms.Button();
            this.noRelationToBtn = new System.Windows.Forms.Button();
            this.currentElement = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yesBtn
            // 
            this.yesBtn.Location = new System.Drawing.Point(419, 334);
            this.yesBtn.Name = "yesBtn";
            this.yesBtn.Size = new System.Drawing.Size(75, 23);
            this.yesBtn.TabIndex = 0;
            this.yesBtn.Text = "Yes";
            this.yesBtn.UseVisualStyleBackColor = true;
            this.yesBtn.Click += new System.EventHandler(this.yesBtn_Click);
            // 
            // noBtn
            // 
            this.noBtn.Location = new System.Drawing.Point(529, 334);
            this.noBtn.Name = "noBtn";
            this.noBtn.Size = new System.Drawing.Size(75, 23);
            this.noBtn.TabIndex = 1;
            this.noBtn.Text = "No";
            this.noBtn.UseVisualStyleBackColor = true;
            this.noBtn.Click += new System.EventHandler(this.noBtn_Click);
            // 
            // newElementBtn
            // 
            this.newElementBtn.Location = new System.Drawing.Point(1073, 51);
            this.newElementBtn.Name = "newElementBtn";
            this.newElementBtn.Size = new System.Drawing.Size(126, 23);
            this.newElementBtn.TabIndex = 2;
            this.newElementBtn.Text = "Add new Element";
            this.newElementBtn.UseVisualStyleBackColor = true;
            this.newElementBtn.Click += new System.EventHandler(this.newElementBtn_Click);
            // 
            // elementInput
            // 
            this.elementInput.Location = new System.Drawing.Point(1073, 22);
            this.elementInput.Name = "elementInput";
            this.elementInput.Size = new System.Drawing.Size(126, 23);
            this.elementInput.TabIndex = 3;
            // 
            // newNodeqst
            // 
            this.newNodeqst.AutoSize = true;
            this.newNodeqst.Location = new System.Drawing.Point(462, 298);
            this.newNodeqst.Name = "newNodeqst";
            this.newNodeqst.Size = new System.Drawing.Size(32, 15);
            this.newNodeqst.TabIndex = 4;
            this.newNodeqst.Text = "-----";
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(1124, 80);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(75, 23);
            this.testBtn.TabIndex = 5;
            this.testBtn.Text = "Test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click_1);
            // 
            // listShowCase
            // 
            this.listShowCase.HideSelection = false;
            this.listShowCase.Location = new System.Drawing.Point(1025, 271);
            this.listShowCase.Name = "listShowCase";
            this.listShowCase.Size = new System.Drawing.Size(174, 444);
            this.listShowCase.TabIndex = 6;
            this.listShowCase.UseCompatibleStateImageBehavior = false;
            // 
            // isEqualToBtn
            // 
            this.isEqualToBtn.Location = new System.Drawing.Point(1025, 213);
            this.isEqualToBtn.Name = "isEqualToBtn";
            this.isEqualToBtn.Size = new System.Drawing.Size(93, 23);
            this.isEqualToBtn.TabIndex = 8;
            this.isEqualToBtn.Text = "Is Equal To";
            this.isEqualToBtn.UseVisualStyleBackColor = true;
            this.isEqualToBtn.Click += new System.EventHandler(this.isEqualToBtn_Click);
            // 
            // isPartOfBtn
            // 
            this.isPartOfBtn.Location = new System.Drawing.Point(1124, 213);
            this.isPartOfBtn.Name = "isPartOfBtn";
            this.isPartOfBtn.Size = new System.Drawing.Size(75, 23);
            this.isPartOfBtn.TabIndex = 8;
            this.isPartOfBtn.Text = "Is Part Of";
            this.isPartOfBtn.UseVisualStyleBackColor = true;
            this.isPartOfBtn.Click += new System.EventHandler(this.isPartOfBtn_Click);
            // 
            // includeBtn
            // 
            this.includeBtn.Location = new System.Drawing.Point(1124, 242);
            this.includeBtn.Name = "includeBtn";
            this.includeBtn.Size = new System.Drawing.Size(75, 23);
            this.includeBtn.TabIndex = 8;
            this.includeBtn.Text = "Includes";
            this.includeBtn.UseVisualStyleBackColor = true;
            this.includeBtn.Click += new System.EventHandler(this.includeBtn_Click);
            // 
            // noRelationToBtn
            // 
            this.noRelationToBtn.Location = new System.Drawing.Point(1025, 242);
            this.noRelationToBtn.Name = "noRelationToBtn";
            this.noRelationToBtn.Size = new System.Drawing.Size(93, 23);
            this.noRelationToBtn.TabIndex = 8;
            this.noRelationToBtn.Text = "No Relation To";
            this.noRelationToBtn.UseVisualStyleBackColor = true;
            this.noRelationToBtn.Click += new System.EventHandler(this.noRelationToBtn_Click);
            // 
            // currentElement
            // 
            this.currentElement.AutoSize = true;
            this.currentElement.Location = new System.Drawing.Point(1029, 173);
            this.currentElement.Name = "currentElement";
            this.currentElement.Size = new System.Drawing.Size(27, 15);
            this.currentElement.TabIndex = 9;
            this.currentElement.Text = "----";
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(1211, 737);
            this.Controls.Add(this.currentElement);
            this.Controls.Add(this.noRelationToBtn);
            this.Controls.Add(this.includeBtn);
            this.Controls.Add(this.isPartOfBtn);
            this.Controls.Add(this.isEqualToBtn);
            this.Controls.Add(this.listShowCase);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.newNodeqst);
            this.Controls.Add(this.elementInput);
            this.Controls.Add(this.newElementBtn);
            this.Controls.Add(this.noBtn);
            this.Controls.Add(this.yesBtn);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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

