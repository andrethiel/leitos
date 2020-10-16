using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;

public partial class Postos_asocial : System.Web.UI.Page
{
    public static string fone;
    public static HttpCookie cookie_local, cookie_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        cookie_local = Request.Cookies["local"];
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["tasy"].ConnectionString);
        OracleCommand cmd = new OracleCommand("SELECT atendimento_paciente_v.*, obter_municipio_ibge_atend(nr_atendimento) municipio FROM atendimento_paciente_v WHERE nr_atendimento = '" + TextBox1.Text + "' and ds_setor_atendimento = '" + cookie_local.Value.ToString() + "'", cn);

        try
        {
            cn.Open();

            OracleDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox2.Text = dr["nm_paciente"].ToString();
                TextBox3.Text = dr["cd_unidade"].ToString();
                TextBox4.Text = dr["municipio"].ToString();
                fone = dr["nr_telefone_celular"].ToString();
            }
            else
            {
                Label1.Text = "Paciente não pertence a sua unidade de internação";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        cookie_id = Request.Cookies["id"];
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbaltas where num_atendimento=@num_atendimento", cn);
        cmd.Parameters.AddWithValue("@num_atendimento", TextBox1.Text);

        cn.Open();
        SqlDataReader dr = null;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {

            Label1.Text = "Paciente já cadastrado";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);

        }
        else
        {
            cmd = new SqlCommand("insert into tbaltas (num_atendimento, nome_pac, leito, cidade, tipo_alta, acompanha, ox, contato, data_alta, usuario, posto, hora, status) values (@num_atendimento, @nome_pac, @leito, @cidade, @tipo_alta, @acompanha, @ox, @contato, @data_alta, @usuario, @posto, @hora, 'Aguardando Ligação')", cn);
            cmd.Parameters.AddWithValue("@num_atendimento", TextBox1.Text);
            cmd.Parameters.AddWithValue("@nome_pac", TextBox2.Text);
            cmd.Parameters.AddWithValue("@leito", TextBox3.Text);
            cmd.Parameters.AddWithValue("@cidade", TextBox4.Text);
            cmd.Parameters.AddWithValue("@tipo_alta", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@acompanha", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@ox", DropDownList3.Text);
            cmd.Parameters.AddWithValue("@contato", fone);
            cmd.Parameters.AddWithValue("@data_alta", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@usuario", cookie_id.Value.ToString());
            cmd.Parameters.AddWithValue("@posto", cookie_local.Value.ToString());
            cmd.Parameters.AddWithValue("@hora", DateTime.Now.ToShortTimeString());


            try
            {
                cmd.ExecuteNonQuery();
                Label1.Text = "Alta solicitada com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
                Response.AddHeader("Refresh", "2;URL=" + Request.RawUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}