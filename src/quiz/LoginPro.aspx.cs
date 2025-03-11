using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Playground2
{
    public partial class LoginProcessing2 : Page
    {
        protected void SubmitButton(object sender, EventArgs e)
        {
            try 
            {
                string FileString = File.ReadAllText("C:/Users/tcpcj/source/repos/Playground/LoginInfo.txt");
                string[] ReadFileInfo = FileString.Split('\n');

                string[,] LoginFile = new string[2,3];
                string[] CurrentLine;

                Response.Write("<table><caption>" +
                    "Login Information</caption><tr><th>First Name</th><th>Email</th><th>Password</th></tr>");

                for (int i = 0; i < 2; i++)
                {
                    CurrentLine = ReadFileInfo[i].Split(',');
                    Response.Write("<tr>");

                    for (int j = 0; j < 3; j++)
                    {
                        LoginFile[i, j] = CurrentLine[j];
                        string CurrentValue = "<td>" + LoginFile[i, j] + "</td>";
                        Response.Write(CurrentValue);
                    }

                    Response.Write("</tr>");
                }

                Response.Write("</table>");
            }

            catch
            {
                Response.Write("Cannot Read File");
            }
            Validate();
        }

        protected void Validate(object sender, EventArgs e)
        {
            int k = 0;
            string FName = fname.Text;
            string Email = EmailTB.Text;
            string Password = PWTB.Text;
            bool IsValid = false;

            string[] ReadFileInfo = File.ReadAllLines("C:/Users/tcpcj/source/repos/Playground/LoginInfo.txt");
            string[,] LoginFile = new string[ReadFileInfo.Length, 3];
            string[] CurrentLine;
            int FLength = ReadFileInfo.Length;

            for (int i = 0; i < FLength; i++)
            {
                CurrentLine = ReadFileInfo[i].Split(',');

                for (int j = 0; j < 3; j++)
                {
                    LoginFile[i, j] = CurrentLine[j];
                }
            }

            while (k < FLength && IsValid == false)
            {
                if (FName == LoginFile[k, 0])
                {
                    if (Email == LoginFile[k, 1])
                    {
                        if (Password == LoginFile[k, 2])
                        {
                            IsValid = true;
                        }
                    }
                }
                k++;
            }

            if (IsValid == true)
            {
                Response.Write("Login Successful!");
                Response.Redirect("WelcomePage.aspx");
            }

            else
            {
                Response.Write("The information you have entered is not valid. Please try again.");
            }
        }
    }
}