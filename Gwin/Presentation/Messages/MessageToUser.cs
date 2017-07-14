using App.Gwin.Application.Presentation.Messages;
using App.Gwin.Presentation.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Gwin.Application.Presentation.Messages
{
    /// <summary>
    /// Show message in Presentation Layer
    /// </summary>
    public class MessageToUser
    {
        /// <summary>
        /// Messages categories
        /// </summary>
        public enum Category {
            MultiLanguageResourceFile,
            BusinessRule,
            Convert,
            ForeignKeViolation,
            EntityValidation
        } 
       

        static MessageToUser()
        {
            

        }

        public static void AddMessage(Category category, string msg)
        {
            // Not Show Message at Test
            //if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            //{
                switch (category)
                {
                    case Category.MultiLanguageResourceFile:
                        MessageBox.Show(msg, MessageToUser_Resource.MultiLanguageResourceFile_Title);
                        break;
                    case Category.BusinessRule:
                        MessageBox.Show(msg, MessageToUser_Resource.BusinessRule_Title);
                        break;
                    case Category.Convert:
                        MessageBox.Show(msg, MessageToUser_Resource.Convert_Title);
                        break;
                    case Category.ForeignKeViolation:
                        if (msg == string.Empty) msg = MessageToUser_Resource.ForeignKeViolation_Message;
                        MessageBox.Show(msg, MessageToUser_Resource.ForeignKeViolation_Title);
                        break;
                    case Category.EntityValidation:
                        if (msg == string.Empty) msg = MessageToUser_Resource.EntityValidation_Message;
                        MessageBox.Show(msg, MessageToUser_Resource.EntityValidation_Title);
                        break;
                    default:
                        break;
                }
            //}

          

            
        }

    }
}
