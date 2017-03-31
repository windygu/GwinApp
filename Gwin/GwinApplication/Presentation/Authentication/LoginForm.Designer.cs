namespace App.Gwin.GwinApplication.Presentation.Authentication
{
    partial class LoginForm
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
            this.loginControl1 = new App.Gwin.Components.Authentication.LoginControl();
            this.SuspendLayout();
            // 
            // loginControl1
            // 
            this.loginControl1.Location = new System.Drawing.Point(12, 12);
            this.loginControl1.Name = "loginControl1";
            this.loginControl1.Size = new System.Drawing.Size(298, 137);
            this.loginControl1.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 158);
            this.Controls.Add(this.loginControl1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Components.Authentication.LoginControl loginControl1;
    }
}