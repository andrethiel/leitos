using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Principal_principalCDI : System.Web.UI.Page
{
    public string vresso, vangior, vtomo, vangiot, vraio, veco, vmamo;

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
                    resso();
                    tomo();
                    raio();
                    eco();
                    angioresso();
                    angiotomo();
                    mamo();
                    contador();
                }
            }
        }
    }
    public void resso()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido=@data_pedido and especial='Ressonância' order by baixa, hora_libera desc", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
                cn.Dispose();
            }
            else
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void tomo()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido=@data_pedido and especial='Tomografia' order by baixa, hora_libera desc", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
                cn.Dispose();
            }
            else
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                GridView2.DataSource = dt;
                GridView2.DataBind();
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void raio()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido=@data_pedido and especial='Raio-X' order by baixa, hora_libera desc", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
                cn.Dispose();
            }
            else
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                GridView3.DataSource = dt;
                GridView3.DataBind();
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void eco()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido=@data_pedido and especial='Ecografia' order by baixa, hora_libera desc", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
                cn.Dispose();
            }
            else
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                GridView4.DataSource = dt;
                GridView4.DataBind();
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void angioresso()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido=@data_pedido and especial='Angioressonâncias' order by baixa, hora_libera desc", cn); 
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
                cn.Dispose();
            }
            else
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                GridView6.DataSource = dt;
                GridView6.DataBind();
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void angiotomo()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido=@data_pedido and especial='Angiotomografias' order by baixa, hora_libera desc", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
                cn.Dispose();
            }
            else
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                GridView7.DataSource = dt;
                GridView7.DataBind();
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void mamo()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select tbexames.*, tblogin.nome_completo from tbexames inner join tblogin on tbexames.usuario_pedido = tblogin.Id where data_pedido=@data_pedido and especial='Mamografia' order by baixa, hora_libera desc", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

        try
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
                cn.Dispose();
            }
            else
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                GridView5.DataSource = dt;
                GridView5.DataBind();
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    cn.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Default.aspx");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "noback()");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("agendados.aspx?session=" + Label1.Text);
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../registrar.aspx?session=" + Label1.Text+"&cdi=1");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string valor = DataBinder.Eval(e.Row.DataItem, "status").ToString();

            if (valor.Trim() == "Exame Cancelado")
            {
                e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
            }
        }
    }

    protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string valor = DataBinder.Eval(e.Row.DataItem, "status").ToString();

            if (valor.Trim() == "Exame Cancelado")
            {
                e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
            }
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string valor = DataBinder.Eval(e.Row.DataItem, "status").ToString();

            if (valor.Trim() == "Exame Cancelado")
            {
                e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
            }
        }
    }

    protected void GridView7_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string valor = DataBinder.Eval(e.Row.DataItem, "status").ToString();

            if (valor.Trim() == "Exame Cancelado")
            {
                e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
            }
        }
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string valor = DataBinder.Eval(e.Row.DataItem, "status").ToString();

            if (valor.Trim() == "Exame Cancelado")
            {
                e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
            }
        }
    }

    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string valor = DataBinder.Eval(e.Row.DataItem, "status").ToString();

            if (valor.Trim() == "Exame Cancelado")
            {
                e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
            }
        }
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Session["setor"] = "CDI";
        Response.Redirect("../alterausuario.aspx?session=" + Label1.Text);
    }
    public void contador()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select COUNT(*) as tipo,(select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Ressonância') as resso, (select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Angioressonâncias') as angior, (select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Tomografia') as tomo, (select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Angiotomografias') as angiot, (select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Raio-X') as raio, (select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Mamografia') as mamo, (select COUNT('baixa') from tbexames where baixa = 'Aguardando agendamento' and data_pedido = @data_pedido and especial = 'Ecografia') as eco", cn);
        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("yyyy/MM/dd"));

        cn.Open();
        SqlDataReader dr = null;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Label2.Text = dr["resso"].ToString();
            Label4.Text = dr["tomo"].ToString();
            Label7.Text = dr["raio"].ToString();
            Label8.Text = dr["eco"].ToString();
            Label9.Text = dr["mamo"].ToString();
            if(dr["angior"].ToString() == "0")
            {
                Label6.Text = dr["angiot"].ToString();
            }
            else
            {
                Label6.Text = dr["angior"].ToString();
            }
        }
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("centro.aspx?session=" + Label1.Text);
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tbexames where id=@id", cn);
        cmd.Parameters.AddWithValue("@id","500");


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
                    Label10.Text = "Exame cadastrado por: " + nome + "no horario: " + hora + "<br>Exame cancelado por: " + dr["usuario_cancela"].ToString() + " no horario: " + dr["hora_cancela"].ToString();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
                }
                else if (dr["baixa"].ToString().Trim() == "Exame agendado")
                {
                    Label10.Text = "Exame ja cadastrado por: " + nome + "no horario: " + hora + "<br>Deseja cancelar esse exame ?";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
                }
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowPopup()", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}