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


public partial class Principal_transfere_asocial : System.Web.UI.Page
{
    public static string fone;

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
                    preenche();
                    TextBox2.Attributes.Add("required", "");
                    TextBox3.Attributes.Add("required", "");
                    TextBox4.Attributes.Add("required", "");
                    TextBox5.Attributes.Add("required", "");
                    DropDownList1.Attributes.Add("required", "");
                    DropDownList2.Attributes.Add("required", "");
                    DropDownList3.Attributes.Add("required", "");
                }
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("pedidos.aspx?session=" + Label1.Text);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbaltas where num_atendimento=@num_atendimento", cn);
        cmd.Parameters.AddWithValue("@num_atendimento", TextBox2.Text);

        cn.Open();
        SqlDataReader dr = null;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {

            Label11.Text = "Paciente já cadastrado";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);

        }
        else
        {
            cmd = new SqlCommand("insert into tbaltas (num_atendimento, nome_pac, leito, cidade, tipo_alta, acompanha, ox, contato, data_alta, usuario, posto) values (@num_atendimento, @nome_pac, @leito, @cidade, @tipo_alta, @acompanha, @ox, @contato, @data_alta, @usuario, @posto)", cn);
            cmd.Parameters.AddWithValue("@num_atendimento", TextBox2.Text);
            cmd.Parameters.AddWithValue("@nome_pac", TextBox3.Text);
            cmd.Parameters.AddWithValue("@leito", TextBox4.Text);
            cmd.Parameters.AddWithValue("@cidade", TextBox5.Text);
            cmd.Parameters.AddWithValue("@tipo_alta", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@acompanha", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@ox", DropDownList3.Text);
            cmd.Parameters.AddWithValue("@contato", fone);
            cmd.Parameters.AddWithValue("@data_alta", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@usuario", Label8.Text);
            cmd.Parameters.AddWithValue("@posto", TextBox1.Text);

            try
            {

                cmd.ExecuteNonQuery();
                Response.AddHeader("Refresh", "1;URL=pedidos.aspx?session=" + Label1.Text);

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
    public void preenche()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tblogin.*, tblocal.local_setor, tblog.session from tblogin inner join tblocal on tblogin.localt = tblocal.id_local inner join tblog on tblogin.Id = tblog.usuario where tblog.session=@session", cn);
        cmd.Parameters.AddWithValue("@session", Label1.Text);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox1.Text = dr["local_setor"].ToString();
                Label8.Text = dr["id"].ToString();
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

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["tasy"].ConnectionString);
        OracleCommand cmd = new OracleCommand("SELECT atendimento_paciente_v.*, obter_municipio_ibge_atend(nr_atendimento) municipio FROM atendimento_paciente_v WHERE nr_atendimento = '" + TextBox2.Text + "'", cn);

        try
        {
            cn.Open();

            OracleDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if(dr["ds_setor_atendimento"].ToString() == TextBox1.Text)
                {
                    TextBox3.Text = dr["nm_paciente"].ToString();
                    TextBox4.Text = dr["cd_unidade"].ToString();
                    TextBox5.Text = dr["municipio"].ToString();
                    fone = dr["nr_telefone_celular"].ToString();
                }
                else
                {
                    Label11.Text = "Paciente não pertence a sua unidade de internação";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
                }
            }
            else
            {
                Label11.Text = "Paciente não encontrado";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}