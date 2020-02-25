
public partial class Login : System.Web.UI.Page
{
    private object sessionname;
    private object cookiedate;

    Random r = new Random();
    int num;

    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_login_failed.Text = "";

        num = r.Next();

        txt_random.Text = num.ToString();
    }

    private bool AuthenticateviaDatabase()
   {
        peopleTableAdapters.peopleTableAdapter user = new peopleTableAdapters.peopleTableAdapter();
        people.peopleDataTable usertable = user.GetData();

        foreach (DataRow row in usertable.Rows)
            if ((txt_username.Text == System.Convert.ToString(row["username"])) && 
                  (txt_password.Text == System.Convert.ToString(row["password"])))
            {
                return true;
            }
        {
            txt_username.Text = "fail";
            return false;
        }
    }
    private bool AnitBot()
    {
        if (txt_username.Text == num.ToString())
        {
            lbl_login_failed.Text = "Anti-Bot Success!";
            return true;
        }
        else
        {
            lbl_login_failed.Text = "Failed!";
            return false;
        }
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        if (AnitBot())
        {
            txt_username.Text = "correct";
        }
    }
   
  
