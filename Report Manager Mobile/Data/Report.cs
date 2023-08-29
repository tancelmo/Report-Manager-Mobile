using Report_Manager_Mobile.Pages;
using Report_Manager_Mobile.Resources.Languages;
using Report_Manager_Mobile.Services;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Color = Syncfusion.Drawing.Color;
using PointF = Syncfusion.Drawing.PointF;
using SizeF = Syncfusion.Drawing.SizeF;

namespace Report_Manager_Mobile.Data
{
    internal class Report
    {
        public static void CreateARA()
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Add a page to the document.
            PdfPage page = document.Pages.Add();
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;
            
            //Get the page width and height.
            float pageWidth = page.GetClientSize().Width;
            float pageHeight = page.GetClientSize().Height;
            RectangleF TotalPriceCellBounds = RectangleF.Empty;
            RectangleF QuantityCellBounds = RectangleF.Empty;
            //Set the header height.
            float headerHeight = 90;
            //Create a brush with a light blue color. 
            PdfColor lightBlue = Color.FromArgb(255, 0, 115, 184);
            PdfBrush lightBlueBrush = new PdfSolidBrush(lightBlue);
            //Create a brush with a dark blue color. 
            PdfColor darkBlue = Color.FromArgb(255, 11, 67, 107);
            PdfBrush darkBlueBrush = new PdfSolidBrush(darkBlue);
            //Create a brush with a white color. 
            PdfBrush whiteBrush = new PdfSolidBrush(Color.FromArgb(255, 255, 255, 255));

            //Get the font file stream from the assembly. 
            Assembly assembly = typeof(Create).GetTypeInfo().Assembly;
            string basePath = "Report_Manager_Mobile.Resources.Fonts.";
            Stream fontStream = assembly.GetManifestResourceStream(basePath + "OpenSans-Regular.ttf");
            //Create a PdfTrueTypeFont from the stream with the different sizes. 
            PdfTrueTypeFont headerFont = new PdfTrueTypeFont(fontStream, 20, PdfFontStyle.Regular);
            PdfTrueTypeFont arialRegularFont = new PdfTrueTypeFont(fontStream, 18, PdfFontStyle.Regular);
            PdfTrueTypeFont arialBoldFont = new PdfTrueTypeFont(fontStream, 9, PdfFontStyle.Bold);
            //Create a string format.
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            float y = 0;
            float x = 0;
            //Set the margins of the address.
            float margin = 30;
            //Set the line space.
            float lineSpace = 10;
            //Create a border pen and draw the border to on the PDF page. 
            PdfColor borderColor = Color.FromArgb(255, 0, 115, 184);
            PdfPen borderPen = new PdfPen(borderColor, 1f);
            graphics.DrawRectangle(borderPen, new RectangleF(0, 0, pageWidth, pageHeight));

            

            #region Header         
            //Fill the header with a light blue brush. 
            graphics.DrawRectangle(lightBlueBrush, new RectangleF(0, 0, pageWidth, headerHeight));
            string title = "AVALIACAO DE RISCOS E ATIVIDADES";
            //Specificy the bounds for the total value. 
            RectangleF headerTotalBounds = new RectangleF(400, 0, pageWidth - 400, headerHeight);
            //Measure the string size using the font. 
            SizeF textSize = headerFont.MeasureString(title);
            graphics.DrawString(title, headerFont, whiteBrush, new RectangleF(0, 0, textSize.Width + 50, headerHeight), format);
            //Draw a rectangle in the PDF page. 
            graphics.DrawRectangle(darkBlueBrush, headerTotalBounds);
            //Draw the total value to the PDF page. 
            graphics.DrawString(Globals.Facility, arialRegularFont, whiteBrush, new RectangleF(400, 0, pageWidth - 400, headerHeight + 10), format);
            //Create a font from the font stream. 
            arialRegularFont = new PdfTrueTypeFont(fontStream, 9, PdfFontStyle.Regular);
            //Set the bottom line alignment and draw the text to the PDF page. 
            format.LineAlignment = PdfVerticalAlignment.Bottom;
            graphics.DrawString(AppResource.Facility, arialRegularFont, whiteBrush, new RectangleF(400, 0, pageWidth - 400, headerHeight / 2 - arialRegularFont.Height), format);
            #endregion

            //Measure the string size using the font. 
            SizeF size = arialRegularFont.MeasureString(AppResource.InvoiceNumber + Globals.ServiceNote);
            y = headerHeight + margin;
            x = (pageWidth - margin) - size.Width;
            //Draw text to a PDF page with the provided font and location. 
            graphics.DrawString(AppResource.InvoiceNumber + Globals.ServiceNote, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            //Measure the string size using the font.
            size = arialRegularFont.MeasureString(AppResource.Date + Globals.InvoiceDate.ToString("dddd dd, MMMM yyyy"));
            x = (pageWidth - margin) - size.Width;
            y += arialRegularFont.Height + lineSpace;
            //Draw text to a PDF page with the provided font and location. 
            graphics.DrawString(AppResource.Date + Globals.InvoiceDate.ToString("dddd dd, MMMM yyyy"), arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            y = headerHeight + margin;
            x = margin;

            //Draw text to a PDF page with the provided font and location.
            size = arialRegularFont.MeasureString(AppResource.MyCompanyARA);
            graphics.DrawString(AppResource.MyCompanyARA, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            graphics.DrawString(AppResource.CompanyName, arialBoldFont, PdfBrushes.Black, new PointF(x + size.Width + 2, y));
            y += arialRegularFont.Height;
            graphics.DrawString(AppResource.CostumerARA, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            graphics.DrawString(Globals.Costumer, arialBoldFont, PdfBrushes.Black, new RectangleF(x + size.Width + 2, y, 200, arialRegularFont.Height * 2));
            y += arialRegularFont.Height * 2;
            size = arialRegularFont.MeasureString(AppResource.Work);
            graphics.DrawString(Globals.Work, arialBoldFont, PdfBrushes.Black, new PointF(x + size.Width + 2, y));

            graphics.DrawString(AppResource.Work, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            arialRegularFont = new PdfTrueTypeFont(fontStream, 8, PdfFontStyle.Regular);
            graphics.DrawString("1  Preencher o documento ANTES de cada atividade a realizar", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height;
            graphics.DrawString("2  Informar ao responsável imediato o mais rápido possível se:", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height;
            graphics.DrawString("a) Identificar qualquer risco não previsto anteriormente;", arialRegularFont, PdfBrushes.Black, new PointF(x + 10, y));
            y += arialRegularFont.Height;
            graphics.DrawString("b) For necessário tomar precauções adicionais para eliminar o risco;", arialRegularFont, PdfBrushes.Black, new PointF(x + 10, y));
            y += arialRegularFont.Height;
            graphics.DrawString("c) For necessário tomar precauções adicionais para redução dos riscos;", arialRegularFont, PdfBrushes.Black, new PointF(x + 10, y));
            y += arialRegularFont.Height;
            graphics.DrawString("d) For necessário utilizar ferramentas/equipamentos especiais para\neliminar o risco;", arialRegularFont, PdfBrushes.Black, new PointF(x + 10, y));
            y += arialRegularFont.Height*2;
            graphics.DrawString("e) For necessário executar trabalhos a quente ou em altura para realização\nprocedimento complementar;", arialRegularFont, PdfBrushes.Black, new PointF(x + 10, y));
            y += arialRegularFont.Height*2;
            graphics.DrawString("3  Não existindo riscos adicionais, escrever \"INEXISTENTE\" no espaço apropriado;", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height;
            graphics.DrawString("4  Não realizar os trabalhos, caso o risco identificado não seja eliminado.", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            arialRegularFont = new PdfTrueTypeFont(fontStream, 9, PdfFontStyle.Regular);

            #region ARA1 to ARA4
            //ARA1
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawRectangle(lightBlueBrush, new RectangleF(x, y, pageWidth - (margin * 2), 20));
            graphics.DrawString(AppResource.ARA1, arialRegularFont, PdfBrushes.White, new PointF(x + 5, y + 3));
            graphics.DrawString(AppResource.Action, arialRegularFont, PdfBrushes.White, new PointF(x + (pageWidth / 2), y + 3));
            graphics.DrawString(UserLocalSettings.ARAEditor1, arialRegularFont, PdfBrushes.Black, new RectangleF(x + (pageWidth / 2), y + arialRegularFont.Height + lineSpace, 195, 100));


            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck1_1) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA1_1, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));
            
            y += arialRegularFont.Height + lineSpace -10;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck1_2) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA1_2, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck1_3) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA1_3, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck1_4) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA1_4, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck1_5) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA1_5, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            //ARA2
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawRectangle(lightBlueBrush, new RectangleF(x, y, pageWidth - (margin * 2), 20));
            graphics.DrawString(AppResource.ARA2, arialRegularFont, PdfBrushes.White, new PointF(x + 5, y + 3));
            graphics.DrawString(AppResource.Action, arialRegularFont, PdfBrushes.White, new PointF(x + (pageWidth / 2), y + 3));
            graphics.DrawString(UserLocalSettings.ARAEditor2, arialRegularFont, PdfBrushes.Black, new RectangleF(x + (pageWidth / 2), y + arialRegularFont.Height + lineSpace, 195, 100));


            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck2_1) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA2_1, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck2_2) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA2_2, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck2_3) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA2_3, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            //ARA3
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawRectangle(lightBlueBrush, new RectangleF(x, y, pageWidth - (margin * 2), 20));
            graphics.DrawString(AppResource.ARA3, arialRegularFont, PdfBrushes.White, new PointF(x + 5, y + 3));
            graphics.DrawString(AppResource.Action, arialRegularFont, PdfBrushes.White, new PointF(x + (pageWidth / 2), y + 3));
            graphics.DrawString(UserLocalSettings.ARAEditor3, arialRegularFont, PdfBrushes.Black, new RectangleF(x + (pageWidth / 2), y + arialRegularFont.Height + lineSpace, 195, 100));


            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck3_1) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA3_1, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck3_2) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA3_2, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck3_3) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA3_3, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            //ARA4
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawRectangle(lightBlueBrush, new RectangleF(x, y, pageWidth - (margin * 2), 20));
            graphics.DrawString(AppResource.ARA4, arialRegularFont, PdfBrushes.White, new PointF(x + 5, y + 3));
            graphics.DrawString(AppResource.Action, arialRegularFont, PdfBrushes.White, new PointF(x + (pageWidth / 2), y + 3));
            graphics.DrawString(UserLocalSettings.ARAEditor4, arialRegularFont, PdfBrushes.Black, new RectangleF(x + (pageWidth / 2), y + arialRegularFont.Height + lineSpace, 195, 100));


            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck4_1) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA4_1, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck4_2) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA4_2, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck4_3) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA4_3, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck4_4) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA4_4, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics.DrawString(BoolToString(UserLocalSettings.ARACheck4_5) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics.DrawString(AppResource.ARA4_5, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            

            #endregion

            #region Footer

            //Create a border pen with the custom dash style and draw the border to the page. 
            borderPen.DashStyle = PdfDashStyle.Custom;
            borderPen.DashPattern = new float[] { 3, 3 };
            graphics.DrawLine(borderPen, new PointF(0, pageHeight - 100), new PointF(pageWidth, pageHeight - 100));

            basePath = "Report_Manager_Mobile.Resources.Images.";
            //Get the image file stream from the assembly.
            Stream imageStream = assembly.GetManifestResourceStream(basePath + "accell.png");

            //Create a PDF bitmap image from the stream.
            PdfBitmap bitmap = new PdfBitmap(imageStream);
            //Draw the image to the PDF page. 
            graphics.DrawImage(bitmap, new RectangleF(10, pageHeight - 70, 132, 40));

            //Calculate the text position and draw the text to the PDF page. 
            y = pageHeight - 110 + margin;
            size = arialRegularFont.MeasureString(AppResource.CompanyName);
            x = pageWidth - size.Width - margin;
            graphics.DrawString(AppResource.CompanyName, arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            //Calculate the text position and draw the text to the PDF page. 
            y += arialRegularFont.Height + lineSpace -10;
            size = arialRegularFont.MeasureString("Av. Joaquim Bôer, 792 - Santa Cruz, Americana - SP,");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("Av. Joaquim Bôer, 792 - Santa Cruz, Americana - SP,", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            //Calculate the text position and draw the text to the PDF page. 
            y += arialRegularFont.Height + lineSpace -10;
            size = arialRegularFont.MeasureString("13477-360 - Telefone: (19) 3471-8400");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("13477-360 - Telefone: (19) 3471-8400", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            // Calculate the text position and draw the text to the PDF page.
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("CNPJ: 60.882.719/0006-30");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("CNPJ: 60.882.719/0006-30", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            // Calculate the text position and draw the text to the PDF page.
            y += arialRegularFont.Height + lineSpace -10;
            size = arialRegularFont.MeasureString("faleconosco@accellsolutions.com");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("faleconosco@accellsolutions.com", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            #endregion

            //PAGE 2 ############################################################

            PdfPage page2 = document.Pages.Add();
            //Create PDF graphics for the page.
            PdfGraphics graphics2 = page2.Graphics;
            //Get the page width and height.
            float pageWidth2 = page2.GetClientSize().Width;
            float pageHeight2 = page2.GetClientSize().Height;
            //Create a border pen and draw the border to on the PDF page. 
            PdfColor borderColor2 = Color.FromArgb(255, 0, 115, 184);
            PdfPen borderPen2 = new PdfPen(borderColor2, 1f);
            graphics2.DrawRectangle(borderPen2, new RectangleF(0, 0, pageWidth2, pageHeight2));
            float headerHeight2 = 90;

            //Create a string format.
            PdfStringFormat format2 = new PdfStringFormat();
            format2.Alignment = PdfTextAlignment.Center;
            format2.LineAlignment = PdfVerticalAlignment.Middle;


            #region Header2      
            //Fill the header with a light blue brush. 
            graphics2.DrawRectangle(lightBlueBrush, new RectangleF(0, 0, pageWidth2, headerHeight2));

            //Specificy the bounds for the total value. 
            arialRegularFont = new PdfTrueTypeFont(fontStream, 18, PdfFontStyle.Regular);
            //Measure the string size using the font. 

            graphics2.DrawString(title, headerFont, whiteBrush, new RectangleF(0, 0, textSize.Width + 50, headerHeight2), format2);
            //Draw a rectangle in the PDF page. 
            graphics2.DrawRectangle(darkBlueBrush, headerTotalBounds);
            //Draw the total value to the PDF page. 
            graphics2.DrawString(Globals.Facility, arialRegularFont, whiteBrush, new RectangleF(400, 0, pageWidth2 - 400, headerHeight2 + 10), format2);
            //Create a font from the font stream. 
            arialRegularFont = new PdfTrueTypeFont(fontStream, 9, PdfFontStyle.Regular);
            //Set the bottom line alignment and draw the text to the PDF page. 
            format2.LineAlignment = PdfVerticalAlignment.Bottom;
            graphics2.DrawString("Facility", arialRegularFont, whiteBrush, new RectangleF(400, 0, pageWidth2 - 400, headerHeight2 / 2 - arialRegularFont.Height), format2);

            
            //Measure the string size using the font. 
            size = arialRegularFont.MeasureString("Invoice Number: " + Globals.ServiceNote);
            y = headerHeight2 + margin;
            x = (pageWidth2 - margin) - size.Width;
            //Draw text to a PDF page with the provided font and location. 
            graphics2.DrawString("Invoice Number: " + Globals.ServiceNote, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            //Measure the string size using the font.
            size = arialRegularFont.MeasureString("Date :" + Globals.InvoiceDate.ToString("dddd dd, MMMM yyyy"));
            x = (pageWidth - margin) - size.Width;
            y += arialRegularFont.Height + lineSpace;
            //Draw text to a PDF page with the provided font and location. 
            graphics2.DrawString("Date: " + Globals.InvoiceDate.ToString("dddd dd, MMMM yyyy"), arialRegularFont, PdfBrushes.Black, new PointF(x+10, y+10));


            #endregion

            y = headerHeight2 + margin;
            x = margin;
            //Draw text to a PDF page with the provided font and location. 
            graphics2.DrawString(Globals.Equipment, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics2.DrawString(Globals.EquipmentType, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics2.DrawString(Globals.EquipmentSN, arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            //ARA5
            y += arialRegularFont.Height + lineSpace;
            graphics2.DrawRectangle(lightBlueBrush, new RectangleF(x, y, pageWidth - (margin * 2), 20));
            graphics2.DrawString(AppResource.ARA5, arialRegularFont, PdfBrushes.White, new PointF(x + 5, y + 3));
            graphics2.DrawString(AppResource.Action, arialRegularFont, PdfBrushes.White, new PointF(x + (pageWidth / 2), y + 3));
            graphics2.DrawString(UserLocalSettings.ARAEditor5, arialRegularFont, PdfBrushes.Black, new RectangleF(x + (pageWidth / 2), y + arialRegularFont.Height + lineSpace, 195, 100));


            y += arialRegularFont.Height + lineSpace;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck5_1) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA5_1, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck5_2) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA5_2, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck5_3) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA5_3, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck5_4) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA5_4, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck5_5) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA5_5, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck5_6) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA5_6, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            //ARA6
            y += arialRegularFont.Height + lineSpace;
            graphics2.DrawRectangle(lightBlueBrush, new RectangleF(x, y, pageWidth2 - (margin * 2), 20));
            graphics2.DrawString(AppResource.ARA6, arialRegularFont, PdfBrushes.White, new PointF(x + 5, y + 3));
            graphics2.DrawString(AppResource.Action, arialRegularFont, PdfBrushes.White, new PointF(x + (pageWidth / 2), y + 3));
            graphics2.DrawString(UserLocalSettings.ARAEditor6, arialRegularFont, PdfBrushes.Black, new RectangleF(x + (pageWidth / 2), y + arialRegularFont.Height + lineSpace, 195, 100));


            y += arialRegularFont.Height + lineSpace;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck6_1) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA6_1, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck6_2) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA6_2, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck6_3) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA6_3, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck6_4) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA6_4, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck6_5) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA6_5, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck6_6) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA6_6, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck6_7) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA6_7, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck6_8) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA6_8, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck6_9) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA6_9, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));


            //ARA7
            y += arialRegularFont.Height + lineSpace;
            graphics2.DrawRectangle(lightBlueBrush, new RectangleF(x, y, pageWidth2 - (margin * 2), 20));
            graphics2.DrawString(AppResource.ARA7, arialRegularFont, PdfBrushes.White, new PointF(x + 5, y + 3));
            graphics2.DrawString(AppResource.Action, arialRegularFont, PdfBrushes.White, new PointF(x + (pageWidth / 2), y + 3));
            graphics2.DrawString(UserLocalSettings.ARAEditor7, arialRegularFont, PdfBrushes.Black, new RectangleF(x + (pageWidth / 2), y + arialRegularFont.Height + lineSpace, 195, 100));


            y += arialRegularFont.Height + lineSpace;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck7_1) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA7_1, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck7_2) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA7_2, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck7_3) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA7_3, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck7_4) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA7_4, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck7_5) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA7_5, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck7_6) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA7_6, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck7_7) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA7_7, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace - 10;
            graphics2.DrawString(BoolToString(UserLocalSettings.ARACheck7_8) + "  ", arialRegularFont, PdfBrushes.Black, new PointF(x + 5, y));
            graphics2.DrawString(AppResource.ARA7_8, arialRegularFont, PdfBrushes.Black, new PointF(x + 30, y));

            y += arialRegularFont.Height + lineSpace;
            graphics2.DrawRectangle(lightBlueBrush, new RectangleF(x, y, pageWidth2 - (margin * 2), 20));
            graphics2.DrawString("Observações", arialRegularFont, PdfBrushes.White, new PointF(x + 5, y + 3));


            #region Footer2


            graphics2.DrawLine(borderPen, new PointF(0, pageHeight - 100), new PointF(pageWidth, pageHeight - 100));

            //Draw the image to the PDF page. 
            graphics2.DrawImage(bitmap, new RectangleF(10, pageHeight - 70, 132, 40));

            //Calculate the text position and draw the text to the PDF page. 
            y = pageHeight - 110 + margin;
            size = arialRegularFont.MeasureString("ACCELL SOLUÇÕES PARA ENERGIA E ÁGUA LTDA.");
            x = pageWidth - size.Width - margin;
            graphics2.DrawString("ACCELL SOLUÇÕES PARA ENERGIA E ÁGUA LTDA.", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            //Calculate the text position and draw the text to the PDF page. 
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("Av. Joaquim Bôer, 792 - Santa Cruz, Americana - SP,");
            x = pageWidth - size.Width - margin;
            graphics2.DrawString("Av. Joaquim Bôer, 792 - Santa Cruz, Americana - SP,", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            //Calculate the text position and draw the text to the PDF page. 
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("13477-360 - Telefone: (19) 3471-8400");
            x = pageWidth - size.Width - margin;
            graphics2.DrawString("13477-360 - Telefone: (19) 3471-8400", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            // Calculate the text position and draw the text to the PDF page.
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("CNPJ: 60.882.719/0006-30");
            x = pageWidth - size.Width - margin;
            graphics2.DrawString("CNPJ: 60.882.719/0006-30", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            // Calculate the text position and draw the text to the PDF page.
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("faleconosco@accellsolutions.com");
            x = pageWidth - size.Width - margin;
            graphics2.DrawString("faleconosco@accellsolutions.com", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            #endregion



            #region Helpers
            string BoolToString(bool b)
            {
                if (b)
                {
                    return AppResource.ARAYes;
                }
                else
                {
                    return AppResource.ARANo;
                }
            }
            #endregion

            RectangleF bounds = new RectangleF(0, 0, document.Pages[0].GetClientSize().Width, 50);
            PdfPageTemplateElement footer = new PdfPageTemplateElement(bounds);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 9);
            PdfBrush brush = new PdfSolidBrush(Color.Black);
            //Create page number field.
            PdfPageNumberField pageNumber = new PdfPageNumberField(font, brush);
            //Create page count field.
            PdfPageCountField count = new PdfPageCountField(font, brush);
            //Add the fields in composite fields.
            PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Page {0} of {1}", pageNumber, count);
            compositeField.Bounds = footer.Bounds;
            //Draw the composite field in footer.
            compositeField.Draw(footer.Graphics, new PointF((pageWidth / 2) - 20, 35));
            //Add the footer template at the bottom.
            document.Template.Bottom = footer;

            using MemoryStream ms = new();
            //Saves the presentation to the memory stream.
            document.Save(ms);
            //Close the PDF document
            document.Close(true);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveService saveService = new();
            //TODO: Remove special characteres from filename
            saveService.SaveAndView(("ARA_INST" + Globals.Facility + "_NS" + Globals.ServiceNote + "_" + Globals.Costumer + ".pdf").Replace(" ", "_"), "application/pdf", ms, UserLocalSettings.ARAPreview);
            

        }

        public static void CreateCTC()
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Add a page to the document.
            PdfPage page = document.Pages.Add();
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Get the page width and height.
            float pageWidth = page.GetClientSize().Width;
            float pageHeight = page.GetClientSize().Height;
            RectangleF TotalPriceCellBounds = RectangleF.Empty;
            RectangleF QuantityCellBounds = RectangleF.Empty;
            //Set the header height.
            float headerHeight = 90;
            //Create a brush with a light blue color. 
            PdfColor lightBlue = Color.FromArgb(255, 189, 31, 44);
            PdfBrush lightBlueBrush = new PdfSolidBrush(lightBlue);
            //Create a brush with a dark blue color. 
            PdfColor darkBlue = Color.FromArgb(255, 163, 35, 48);
            PdfBrush darkBlueBrush = new PdfSolidBrush(darkBlue);
            //Create a brush with a white color. 
            PdfBrush whiteBrush = new PdfSolidBrush(Color.FromArgb(255, 255, 255, 255));

            //Get the font file stream from the assembly. 
            Assembly assembly = typeof(Create).GetTypeInfo().Assembly;
            string basePath = "Report_Manager_Mobile.Resources.Fonts.";
            Stream fontStream = assembly.GetManifestResourceStream(basePath + "OpenSans-Regular.ttf");
            //Create a PdfTrueTypeFont from the stream with the different sizes. 
            PdfTrueTypeFont headerFont = new PdfTrueTypeFont(fontStream, 18, PdfFontStyle.Regular);
            PdfTrueTypeFont arialRegularFont = new PdfTrueTypeFont(fontStream, 18, PdfFontStyle.Regular);
            PdfTrueTypeFont arialBoldFont = new PdfTrueTypeFont(fontStream, 9, PdfFontStyle.Bold);
            //Create a string format.
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            float y = 0;
            float x = 0;
            //Set the margins of the address.
            float margin = 30;
            //Set the line space.
            float lineSpace = 10;
            //Create a border pen and draw the border to on the PDF page. 
            PdfColor borderColor = Color.FromArgb(255, 0, 115, 184);
            PdfPen borderPen = new PdfPen(borderColor, 1f);
            graphics.DrawRectangle(borderPen, new RectangleF(0, 0, pageWidth, pageHeight));

            //Create a new PdfGrid. 
            PdfGrid grid = new PdfGrid();
            //Add five columns to the grid.
            grid.Columns.Add(5);
            //Create the header row of the grid.
            PdfGridRow[] headerRow = grid.Headers.Add(1);
            //Set style to the header row and set value to the header cells. 
            headerRow[0].Style.BackgroundBrush = new PdfSolidBrush(new PdfColor(68, 114, 196));
            headerRow[0].Style.TextBrush = PdfBrushes.White;
            headerRow[0].Cells[0].Value = "Product ID";
            headerRow[0].Cells[0].StringFormat.Alignment = PdfTextAlignment.Center;
            headerRow[0].Cells[1].Value = "Product Name";
            headerRow[0].Cells[2].Value = "Price ($)";
            headerRow[0].Cells[3].Value = "Quantity";
            headerRow[0].Cells[4].Value = "Total ($)";
            //Add products to the grid table.
            AddProducts("CA-1098", "AWC Logo Cap", 8.99, 2, 17.98, grid);
            AddProducts("LJ-0192", "Long-Sleeve Logo Jersey,M", 49.99, 3, 149.97, grid);
            AddProducts("So-B909-M", "Mountain Bike Socks,M", 9.50, 2, 19, grid);
            AddProducts("LJ-0192", "Long-Sleeve Logo Jersey,M", 49.99, 4, 199.96, grid);
            AddProducts("FK-5136", "ML Fork", 175.49, 6, 1052.94, grid);
            AddProducts("HL-U509", "Sports-100 Helmet,Black", 34.99, 1, 34.99, grid);

            #region Header         
            //Fill the header with a light blue brush. 
            graphics.DrawRectangle(lightBlueBrush, new RectangleF(0, 0, pageWidth, headerHeight));
            string title = "CONFERENCIA DE TRABALHO DE CAMPO";
            //Specificy the bounds for the total value. 
            RectangleF headerTotalBounds = new RectangleF(400, 0, pageWidth - 400, headerHeight);
            //Measure the string size using the font. 
            SizeF textSize = headerFont.MeasureString(title);
            graphics.DrawString(title, headerFont, whiteBrush, new RectangleF(0, 0, textSize.Width + 80, headerHeight), format);
            //Draw a rectangle in the PDF page. 
            graphics.DrawRectangle(darkBlueBrush, headerTotalBounds);
            //Draw the total value to the PDF page. 
            graphics.DrawString(Globals.Facility, arialRegularFont, whiteBrush, new RectangleF(400, 0, pageWidth - 400, headerHeight + 10), format);
            //Create a font from the font stream. 
            arialRegularFont = new PdfTrueTypeFont(fontStream, 9, PdfFontStyle.Regular);
            //Set the bottom line alignment and draw the text to the PDF page. 
            format.LineAlignment = PdfVerticalAlignment.Bottom;
            graphics.DrawString("Facility", arialRegularFont, whiteBrush, new RectangleF(400, 0, pageWidth - 400, headerHeight / 2 - arialRegularFont.Height), format);
            #endregion

            //Measure the string size using the font. 
            SizeF size = arialRegularFont.MeasureString("Invoice Number: 2058557939");
            y = headerHeight + margin;
            x = (pageWidth - margin) - size.Width;
            //Draw text to a PDF page with the provided font and location. 
            graphics.DrawString("Invoice Number: 2058557939", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            //Measure the string size using the font.
            size = arialRegularFont.MeasureString("Date :" + Globals.InvoiceDate.ToString("dddd dd, MMMM yyyy"));
            x = (pageWidth - margin) - size.Width;
            y += arialRegularFont.Height + lineSpace;
            //Draw text to a PDF page with the provided font and location. 
            graphics.DrawString("Date: " + Globals.InvoiceDate.ToString("dddd dd, MMMM yyyy"), arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            y = headerHeight + margin;
            x = margin;
            //Draw text to a PDF page with the provided font and location. 
            graphics.DrawString(Globals.Equipment, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString(Globals.EquipmentType, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString(Globals.EquipmentSN, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString(Globals.Adress, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString("9365550136", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            #region Grid
            //Set the width of theto grid columns. 
            grid.Columns[0].Width = 110;
            grid.Columns[1].Width = 150;
            grid.Columns[2].Width = 110;
            grid.Columns[3].Width = 70;
            grid.Columns[4].Width = 100;
            for (int i = 0; i < grid.Headers.Count; i++)
            {
                //Set the height ofto the grid header row. 
                grid.Headers[i].Height = 20;
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    //Create a string format for the header cell. 
                    PdfStringFormat pdfStringFormat = new PdfStringFormat();
                    pdfStringFormat.LineAlignment = PdfVerticalAlignment.Middle;
                    pdfStringFormat.Alignment = PdfTextAlignment.Left;
                    pdfStringFormat.Alignment = PdfTextAlignment.Left;
                    //Set cell padding for header cell. 
                    if (j == 0 || j == 2)
                        grid.Headers[i].Cells[j].Style.CellPadding = new PdfPaddings(30, 1, 1, 1);
                    //Set a string format to the grid header cell. 
                    grid.Headers[i].Cells[j].StringFormat = pdfStringFormat;
                    //Set font to the grid header cell. 
                    grid.Headers[i].Cells[j].Style.Font = arialBoldFont;
                }
                //Set the value ofto the grid header cell. 
                grid.Headers[0].Cells[0].Value = "Product ID";
            }
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                //Set the height ofto the grid row. 
                grid.Rows[i].Height = 23;
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    //Create a string format for the grid row. 
                    PdfStringFormat pdfStringFormat = new PdfStringFormat();
                    pdfStringFormat.LineAlignment = PdfVerticalAlignment.Middle;
                    pdfStringFormat.Alignment = PdfTextAlignment.Left;

                    //Set cell padding for grid row cell. 
                    if (j == 0 || j == 2)
                        grid.Rows[i].Cells[j].Style.CellPadding = new PdfPaddings(30, 1, 1, 1);

                    //Seta string format to the grid row cell. 
                    grid.Rows[i].Cells[j].StringFormat = pdfStringFormat;
                    //Set the font to the grid row cell. 
                    grid.Rows[i].Cells[j].Style.Font = arialRegularFont;
                }
            }

            //Apply built-in table style to the grid. 
            grid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable4Accent5);
            //Subscribeing to begin the cell layout event.
            grid.BeginCellLayout += Grid_BeginCellLayout;
            //Draw the PDF grid to the PDF page and get the layout result. 
            PdfGridLayoutResult result = grid.Draw(page, new PointF(0, y + 40));

            //Using the layout result, continue to draw the text. 
            y = result.Bounds.Bottom + lineSpace;
            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            RectangleF bounds = new RectangleF(QuantityCellBounds.X, y, QuantityCellBounds.Width, QuantityCellBounds.Height);
            //Draw the text to the PDF page based on the layout result. 
            page.Graphics.DrawString("Grand Total:", arialBoldFont, PdfBrushes.Black, bounds, format);
            //Draw the total amount value to the PDF page based on the layout result. 
            bounds = new RectangleF(TotalPriceCellBounds.X, y, TotalPriceCellBounds.Width, TotalPriceCellBounds.Height);
            page.Graphics.DrawString("$" + GetTotalAmount(grid).ToString(), arialBoldFont, PdfBrushes.Black, bounds);

            //Create a border pen with the custom dash style and draw the border to the page. 
            borderPen.DashStyle = PdfDashStyle.Custom;
            borderPen.DashPattern = new float[] { 3, 3 };
            graphics.DrawLine(borderPen, new PointF(0, pageHeight - 100), new PointF(pageWidth, pageHeight - 100));

            basePath = "Report_Manager_Mobile.Resources.Images.";
            //Get the image file stream from the assembly.
            Stream imageStream = assembly.GetManifestResourceStream(basePath + "accell.png");

            //Create a PDF bitmap image from the stream.
            PdfBitmap bitmap = new PdfBitmap(imageStream);
            //Draw the image to the PDF page. 
            graphics.DrawImage(bitmap, new RectangleF(10, pageHeight - 70, 132, 40));

            //Calculate the text position and draw the text to the PDF page. 
            y = pageHeight - 110 + margin;
            size = arialRegularFont.MeasureString("ACCELL SOLUÇÕES PARA ENERGIA E ÁGUA LTDA.");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("ACCELL SOLUÇÕES PARA ENERGIA E ÁGUA LTDA.", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            //Calculate the text position and draw the text to the PDF page. 
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("Av. Joaquim Bôer, 792 - Santa Cruz, Americana - SP,");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("Av. Joaquim Bôer, 792 - Santa Cruz, Americana - SP,", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            //Calculate the text position and draw the text to the PDF page. 
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("13477-360 - Telefone: (19) 3471-8400");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("13477-360 - Telefone: (19) 3471-8400", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            // Calculate the text position and draw the text to the PDF page.
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("CNPJ: 60.882.719/0006-30");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("CNPJ: 60.882.719/0006-30", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            // Calculate the text position and draw the text to the PDF page.
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("faleconosco@accellsolutions.com");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("faleconosco@accellsolutions.com", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            using MemoryStream ms = new();
            //Saves the presentation to the memory stream.
            document.Save(ms);
            //Close the PDF document
            document.Close(true);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveService saveService = new();
            saveService.SaveAndView(("CTC_INST" + Globals.Facility + "_NS" + Globals.ServiceNote + "_" + Globals.Costumer + ".pdf").Replace(" ", "_"), "application/pdf", ms, UserLocalSettings.ARAPreview);
            #endregion

            #region Helper Methods

            void Grid_BeginCellLayout(object sender, PdfGridBeginCellLayoutEventArgs args)
            {
                PdfGrid grid = sender as PdfGrid;
                if (args.CellIndex == grid!.Columns.Count - 1)
                {
                    //Get the bounds of price cell in grid row. 
                    TotalPriceCellBounds = args.Bounds;
                }
                else if (args.CellIndex == grid.Columns.Count - 2)
                {
                    //Get the bounds of quantity cell in grid row. 
                    QuantityCellBounds = args.Bounds;
                }

            }
            //Create and row for the grid.
            void AddProducts(string productId, string productName, double price, int quantity, double total, PdfGrid grid)
            {
                //Add a new row and set the product value to the grid row cells. 
                PdfGridRow row = grid.Rows.Add();
                row.Cells[0].Value = productId;
                row.Cells[1].Value = productName;
                row.Cells[2].Value = price.ToString();
                row.Cells[3].Value = quantity.ToString();
                row.Cells[4].Value = total.ToString();
            }
            // <summary>
            // Get the Total amount of the purcharsed items.
            // </summary>
            float GetTotalAmount(PdfGrid grid)
            {
                float Total = 0f;
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    string cellValue = grid.Rows[i].Cells[grid.Columns.Count - 1].Value.ToString();
                    float result = float.Parse(cellValue, System.Globalization.CultureInfo.InvariantCulture);
                    Total += result;
                }
                return Total;

            }
            #endregion
        }

        public static void CreateRT()
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Add a page to the document.
            PdfPage page = document.Pages.Add();
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;

            //Get the page width and height.
            float pageWidth = page.GetClientSize().Width;
            float pageHeight = page.GetClientSize().Height;
            RectangleF TotalPriceCellBounds = RectangleF.Empty;
            RectangleF QuantityCellBounds = RectangleF.Empty;
            //Set the header height.
            float headerHeight = 90;
            //Create a brush with a light blue color. 
            PdfColor lightBlue = Color.FromArgb(255, 117, 138, 159);
            PdfBrush lightBlueBrush = new PdfSolidBrush(lightBlue);
            //Create a brush with a dark blue color. 
            PdfColor darkBlue = Color.FromArgb(255, 69, 83, 104);
            PdfBrush darkBlueBrush = new PdfSolidBrush(darkBlue);
            //Create a brush with a white color. 
            PdfBrush whiteBrush = new PdfSolidBrush(Color.FromArgb(255, 255, 255, 255));

            //Get the font file stream from the assembly. 
            Assembly assembly = typeof(Create).GetTypeInfo().Assembly;
            string basePath = "Report_Manager_Mobile.Resources.Fonts.";
            Stream fontStream = assembly.GetManifestResourceStream(basePath + "OpenSans-Regular.ttf");
            //Create a PdfTrueTypeFont from the stream with the different sizes. 
            PdfTrueTypeFont headerFont = new PdfTrueTypeFont(fontStream, 18, PdfFontStyle.Regular);
            PdfTrueTypeFont arialRegularFont = new PdfTrueTypeFont(fontStream, 18, PdfFontStyle.Regular);
            PdfTrueTypeFont arialBoldFont = new PdfTrueTypeFont(fontStream, 9, PdfFontStyle.Bold);
            //Create a string format.
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            float y = 0;
            float x = 0;
            //Set the margins of the address.
            float margin = 30;
            //Set the line space.
            float lineSpace = 10;
            //Create a border pen and draw the border to on the PDF page. 
            PdfColor borderColor = Color.FromArgb(255, 0, 115, 184);
            PdfPen borderPen = new PdfPen(borderColor, 1f);
            graphics.DrawRectangle(borderPen, new RectangleF(0, 0, pageWidth, pageHeight));

            //Create a new PdfGrid. 
            PdfGrid grid = new PdfGrid();
            //Add five columns to the grid.
            grid.Columns.Add(5);
            //Create the header row of the grid.
            PdfGridRow[] headerRow = grid.Headers.Add(1);
            //Set style to the header row and set value to the header cells. 
            headerRow[0].Style.BackgroundBrush = new PdfSolidBrush(new PdfColor(68, 114, 196));
            headerRow[0].Style.TextBrush = PdfBrushes.White;
            headerRow[0].Cells[0].Value = "Product ID";
            headerRow[0].Cells[0].StringFormat.Alignment = PdfTextAlignment.Center;
            headerRow[0].Cells[1].Value = "Product Name";
            headerRow[0].Cells[2].Value = "Price ($)";
            headerRow[0].Cells[3].Value = "Quantity";
            headerRow[0].Cells[4].Value = "Total ($)";
            //Add products to the grid table.
            AddProducts("CA-1098", "AWC Logo Cap", 8.99, 2, 17.98, grid);
            AddProducts("LJ-0192", "Long-Sleeve Logo Jersey,M", 49.99, 3, 149.97, grid);
            AddProducts("So-B909-M", "Mountain Bike Socks,M", 9.50, 2, 19, grid);
            AddProducts("LJ-0192", "Long-Sleeve Logo Jersey,M", 49.99, 4, 199.96, grid);
            AddProducts("FK-5136", "ML Fork", 175.49, 6, 1052.94, grid);
            AddProducts("HL-U509", "Sports-100 Helmet,Black", 34.99, 1, 34.99, grid);

            #region Header         
            //Fill the header with a light blue brush. 
            graphics.DrawRectangle(lightBlueBrush, new RectangleF(0, 0, pageWidth, headerHeight));
            string title = "RELATÓRIO DE TROCA";
            //Specificy the bounds for the total value. 
            RectangleF headerTotalBounds = new RectangleF(400, 0, pageWidth - 400, headerHeight);
            //Measure the string size using the font. 
            SizeF textSize = headerFont.MeasureString(title);
            graphics.DrawString(title, headerFont, whiteBrush, new RectangleF(0, 0, textSize.Width + 50, headerHeight), format);
            //Draw a rectangle in the PDF page. 
            graphics.DrawRectangle(darkBlueBrush, headerTotalBounds);
            //Draw the total value to the PDF page. 
            graphics.DrawString(Globals.Facility, arialRegularFont, whiteBrush, new RectangleF(400, 0, pageWidth - 400, headerHeight + 10), format);
            //Create a font from the font stream. 
            arialRegularFont = new PdfTrueTypeFont(fontStream, 9, PdfFontStyle.Regular);
            //Set the bottom line alignment and draw the text to the PDF page. 
            format.LineAlignment = PdfVerticalAlignment.Bottom;
            graphics.DrawString("Facility", arialRegularFont, whiteBrush, new RectangleF(400, 0, pageWidth - 400, headerHeight / 2 - arialRegularFont.Height), format);
            #endregion

            //Measure the string size using the font. 
            SizeF size = arialRegularFont.MeasureString("Invoice Number: 2058557939");
            y = headerHeight + margin;
            x = (pageWidth - margin) - size.Width;
            //Draw text to a PDF page with the provided font and location. 
            graphics.DrawString("Invoice Number: 2058557939", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            //Measure the string size using the font.
            size = arialRegularFont.MeasureString("Date :" + Globals.InvoiceDate.ToString("dddd dd, MMMM yyyy"));
            x = (pageWidth - margin) - size.Width;
            y += arialRegularFont.Height + lineSpace;
            //Draw text to a PDF page with the provided font and location. 
            graphics.DrawString("Date: " + Globals.InvoiceDate.ToString("dddd dd, MMMM yyyy"), arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            y = headerHeight + margin;
            x = margin;
            //Draw text to a PDF page with the provided font and location. 
            graphics.DrawString(Globals.Equipment, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString(Globals.EquipmentType, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString(Globals.EquipmentSN, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString(Globals.Adress, arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString("9365550136", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            #region Grid
            //Set the width of theto grid columns. 
            grid.Columns[0].Width = 110;
            grid.Columns[1].Width = 150;
            grid.Columns[2].Width = 110;
            grid.Columns[3].Width = 70;
            grid.Columns[4].Width = 100;
            for (int i = 0; i < grid.Headers.Count; i++)
            {
                //Set the height ofto the grid header row. 
                grid.Headers[i].Height = 20;
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    //Create a string format for the header cell. 
                    PdfStringFormat pdfStringFormat = new PdfStringFormat();
                    pdfStringFormat.LineAlignment = PdfVerticalAlignment.Middle;
                    pdfStringFormat.Alignment = PdfTextAlignment.Left;
                    pdfStringFormat.Alignment = PdfTextAlignment.Left;
                    //Set cell padding for header cell. 
                    if (j == 0 || j == 2)
                        grid.Headers[i].Cells[j].Style.CellPadding = new PdfPaddings(30, 1, 1, 1);
                    //Set a string format to the grid header cell. 
                    grid.Headers[i].Cells[j].StringFormat = pdfStringFormat;
                    //Set font to the grid header cell. 
                    grid.Headers[i].Cells[j].Style.Font = arialBoldFont;
                }
                //Set the value ofto the grid header cell. 
                grid.Headers[0].Cells[0].Value = "Product ID";
            }
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                //Set the height ofto the grid row. 
                grid.Rows[i].Height = 23;
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    //Create a string format for the grid row. 
                    PdfStringFormat pdfStringFormat = new PdfStringFormat();
                    pdfStringFormat.LineAlignment = PdfVerticalAlignment.Middle;
                    pdfStringFormat.Alignment = PdfTextAlignment.Left;

                    //Set cell padding for grid row cell. 
                    if (j == 0 || j == 2)
                        grid.Rows[i].Cells[j].Style.CellPadding = new PdfPaddings(30, 1, 1, 1);

                    //Seta string format to the grid row cell. 
                    grid.Rows[i].Cells[j].StringFormat = pdfStringFormat;
                    //Set the font to the grid row cell. 
                    grid.Rows[i].Cells[j].Style.Font = arialRegularFont;
                }
            }

            //Apply built-in table style to the grid. 
            grid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable4Accent5);
            //Subscribeing to begin the cell layout event.
            grid.BeginCellLayout += Grid_BeginCellLayout;
            //Draw the PDF grid to the PDF page and get the layout result. 
            PdfGridLayoutResult result = grid.Draw(page, new PointF(0, y + 40));

            //Using the layout result, continue to draw the text. 
            y = result.Bounds.Bottom + lineSpace;
            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            RectangleF bounds = new RectangleF(QuantityCellBounds.X, y, QuantityCellBounds.Width, QuantityCellBounds.Height);
            //Draw the text to the PDF page based on the layout result. 
            page.Graphics.DrawString("Grand Total:", arialBoldFont, PdfBrushes.Black, bounds, format);
            //Draw the total amount value to the PDF page based on the layout result. 
            bounds = new RectangleF(TotalPriceCellBounds.X, y, TotalPriceCellBounds.Width, TotalPriceCellBounds.Height);
            page.Graphics.DrawString("$" + GetTotalAmount(grid).ToString(), arialBoldFont, PdfBrushes.Black, bounds);

            //Create a border pen with the custom dash style and draw the border to the page. 
            borderPen.DashStyle = PdfDashStyle.Custom;
            borderPen.DashPattern = new float[] { 3, 3 };
            graphics.DrawLine(borderPen, new PointF(0, pageHeight - 100), new PointF(pageWidth, pageHeight - 100));

            basePath = "Report_Manager_Mobile.Resources.Images.";
            //Get the image file stream from the assembly.
            Stream imageStream = assembly.GetManifestResourceStream(basePath + "accell.png");

            //Create a PDF bitmap image from the stream.
            PdfBitmap bitmap = new PdfBitmap(imageStream);
            //Draw the image to the PDF page. 
            graphics.DrawImage(bitmap, new RectangleF(10, pageHeight - 70, 132, 40));

            //Calculate the text position and draw the text to the PDF page. 
            y = pageHeight - 110 + margin;
            size = arialRegularFont.MeasureString("ACCELL SOLUÇÕES PARA ENERGIA E ÁGUA LTDA.");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("ACCELL SOLUÇÕES PARA ENERGIA E ÁGUA LTDA.", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            //Calculate the text position and draw the text to the PDF page. 
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("Av. Joaquim Bôer, 792 - Santa Cruz, Americana - SP,");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("Av. Joaquim Bôer, 792 - Santa Cruz, Americana - SP,", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            //Calculate the text position and draw the text to the PDF page. 
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("13477-360 - Telefone: (19) 3471-8400");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("13477-360 - Telefone: (19) 3471-8400", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            // Calculate the text position and draw the text to the PDF page.
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("CNPJ: 60.882.719/0006-30");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("CNPJ: 60.882.719/0006-30", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            // Calculate the text position and draw the text to the PDF page.
            y += arialRegularFont.Height + lineSpace - 10;
            size = arialRegularFont.MeasureString("faleconosco@accellsolutions.com");
            x = pageWidth - size.Width - margin;
            graphics.DrawString("faleconosco@accellsolutions.com", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            using MemoryStream ms = new();
            //Saves the presentation to the memory stream.
            document.Save(ms);
            //Close the PDF document
            document.Close(true);
            ms.Position = 0;
            //Saves the memory stream as file.
            SaveService saveService = new();
            saveService.SaveAndView(("RT_INST" + Globals.Facility + "_NS" + Globals.ServiceNote + "_" + Globals.Costumer + ".pdf").Replace(" ", "_"), "application/pdf", ms, UserLocalSettings.ARAPreview);
            #endregion

            #region Helper Methods

            void Grid_BeginCellLayout(object sender, PdfGridBeginCellLayoutEventArgs args)
            {
                PdfGrid grid = sender as PdfGrid;
                if (args.CellIndex == grid!.Columns.Count - 1)
                {
                    //Get the bounds of price cell in grid row. 
                    TotalPriceCellBounds = args.Bounds;
                }
                else if (args.CellIndex == grid.Columns.Count - 2)
                {
                    //Get the bounds of quantity cell in grid row. 
                    QuantityCellBounds = args.Bounds;
                }

            }
            //Create and row for the grid.
            void AddProducts(string productId, string productName, double price, int quantity, double total, PdfGrid grid)
            {
                //Add a new row and set the product value to the grid row cells. 
                PdfGridRow row = grid.Rows.Add();
                row.Cells[0].Value = productId;
                row.Cells[1].Value = productName;
                row.Cells[2].Value = price.ToString();
                row.Cells[3].Value = quantity.ToString();
                row.Cells[4].Value = total.ToString();
            }
            // <summary>
            // Get the Total amount of the purcharsed items.
            // </summary>
            float GetTotalAmount(PdfGrid grid)
            {
                float Total = 0f;
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    string cellValue = grid.Rows[i].Cells[grid.Columns.Count - 1].Value.ToString();
                    float result = float.Parse(cellValue, System.Globalization.CultureInfo.InvariantCulture);
                    Total += result;
                }
                return Total;

            }
            #endregion
        }
    }
}
