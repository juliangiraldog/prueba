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
using System.Data.OleDb;
using System.Drawing;
using System.Text.RegularExpressions;


public partial class ChateandoConExpertos01 : System.Web.UI.Page
{

    OleDbConnection conn;
    string sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        String documento = String.Empty;
        documento = Session["documento"].ToString();
        txtDocumento.Text = documento;
        txtDocumento.Enabled = false;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        String numId = txtDocumento.Text.Replace("'", "");
        string coment = TextBox1.Text;

        insertarcomentarionuevo(numId, coment);

        Response.Redirect("Gracias01.aspx");
    }

    public void insertarcomentarionuevo(string numeroIdentifica, string Comentarios)
    {
        sql = "INSERT INTO RegTipoComentarioProplan(numeroIdentifica,Comentarios ) VALUES ('" + numeroIdentifica + "','" + Comentarios + "')";
        //return (sql);
        EjecutarDataSet(sql);
    }

    private DataSet EjecutarDataSet(String query)
    {

        AbrirConexion();
        DataSet ds = new DataSet();
        //DataSet dx = new DataSet();
        OleDbCommand cmd = new OleDbCommand(query, conn);
        //OleDbCommand cmd = new OleDbCommand(consult, conn);
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //da.Fill(dx);
        da.Fill(ds);
        CerrarConexion();
        return ds;
    }
    private void AbrirConexion()
    {
        conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["_accessConn"].ToString());
        if (conn.State == ConnectionState.Open)
            return;
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            throw new Exception("Error Al Conectar Con la Base de Datos: " + ex.Message);
        }

    }
    private void CerrarConexion()
    {
        try
        {
            conn.Close();
            conn.Dispose();
        }
        catch (Exception ex)
        {
            throw new Exception("Error Al Cerrar la Conexion Con la Base de Datos: " + ex.Message);
        }

    }
    private String EjecutarScalar(String query)
    {
        AbrirConexion();
        String str;
        OleDbCommand cmd = new OleDbCommand(query, conn);
        str = cmd.ExecuteScalar().ToString();
        CerrarConexion();
        return str;
    }
    
}
