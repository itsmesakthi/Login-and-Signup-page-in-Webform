using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.Script.Services;

namespace Home
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userid = TextUser.Text;
                string password = TextPass.Text;
                sqlcon.Open();
                string sqlqry = "select * from Login where user_id='" + userid + "' and password='" + password + "'";
                SqlCommand cmd = new SqlCommand(sqlqry, sqlcon);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    LogInfo.Text = "Login Sucessfully......!!";
                }
                else
                {
                    LogInfo.Text = "UserId & Password Is not correct Try again..!!";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }          

        public RegNewUserResult DoRegNewUser(String userid, String password)
        {

            if (this.IsUsernameExists(userid))
            {
                return RegNewUserResult.UsernameAlreadyExists;
            }
            else if (userid == "" && password == "")
            {
                return RegNewUserResult.UsernameorPasswordIsEmpty;
            } 
            else if(userid != "" && password != ""){
                sqlcon.Open();
                string sqlqry = "INSERT INTO Login (user_id, password) VALUES ('" + userid + "','" + password + "')";
                SqlCommand sqlcmd = new SqlCommand(sqlqry, sqlcon);
                sqlcmd.ExecuteNonQuery();
                TextUser.Text = "";
                TextPass.Text = "";
            }
            sqlcon.Close();
            return RegNewUserResult.Success;
        }
        public Boolean IsUsernameExists(String userid)
        {
            string sqlqry = "select user_id from Login where user_id=@user_id";
            SqlCommand sqlcmd = new SqlCommand(sqlqry, sqlcon);
            SqlParameter parausername = sqlcmd.Parameters.Add("@user_id", SqlDbType.NVarChar);
            parausername.Value = userid;
            try
            {
                sqlcon.Open();
                Object result = sqlcmd.ExecuteScalar();
                return result != null;
            }
            finally
            {
                sqlcon.Close();
            }
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
        protected void ButtonSignup_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }
            String userid = TextUser.Text;
            String password = TextPass.Text;
            RegNewUserResult result = this.DoRegNewUser(userid, password);

            if (result == RegNewUserResult.UsernameAlreadyExists)
            {
                LogInfo.Text = ("Username [" + userid + "] is already exists. !");
            }
            else if (result == RegNewUserResult.UsernameorPasswordIsEmpty)
            {
                LogInfo.Text = ("Username or password should not be empty!!!");
            }
            else if (result == RegNewUserResult.DatabaseFail)
            {
                //JSHelper.MsgBox("Database error, please try later.");
                LogInfo.Text = ("Database error, please try later.");
            }
            else if (result == RegNewUserResult.Success)
            {
                FormsAuthentication.SetAuthCookie(userid, false);
                LogInfo.Text = ("Signup Completed");
                //Response.Redirect("~/Login.aspx");
            }
        }

        public ForgetPasswordResult DoUpdateForgetPassword(string userid, string password)
        {
            if (userid == "" && password == "")
            {
                return ForgetPasswordResult.UsernameorPasswordIsEmpty;
            }
            try
            {
                sqlcon.Open();
                string sqlqry = "UPDATE Login SET password='" + password + "' WHERE user_id ='" + userid + "'";
                SqlCommand sqlcmd = new SqlCommand(sqlqry, sqlcon);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            sqlcon.Close();
            return ForgetPasswordResult.success;

        }
        protected void ButtonForget_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }
            string userid = TextUser.Text;
            string password = TextPass.Text;
            ForgetPasswordResult result = this.DoUpdateForgetPassword(userid, password);

            if (result == ForgetPasswordResult.UsernameorPasswordIsEmpty)
            {
                LogInfo.Text = ("Username and password should not be empty!!!");
            }
            else if (result == ForgetPasswordResult.DatabaseFail)
            {
                //JSHelper.MsgBox("Database error, please try later.");
                LogInfo.Text = ("Database error, please try later.");
            }
            else if (result == ForgetPasswordResult.success)
            {
                LogInfo.Text = ("Password update completed successfully.");
                //Response.Redirect(url: "~/Login.aspx");
                //Response.Redirect("~/Login.aspx");
            }

        }
        public enum RegNewUserResult
        {
            Success,
            UsernameAlreadyExists,
            UsernameorPasswordIsEmpty,
            DatabaseFail
        }
        public enum ForgetPasswordResult
        {
            success,
            UsernameorPasswordIsEmpty,
            DatabaseFail
        }
    }
}