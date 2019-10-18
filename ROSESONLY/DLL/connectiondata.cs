using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Net.Mail;
using DevExpress.XtraEditors;

namespace ROSESONLY.DLL
{
    class connectiondata
    {
        public SqlConnection con;
        public static int screenWidth = 0;
        public static int screenHieght = 0;
        public static int user_id;
        public static string _username;
        public connectiondata()
        {
            string path = Application.StartupPath + @"\DB_ROSES.mdf".ToString();
            switch (Properties.Settings.Default.connection_type)

            {

        case "Local Server":
        con = new SqlConnection(@"server=.\SQL; Database=DB_ROSES; Integrated Security=true");
                    break;
        case "LocalDB2016":
        con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName='" + path + "';Initial Catalog=DB_ROSES;Integrated Security=True;");
        break;

        case "LocalDb2012":
        con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFileName='" + path + "';Initial Catalog=DB_ROSES;Integrated Security=True;");
        break;
            }

        }
        //open connections
        public void opencnnection()
        {
            if(con.State!= ConnectionState.Open)
            {
                con.Open();
            }
        }
        //close connections
        public void closconnection()
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
        }
    public DataTable getdata(string storedname,SqlParameter[]param)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedname;
            cmd.Connection = con;
        if (param!=null)
        {
        foreach (SqlParameter item in param)
            {
                cmd.Parameters.Add(item);
            }
        }
        SqlDataAdapter adptor = new SqlDataAdapter();
        adptor.SelectCommand = cmd;
        DataTable dt = new DataTable();
        adptor.Fill(dt);
        return dt;
        }
    public void runproc(string procname, SqlParameter[] param)//create method for run storedProcedure
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = procname;
        cmd.Connection = con;
        if (param != null)//cheack array value
        {
            foreach (SqlParameter item in param)
            {
                cmd.Parameters.Add(item);
            }
        }
        opencnnection();
        cmd.ExecuteNonQuery();
        closconnection();
    }
    public DataSet get_dataset(string storedname, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedname;
            cmd.Connection = con;
            if (param != null)
            {
                foreach (SqlParameter item in param)
                {
                    cmd.Parameters.Add(item);
                }
            }
            SqlDataAdapter adptor = new SqlDataAdapter();
            adptor.SelectCommand = cmd;
            DataSet dt = new DataSet();
            adptor.Fill(dt);
            return dt;
        }

        //custmize form size
        //public static void ResizeForm(DevExpress.XtraEditors.XtraForm frmName,
        // int currentWidth, int currentHight, int newWidth, int newheight)
        //{
        //    int[] fheight = new int[frmName.Controls.Count];
        //    int[] fwidith = new int[frmName.Controls.Count];
        //    int[] ftop = new int[frmName.Controls.Count];
        //    int[] fleft = new int[frmName.Controls.Count];
        //    //set controls size to array
        //    int ArrayIndex = 0;
        //    foreach (Control item in frmName.Controls)
        //    {
        //        fheight[ArrayIndex] = item.Height;
        //        fwidith[ArrayIndex] = item.Width;
        //        ftop[ArrayIndex] = item.Top;
        //        fleft[ArrayIndex] = item.Left;
        //        ArrayIndex++;
        //    }
        //    //set controls size percen from form
        //    int index = 0;
        //    foreach (Control item in frmName.Controls)
        //    {
        //        item.Width = ((fwidith[index] * newWidth) / currentWidth);
        //        item.Height = ((fheight[index] * newheight) / currentHight);
        //        item.Top = ((ftop[index] * newheight) / currentHight);
        //        item.Left = ((fleft[index] * newWidth) / currentWidth);
        //        index++;
        //    }

        //}
        //    //resizing group panel.....................
        //    public static  void ResizingPanel(DevExpress.XtraEditors.GroupControl Groupcontrol,int CurrentWidth,int CurrentHight,int NewWidth,int NewHeight)
        //{
        //    int[] fheight = new int[Groupcontrol.Controls.Count];
        //    int[] fwidith = new int[Groupcontrol.Controls.Count];
        //    int[] ftop = new int[Groupcontrol.Controls.Count];
        //    int[] fleft = new int[Groupcontrol.Controls.Count];
        //    //set controls size to array
        //    int ArrayIndex = 0;
        //    foreach (Control item in Groupcontrol.Controls)
        //    {
        //        fheight[ArrayIndex] = item.Height;
        //        fwidith[ArrayIndex] = item.Width;
        //        ftop[ArrayIndex] = item.Top;
        //        fleft[ArrayIndex] = item.Left;
        //        ArrayIndex++;
        //    }
        //    //set controls size percen from form
        //    int index = 0;
        //    foreach (Control item in Groupcontrol.Controls)
        //    {
        //        item.Width = ((fwidith[index] * NewWidth) / CurrentWidth);
        //        item.Height = ((fheight[index] * NewHeight) / CurrentHight);
        //        item.Top = ((ftop[index] * NewHeight) / CurrentHight);
        //        item.Left = ((fleft[index] * NewWidth) / CurrentWidth);
        //        index++;
        //    }

        //}








    }
}
