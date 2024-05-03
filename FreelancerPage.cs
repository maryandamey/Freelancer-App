using FreelancerApp.ClientSide;
using FreelancerApp.FreelancerSide;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace FreelancerApp
{
    
    public partial class FreelancerPage : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
      
        public FreelancerPage(int userID)
        {
            InitializeComponent();
            GlobalVariable.UserID = userID; 
            random = new Random();
        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;

                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbltitle.Text = childForm.Text;
        }

        private void FreelancerPage_Load(object sender, EventArgs e)
        {

        }

        private void BtnFreelancerDash_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FreelancerSide.FreelancerDash(GlobalVariable.UserID), sender);
        }

        private void btnBrowseProject_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FreelancerSide.BrowseProjects(), sender);
        }

        private void btnCompletePoject_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FreelancerSide.CompletedProjects(), sender);
        }

        private void btnFreeProfile_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FreelancerSide.FreelancerProfile(GlobalVariable.UserID), sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login frm3 = new Login();
            frm3.Show();
            this.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
             
        }
    }
}
