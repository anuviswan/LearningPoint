namespace Awaitable
{
    partial class MainForm
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
            this.btnDemoUsingTaskAwaiter = new System.Windows.Forms.Button();
            this.logText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDemoUsingTaskAwaiter
            // 
            this.btnDemoUsingTaskAwaiter.Location = new System.Drawing.Point(12, 12);
            this.btnDemoUsingTaskAwaiter.Name = "btnDemoUsingTaskAwaiter";
            this.btnDemoUsingTaskAwaiter.Size = new System.Drawing.Size(158, 23);
            this.btnDemoUsingTaskAwaiter.TabIndex = 0;
            this.btnDemoUsingTaskAwaiter.Text = "Start Demo using TaskAwaiter";
            this.btnDemoUsingTaskAwaiter.UseVisualStyleBackColor = true;
            this.btnDemoUsingTaskAwaiter.Click += new System.EventHandler(this.btnDemoUsingTaskAwaiter_Click);
            // 
            // logText
            // 
            this.logText.Location = new System.Drawing.Point(12, 41);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.Size = new System.Drawing.Size(638, 457);
            this.logText.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 510);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.btnDemoUsingTaskAwaiter);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDemoUsingTaskAwaiter;
        private System.Windows.Forms.TextBox logText;
    }
}