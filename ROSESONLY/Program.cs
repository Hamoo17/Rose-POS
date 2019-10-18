using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using ROSESONLY.forms;
namespace ROSESONLY
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

          //  BonusSkins.Register();
          //  SkinManager.EnableFormSkins();
         //   UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");
            Application.Run(new frm_login());
        }
    }
}
