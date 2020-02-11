using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Principal_principal : System.Web.UI.Page
{
    public static string id, id_session, sui;
    SqlConnection cn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            preenche();
        }
        else
        {
            if (Request.Cookies == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                
                Label1.Text = Request.QueryString["session"];
                if (Request.QueryString["session"] == null)
                {
                    Response.Redirect("../Default.aspx");
                }
                else
                {
                    azul();
                    verde();
                    uco();
                    cc();
                    

                    cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("select tbpedido.*, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where tbpedido.uti = 'UTI Lilas' and tbpedido.leito IS NULL order by leito, hora_pedido desc", cn);

                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        grdLilas.DataSource = dt;
                        grdLilas.DataBind();
                        dr.Close();
                        dt.Clear();


                        cmd = new SqlCommand("select tbtransfere.*, tblogin.nome_completo from tbtransfere inner join tblogin on tbtransfere.usuario_pedido = tblogin.Id where data_pedido = '" + DateTime.Now.ToString("dd/MM/yyyy") + "' and not tbtransfere.local = 'Centro Cirurgico' and tbtransfere.leito IS NULL order by leito, hora_pedido desc", cn);

                        dr = cmd.ExecuteReader();
                        dt = new DataTable();
                        dt.Load(dr);
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
                        cn.Close();
                        cn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }
    }
    protected void LinkButton3_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../registrar.aspx?session=" + Label1.Text);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("dados.aspx?session=" + Label1.Text);
    }
    public void azul()
    {
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbpedido.*, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where tbpedido.uti = 'UTI Azul' and tbpedido.leito IS NULL order by leito, hora_pedido desc", cn);

        cn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dr);
        grdAzul.DataSource = dt;
        grdAzul.DataBind();

        cn.Close();
        cn.Dispose();
    }
    public void verde()
    {
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbpedido.*, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where tbpedido.uti = 'UTI Verde' and tbpedido.leito IS NULL order by leito, hora_pedido desc", cn);

        cn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dr);
        grdVerde.DataSource = dt;
        grdVerde.DataBind();

        cn.Close();
        cn.Dispose();
    }
    public void uco()
    {
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbpedido.*, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where tbpedido.uti = 'UTI Coronariana' and tbpedido.leito IS NULL order by leito, hora_pedido desc", cn);

        cn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dr);
        grduco.DataSource = dt;
        grduco.DataBind();

        cn.Close();
        cn.Dispose();
    }
    public void cc()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbtransfere.*, tblogin.nome_completo from tbtransfere inner join tblogin on tbtransfere.usuario_pedido = tblogin.Id where tbtransfere.leito IS NULL and tbtransfere.local='Centro Cirurgico ' order by leito, hora_pedido desc", cn);

        cn.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dr);
        grdCC.DataSource = dt;
        grdCC.DataBind();
        cn.Close();
        cn.Dispose();
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Session["setor"] = "ADM";
        Response.Redirect("../alterausuario.aspx?session=" + Label1.Text);
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("recuti.aspx?session=" + Label1.Text);
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "Editar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView2.Rows[index];
            LinkButton pront = (LinkButton)row.FindControl("LinkButton6");
            string prontlilas = Convert.ToString(pront.Text);
           

            DropDownList3.Attributes.Add("required", "");
            TextBox11.Attributes.Add("placeholder", "Quarto");
            TextBox11.Attributes.Add("required", "");
            DropDownList2.Attributes.Add("required", "");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowPopup()", true);
        }
        
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        inserir();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }

    protected void grdLilas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grdLilas.Rows[index];
            LinkButton pront = (LinkButton)row.FindControl("LinkButton7");
            string prontconv = Convert.ToString(pront.Text);
            Label14.Text = prontconv;

            DropDownList3.Attributes.Add("required", "");
            TextBox11.Attributes.Add("placeholder", "Quarto");
            TextBox11.Attributes.Add("required", "");
            DropDownList2.Attributes.Add("required", "");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowPopup()", true);
        }
    }

    public void preenche()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tblogin.*, tblocal.local_setor, tblog.session from tblogin inner join tblocal on tblogin.localt = tblocal.id_local inner join tblog on tblogin.Id = tblog.usuario where tblog.session=@session", cn);
        cmd.Parameters.AddWithValue("@session", Request.QueryString["session"]);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id_session = dr["id"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cn.Close();
            cn.Dispose();
        }
    }
    public void inserir()
    {
        if (DropDownList3.Text == "Suite 2 leitos")
        {
            sui = DropDownList3.Text + "-" + TextBox11.Text + "-" + DropDownList2.Text;
        }
        else
        {
            sui = TextBox11.Text + "-" + DropDownList2.Text;
        }
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("update tbpedido set leito=@leito, usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where num_atendimento=@num_atendimento and data_pedido=@data_pedido", cn);
        cmd.Parameters.AddWithValue("@leito", sui);
        cmd.Parameters.AddWithValue("@usuario_libera", id_session);
        cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora_libera", DateTime.Now.ToShortTimeString());
        cmd.Parameters.AddWithValue("@num_atendimento", Label14.Text);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}