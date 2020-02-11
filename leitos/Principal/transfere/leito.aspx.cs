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

public partial class Principal_leito : System.Web.UI.Page
{
    string id;
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
                    TextBox2.Attributes.Add("required", "");
                    TextBox3.Attributes.Add("required", "");
                    TextBox4.Attributes.Add("required", "");
                    TextBox5.Attributes.Add("required", "");
                    TextBox6.Attributes.Add("required", "");
                    DropDownList1.Attributes.Add("required", "");
                    DropDownList2.Attributes.Add("required", "");
                    DropDownList3.Attributes.Add("required", "");
                    DropDownList4.Attributes.Add("required", "");

                    Label1.Text = Request.QueryString["session"];
                    preenche();
                    if (TextBox1.Text.Trim() == "Centro Cirurgico")
                    {
                        Label6.Visible = false;
                        Label10.Visible = false;
                        Label7.Visible = false;
                        Label5.Visible = false;
                        TextBox5.Visible = false;
                        DropDownList2.Visible = false;
                        TextBox6.Visible = false;
                        TextBox4.Visible = false;
                        Button1.Text = "Solicitar Leito";
                    }
                }
            }
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("pedidos.aspx?session=" + Label1.Text);
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
            while (dr.Read())
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Trim() == "Centro Cirurgico")
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into tbtransfere (num_atendimento, nome_pac,sexo, local, usuario_pedido, diagnostico, usuario_libera, data_pedido, hora_pedido, autoriza, convenio, especial) values (@num_atendimento, @nome_pac,@sexo, @local, @usuario_pedido, @diagnostico,@usuario_libera,@data_pedido, @hora_pedido, @autoriza, @convenio, @especial)", cn);
            cmd.Parameters.AddWithValue("@num_atendimento", TextBox2.Text);
            cmd.Parameters.AddWithValue("@nome_pac", TextBox3.Text);
            cmd.Parameters.AddWithValue("@sexo", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@local", TextBox1.Text);
            cmd.Parameters.AddWithValue("@usuario_pedido", Label8.Text);
            cmd.Parameters.AddWithValue("@diagnostico", TextBox4.Text);
            cmd.Parameters.AddWithValue("@usuario_libera", Label8.Text);
            cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@hora_pedido", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@autoriza", "n");
            cmd.Parameters.AddWithValue("@convenio", DropDownList3.Text);
            cmd.Parameters.AddWithValue("@especial", DropDownList4.Text);


            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);
                preenche();
                cn.Close();
                cn.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into tbtransfere (num_atendimento, nome_pac,sexo, local, quarto, usuario_pedido, diagnostico, usuario_libera, data_pedido, hora_pedido, motivo, autoriza) values (@num_atendimento, @nome_pac,@sexo, @local, @quarto, @usuario_pedido, @diagnostico,@usuario_libera,@data_pedido, @hora_pedido, @motivo, @autoriza)", cn);
            cmd.Parameters.AddWithValue("@num_atendimento", TextBox2.Text);
            cmd.Parameters.AddWithValue("@nome_pac", TextBox3.Text);
            cmd.Parameters.AddWithValue("@sexo", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@local", TextBox1.Text);
            cmd.Parameters.AddWithValue("@quarto", TextBox5.Text + "-" + DropDownList2.Text);
            cmd.Parameters.AddWithValue("@usuario_pedido", Label8.Text);
            cmd.Parameters.AddWithValue("@diagnostico", TextBox4.Text);
            cmd.Parameters.AddWithValue("@usuario_libera", Label8.Text);
            cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));
            cmd.Parameters.AddWithValue("@hora_pedido", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@motivo", TextBox6.Text);
            cmd.Parameters.AddWithValue("@autoriza", "n");

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);
                preenche();
                cn.Close();
                cn.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["tasy"].ConnectionString);
        OracleCommand cmd = new OracleCommand("select nm_paciente, ie_sexo, ds_convenio from atendimento_paciente_v where nr_atendimento = " + TextBox2.Text, cn); //nr_prontuario

        try
        {
            cn.Open();

            OracleDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox3.Text = dr["nm_paciente"].ToString();
                DropDownList3.Items.Add(dr["ds_convenio"].ToString());
                DropDownList3.Text = dr["ds_convenio"].ToString();
                string sex = dr["ie_sexo"].ToString();
                if(sex == "M")
                {
                    DropDownList1.Text = "Masculino";
                }
                else
                {
                    DropDownList1.Text = "Feminino";
                }

            }
            else
            {
                Label1.Text = "N° de atendimento invalido";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "error()", true);
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }
}