using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Assignment_Manager_v1.RefreshCompetition;

namespace Assignment_Manager_v1
{
    public partial class AssignStudentForm : Form
    {
        public AssignStudentForm()
        {
            InitializeComponent();


            // 添加 DataGridView 控件的列
            DataGridViewRecommended.Columns.Add("MemberID", "Student ID");
            DataGridViewRecommended.Columns.Add("StudentName", "Student Name");
            DataGridViewRecommended.Columns.Add("CompetitionID", "Competition ID");
            DataGridViewRecommended.Columns.Add("CompetitionName", "Competition Name");
            DataGridViewRecommended.Columns.Add("CoachID", "Coach ID");
            DataGridViewRecommended.Columns.Add("Usename", "Coach Name");


            RecommendStudent dbaction = new RecommendStudent();
            string query_RefreshDataGrid = "SELECT rm.memberID,ui.userName, rm.competitionID, c.competitionName, rm.coachID,cm.userName FROM RecommendedMemb rm Join UserInfo ui on rm.memberID = ui.userID Join CoachMember cm on rm.coachID = cm.userID Join Competition c on rm.competitionID = c.competitionID";
            dbaction.RefreshDataGrid(DataGridViewRecommended, query_RefreshDataGrid);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void DataGridViewRecommended_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 获取选定行的每个单元格的值并放入文本框中
                DataGridViewRow selectedRow = DataGridViewRecommended.Rows[e.RowIndex];
                LblStudentID.Text = selectedRow.Cells["MemberID"].Value.ToString();
                LblStudentName.Text = selectedRow.Cells["StudentName"].Value.ToString();
                LblCompetitionID.Text = selectedRow.Cells["CompetitionID"].Value.ToString();
                LblCompetitionName.Text = selectedRow.Cells["CompetitionName"].Value.ToString();
                LblCoachID.Text = selectedRow.Cells["CoachID"].Value.ToString();
                LblCoachName.Text = selectedRow.Cells["Usename"].Value.ToString();
            }
        }

        private void BtnAssign_Click(object sender, EventArgs e)
        {
            RecommendStudent dbaction = new RecommendStudent();
            dbaction.AssignStudent(LblStudentID, LblCompetitionID);

            string query_RefreshDataGrid = "SELECT rm.memberID,ui.userName, rm.competitionID, c.competitionName, rm.coachID,cm.userName FROM RecommendedMemb rm Join UserInfo ui on rm.memberID = ui.userID Join CoachMember cm on rm.coachID = cm.userID Join Competition c on rm.competitionID = c.competitionID";
            dbaction.RefreshDataGrid(DataGridViewRecommended, query_RefreshDataGrid);
        }

        private void btn_Competition_Click(object sender, EventArgs e)
        {
            CompetitionForm Competition = new CompetitionForm();
            this.Hide();
            Competition.Show();
        }

        private void BtnFindStudent_Click(object sender, EventArgs e)
        {
            FindStudentForm FindStudent = new FindStudentForm();
            this.Hide();
            FindStudent.Show();
        }

        private void btn_MainPage_Click(object sender, EventArgs e)
        {
            Manager_UI MainPage = new Manager_UI();
            this.Hide();
            MainPage.Show();
        }

        private void Btn_UpdateResult_Click(object sender, EventArgs e)
        {
            UpdateResultForm updateResult = new UpdateResultForm();
            this.Hide();
            updateResult.Show();
        }

        private void AssignStudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
