using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartStudyPlanner
{
    public partial class MainForm : Form
    {
        int minutes = 25;
        int seconds = 0;
        public MainForm()
        {
            InitializeComponent();

            lblDate.Text = DateTime.Now.ToLongDateString();

            dataGridView1.ColumnCount = 5;

            dataGridView1.Columns[0].Name = "Subject";
            dataGridView1.Columns[1].Name = "Task";
            dataGridView1.Columns[2].Name = "Priority";
            dataGridView1.Columns[3].Name = "Due Date";
            dataGridView1.Columns[4].Name = "Status";
        }
        private void UpdateStats()
        {
            int total = dataGridView1.Rows.Count;
            int completed = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[4].Value != null &&
                    row.Cells[4].Value.ToString() == "Completed")
                {
                    completed++;
                }
            }

            lblTotalTasks.Text = "Tasks: " + total;
            lblCompleted.Text = "Completed: " + completed;
            lblPending.Text = "Pending: " + (total - completed);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Button Works!");
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (txtSubject.Text == "" || txtTask.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            dataGridView1.Rows.Add(
                txtSubject.Text,
                txtTask.Text,
                cmbPriority.Text,
                dtpDueDate.Value.ToShortDateString(),
                "Pending"
            );

            MessageBox.Show("Task Added Successfully");

            txtSubject.Clear();
            txtTask.Clear();
            UpdateStats();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.CurrentRow.Cells[0].Value = txtSubject.Text;
                dataGridView1.CurrentRow.Cells[1].Value = txtTask.Text;
                dataGridView1.CurrentRow.Cells[2].Value = cmbPriority.Text;
                dataGridView1.CurrentRow.Cells[3].Value = dtpDueDate.Value.ToShortDateString();

                MessageBox.Show("Task Updated");

                UpdateStats();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                MessageBox.Show("Task Deleted");
                UpdateStats();
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.CurrentRow.Cells[4].Value = "Completed";

                MessageBox.Show("Task Completed");
                UpdateStats();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            minutes = 25;
            seconds = 0;

            lblTimer.Text = "25:00";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds == 0)
            {
                if (minutes == 0)
                {
                    timer1.Stop();
                    MessageBox.Show("Study Session Complete!");
                    return;
                }

                minutes--;
                seconds = 59;
            }
            else
            {
                seconds--;
            }

            lblTimer.Text =
                minutes.ToString("00") + ":" +
                seconds.ToString("00");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Selected = false;

                if (row.Cells[1].Value != null &&
                    row.Cells[1].Value.ToString().ToLower()
                    .Contains(textBox1.Text.ToLower()))
                {
                    row.Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }
                private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
        "FocusFlow - Smart Study Planner\n\nDeveloped using C# Windows Forms\n\nCreated by: Subathra",
        "About");
        }
    }
 }

   
