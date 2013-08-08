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

public partial class Registro01 : System.Web.UI.Page
{

    OleDbConnection conn;
    string sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["documento"] == null)
            {
                Response.Redirect("Inicio01.aspx");
            }
            String documento = String.Empty;
            String tipoDocumento = String.Empty;
            documento = Session["documento"].ToString();
            tipoDocumento = Session["tipoDocumento"].ToString();
            txtDocumento.Text = documento;
            lstDocumento.SelectedValue = tipoDocumento;
            txtDocumento.Enabled = false;
            lstDocumento.Enabled = false;
            int i;
            string x;
            //string y;
            //this.ddlAnioP.Items.Insert(0,"Año");

            for (i = 0; i <= 80; i++)
            {
                x = Convert.ToString(DateTime.Now.Year - i);
                this.lstAnio.Items.Insert(i + 1, x);
                this.lstanioG.Items.Insert(i + 1, x);
                this.lstAnioNac.Items.Insert(i + 1, x);
            }
        }
        if (!IsPostBack)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = false;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        String nombre = txtNombre.Text;
        String apellido = txtApellidos.Text;
        String telFijo = txtTelefono.Text;
        String Sexof;
        if (femenino.Checked)
        {
            Sexof = "Mujer";
        }
        else
        {
            Sexof = "Hombre";
        }


        String ciudad = lstCiudad.SelectedValue;
        String direccion = txtDireccion.Text;
        String tipoId = lstDocumento.SelectedItem.Text;
        String numId = txtDocumento.Text.Replace("'", "");
        String fechaHoy = DateTime.Today.Month.ToString(lstMesNac.SelectedItem.ToString()) + "/" + DateTime.Today.Day.ToString(lstDiaNac.SelectedItem.ToString()) + "/" + DateTime.Today.Year.ToString(lstAnioNac.SelectedItem.ToString());
        String cel = txtCelular.Text;
        String mail = txtMail.Text;
        String TipoMasc;
        String Gato = txtNombreGato.Text;
        String sGato;
        String FGato = DateTime.Today.Month.ToString(LstMesG.SelectedItem.ToString()) + "/" + DateTime.Today.Day.ToString(LstDiaG.SelectedItem.ToString()) + "/" + DateTime.Today.Year.ToString(lstanioG.SelectedItem.ToString());
        String Raza = lstRazaG.SelectedValue;
        if (HembraG.Checked)
        {
            sGato = "hembra";
        }
        else
        {
            sGato = "Macho";
        }
        String Perro = TxtNomP.Text;
        String sPerro;
        String FPerro = DateTime.Today.Month.ToString(lstMes.SelectedItem.ToString()) + "/" + DateTime.Today.Day.ToString(lstDia.SelectedItem.ToString()) + "/" + DateTime.Today.Year.ToString(lstAnio.SelectedItem.ToString());
        String RazaP = LstRazaP.SelectedValue;
        if (RdHembraP.Checked)
        {
            sPerro = "hembra";
        }
        else
        {
            sPerro = "Macho";
        }

        if (chgato.Checked)
        {
            TipoMasc = "Gato";
        }
        else
        {
            TipoMasc = "Perro";
        }

        if (chgato.Checked == true && chperro.Checked == true)
        {
            TipoMasc = "Gato , perro";
        }



        //if (chgato.Checked == true) {

        //    String nombreGato = txtNombreGato.Text;
        //    String fechagat=DateTime.now


        //}


        if (txtNombre.Text == String.Empty)
        {
            Label2.Text = "El nombres es obligatorio";
            txtNombre.Focus();
            return;
        }

        if (txtApellidos.Text == String.Empty)
        {
            Label2.Text = "El apellidos es obligatorio";
            txtApellidos.Focus();
            return;
        }
        if (lstDiaNac.SelectedValue == "" || lstMesNac.SelectedValue == "" || lstAnioNac.SelectedValue == "")
        {
            Label2.Text = "La fecha de nacimiento es obligatorio";
            lstDiaNac.Focus();
            return;
        }
        String diaGa = LstDiaG.SelectedItem.Text;
        String mesGa = LstMesG.SelectedValue;
        String anioGa = lstanioG.SelectedItem.Text;
        String fechaNacGato = mesGa + "-" + diaGa + "-" + anioGa;
        if (anioGa == "")
        {
            fechaNacGato = "1900/01/01";
        }
        String diaPe = lstDia.SelectedItem.Text;
        String mesPe = lstMes.SelectedValue;
        String anioPe = lstAnio.SelectedItem.Text;
        String fechaNacPerro = mesPe + "-" + diaPe + "-" + anioPe;
        if (anioPe == "")
        {
            fechaNacPerro = "1900/01/01";
        }

        String diaP = lstDiaNac.SelectedItem.Text;
        String mesP = lstMesNac.SelectedValue;
        String anioP = lstAnioNac.SelectedItem.Text;
        String fechaNacP = mesP + "-" + diaP + "-" + anioP;
        if (mesP == "")
        {
            fechaNacP = "1900/01/01";
        }
        String info = "1";
        int anioActual = DateTime.Now.Year;
        int anioNac = Convert.ToInt16(lstAnioNac.SelectedValue);
        int difEdad = anioActual - anioNac;
        if (difEdad <= 13)
        {
            Label2.Text = "La Fecha es incorrecta.Debe ser mayor de 13 años";
            return;
        }

        if (femenino.Checked == false && masculino.Checked == false)
        {
            Label2.Text = "El sexo es obligatorio";
            femenino.Focus();
            return;
        }
        if (txtTelefono.Text == String.Empty)
        {
            Label2.Text = "El teléfono es obligatorio";
            txtTelefono.Focus();
            return;
        }
        if (IsText(txtTelefono.Text))
        {
            Label2.Text = "Debe ingresar Numeros";
            txtTelefono.Focus();
            return;
        }
        if (txtCelular.Text == String.Empty)
        {
            Label2.Text = "El celular es obligatorio";
            txtCelular.Focus();
            return;
        }
        if (IsText(txtCelular.Text))
        {
            Label2.Text = "Debe ingresar Numeros";
            txtCelular.Focus();
            return;
        }
        if (txtMail.Text == String.Empty)
        {
            Label2.Text = "El E-mail es obligatorio";
            txtMail.Focus();
            return;
        }

        if (txtDireccion.Text == String.Empty)
        {
            Label2.Text = "La dirección es obligatorio";
            txtDireccion.Focus();
            return;
        }

        if (lstCiudad.SelectedValue == "")
        {
            Label2.Text = "La ciudad es obligatorio";
            Label2.Focus();
            return;
        }
        if (chgato.Checked == false && chperro.Checked == false)
        {
            Label2.Text = "Seleccione La clase de mascota que tiene";
            Label2.Focus();
            return;

        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //if (chgato.Checked == true)
        //{
        //    LbNomGato.Visible = true;
        //    txtNombreGato.Visible = true;
        //    LbFechNaciG.Visible = true;
        //    LstDiaG.Visible = true;
        //    LstMesG.Visible = true;
        //    lstanioG.Visible = true;
        //    lstRazaG.Visible = true;
        //    LbSexGato.Visible = true;
        //    HembraG.Visible = true;
        //    MachoG.Visible = true;
        //    LbRazaGato.Visible = true;



        // }else{

        //     LbNomGato.Visible = false;
        //     txtNombreGato.Visible = false;
        //     LbFechNaciG.Visible = false;
        //     LstDiaG.Visible = false;
        //     LstMesG.Visible = false;
        //     lstanioG.Visible = false;
        //     lstRazaG.Visible = false;
        //     LbSexGato.Visible = false;
        //     HembraG.Visible = false;
        //     MachoG.Visible = false;

        // }
        //if (chperro.Checked == true)
        //{

        //    LbNomPerro.Visible = true;
        //    TxtNomP.Visible = true;
        //    LbSexoP.Visible = true;
        //    RdHembraP.Visible = true;
        //    RdMachoP.Visible = true;
        //    LbFechPerro.Visible = true;
        //    lstDia.Visible = true;
        //    lstMes.Visible = true;
        //    lstAnio.Visible = true;
        //    LbRazaP.Visible = true;
        //    LstRazaP.Visible = true;




        //}
        //else
        //{

        //    LbNomPerro.Visible = false;
        //    TxtNomP.Visible = false;
        //    LbSexoP.Visible = false;
        //    RdHembraP.Visible = false;
        //    RdMachoP.Visible = false;
        //    LbFechPerro.Visible = false;
        //    lstDia.Visible = false;
        //    lstMes.Visible = false;
        //    lstAnio.Visible = false;
        //    LbRazaP.Visible = false;
        //    LstRazaP.Visible = false;



        //}


        //if (chgato.Checked == true && chperro.Checked == true)
        //{

        //    LbNomGato.Visible = true;
        //    txtNombreGato.Visible = true;
        //    LbFechNaciG.Visible = true;
        //    LstDiaG.Visible = true;
        //    LstMesG.Visible = true;
        //    lstanioG.Visible = true;
        //    lstRazaG.Visible = true;
        //    LbSexGato.Visible = true;
        //    HembraG.Visible = true;
        //    MachoG.Visible = true;
        //    LbNomPerro.Visible = true;
        //    TxtNomP.Visible = true;
        //    LbSexoP.Visible = true;
        //    RdHembraP.Visible = true;
        //    RdMachoP.Visible = true;
        //    LbFechPerro.Visible = true;
        //    lstDia.Visible = true;
        //    lstMes.Visible = true;
        //    lstAnio.Visible = true;
        //    LbRazaP.Visible = true;
        //    LstRazaP.Visible = true;



        //}

        ///////////////////////////////////////////////////////////////////////////////




        if (chgato.Checked)
        {

            if (txtNombreGato.Text == String.Empty)
            {
                Label2.Text = "El Nombre del gato es obligatorio";
                txtDireccion.Focus();
                return;
            }
            if (LstDiaG.SelectedValue == "" || LstMesG.SelectedValue == "" || lstanioG.SelectedValue == "")
            {
                Label2.Text = "Ingrese Fecha de nacimiento del gato";
                return;
            }

            if (lstRazaG.SelectedValue == "")
            {
                Label2.Text = "La raza del Gato es obligatorio";
                Label2.Focus();
                return;
            }

            if (HembraG.Checked == false && MachoG.Checked == false)
            {
                Label2.Text = "El sexo del gato  es obligatorio";
                Label2.Focus();
                return;
            }

        }
        if (chperro.Checked)
        {
            if (TxtNomP.Text == String.Empty)
            {
                Label2.Text = "El Nombre del Perro es obligatorio";
                txtDireccion.Focus();
                return;
            }

            if (lstDia.SelectedValue == "" || lstMes.SelectedValue == "" || lstAnio.SelectedValue == "")
            {
                Label2.Text = "Ingrese Fecha de nacimiento del perro";

                return;
            }

            if (LstRazaP.SelectedValue == "")
            {
                Label2.Text = "La raza del Perro es obligatorio";

                return;
            }



            if (RdHembraP.Checked == false && RdMachoP.Checked == false)
            {
                Label2.Text = "El sexo del Perro es obligatorio";
                femenino.Focus();
                return;
            }


        }
        if (CheckBox1.Checked == false)
        {
            Label2.Text = "Debe aceptar ";
            CheckBox1.Focus();
            return;

        }

        //  DateTime viejaFecha = new DateTime(Convert.ToInt32(this.lstAnioNac.SelectedItem.Value), Convert.ToInt32(this.lstMesNac.SelectedItem.Value), 1);
        // DateTime nuevaFecha = DateTime.Now;


        // String fechaActual = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();

        /* insertarRegistroNuevo (numId, tipoId, nombre + " " + apellido, "", ciudad, "", direccion, telFijo, cel, mail, "1900/01/01",
             "",  fechaHoy,  TipoMasc, "", "");*/
        //insertarRegistroNuevo(numId, tipoId, nombre, apellido, fechaHoy, sexof, telFijo, cel, mail, direccion, ciudad, TipoMasc);
        DateTime viejaFecha = new DateTime(Convert.ToInt32(this.lstAnioNac.SelectedItem.Value), Convert.ToInt32(this.lstMesNac.SelectedItem.Value), 1);
        DateTime nuevaFecha = DateTime.Now;

        // Diferencia en días, horas y minutos 
        TimeSpan ts = nuevaFecha - viejaFecha;
        // Diferencia en días
        int edadMeses = ts.Days / 30;
        String fechaActual = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
        if (validarRegistroNuevo(numId))
        {
            DataSet dsP = new DataSet();
            DataSet dsR = new DataSet();



            ActualizarRegistroNuevo(tipoId, numId, nombre, apellido, fechaNacP, Sexof, telFijo, cel, mail, direccion, ciudad, info);
            ActualizarMascotaGNueva(numId, Gato, fechaNacGato, Raza, sGato);

        }

        else
        {
            insertarRegistroNuevo(tipoId, numId, nombre, apellido, fechaNacP, Sexof, telFijo, cel, mail, direccion, ciudad, TipoMasc, info);
            
        }
        if (chgato.Checked == true)
        {
            if (validarRegistroNuevoG(numId))
            {
                DataSet dsP = new DataSet();
                DataSet dsR = new DataSet();



                insertarmascotanueva(numId, Gato, fechaNacGato, Raza, sGato);


            }

         
        }

        if (chperro.Checked)
        {
            insertarmascotaPnueva(numId, Perro, fechaNacPerro, RazaP, sPerro);

        }

        Response.Redirect("ChateandoConExpertos01.aspx");


    }

    public bool validarRegistroNuevo(string numeroIdentifica)
    {
        String var = EjecutarScalar("if exists(SELECT  numeroIdentifica FROM RegTipoMascotaProplan WHERE (numeroIdentifica = '" + numeroIdentifica + "')) select 'si' else select 'no'");
        if (var == "si")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool validarRegistroNuevoG(string numeroIdentifica)
    {
        String var = EjecutarScalar2("if exists(SELECT  numeroIdentifica FROM RegTipoDatosGatoProplan ) select 'si' else select 'no'");
        if (var == "si")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public DataSet validar(string numeroIdentifica)
    {
        DataSet ds = new DataSet();
        sql = "SELECT  tipoIdentificacion, numeroIdentifica,   nombre, apellido, fechaNacimiento, sexof";
        sql += " telefono, celular,  email,  direccion ,  ciudad ,TipoMascota ,AceptaInfo FROM RegTipoMascotaProplan ";
        sql += "WHERE numeroIdentifica = ('" + numeroIdentifica + "')";
        ds = EjecutarDataSet(sql);
        return ds;
    }
    public DataSet validarMascotaG(string numeroIdentifica)
    {
        DataSet ds = new DataSet();
        sql = "SELECT  numeroIdentifica, nombreDelGato, fechaNacGato, razaGato, SexoGato FROM RegTipoDatosGatoProplan ";
        sql += "WHERE numeroIdentifica = ('" + numeroIdentifica + "')";
        ds = EjecutarDataSet(sql);
        return ds;
    }

    public DataSet validarMascotaP(string numeroIdentifica)
    {
        DataSet ds = new DataSet();
        sql = "SELECT  numeroIdentifica, nombreDelPerro, fechaNacPerro, razaPerro, SexoPerro FROM RegTipoDatosPerroProplan ";
        sql += "WHERE numeroIdentifica = ('" + numeroIdentifica + "')";
        ds = EjecutarDataSet(sql);
        return ds;
    }
    public void insertarRegistroNuevo(string tipoIdentificacion, string numeroIdentifica, string nombre, string apellido, string fechaNacimiento, string sexof,
    string telefono, string celular, string email, string direccion, string ciudad, string TipoMascota, string AceptaInfo)
    {

        sql = "INSERT INTO RegTipoMascotaProplan (  tipoIdentificacion,numeroIdentifica,   nombre, apellido, fechaNacimiento, sexof,";
        sql += " telefono,celular,  email,  direccion ,  ciudad ,TipoMascota , AceptaInfo) VALUES ('" + tipoIdentificacion + "','" + numeroIdentifica + "','";
        sql += nombre + "','" + apellido + "', CONVERT(DATETIME,'";
        sql += fechaNacimiento + "',101),'" + sexof + "','" + telefono + "','" + celular + "','" + email + "','" + direccion + "','" + ciudad + "','";
        sql += TipoMascota + "','" + AceptaInfo + "')";
        //return (sql);
        EjecutarDataSet(sql);
    }
    public void ActualizarRegistroNuevo(string tipoIdentificacion, string numeroIdentifica, string nombre, string apellido, string fechaNacimiento, string sexof,
    string telefono, string celular, string email, string direccion, string ciudad, string AceptaInfo)
    {

        sql = "UPDATE RegTipoMascotaProplan";
        sql += " SET  tipoIdentificacion = RTRIM(LTRIM('" + tipoIdentificacion + "')), ";
        sql += "numeroIdentifica = RTRIM(LTRIM('" + numeroIdentifica + "')), ";
        sql += "nombre = RTRIM(LTRIM('" + nombre + "')), ";
        sql += "apellido = RTRIM(LTRIM('" + apellido + "')), ";
        sql += "fechaNacimiento = CONVERT(DATETIME,'" + fechaNacimiento + "',101), ";
        sql += "sexof = RTRIM(LTRIM('" + sexof + "')), ";
        sql += "telefono = RTRIM(LTRIM('" + telefono + "')), ";
        sql += "celular = RTRIM(LTRIM('" + celular + "')), ";
        sql += "email = RTRIM(LTRIM('" + email + "')), ";
        sql += "direccion = RTRIM(LTRIM('" + direccion + "')), ";
        sql += "ciudad = RTRIM(LTRIM('" + ciudad + "')), ";
        sql += "AceptaInfo = RTRIM(LTRIM('" + AceptaInfo + "')) ";

        sql += "WHERE numeroIdentifica = RTRIM(LTRIM('" + numeroIdentifica + "'))";

        EjecutarDataSet(sql);
    }
    public void ActualizarMascotaGNueva(string numeroIdentifica, string nombreDelGato,
        string fechaNacGato, string razaGato, string SexoGato)
    {

        sql = "UPDATE RegTipoDatosGatoProplan";
        sql += " SET numeroIdentifica = RTRIM(LTRIM('" + numeroIdentifica + "')), ";
        sql += "nombreDelGato = RTRIM(LTRIM('" + nombreDelGato + "')), ";
        sql += "fechaNacGato = CONVERT(DATETIME,'" + fechaNacGato + "',101), ";
        sql += "razaGato = RTRIM(LTRIM('" + razaGato + "')), ";
        sql += "SexoGato = RTRIM(LTRIM('" + SexoGato + "')) ";
        sql += "WHERE numeroIdentifica = RTRIM(LTRIM('" + numeroIdentifica + "'))";

        EjecutarDataSet(sql);
    }
    public void insertarmascotanueva(string numeroIdentifica, string nombreDelGato, string fechaNacGato, string razaGato, string SexoGato)
    {
        sql = "INSERT INTO RegTipoDatosGatoProplan(numeroIdentifica,nombreDelGato, fechaNacGato,razaGato,SexoGato ) VALUES ('" + numeroIdentifica + "','" + nombreDelGato + "',CONVERT(DATETIME,'";
        sql += fechaNacGato + "',101),'" + razaGato + "','";
        sql += SexoGato + "')";
        //return (sql);
        EjecutarDataSet(sql);
    }

    public void insertarmascotaPnueva(string numeroIdentifica, string nombreDelPerro, string fechaNacPerro, string razaPerro, string SexoPerro)
    {
        sql = "INSERT INTO RegTipoDatosPerroProplan(numeroIdentifica,nombreDelPerro, fechaNacPerro,razaPerro,SexoPerro ) VALUES ('" + numeroIdentifica + "','" + nombreDelPerro + "',CONVERT(DATETIME,'";
        sql += fechaNacPerro + "',101),'" + razaPerro + "','";
        sql += SexoPerro + "')";
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
    private String EjecutarScalar2(String query)
    {
        AbrirConexion();
        String str;
        OleDbCommand cmd = new OleDbCommand(query, conn);
        str = cmd.ExecuteScalar().ToString();
        CerrarConexion();
        return str;
    }

    //{
    //   conBd.InsertarRegTipoMascotaProplan(lstDocumento.Text, Convert.ToInt32(txtDocumento.Text), txtNombre.Text, txtApellidos.Text, DateTime.Parse(lstMesNac.SelectedValue.ToString() + '/' + lstDiaNac.SelectedValue.ToString() + '/' + lstAnioNac.SelectedValue.ToString()), femenino.Text, masculino.Text, Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtCelular.Text), txtMail.Text, txtDireccion.Text, lstCiudad.Text, chgato.Text, chperro.Text, txtNombreGato.Text, TxtNomP.Text, DateTime.Parse(lstMes.SelectedValue.ToString() + '/' + lstDia.SelectedValue.ToString() + '/' + lstAnio.SelectedValue.ToString()), DateTime.Parse(LstMesP.SelectedValue.ToString() + '/' + LstDiaP.SelectedValue.ToString() + '/' + LspAñoP.SelectedValue.ToString()), lstRaza.Text, LstRazaP.Text, Hembra.Text, Macho.Text, RdMachoP.Checked.ToString(), RdHembraP.Checked.ToString());
    //}
    //if(chgato.Checked== true || chperro.Checked== false ){

    //    conBd.InsertarRegTipoMascotaProplan(lstDocumento.Text, Convert.ToInt32(txtDocumento.Text), txtNombre.Text, txtApellidos.Text, DateTime.Parse(lstMesNac.SelectedValue.ToString() + '/' + lstDiaNac.SelectedValue.ToString() + '/' + lstAnioNac.SelectedValue.ToString()), femenino.Text, masculino.Text, Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtCelular.Text), txtMail.Text, txtDireccion.Text, lstCiudad.Text, chgato.Text,  txtNombreGato.Text,  DateTime.Parse(lstMes.SelectedValue.ToString() + '/' + lstDia.SelectedValue.ToString() + '/' + lstAnio.SelectedValue.ToString()),  lstRaza.Text,  Hembra.Text, Macho.Text);
    //}


    //conBd.InsertarRegTipo(char.Parse(lstDocumento.SelectedItem.ToString()), Convert.ToInt32(txtDocumento.Text), txtNombre.Text, txtApellidos.Text, DateTime.Parse(lstMesNac.SelectedItem.ToString() + '/' + lstDiaNac.SelectedItem.ToString() + '/' + lstAnioNac.SelectedItem.ToString()), femenino.Text, masculino.Text, Convert.ToInt32(txtTelefono), Convert.ToInt32(txtCelular), txtMail.Text, txtDireccion.Text, lstCiudad.Text);

    //VALIDA QUE SOLO SE PUEDAN INGRESAR NUMEROS 
    private bool IsText(string strTextEntry)
    {
        Regex objNotWholePattern = new Regex("[^0-9 ]");
        return objNotWholePattern.IsMatch(strTextEntry);
    }

    protected void LbFactura_Click(object sender, EventArgs e)
    {
        //divFacturaLabel.Visible = true;
        //divFacturaText.Visible = true;
        //divFacturaIma1.Visible = true;
        //divFacturaIma2.Visible = true;
        this.Panel1.Visible = true;
        if (chgato.Checked == true && chperro.Checked == true)
        {
            this.Panel2.Visible = true;
            this.Panel1.Visible = true;

        }
        if (chgato.Checked == false) {

            this.Panel1.Visible = false;
        }
    }
    protected void LbFactura2_Click(object sender, EventArgs e)
    {
        //divFacturaLabel.Visible = true;
        //divFacturaText.Visible = true;
        //divFacturaIma1.Visible = true;
        //divFacturaIma2.Visible = true;

        this.Panel2.Visible = true;
        if (chgato.Checked == true && chperro.Checked == true)
        {
            this.Panel2.Visible = true;
            this.Panel1.Visible = true;

        }

        if (chperro.Checked == false)
        {

            this.Panel2.Visible = false;
        }
    }

    
}
