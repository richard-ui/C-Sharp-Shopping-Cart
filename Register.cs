public partial class register : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection con1 = new SqlConnection();  // establishes new connection

    static string Encrypt(string value)   // string method to for encryption
    {
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())       // uses md5 hasg function to appropriately encrpt
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] data = md5.ComputeHash(utf8.GetBytes(value));
            return Convert.ToBase64String(data);
        }
    }

    
    private bool authenticateUsernameViaDatabase() // private method
    {
        peopleTableAdapters.peopleTableAdapter peopleEnc = new peopleTableAdapters.peopleTableAdapter();
        people.peopleDataTable peopleTable = peopleEnc.GetData();

        foreach (DataRow row in peopleTable.Rows)
            if ((txt_username.Text == System.Convert.ToString(row["username"])))              // checks to see if username exists, return true
            {
                return true;
            }
        {
            return false;
        }

    }
