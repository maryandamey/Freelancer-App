namespace FreelancerApp
{
    partial class FreelancerPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreelancerPage));
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnFreeProfile = new System.Windows.Forms.Button();
            this.btnCompletePoject = new System.Windows.Forms.Button();
            this.btnBrowseProject = new System.Windows.Forms.Button();
            this.BtnFreelancerDash = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDesktop.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDesktop
            // 
            this.panelDesktop.Controls.Add(this.panelTitleBar);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(249, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(835, 581);
            this.panelDesktop.TabIndex = 5;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelTitleBar.Controls.Add(this.pictureBox1);
            this.panelTitleBar.Controls.Add(this.lbltitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(835, 80);
            this.panelTitleBar.TabIndex = 2;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbltitle.ForeColor = System.Drawing.Color.White;
            this.lbltitle.Location = new System.Drawing.Point(355, 28);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(83, 18);
            this.lbltitle.TabIndex = 0;
            this.lbltitle.Text = "DashBoard";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(67)))));
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnFreeProfile);
            this.panelMenu.Controls.Add(this.btnCompletePoject);
            this.panelMenu.Controls.Add(this.btnBrowseProject);
            this.panelMenu.Controls.Add(this.BtnFreelancerDash);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(249, 581);
            this.panelMenu.TabIndex = 3;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 320);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(249, 60);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "    Log Out";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnFreeProfile
            // 
            this.btnFreeProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFreeProfile.FlatAppearance.BorderSize = 0;
            this.btnFreeProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFreeProfile.ForeColor = System.Drawing.Color.White;
            this.btnFreeProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnFreeProfile.Image")));
            this.btnFreeProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFreeProfile.Location = new System.Drawing.Point(0, 260);
            this.btnFreeProfile.Name = "btnFreeProfile";
            this.btnFreeProfile.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnFreeProfile.Size = new System.Drawing.Size(249, 60);
            this.btnFreeProfile.TabIndex = 5;
            this.btnFreeProfile.Text = "    Profile Info";
            this.btnFreeProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFreeProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFreeProfile.UseVisualStyleBackColor = true;
            this.btnFreeProfile.Click += new System.EventHandler(this.btnFreeProfile_Click);
            // 
            // btnCompletePoject
            // 
            this.btnCompletePoject.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompletePoject.FlatAppearance.BorderSize = 0;
            this.btnCompletePoject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompletePoject.ForeColor = System.Drawing.Color.White;
            this.btnCompletePoject.Image = ((System.Drawing.Image)(resources.GetObject("btnCompletePoject.Image")));
            this.btnCompletePoject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompletePoject.Location = new System.Drawing.Point(0, 200);
            this.btnCompletePoject.Name = "btnCompletePoject";
            this.btnCompletePoject.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnCompletePoject.Size = new System.Drawing.Size(249, 60);
            this.btnCompletePoject.TabIndex = 3;
            this.btnCompletePoject.Text = "    Completed Projects";
            this.btnCompletePoject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompletePoject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCompletePoject.UseVisualStyleBackColor = true;
            this.btnCompletePoject.Click += new System.EventHandler(this.btnCompletePoject_Click);
            // 
            // btnBrowseProject
            // 
            this.btnBrowseProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBrowseProject.FlatAppearance.BorderSize = 0;
            this.btnBrowseProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseProject.ForeColor = System.Drawing.Color.White;
            this.btnBrowseProject.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseProject.Image")));
            this.btnBrowseProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseProject.Location = new System.Drawing.Point(0, 140);
            this.btnBrowseProject.Name = "btnBrowseProject";
            this.btnBrowseProject.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnBrowseProject.Size = new System.Drawing.Size(249, 60);
            this.btnBrowseProject.TabIndex = 2;
            this.btnBrowseProject.Text = "   Browse Project";
            this.btnBrowseProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowseProject.UseVisualStyleBackColor = true;
            this.btnBrowseProject.Click += new System.EventHandler(this.btnBrowseProject_Click);
            // 
            // BtnFreelancerDash
            // 
            this.BtnFreelancerDash.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnFreelancerDash.FlatAppearance.BorderSize = 0;
            this.BtnFreelancerDash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFreelancerDash.ForeColor = System.Drawing.Color.White;
            this.BtnFreelancerDash.Image = ((System.Drawing.Image)(resources.GetObject("BtnFreelancerDash.Image")));
            this.BtnFreelancerDash.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFreelancerDash.Location = new System.Drawing.Point(0, 80);
            this.BtnFreelancerDash.Name = "BtnFreelancerDash";
            this.BtnFreelancerDash.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.BtnFreelancerDash.Size = new System.Drawing.Size(249, 60);
            this.BtnFreelancerDash.TabIndex = 1;
            this.BtnFreelancerDash.Text = "     DashBoard";
            this.BtnFreelancerDash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFreelancerDash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnFreelancerDash.UseVisualStyleBackColor = true;
            this.BtnFreelancerDash.Click += new System.EventHandler(this.BtnFreelancerDash_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(37)))), ((int)(((byte)(77)))));
            this.panelLogo.Controls.Add(this.bunifuPictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.panelLogo.Size = new System.Drawing.Size(249, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.AutoSizeHeight = false;
            this.bunifuPictureBox1.BorderRadius = 0;
            this.bunifuPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuPictureBox1.Image")));
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(73, 3);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(79, 79);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 26;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(759, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FreelancerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 581);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "FreelancerPage";
            this.Text = "FreelancerPage";
            this.Load += new System.EventHandler(this.FreelancerPage_Load);
            this.panelDesktop.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnFreeProfile;
        private System.Windows.Forms.Button btnCompletePoject;
        private System.Windows.Forms.Button btnBrowseProject;
        private System.Windows.Forms.Button BtnFreelancerDash;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lbltitle;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}