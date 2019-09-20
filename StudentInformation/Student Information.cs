using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInformation
{
    public partial class Form1 : Form
    {
        List<string> id = new List<string> { };
        List<string> name = new List<string> { };
        List<string> mobile = new List<string> { };
        List<int> age = new List<int> { };
        List<string> address = new List<string> { };
        List<float> gpa = new List<float> { };
        int i = 0;
        string message = "";
        public Form1()
        {
            InitializeComponent();
        }


        //Added Information To List by using StudentInfoAddButton_Click
        private void StudentInfoAddButton_Click(object sender, EventArgs e)
        {
            
            Value_Assign_to_List();
            Student_Information_Reset();
        }

        //Student All Information Show by Using StudentIfoShowButton_Click
        private void StudentIfoShowButton_Click(object sender, EventArgs e)
        {
            All_Student_Info_Show();
            MAX_MIN_AVG_TOTAL_GPA_Count();
        }

        //Search Student Information By Using StudentSearchButton_Click
        private void StudentSearchButton_Click(object sender, EventArgs e)
        {
            Student_Info_Sarch_By_ID_Name_Mobile();
            Student_Information_Reset();
        }

        //Student Information Assign to List
        private void Value_Assign_to_List()
        {
            try
            {
                if ((!String.IsNullOrEmpty(idTextBox.Text) && idTextBox.Text.Length == 4) && id.Contains(idTextBox.Text) == false)
                {
                    id.Add(idTextBox.Text);
                }
                else
                    MessageBox.Show("ID Shuld be 4 Charecter and Must be Unique");
                if ((!String.IsNullOrEmpty(nameTextBox.Text) && nameTextBox.Text.Length < 30))
                {
                    name.Add(nameTextBox.Text);
                }
                else
                    MessageBox.Show("Name Must be Inserted");
                if ((!String.IsNullOrEmpty(mobileTextBox.Text) && mobileTextBox.Text.Length == 11) && mobile.Contains(mobileTextBox.Text) == false)
                {
                    mobile.Add(mobileTextBox.Text);
                }
                else
                    MessageBox.Show("Mobile Num Should be 11 Charecter and Must be Unique");
                try
                {
                    age.Add(Convert.ToInt32(ageTextBox.Text));
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                address.Add(addressTextBox.Text);
                try
                {
                    if ((!String.IsNullOrEmpty(gpaTextBox.Text) && (float.Parse(gpaTextBox.Text) <= 4) && (float.Parse(gpaTextBox.Text) >= 0)))
                    {
                        gpa.Add(float.Parse(gpaTextBox.Text));
                    }
                    else
                        MessageBox.Show("GPA less than 4");   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Recently_Added_Student_Info_Show_();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //Recently_Added_Student_Info_Show_
        private void Recently_Added_Student_Info_Show_()
        {
            message = "Id : " + id[i] + "\nName : " + name[i] + "\nMobile : " + mobile[i]
            + "\nAge : " + age[i] + "\nAddress : " + address[i] + "\nGPA Point : " + gpa[i] + "\n\n";
            showRichTextBox.Text = message.ToString();
            i++;
        }

       // All_Student_Info_Show
        private void All_Student_Info_Show()
        {
            for (i = 0; i < id.Count(); i++)
            {
                message += "Id : " + id[i] + "\nName : " + name[i] + "\nMobile : " + mobile[i]
                           + "\nAge : " + age[i] + "\nAddress : " + address[i] + "\nGPA Point : " + gpa[i] + "\n\n";
            }
            showRichTextBox.Text = message.ToString();
        }

        //Student_Info_Sarch_By_ID_Name_Mobile 
        private void Student_Info_Sarch_By_ID_Name_Mobile()
        {
            try
            {
                if (studentId_RadioButton.Checked == true)
                {
                    for (i = 0; i < id.Count(); i++)
                    {
                        if (id[i].Equals(idTextBox.Text))
                        {
                            message += "Id : " + id[i] + "\nName : " + name[i] + "\nMobile : " + mobile[i]
                            + "\nAge : " + age[i] + "\nAddress : " + address[i] + "\nGPA Point : " + gpa[i] + "\n\n";
                        }

                    }
                    showRichTextBox.Text = message.ToString();
                }
                else if (studentNameRadioButton.Checked == true)
                {
                    for (i = 0; i < id.Count(); i++)
                    {
                        if (name[i].Equals(nameTextBox.Text))
                        {
                            message += "Id : " + id[i] + "\nName : " + name[i] + "\nMobile : " + mobile[i]
                            + "\nAge : " + age[i] + "\nAddress : " + address[i] + "\nGPA Point : " + gpa[i] + "\n\n";
                        }

                    }
                    showRichTextBox.Text = message.ToString();
                }
                else if (studenMobileRadioButton.Checked == true)
                {
                    for (i = 0; i < id.Count(); i++)
                    {
                        if (mobile[i].Equals(mobileTextBox.Text))
                        {
                            message += "Id : " + id[i] + "\nName : " + name[i] + "\nMobile : " + mobile[i]
                            + "\nAge : " + age[i] + "\nAddress : " + address[i] + "\nGPA Point : " + gpa[i] + "\n\n";
                        }

                    }
                    showRichTextBox.Text = message.ToString();
                }
                else
                    MessageBox.Show("Search Item is not Match the Input");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //MAX_MIN_AVG_TOTAL_GPA_Count
        private void MAX_MIN_AVG_TOTAL_GPA_Count()
        {
            float totalGPA = 0;
            float maxGPA = gpa.Max();
            maxGPATextBox.Text = maxGPA.ToString();
            float minGPA = gpa.Min();
            minGPATextBox.Text = minGPA.ToString();
            float avgGPA = gpa.Average();
            avgGPATextBox.Text = avgGPA.ToString();
            maxGpaStudentNameTextBox.Text = name[gpa.IndexOf(maxGPA)];
            minGpaStudentNameTextBox.Text = name[gpa.IndexOf(minGPA)];
            for (i = 0; i < gpa.Count(); i++)
            {
                totalGPA += gpa[i];
            }
            totalGPATextBox.Text = totalGPA.ToString();
        }

        //Student_Information_Reset
        private void Student_Information_Reset()
        {
            idTextBox.Clear();
            nameTextBox.Clear();
            mobileTextBox.Clear();
            ageTextBox.Clear();
            addressTextBox.Clear();
            gpaTextBox.Clear();
            maxGpaStudentNameTextBox.Clear();
            minGpaStudentNameTextBox.Clear();
            avgGPATextBox.Clear();
            totalGPATextBox.Clear();
            maxGPATextBox.Clear();
            minGPATextBox.Clear();

        }
    }
}
