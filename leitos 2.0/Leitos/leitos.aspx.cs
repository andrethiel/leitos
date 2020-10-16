using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Leitos_leitos : System.Web.UI.Page
{
    public static string id, nome;
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("select tbpedido.id, tbpedido.num_atendimento, tbpedido.nome_pac, tbpedido.uti, tbpedido.box, tbpedido.data_libera, tbpedido.hora_libera, tbpedido.diagnostico, tbpedido.especial, tbpedido.convenio, tbpedido.leito, tbpedido.sexo, tblogin.nome_completo from tbpedido inner join tblogin on tbpedido.usuario_pedido = tblogin.Id where data_libera = '" + DateTime.Now.ToString("dd/MM/yyyy") + "' and leito != ''" +
            "union select tbtransfere.id, tbtransfere.num_atendimento, tbtransfere.nome_pac, tbtransfere.Local, tbtransfere.quarto, tbtransfere.data_libera, tbtransfere.hora_libera, tbtransfere.diagnostico, tbtransfere.especial, tbtransfere.convenio, tbtransfere.leito,tbtransfere.sexo, tblogin.nome_completo from tbtransfere inner join tblogin on tbtransfere.usuario_pedido = tblogin.Id where data_libera = '" + DateTime.Now.ToString("dd/MM/yyyy") + "' and leito != ''", cn);

        cn.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        Repeater1.DataSource = ds.Tables[0];
        Repeater1.DataBind();
        cn.Close();
    }

    //protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    string[] valores = e.CommandArgument.ToString().Split(new char[] { ',' });
    //    id = valores[0].ToString();
    //    nome = valores[1].ToString();
    //    Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "ShowPopup();", true);
    //}

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
    //    SqlCommand cmd = new SqlCommand("select * from tbpedido where id=@id and nome_pac=@nome_pac", cn);
    //    cmd.Parameters.AddWithValue("@id", id);
    //    cmd.Parameters.AddWithValue("@nome_pac", nome);

    //    cn.Open();
    //    SqlDataReader dr = cmd.ExecuteReader();
    //    if (dr.HasRows)
    //    {
    //        cmd = new SqlCommand("update tbpedido set leito=NULL, usuario_libera=NULL, data_libera=NULL, hora_libera=NULL where id=@id and data_pedido=@data_pedido", cn);
    //        cmd.Parameters.AddWithValue("@id", id);
    //        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));

    //        try
    //        {
    //            cmd.ExecuteNonQuery();
    //            Label1.Text = "Leito liberad com sucesso";
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
    //            Response.AddHeader("Refresh", "3;URL=" + Request.RawUrl);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            cn.Close();
    //        }
    //    }
    //    else
    //    {
    //        cmd = new SqlCommand("update tbtransfere set leito=NULL, usuario_libera=NULL, data_libera=NULL, hora_libera=NULL where id=@id and data_pedido=@data_pedido", cn);
    //        cmd.Parameters.AddWithValue("@id", id);
    //        cmd.Parameters.AddWithValue("@data_pedido", DateTime.Now.ToString("dd/MM/yyyy"));

    //        try
    //        {
    //            cmd.ExecuteNonQuery();
    //            Label1.Text = "Leito liberad com sucesso";
    //            Page.ClientScript.RegisterStartupScript(this.GetType(), "show", "sucesso()", true);
    //            Response.AddHeader("Refresh", "3;URL=" + Request.RawUrl);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            cn.Close();
    //        }
    //    }
    //}
}