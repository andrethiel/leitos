using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
using iTextSharp.text.pdf;
using System.Text;

public partial class Principal_recuti : System.Web.UI.Page
{
    public static int tamanho;
    //public static string[] nomes;
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
                    TextBox1.Attributes.Add("required", "");
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        int numFiles = Request.Files.Count;
        int uploadedCount = 0;
        for (int i = 0; i < numFiles; i++)
        {
            var uploadedFile = Request.Files[i];
            if (uploadedFile.ContentLength > 0)
            {

                string extensao = Path.GetExtension(uploadedFile.FileName);
                string filename = string.Format("{0:00000000000000}", gerarID());
                uploadedFile.SaveAs(Server.MapPath("PDF_DO/") + filename + i + extensao);
                uploadedCount++;

                if (i == 0)
                {
                    Label11.Text = filename + i + extensao;
                }
                else if (i == 1)
                {
                    Label12.Text = filename + i + extensao;
                }
                else
                {
                    Label13.Text = filename + i + extensao;
                }
            }
            else
            {
                Label10.Text = "Para inserir uma D.O. Selecione os arquivos do paciente";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
            }
        }
        inserePac();

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("insert into tbdo_arquivo (id_pac, do, pron, arquivos) values (@id_pac, @do, @pron, @arquivos)", cn);
        cmd.Parameters.AddWithValue("@id_pac", Label7.Text);
        cmd.Parameters.AddWithValue("@do", Label11.Text);
        cmd.Parameters.AddWithValue("@pron", Label12.Text);
        cmd.Parameters.AddWithValue("@arquivos", Label13.Text);

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            limpar(this);
            Label10.Text = "Arquivos importados com sucesso";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
            cn.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public Int64 gerarID()
    {
        try
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            string s = data.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
            return Convert.ToInt64(s);
        }
        catch (Exception ex)
        {

            throw ex;
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
    public void inserePac()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("insert into tbdo (num_atendimento, nome_pac, data_do, usuario_up, data_up, hora_up) values(@num_atendimento, @nome_pac, @data_do, @usuario_up, @data_up, @hora_up)", cn);
        cmd.Parameters.AddWithValue("@num_atendimento", TextBox1.Text);
        cmd.Parameters.AddWithValue("@nome_pac", TextBox2.Text);
        cmd.Parameters.AddWithValue("@data_do", TextBox3.Text);
        cmd.Parameters.AddWithValue("@usuario_up", Label6.Text);
        cmd.Parameters.AddWithValue("data_up", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@hora_up", DateTime.Now.ToShortTimeString());

        try
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            cmd = new SqlCommand("select * from tbdo where num_atendimento=@num_atendimento", cn);
            cmd.Parameters.AddWithValue("@num_atendimento", TextBox1.Text);

            cn.Open();
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Label7.Text = dr["id"].ToString();
            }
            cn.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("principal.aspx?session=" + Label1.Text);
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("do.aspx?session=" + Label1.Text);
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
                ((DropDownList)cla).Text = "";
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
}