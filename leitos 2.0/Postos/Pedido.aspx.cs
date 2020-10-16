using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UTI_Pedido : System.Web.UI.Page
{
    public static HttpCookie cookie_local, cookie_id;
    public static string sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            cookie_local = Request.Cookies["local"];
            cookie_id = Request.Cookies["id"];
        }
        else
        {
            TextBox2.Attributes.Add("placeholder", "N° Atendimento");
            TextBox2.Attributes.Add("required", "");
            TextBox3.Attributes.Add("placeholder", "Nome do paciente");
            TextBox4.Attributes.Add("placeholder", "Sexo");
            TextBox5.Attributes.Add("placeholder", "Leito");
            TextBox6.Attributes.Add("placeholder", "Convenio");
            TextBox7.Attributes.Add("placeholder", "Diagnostico do paciente");
            TextBox7.Attributes.Add("required", "");
            TextBox8.Attributes.Add("placeholder", "Observação do Paciente");
            DropDownList1.Attributes.Add("required", "");

            especialidade();
        }
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        if (cookie_local.Value.ToString() == "Centro Cirurgico")
        {
            sql = "select * from paciente_internado_atual_v WHERE nr_atendimento = '" + TextBox2.Text + "'";
            TextBox7.Attributes.Remove("required");
            TextBox7.Enabled = false;
        }
        else
        {
            sql = "select * from paciente_internado_atual_v WHERE ds_setor_atendimento = '" + cookie_local.Value.ToString() + "' and nr_atendimento = '" + TextBox2.Text + "'";
        }

        OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["tasy"].ConnectionString);
        OracleCommand cmd = new OracleCommand(sql, cn);

        try
        {
            cn.Open();

            OracleDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox3.Text = dr["nm_paciente"].ToString();
                TextBox4.Text = dr["ie_sexo"].ToString();
                string leito = dr["cd_unidade"].ToString();
                TextBox6.Text = dr["ds_convenio"].ToString();

                string leito_novo = leito.Replace("Quarto ", "");
                leito_novo = leito_novo.Replace("L", "-");
                leito_novo = leito_novo.Replace("01", "A");
                leito_novo = leito_novo.Replace("02", "B");
                leito_novo = leito_novo.Replace("03", "C");
                leito_novo = leito_novo.Replace("M", "Masculino");
                leito_novo = leito_novo.Replace("F", "Feminino");

                TextBox5.Text = leito_novo;
            }
            else
            {
                Label1.Text = "Paciente não pertence ao seu setor";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void especialidade()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbespecialidade", cn);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(dr["especialidade"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (cookie_local.Value.ToString() == "Centro Cirurgico")
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into tbtransfere (num_atendimento, nome_pac,sexo, local, usuario_pedido, diagnostico, usuario_libera, data_pedido, hora_pedido, autoriza, convenio, especial) values (@num_atendimento, @nome_pac,@sexo, @local, @usuario_pedido, @diagnostico,@usuario_libera,@data_pedido, @hora_pedido, @autoriza, @convenio, @especial)", cn);
            cmd.Parameters.AddWithValue("@num_atendimento", TextBox2.Text);
            cmd.Parameters.AddWithValue("@nome_pac", TextBox3.Text);
            cmd.Parameters.AddWithValue("@sexo", TextBox4.Text);
            cmd.Parameters.AddWithValue("@local", cookie_local.Value.ToString());
            cmd.Parameters.AddWithValue("@usuario_pedido", cookie_id.Value.ToString());
            cmd.Parameters.AddWithValue("@diagnostico", TextBox7.Text);
            cmd.Parameters.AddWithValue("@usuario_libera", cookie_id.Value.ToString());
            cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@hora_pedido", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@autoriza", "n");
            cmd.Parameters.AddWithValue("@convenio", TextBox6.Text);
            cmd.Parameters.AddWithValue("@especial", DropDownList1.Text);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Label1.Text = "Leito pedido com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
                Response.AddHeader("Refresh", "1;URL=" + Request.RawUrl);
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
        else
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into tbtransfere (num_atendimento, nome_pac,sexo, local, quarto, usuario_pedido, diagnostico, usuario_libera, data_pedido, hora_pedido, motivo, autoriza) values (@num_atendimento, @nome_pac,@sexo, @local, @quarto, @usuario_pedido, @diagnostico,@usuario_libera,@data_pedido, @hora_pedido, @motivo, @autoriza)", cn);

            cmd.Parameters.AddWithValue("@num_atendimento", TextBox2.Text);
            cmd.Parameters.AddWithValue("@nome_pac", TextBox3.Text);
            cmd.Parameters.AddWithValue("@sexo", TextBox4.Text);
            cmd.Parameters.AddWithValue("@local", cookie_local.Value.ToString());
            cmd.Parameters.AddWithValue("@quarto", TextBox5.Text);
            cmd.Parameters.AddWithValue("@usuario_pedido", cookie_id.Value.ToString());
            cmd.Parameters.AddWithValue("@diagnostico", TextBox7.Text);
            cmd.Parameters.AddWithValue("@usuario_libera", cookie_id.Value.ToString());
            cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@hora_pedido", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@autoriza", "n");
            cmd.Parameters.AddWithValue("@motivo", TextBox6.Text);
            cmd.Parameters.AddWithValue("@convenio", TextBox6.Text);
            cmd.Parameters.AddWithValue("@especial", DropDownList1.Text);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Label1.Text = "Leito pedido com sucesso";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
                Response.Redirect(Request.RawUrl);
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