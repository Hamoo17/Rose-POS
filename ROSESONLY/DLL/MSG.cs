using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROSESONLY.forms;
namespace ROSESONLY.DLL
{
    class MSg
    {

        public enum msgbutton
        {
            ok = 1,
            okcancel = 2,
        }

        public enum msgicon
        {
            information = 1,
            warning = 2,
            saved = 3,
            delete = 4,
        }
        public enum result
        {
            OK,
            CANCEL,
        }
        public static result showmsg(string msgtext, msgbutton msgbutton, msgicon msgicon)
        {
            frm_msg.getmain.lb_msgtxt.Text = msgtext;
            if (msgbutton == msgbutton.ok)
            {
                frm_msg.getmain.btn_cancel.Visible = false;
                frm_msg.getmain.btn_ok.Visible = false;
                frm_msg.getmain.ClientSize = new System.Drawing.Size(289, 40);
                frm_msg.getmain.timer1.Enabled = true;
                frm_msg.getmain.changlocation();
            }

            switch (msgicon)
            {
                case msgicon.information:
                    frm_msg.getmain.msg_icon.Image = ROSESONLY.Properties.Resources.informations;
                    break;

                case msgicon.warning:
                    frm_msg.getmain.msg_icon.Image = ROSESONLY.Properties.Resources.warning;
                    break;

                case msgicon.saved:
                    frm_msg.getmain.msg_icon.Image = ROSESONLY.Properties.Resources.save;
                    break;

                case msgicon.delete:
                    frm_msg.getmain.msg_icon.Image = ROSESONLY.Properties.Resources.delete;
                    break;
            }

            frm_msg.getmain.ShowDialog();
            if (frm_msg.status == "OK")
            {
                return result.OK;
            }
            else
            {
                return result.CANCEL;
            }
        }
    }
}
