namespace graphTest
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addElement = new System.Windows.Forms.Button();
            this.elementInput = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // addElement
            // 
            this.addElement.Location = new System.Drawing.Point(1284, 105);
            this.addElement.Name = "addElement";
            this.addElement.Size = new System.Drawing.Size(159, 63);
            this.addElement.TabIndex = 0;
            this.addElement.Text = "Add Element";
            this.addElement.UseVisualStyleBackColor = true;
            this.addElement.Click += new System.EventHandler(this.addElement_Click);
            // 
            // elementInput
            // 
            this.elementInput.Location = new System.Drawing.Point(1284, 79);
            this.elementInput.Name = "elementInput";
            this.elementInput.Size = new System.Drawing.Size(158, 20);
            this.elementInput.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 809);
            this.Controls.Add(this.elementInput);
            this.Controls.Add(this.addElement);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addElement;
        private System.Windows.Forms.TextBox elementInput;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

