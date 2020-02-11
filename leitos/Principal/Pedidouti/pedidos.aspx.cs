using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Leitos_Principal_Pedidouti_pedidos : System.Web.UI.Page
{
    string id, setor;
    int ver;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            
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
                    Response.Redirect("../../Default.aspx");
                }
                else
                {
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("select tblogin.*, tblocal.local_setor, tblog.session from tblogin inner join tblocal on tblogin.localt = tblocal.id_local inner join tblog on tblogin.Id = tblog.usuario where tblog.session=@session", cn);
                    cmd.Parameters.AddWithValue("@session", Label1.Text);

                    try
                    {
                        cn.Open();
                        SqlDataReader dr = null;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            id = dr["id"].ToString();
                            setor = dr["local_setor"].ToString();
                            preenche();
                            exame();
                        }
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

    public void preenche()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbpedido.*, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where data_pedido=@data_pedido and uti=@uti  order by leito, hora_pedido desc", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));
        cmd.Parameters.AddWithValue("@uti", setor.Trim());

        try
        {
            cn.Open();
            SqlDataReader le = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(le);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cn.Close();
            cn.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("leito.aspx?session=" + Label1.Text);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("pedidos.aspx?session=" + Label1.Text);
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("examecdi.aspx?session=" + Label1.Text);
    }
    public void exame()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido=@data_pedido and local=@local", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));
        cmd.Parameters.AddWithValue("@local", setor.Trim());
        try
        {
            cn.Open();
            SqlDataReader le = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(le);
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

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string valor = DataBinder.Eval(e.Row.DataItem, "status").ToString();

            if (valor.Trim() == "Exame Cancelado")
            {
                e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
            }
        }
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        foreach(GridViewRow grid in this.GridView2.Rows)
        {
            string id = grid.Cells[0].Text;
            LinkButton link = (LinkButton)grid.Cells[0].FindControl("LinkButton1");
            int.TryParse(link.Text, out ver);

            Response.Write(ver);
        }
    }

    protected void LinkButton4_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../../default.aspx");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "noback()");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Session["setor"] = "UTI";
        Response.Redirect("../../alterausuario.aspx?session=" + Label1.Text);
    }
}