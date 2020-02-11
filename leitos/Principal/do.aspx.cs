using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;


public partial class Principal_do : System.Web.UI.Page
{
    public static string arqiuvo_DO, arquivo_documentos, arquivos;

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
                    preenche();
                    GridView2.Visible = false;
                }
            }
        }
        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbdo_arquivo where id_pac=@id_pac", cn);
        cmd.Parameters.AddWithValue("@id_pac", id);

        try
        {
            cn.Open();
            SqlDataReader ds = cmd.ExecuteReader();
            if (ds.Read())
            {
                arqiuvo_DO = ds["do"].ToString();
                arquivo_documentos = ds["pron"].ToString();
                arquivos = ds["arquivos"].ToString();
                if(arquivos == "null")
                {
                    Response.Write("SIM");
                }
                ds.Close();

                GridView2.Visible = true;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                GridView2.DataSource = dt;
                GridView2.DataBind();
                dr.Close();
                dt.Clear();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DO")
        {
            if(arqiuvo_DO.TrimEnd() == "null")
            {
                Label10.Text = "A D.O desse paciente não foi importado";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
            }
            else
            {
                WebClient user = new WebClient();
                Byte[] buffer = user.DownloadData(Server.MapPath("PDF_DO/" + arqiuvo_DO));
                if (buffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.BinaryWrite(buffer);
                }
            }
            
        }
        else if (e.CommandName == "pront")
        {
            if(arquivo_documentos.TrimEnd() == "null")
            {
                Label10.Text = "O prontuario desse paciente não foi importado";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
            }
            else
            {
                WebClient user = new WebClient();
                Byte[] buffer = user.DownloadData(Server.MapPath("PDF_DO/" + arquivo_documentos));
                if (buffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.BinaryWrite(buffer);
                }
            }
            

        }
        else if (e.CommandName == "arquivos")
        {
            if (arquivos.TrimEnd() == "null")
            {
                Label10.Text = "Os documentos desse paciente não foram importados";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
            }
            else
            {
                WebClient user = new WebClient();
                Byte[] buffer = user.DownloadData(Server.MapPath("PDF_DO/" + arquivos));
                if (buffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.BinaryWrite(buffer);
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" && TextBox2.Text == "")
        {
            Label10.Text = "Digite o número do prontuario ou o nome do paciente";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
        }
        else if (TextBox1.Text != "")
        { 
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select tbdo.*, tbdo_arquivo.* from tbdo inner join tbdo_arquivo on tbdo.id = tbdo_arquivo.id_pac where num_atendimento=@num_atendimento", cn);
            cmd.Parameters.AddWithValue("@num_atendimento", TextBox1.Text);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                dr.Close();
                dt.Clear();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select tbdo.*, tbdo_arquivo.* from tbdo inner join tbdo_arquivo on tbdo.id = tbdo_arquivo.id_pac where nome_pac=@nome_pac", cn);
            cmd.Parameters.AddWithValue("@nome_pac", TextBox2.Text);

            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                dr.Close();
                dt.Clear();

            }
            catch (Exception ex)
            {
                throw ex;
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
                Label6.Text = dr["id"].ToString();
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

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("recuti.aspx?session=" + Label1.Text);
    }
}
   