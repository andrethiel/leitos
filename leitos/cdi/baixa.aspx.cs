using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class cdi_baixa : System.Web.UI.Page
{
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
                    Response.Redirect("../Default.aspx");
                }
                else
                {
                    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("select * from tbexames where id=@id", cn);
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["atende"].ToString());


                    try
                    {
                        cn.Open();
                        SqlDataReader dr = null;
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            string nome = dr["usuario_libera"].ToString();
                            string hora = dr["hora_libera"].ToString();
                            string cancela = dr["status"].ToString();
                            if (cancela.Trim() == "Exame Cancelado")
                            {
                                Label9.Text = "Exame cadastrado por: " + nome + "no horario: " + hora + "<br>Exame cancelado por: " + dr["usuario_cancela"].ToString() + " no horario: " + dr["hora_cancela"].ToString();
                                Button3.Visible = false;
                                Button4.Text = "OK";
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
                            }
                            else if(dr["baixa"].ToString().Trim() == "Exame agendado")
                            {
                                Label9.Text = "Exame ja cadastrado por: " + nome + "no horario: " + hora + "<br>Deseja cancelar esse exame ?";
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
                            }
                            else
                            {
                                cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
                                cmd = new SqlCommand("select * from tbexames where id=@id", cn);
                                cmd.Parameters.AddWithValue("@id", Request.QueryString["atende"].ToString());

                                cn.Open();
                                dr = null;
                                dr = cmd.ExecuteReader();
                                if (dr.Read())
                                {
                                    TextBox1.Text = dr["local"].ToString();
                                    TextBox3.Text = dr["nome_pac"].ToString();
                                    TextBox2.Text = dr["especial"].ToString();
                                    TextBox4.Text = dr["procede"].ToString();
                                    TextBox5.Text = dr["quarto"].ToString();
                                    TextBox6.Text = dr["obs"].ToString();
                                    preenche();
                                    Button2.Visible = false;
                                }
                            }
                            
                        }
                        else
                        {
                            
                        }
                    }
                    catch(Exception ex)
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
        SqlCommand cmd = new SqlCommand("select tblogin.*, tblocal.local_setor, tblog.session from tblogin inner join tblocal on tblogin.localt = tblocal.id_local inner join tblog on tblogin.Id = tblog.usuario where tblog.session=@session", cn);
        cmd.Parameters.AddWithValue("@session", Label1.Text);

        try
        {
            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Label13.Text = dr["nome_completo"].ToString();

            }
            cn.Close();
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
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("update tbexames set baixa= 'Exame agendado', usuario_libera=@usuario_libera, data_libera=@data_libera, hora_libera=@hora_libera where id=@id", cn);
        cmd.Parameters.AddWithValue("@usuario_libera", Label13.Text);
        cmd.Parameters.AddWithValue("@data_libera", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora_libera", DateTime.Now.ToShortTimeString());
        cmd.Parameters.AddWithValue("@id", Request.QueryString["atende"].ToString());

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("principalCDI.aspx?session=" + Label1.Text);
            cn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("principalCDI.aspx?session=" + Label1.Text);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("update tbexames set status= 'Exame Cancelado', usuario_cancela=@usuario_cancela, data_cancela=@data_cancela, hora_cancela=@hora_cancela where id=@id", cn);
        cmd.Parameters.AddWithValue("@usuario_cancela", Label13.Text);
        cmd.Parameters.AddWithValue("@data_cancela", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora_cancela", DateTime.Now.ToShortTimeString());
        cmd.Parameters.AddWithValue("@id", Request.QueryString["atende"].ToString());

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("principalCDI.aspx?session=" + Label1.Text);
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if(Button4.Text == "OK")
        {
            Response.Redirect("principalCDI.aspx?session=" + Label1.Text);
        }
        else
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from tbexames where tbexames.id=@id", cn);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["atende"].ToString());

            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox1.Text = dr["local"].ToString();
                TextBox3.Text = dr["nome_pac"].ToString();
                TextBox2.Text = dr["especial"].ToString();
                TextBox4.Text = dr["procede"].ToString();
                TextBox5.Text = dr["quarto"].ToString();
                TextBox6.Text = dr["obs"].ToString();
                preenche();
                Button1.Visible = false;
            }
        }
    }
}