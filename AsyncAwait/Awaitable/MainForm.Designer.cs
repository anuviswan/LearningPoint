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
            this.btnExecuteOnDifferentThread = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnExecuteOnSameThread = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExecuteOnDifferentThread
            // 
            this.btnExecuteOnDifferentThread.Location = new System.Drawing.Point(665, 393);
            this.btnExecuteOnDifferentThread.Name = "btnExecuteOnDifferentThread";
            this.btnExecuteOnDifferentThread.Size = new System.Drawing.Size(123, 45);
            this.btnExecuteOnDifferentThread.TabIndex = 0;
            this.btnExecuteOnDifferentThread.Text = "Execute";
            this.btnExecuteOnDifferentThread.UseVisualStyleBackColor = true;
            this.btnExecuteOnDifferentThread.Click += new System.EventHandler(this.btnExecuteOnDifferentThread_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(776, 373);
            this.txtLog.TabIndex = 1;
            // 
            // btnExecuteOnSameThread
            // 
            this.btnExecuteOnSameThread.Location = new System.Drawing.Point(536, 393);
            this.btnExecuteOnSameThread.Name = "btnExecuteOnSameThread";
            this.btnExecuteOnSameThread.Size = new System.Drawing.Size(123, 45);
            this.btnExecuteOnSameThread.TabIndex = 2;
            this.btnExecuteOnSameThread.Text = "Execute";
            this.btnExecuteOnSameThread.UseVisualStyleBackColor = true;
            this.btnExecuteOnSameThread.Click += new System.EventHandler(this.btnExecuteOnSameThread_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExecuteOnSameThread);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnExecuteOnDifferentThread);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecuteOnDifferentThread;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnExecuteOnSameThread;
    }
}