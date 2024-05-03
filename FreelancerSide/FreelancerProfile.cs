using FreelancerApp.Connections;
using System;
using System.Data;
using System.Windows.Forms;

namespace FreelancerApp.FreelancerSide
{
    public partial class FreelancerProfile : Form
    {
        private int userID;

        public FreelancerProfile(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            LoadProfile();
        }

        private void LoadProfile()
        {
            string mySQL = "SELECT * FROM FreelancerProfile WHERE User_ID = " + userID;
            DataTable profileData = ServerConnection.executeSQL(mySQL);

            if (profileData.Rows.Count > 0)
            {
                skillsComboBox.SelectedItem = profileData.Rows[0]["Skills"].ToString();
                SetExpertiseBasedOnSkill(profileData.Rows[0]["Skills"].ToString());
                PortfolioTextBox.Text = profileData.Rows[0]["Portfolio"].ToString();
                PastWorkTextBox.Text = profileData.Rows[0]["Past_Work"].ToString();
            }
            else
            {
                skillsComboBox.SelectedItem = "";
                expertiseComboBox.SelectedItem = "";
                PortfolioTextBox.Text = "";
                PastWorkTextBox.Text = "";
                MessageBox.Show("Please insert your profile details", "Insert Profile", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            string caption = "Save Profile Info : FreelancerApp";

            if (string.IsNullOrEmpty(skillsComboBox.SelectedItem?.ToString()))
            {
                MessageBox.Show("Please Enter your Skills", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                skillsComboBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(expertiseComboBox.SelectedItem?.ToString()))
            {
                MessageBox.Show("Please Enter your Expertise", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                expertiseComboBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(PortfolioTextBox.Text))
            {
                MessageBox.Show("Please Enter your Portfolio", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PortfolioTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(PastWorkTextBox.Text))
            {
                MessageBox.Show("Please Enter your Past Work", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PastWorkTextBox.Focus();
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to save your Profile Info ?", "Save Data:FreelancerApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string mySQL = string.Empty;
                mySQL = "IF NOT EXISTS (SELECT * FROM FreelancerProfile WHERE User_ID = " + userID + ") ";
                mySQL += "INSERT INTO FreelancerProfile (User_ID, Skills, Expertise, Portfolio, Past_Work) VALUES ";
                mySQL += "(" + userID + ", '" + skillsComboBox.SelectedItem.ToString() + "', '" + expertiseComboBox.SelectedItem.ToString() + "', '" + PortfolioTextBox.Text + "', '" + PastWorkTextBox.Text + "') ";
                mySQL += "ELSE ";
                mySQL += "UPDATE FreelancerProfile SET ";
                mySQL += "Skills = '" + skillsComboBox.SelectedItem.ToString() + "', ";
                mySQL += "Expertise = '" + expertiseComboBox.SelectedItem.ToString() + "', ";
                mySQL += "Portfolio = '" + PortfolioTextBox.Text + "', ";
                mySQL += "Past_Work = '" + PastWorkTextBox.Text + "' ";
                mySQL += "WHERE User_ID = " + userID;

                ServerConnection.executeSQL(mySQL);

                MessageBox.Show("Your Profile Informations has been saved ", "SaveData: FreeLancerApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FreelancerProfile_Load(object sender, EventArgs e)
        {
            skillsComboBox.Items.AddRange(new string[] {
        "Web Development",
        "Mobile App Development",
        "Graphic Design",
        "Digital Marketing",
        "Writing & Translation",
        "Video & Animation",
        "Audio & Music Production",
        "Data Entry & Admin Support",
        "Business Consulting",
        "Legal Services"
    });

            expertiseComboBox.Items.AddRange(new string[] {
        "Full Stack",
        "Android Development ",
        "Adobe Photoshop",
        "Email Marketing",
        "Blog Writing",
        "Video Editing",
        "Audio Editing",
        "Data Entry",
        "Business Development",
        "Contract Drafting"
    });

            // Set default messages as the selected items
            skillsComboBox.SelectedItem = "Choose your skills";
            expertiseComboBox.SelectedItem = "Choose your expertise";

            // Load profile data if it exists
            LoadProfile();

            // Add event handler for skillsComboBox.SelectedIndexChanged
            skillsComboBox.SelectedIndexChanged += SkillsComboBox_SelectedIndexChanged;
        }

        private void SkillsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetExpertiseBasedOnSkill(skillsComboBox.SelectedItem?.ToString());
        }

        private void SetExpertiseBasedOnSkill(string skill)
        {
            switch (skill)
            {
                case "Web Development":
                    expertiseComboBox.SelectedItem = "Full Stack";
                    break;
                case "Mobile App Development":
                    expertiseComboBox.SelectedItem = "Android Development ";
                    break;
                case "Graphic Design":
                    expertiseComboBox.SelectedItem = "Adobe Photoshop";
                    break;
                case "Digital Marketing":
                    expertiseComboBox.SelectedItem = "Email Marketing";
                    break;
                case "Writing & Translation":
                    expertiseComboBox.SelectedItem = "Blog Writing";
                    break;
                case "Video & Animation":
                    expertiseComboBox.SelectedItem = "Video Editing";
                    break;
                case "Audio & Music Production":
                    expertiseComboBox.SelectedItem = "Audio Editing";
                    break;
                case "Data Entry & Admin Support":
                    expertiseComboBox.SelectedItem = "Data Entry";
                    break;
                case "Business Consulting":
                    expertiseComboBox.SelectedItem = "Business Development";
                    break;
                case "Legal Services":
                    expertiseComboBox.SelectedItem = "Contract Drafting";
                    break;
                default:
                    expertiseComboBox.SelectedItem = "Choose your expertise";
                    break;
            }
        }
    }
}