namespace ProcessManager
{
    partial class InfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoDialog));
            this.text = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_showAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.text.Location = new System.Drawing.Point(1, 21);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(415, 144);
            this.text.TabIndex = 1;
            this.text.Text = "text";
            this.text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ok
            // 
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btn_ok.Location = new System.Drawing.Point(160, 171);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(98, 38);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "&Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.Ok_click);
            // 
            // btn_showAll
            // 
            this.btn_showAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_showAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btn_showAll.Location = new System.Drawing.Point(350, 194);
            this.btn_showAll.Name = "btn_showAll";
            this.btn_showAll.Size = new System.Drawing.Size(65, 24);
            this.btn_showAll.TabIndex = 3;
            this.btn_showAll.Text = "show all";
            this.btn_showAll.UseVisualStyleBackColor = true;
            this.btn_showAll.Click += new System.EventHandler(this.btn_showAll_Click);
            // 
            // InfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 218);
            this.Controls.Add(this.btn_showAll);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfoDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.InfoDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label text;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_showAll;
    }
}