using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class alterar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id;
        if (Page.IsPostBack)
        {

        }
        else
        {
            Label1.Text = Request.QueryString["session"];
            //id = Request.QueryString["tipo"].ToString();
            if (Request.QueryString["session"] == null)
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                Label13.Text = Request.QueryString["tipo"].ToString();
                preenche();
                if (Label13.Text == "2")
                {
                    posto();
                }
                else
                {
                    UTI();
                    Label6.Text = "BOX";
                    Label7.Text = "Obs. do paciente";
                }
            }

        }
    }
    public void limpar(Control controle)
    {
        foreach (Control ctle in controle.Controls)
        {
            if (ctle is TextBox)
            {
                ((TextBox)ctle).Text = string.Empty;
            }
            else if (ctle.Controls.Count > 0)
            {
                limpar(ctle);
            }
        }
        foreach (Control cla in controle.Controls)
        {
            if (cla is DropDownList)
            {
                ((DropDownList)cla).Text = "Escolha um sexo";
            }
            else if (cla.Controls.Count > 0)
            {
                limpar(cla);
            }
        }
        foreach (Control cla in controle.Controls)
        {
            if (cla is RadioButton)
            {
                ((RadioButton)cla).Checked = false;
            }
            else if (cla.Controls.Count > 0)
            {
                limpar(cla);
            }
        }
        foreach (Control cla in controle.Controls)
        {
            if (cla is CheckBox)
            {
                ((CheckBox)cla).Checked = false;
            }
            else if (cla.Controls.Count > 0)
            {
                limpar(cla);
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
            while (dr.Read())
            {
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
    public void posto()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbtransfere where num_atendimento = @num_atendimento", cn);
        cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox1.Text = dr["local"].ToString();
                TextBox2.Text = dr["num_atendimento"].ToString();
                TextBox3.Text = dr["nome_pac"].ToString();
                TextBox12.Text = dr["sexo"].ToString();
                TextBox4.Text = dr["diagnostico"].ToString();
                TextBox5.Text = dr["quarto"].ToString();
                TextBox8.Text = dr["leito"].ToString();
                TextBox6.Text = dr["motivo"].ToString();
                cn.Close();
                cn.Dispose();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void UTI()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbpedido where num_atendimento = @num_atendimento", cn);
        cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox1.Text = dr["uti"].ToString();
                TextBox2.Text = dr["num_atendimento"].ToString();
                TextBox3.Text = dr["nome_pac"].ToString();
                TextBox12.Text = dr["sexo"].ToString();
                TextBox4.Text = dr["diagnostico"].ToString();
                TextBox5.Text = dr["box"].ToString();
                TextBox6.Text = dr["obs"].ToString();
                TextBox8.Text = dr["leito"].ToString();
                TextBox9.Text = dr["iso"].ToString();
                TextBox11.Text = dr["especial"].ToString();
                TextBox10.Text = dr["convenio"].ToString();
                cn.Close();
                cn.Dispose();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Label13.Text == "2")
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update tbtransfere set leito=@leito where num_atendimento=@num_atendimento", cn);
            cmd.Parameters.AddWithValue("@leito", TextBox7.Text + "-" + DropDownList2.Text);
            cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            //uti
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update tbpedido set leito=@leito where num_atendimento=@num_atendimento", cn);
            cmd.Parameters.AddWithValue("@leito", TextBox7.Text + "-" + DropDownList2.Text);
            cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("principal.aspx?session=" + Label1.Text);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Label13.Text == "2")
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update tbtransfere set leito=NULL, data_libera=NULL, hora_libera=NULL where num_atendimento=@num_atendimento", cn);
            cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update tbpedido set leito=NULL, data_libera=NULL, hora_libera=NULL where num_atendimento=@num_atendimento", cn);
            cmd.Parameters.AddWithValue("@num_atendimento", Request.QueryString["atende"].ToString());

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}