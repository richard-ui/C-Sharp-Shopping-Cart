public partial class Products : System.Web.UI.Page
{
//get database class
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
        Item.ProductsDataTable prodTable = item.GetData(); // this code demonstrates the use of an adapter to retrive the current
        //items avaiable to customers

        cartTableAdapters.CartTableAdapter cartitem = new cartTableAdapters.CartTableAdapter();
        cart.CartDataTable cartTable = cartitem.GetData(); // this adapter retrives all the cart items added by the customer

        int i = grd_load.SelectedIndex; // certain row selected

        if (System.Convert.ToString(prodTable.Rows[i]["product_id"]) == System.Convert.ToString(cartTable.Rows[i]["cartId"]))
        {
            txt_search.Text = "error!"; // if the id of the product has already been selected then provide this error
        }
        else
        {
            string ins = "Insert into [Cart](cartId, Product_name, Price, Image) values('" + System.Convert.ToString(prodTable.Rows[i]["product_id"]) + "', '" + System.Convert.ToString(prodTable.Rows[i]["Product_name"]) + "', '" + System.Convert.ToDouble(prodTable.Rows[i]["Price"]) + "', '" + System.Convert.ToString(prodTable.Rows[i]["Image"]) + "')";
            SqlCommand com = new SqlCommand(ins, con);
            con.Open();
            com.ExecuteNonQuery(); // if id not already added to cart table then use sql insert statement to insert the selected item into cart table 
            con.Close();

            Response.Redirect("Cart.aspx"); // redirect to cart page to view addedd item(s)
        }
    }
