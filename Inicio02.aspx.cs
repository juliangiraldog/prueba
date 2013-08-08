using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Drawing;

public partial class Inicio02 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        if (dSeleccion.SelectedValue == "")
        {
            Label1.Text = "Debe seleccionar un tipo de identificación";
            dSeleccion.Focus();
            return;
        }
        if (TextBox1.Text == String.Empty)
        {
            Label1.Text = "Debe ingresar su número de identificación";
            TextBox1.Focus();
            return;
        }

        if (IsText(TextBox1.Text))
        {
            Label1.Text = "Debe ingresar Numeros";
            TextBox1.Focus();
            return;
        }
        Session["documento"] = TextBox1.Text;
        Session["tipoDocumento"] = dSeleccion.SelectedValue;
        Response.Redirect("Registro01.aspx");


    }
    private bool IsText(string strTextEntry)
    {
        Regex objNotWholePattern = new Regex("[^0-9 ]");
        return objNotWholePattern.IsMatch(strTextEntry);
    }
}
