public partial class Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            String sPath = MapPath(FileUpload1.FileName);
            FileUpload1.PostedFile.SaveAs(sPath);
            FileUpload1.SaveAs(Server.MapPath("images//" + FileUpload1.FileName));
            lbl_Receive.Text = "Received " + FileUpload1.FileName + ", Content Type " + FileUpload1.PostedFile.ContentType + ", Length " + FileUpload1.PostedFile.ContentLength;

            string mysql;
            mysql = "insert into Products (product_id, Product_name, Price, Image) values ('" + txt_ID.Text + "','" + txt_Product.Text + "','" + txt_Price.Text + "','" + FileUpload1.FileName + "')";
            sql_Products.SelectCommand = mysql;
            dl_Products.DataBind();
            Response.Redirect("Upload.aspx");
        }
        else
        {
            lbl_Receive.Text = "Image was not uploaded";
        }
    }
}
