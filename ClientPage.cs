using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FreelancerApp.Register;

namespace FreelancerApp
{
    public partial class ClientPage : Form
    {

        private int userID;
        private UserType userType;
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public ClientPage(int userID, UserType userType)
        {
            InitializeComponent();
            random = new Random();
            this.userID = userID;
            this.userType = userType;
        }
        //Methods
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

        private void ClientPage_Load(object sender, EventArgs e)
        {

        }

        private void BtnClientDash_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClientSide.ClientDash(userID, userType), sender);
        }

        private void btnFreelancerProfile_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new ClientSide.FreelancerProfile(), sender);

        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClientSide.AddProject(GlobalVariable.UserID), sender);

        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClientSide.Reviews(), sender);

        }

      

        private void CLientProfilepictureBox_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClientSide.FreelancerProfile(), sender);
        }

        private void btnClinetProfile_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClientSide.ClientProfile(GlobalVariable.UserID), sender);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login frm3 = new Login();
            frm3.Show();
            this.Close();

        }

        private void bidbutton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClientSide.bids(GlobalVariable.UserID), sender);
        }
    }
}
