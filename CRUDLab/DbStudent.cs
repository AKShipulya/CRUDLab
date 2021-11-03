using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDLab
{
    class DbStudent
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=student";
            MySqlConnection connection = new MySqlConnection(sql);
            try
            {
                connection.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("MySQL Connection! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return connection;
        }

        public static void AddStudent(Student student)
        {
            string sql = "INSERT INTO student_table VALUES (NULL, @StudentName, @StudentReg, @StudentClass, @StudentSection, NULL)";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = student.Name;
            command.Parameters.Add("@StudentReg", MySqlDbType.VarChar).Value = student.Reg;
            command.Parameters.Add("@StudentClass", MySqlDbType.VarChar).Value = student.Class;
            command.Parameters.Add("@StudentSection", MySqlDbType.VarChar).Value = student.Section;
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Added Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Student has been not inserted! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public static void UpdateStudent(Student student, string id)
        {
            string sql = "UPDATE student_table SET Name = @StudentName, Reg = @StudentReg, Class = @StudentClass, Section = @StudentSection WHERE ID = @StudentID";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@StudentID", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@StudentName", MySqlDbType.VarChar).Value = student.Name;
            command.Parameters.Add("@StudentReg", MySqlDbType.VarChar).Value = student.Reg;
            command.Parameters.Add("@StudentClass", MySqlDbType.VarChar).Value = student.Class;
            command.Parameters.Add("@StudentSection", MySqlDbType.VarChar).Value = student.Section;
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Student has been not updated! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public static void DeleteStudent(string id)
        {
            string sql = "DELETE FROM student_table WHERE ID = @StudentID";
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add("@StudentID", MySqlDbType.VarChar).Value = id;
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Student has been not deleted! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        public static void DisplayAndSearchStudent(string query, DataGridView dataGrid)
        {
            string sql = query;
            MySqlConnection connection = GetConnection();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGrid.DataSource = table;
            connection.Close();
        }
    }
}
