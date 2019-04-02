    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace EmployeeRecords
{
    public partial class mainForm : Form
    {
        List<Employee> employeeDB = new List<Employee>();

        public mainForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Employee yeet = new Employee(idInput.Text, fnInput.Text, lnInput.Text, dateInput.Text, salaryInput.Text);
            employeeDB.Add(yeet);
            outputLabel.Text = "employee added";
            ClearLabels();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
           
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = "";
            foreach (Employee p in employeeDB)
            {
                outputLabel.Text += "Employee ID: " + p.id;
                outputLabel.Text += "\nName: " + p.firstName + " "+  p.lastName;
                outputLabel.Text += "\nSalary: " + p.salary;
                outputLabel.Text += "\nDate Started: " + p.date + "\n";
            }
        }

        private void ClearLabels()
        {
            idInput.Text = "";
            fnInput.Text = "";
            lnInput.Text = "";
            dateInput.Text = "";
            salaryInput.Text = "";
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            saveDB();
        }

        public void loadDB()
        {
            
        }

        public void saveDB()
        {
            XmlWriter writer = XmlWriter.Create("Resources/EmployeeData.xml", null);
            writer.WriteStartElement("Employee");

            foreach(Employee p in employeeDB)
            {
                writer.WriteElementString("ID", p.id);
                writer.WriteElementString("FirstName", p.firstName);
                writer.WriteElementString("LastName", p.lastName);
                writer.WriteElementString("Salary", p.salary);
                writer.WriteElementString("StartDate", p.date);
            }
            
        }
    }
}
