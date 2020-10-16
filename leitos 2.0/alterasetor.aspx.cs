using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class alterasetor : System.Web.UI.Page
{
    public static HttpCookie cookie_local, cookie_id;
    public static string local;

    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1.Attributes.Add("required", "");
        cookie_local = Request.Cookies["local"];
        cookie_id = Request.Cookies["id"];
        TextBox1.Text = cookie_local.Value.ToString();

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tblocal where not local_setor = 'Recepção C' and not local_setor = 'Assistente Social' and not local_setor = 'Recepção A' and not local_setor = 'Recepção UTI' and not local_setor = 'Centro de Imagem' order by local_setor", cn);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(dr["local_setor"].ToString());
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
        if (TextBox1.Text == DropDownList1.Text)
        {
            Label1.Text = "Atenção: O setor de trabalho não pode ser o mesmo que o anterior";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error();", true);
        }
        else
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update tblogin set localt=@localt where id=@id", cn);
            cmd.Parameters.AddWithValue("@localt", local);
            cmd.Parameters.AddWithValue("@id", cookie_id.Value.ToString());

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Label1.Text = "Setor alterado com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso();", true);
                cn.Close();
                Response.AddHeader("Refresh", "2;URL=Default.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tblocal where local_setor=@local_setor ", cn);
        cmd.Parameters.AddWithValue("@local_setor", DropDownList1.Text);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                local = dr["id_local"].ToString();
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
        DropDownList1.Attributes.Remove("required");
        Response.Redirect("alterausuario.aspx");
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "$('#DropDownList1').prop('required', false); window.location.href = 'alterausuario.aspx';", true);
    }
}