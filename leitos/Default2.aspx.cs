using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Tesseract;
using System.IO;
using PQScan.PDFToImage;
using System.Drawing;

public partial class Default2 : System.Web.UI.Page
{
    string textodecriptografado, senha = "YEC9OrNKt3KZZcapRyiq0Q==";

    protected void Page_Load(object sender, EventArgs e)
    {
        string chave = "Chave secreta";
        Crypt crypt = new Crypt(CryptProvider.DES);
        crypt.Key = chave;
        textodecriptografado = crypt.Decrypt(senha);
        Response.Write(textodecriptografado);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        convertImagem();
        var imagem = @"G:\output0.jpg";

        try
        {
            using (var engine = new TesseractEngine(Server.MapPath(@"~/tessdata"), "eng", EngineMode.Default))
            {
                using (var img = new System.Drawing.Bitmap(imagem))
                {
                    using (var pix = PixConverter.ToPix(img))
                    {
                        using (var page = engine.Process(pix))
                        {
                            resultText.InnerText = page.GetText();
                            string texto = page.GetText();
                            //if(texto.Contains("2858021"))
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void convertImagem()
    {
        PDFDocument pdf = new PDFDocument();
        pdf.LoadPDF(Server.MapPath("~/principal/PDF_DO/Scanner_20191025.pdf"));
        int count = pdf.PageCount;

        for (int i = 0; i < count; i++)
        {
            // Convert PDF page to image.
            Bitmap jpgImage = pdf.ToImage(i);

            // Save image with jpg file type.
            jpgImage.Save("g:/output" + i + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

    }
}