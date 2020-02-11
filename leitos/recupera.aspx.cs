using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;

public partial class recupera : System.Web.UI.Page
{
    string email, nome, link;
    protected void Page_Load(object sender, EventArgs e)
    {
        Div1.Visible = false;
        TextBox1.Attributes.Add("placeholder", "Email");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["interno"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select * from tblogin where email=@email", cn);
        cmd.Parameters.AddWithValue("@email", TextBox1.Text);

        cn.Open();
        SqlDataReader dr = null;
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            email = dr["email"].ToString();
            link = dr["id"].ToString();
            nome = dr["nome_completo"].ToString();
            dr.Close();
            Label1.Text = email;
            mandaemail();
            form.Visible = false;
            Div1.Visible = true;
        }
        else
        {
            dr.Close();
            Label2.Text = "Email não corresponde/existe cadastrado no sistema";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup", "error();", true);
        }
    }
    private void mandaemail()
    {
        StringBuilder CorpoEmail = new StringBuilder();
        CorpoEmail.Append("<img src='http://placrim.com.br/antigo/wp-content/uploads/logo_hnsr.png' width='136'><br><br><br>").Append(Environment.NewLine);
        CorpoEmail.Append("Prezado (a): <b>" + nome + "</b><BR>").Append(Environment.NewLine);
        CorpoEmail.Append("Acesse o <a href='http://leitos-rocio/senha.aspx?token=" + link + "'>link</a> para alterar sua senha<br><br>");        
        CorpoEmail.Append("Hospital do Rocio<br>").Append(Environment.NewLine);
        CorpoEmail.Append("Rua Maria Aparecida de Oliveira, 599, Bairro São Gerônimo, em Campo Largo-PR.</p>").Append(Environment.NewLine);
        CorpoEmail.Append("<a href='http://hospitaldorocio.com.br'>www.hospitaldorocio.com.br</a>").Append(Environment.NewLine);

        string mail = "no-replace@hospitaldorocio.com.br";
        string senha = "#PaoDeBatata@123!@#.,";

        MailMessage msg = new MailMessage();
        msg.From = new MailAddress(mail);
        msg.To.Add(email);
        msg.Subject = "Recuperação de senha";
        msg.Body = CorpoEmail.ToString();
        msg.IsBodyHtml = true;

        string server = "mail.hospitaldorocio.com.br";
        int port = 587;
        SmtpClient client = new SmtpClient(server, port);
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.Credentials = new NetworkCredential(mail, senha);

        try
        {
            client.Send(msg);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}