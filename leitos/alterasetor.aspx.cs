using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class alterarsetor : System.Web.UI.Page
{
    public static string setor;
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
                Label2.Text = Request.QueryString["session"];
                if (Request.QueryString["session"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    preenche();
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("select tblogin.*, tblocal.*, tblog.session from tblogin inner join tblocal on tblogin.localt = tblocal.id_local inner join tblog on tblogin.Id = tblog.usuario where tblog.session=@session", cn);
                    cmd.Parameters.AddWithValue("@session", Request.QueryString["session"].ToString());

                    try
                    {
                        cn.Open();
                        SqlDataReader dr = null;
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            DropDownList1.Items.Add(dr["local_setor"].ToString());
                            DropDownList1.Enabled = false;
                            Label3.Text = dr["id"].ToString();
                            //setor = dr["local_setor"].ToString();
                            Label1.Text = dr["id_local"].ToString();
                            
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
            }
        }
    }
    public void preenche()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tblocal where not local_setor = 'Recepção C' and not local_setor = 'Recepção A' and not local_setor = 'Recepção UTI' and not local_setor = 'Centro de Imagem' order by local_setor", cn);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList2.Items.Add(dr["local_setor"].ToString());
            }
            dr.Close();

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

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(DropDownList2.Text == DropDownList1.Text)
        {
            Label4.Text = "Atenção: O setor de trabalho não pode ser o mesmo que o anterior";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
        }
        else
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update tblogin set localt=@localt where id=@id", cn);
            cmd.Parameters.AddWithValue("@localt", Label1.Text);
            cmd.Parameters.AddWithValue("@id", Label3.Text);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Label4.Text = "Setor alterado com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "sucesso();", true);
                cn.Close();
                Response.AddHeader("Refresh", "2;URL=Default.aspx");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tblocal where local_setor=@local_setor ", cn);
        cmd.Parameters.AddWithValue("@local_setor", DropDownList2.Text);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Label1.Text = dr["id_local"].ToString();
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        setor = Session.Contents["setor"].ToString();

        if (setor == "Posto")
        {
            Response.Redirect("principal/transfere/pedidos.aspx?session=" + Request.QueryString["session"].ToString());
        }
        if (setor == "UTI")
        {
            Response.Redirect("principal/pedidouti/pedidos.aspx?session=" + Request.QueryString["session"].ToString());
        }
        if (setor == "ADM")
        {
            Response.Redirect("principal/principal.aspx?session=" + Request.QueryString["session"].ToString());
        }
        if (setor == "CDI")
        {
            Response.Redirect("cdi/principalCDI.aspx?session=" + Request.QueryString["session"].ToString());
        }
    }
}