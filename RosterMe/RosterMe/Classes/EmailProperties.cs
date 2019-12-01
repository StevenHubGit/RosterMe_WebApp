using RosterMe.Models.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace RosterMe.Classes
{
    public class EmailProperties
    {
        //Class variables
        private static String LOG_TAG = "Email Properties Class message";
        private static String fromEmail = "";
        private static String toEmail = "";
        private static String subjectEmail = "";
        private static MailPriority priorityEmail;
        private static String fromEmailPassword = "";


        /* ---- Send Email to person: TEST ---- */
        public static bool TEST_SendEmailToPerson()
        {
            //Create boolean to return
            bool isSent = false;

            /* ---- Mail Message to set email content ---- */
            //Instantiate Mail Message
            MailMessage mail = new MailMessage();

            //Set email to receive
            mail.To.Add("cultureonit@gmail.com");

            //Set email to send & format
            mail.From = new MailAddress
            (
                //Email to send from
                "templedelapaix987@gmail.com",
                //Email Head (example: Shift Request)
                "Email head", 
                //Set format
                System.Text.Encoding.UTF8
            );
            
            //Set email subject & format
            mail.Subject = "This mail is send from asp.net application";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            
            //Set email body content & format
            mail.Body = "This is Email Body Text";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            
            //Set email priority
            mail.Priority = MailPriority.High;
            
            /* ---- SMTP Client for setting email & host configuration ---- */
            //Instantiate SMTP Client
            SmtpClient client = new SmtpClient();
            
            //Set SMTP Client settings
            client.Credentials = new NetworkCredential
            (
                //Email to send from
                "templedelapaix987@gmail.com", 
                //Password of account to send from
                "GooStev15"
            );

            //Set SMTP Port
            client.Port = 587;

            //Set SMTP Email Host
            client.Host = "smtp.gmail.com";

            //Set SMTP SSL
            client.EnableSsl = true;

            try
            {
                client.Send(mail);

                //Set boolean
                isSent = true;

                //Print message
                Console.WriteLine(LOG_TAG + ": Alright !" +
                    "\nThe email has been sent to the employee" +
                    "\n\nEmail information" +
                    "\n- From: " + fromEmail +
                    "\n- To: " + toEmail +
                    "\n- Subject: " + subjectEmail +
                    "\n- Priority: " + priorityEmail +
                    "\n\nCredentials" +
                    "\n- From: " + fromEmail +
                    "\n- Password: " + fromEmailPassword
                );
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;

                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }

                Console.WriteLine(LOG_TAG + ": Wait..." +
                    "\nThe email is not sent" +
                    "\n- Message: " + ex.Message
                );
            }

            //Return boolean
            return isSent;
        }

        /* ---- Send Email to employee ---- */
        public static bool sendEmailToInvitedEmployee(
            List<ShiftInvitation> shiftInvitationList, String subject, MailPriority priority)
        {
            //Create boolean to return
            bool isSent = false;

            //Declare variables & store values
            fromEmail = "templedelapaix987@gmail.com";
            fromEmailPassword = "GooStev15";
            priorityEmail = priority;
            subjectEmail = subject;

            //Loop through input List
            foreach(var invitation in shiftInvitationList)
            {
                //Store data
                toEmail = invitation.Employee.Email;
            }

            /* ---- Mail Message to set email content ---- */
            //Instantiate Mail Message
            MailMessage mail = new MailMessage();

            //Set email to receive
            mail.To.Add("cultureonit@gmail.com");
            //mail.To.Add("darylgeorge646@gmail.com");

            //Set email to send & format
            mail.From = new MailAddress
            (
                //Email to send from
                fromEmail,
                //Email Head (example: Shift Request)
                "Shift Request",
                //Set format
                System.Text.Encoding.UTF8
            );

            //Set email subject & format
            mail.Subject = subjectEmail;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            //Set email body content & format
            mail.Body = 
                "Good Day !" +
                "\n\nThis is a test for shift confirmation";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;

            //Set email priority
            mail.Priority = MailPriority.High;

            /* ---- SMTP Client for setting email & host configuration ---- */
            //Instantiate SMTP Client
            SmtpClient client = new SmtpClient();

            //Set SMTP Client settings
            client.Credentials = new NetworkCredential
            (
                //Email to send from
                fromEmail,
                //Password of account to send from
                fromEmailPassword
            );

            //Set SMTP Port
            client.Port = 587;

            //Set SMTP Email Host
            client.Host = "smtp.gmail.com";

            //Set SMTP SSL
            client.EnableSsl = true;

            try
            {
                client.Send(mail);

                //Set boolean
                isSent = true;

                //Print message
                Console.WriteLine(LOG_TAG + ": Alright !" +
                    "\nThe email has been sent to the employee" +
                    "\n\nEmail information" +
                    "\n- From: " + fromEmail +
                    "\n- To: " + toEmail +
                    "\n- Subject: " + subjectEmail +
                    "\n- Priority: " + priorityEmail +
                    "\n\nCredentials" +
                    "\n- From: " + fromEmail +
                    "\n- Password: " + fromEmailPassword
                );
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;

                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }

                Console.WriteLine(LOG_TAG + ": Wait..." +
                    "\nThe email is not sent" +
                    "\n- Message: " + ex.Message
                );
            }

            //Return boolean
            return isSent;
        }
    }
}
