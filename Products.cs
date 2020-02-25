public partial class Products : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\rickysDB.mdf;Integrated Security=True");

    protected void Page_Load(object sender, EventArgs e)
    {
        grd_search.Visible = false;

    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        grd_load.Visible = false;
        grd_search.Visible = true;
    }

    protected void grd_load_SelectedIndexChanged(object sender, EventArgs e)
    {
        ItemTableAdapters.ProductsTableAdapter item = new ItemTableAdapters.ProductsTableAdapter();
        Item.ProductsDataTable prodTable = item.GetData();

        cartTableAdapters.CartTableAdapter cartitem = new cartTableAdapters.CartTableAdapter();
        cart.CartDataTable cartTable = cartitem.GetData();

        int i = grd_load.SelectedIndex; // row selected

        if (System.Convert.ToString(prodTable.Rows[i]["product_id"]) == System.Convert.ToString(cartTable.Rows[i]["cartId"]))
        {
            txt_search.Text = "error!";
        }
        else
        {
            string ins = "Insert into [Cart](cartId, Product_name, Price, Image) values('" + System.Convert.ToString(prodTable.Rows[i]["product_id"]) + "', '" + System.Convert.ToString(prodTable.Rows[i]["Product_name"]) + "', '" + System.Convert.ToDouble(prodTable.Rows[i]["Price"]) + "', '" + System.Convert.ToString(prodTable.Rows[i]["Image"]) + "')";
            SqlCommand com = new SqlCommand(ins, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            Response.Redirect("Cart.aspx");
        }
    }
