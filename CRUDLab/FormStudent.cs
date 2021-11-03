using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDLab
{
    public partial class FormStudent : Form
    {
        private readonly FormStudentInfo _parent;
        public string id, name, reg, @class, section;
        public FormStudent(FormStudentInfo parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateStudent()
        {
            lblText.Text = "Update Student";
            btnSave.Text = "Update";
            txtName.Text = name;
            txtReg.Text = reg;
            txtClass.Text = @class;
            txtSection.Text = section;
        }

        public void SaveInfo()
        {
            lblText.Text = "Add Student";
            btnSave.Text = "Save";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            txtName.Text = txtReg.Text = txtClass.Text = txtSection.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student name too short or empty");
                return;
            }
            if (txtReg.Text.Trim().Length < 1)
            {
                MessageBox.Show("Student reg too short or empty");
                return;
            }
            if (txtClass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student class is empty");
                return;
            }
            if (txtSection.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student section is empty");
                return;
            }
            if (btnSave.Text == "Save")
            {
                Student student = new Student(txtName.Text.Trim(), txtReg.Text.Trim(), txtClass.Text.Trim(), txtSection.Text.Trim());
                DbStudent.AddStudent(student);
                Clear();
            }
            if (btnSave.Text == "Update")
            {
                Student student = new Student(txtName.Text.Trim(), txtReg.Text.Trim(), txtClass.Text.Trim(), txtSection.Text.Trim());
                DbStudent.UpdateStudent(student, id);
            }
            _parent.Display();
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
