using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing;
using OfficeIMO.Word;

namespace OfficeIMO.Examples.Word {
    internal static partial class Images {
        internal static void Example_AddingImages(string folderPath, bool openWord) {
            Console.WriteLine("[*] Creating standard document with some Images");
            //string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //string imagePaths = System.IO.Path.Combine(baseDirectory, "Images");
            string filePath = System.IO.Path.Combine(folderPath, "BasicDocumentWithImages.docx");
            string imagePaths = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Images");

            using (WordDocument document = WordDocument.Create(filePath)) {
                document.BuiltinDocumentProperties.Title = "This is sparta";
                document.BuiltinDocumentProperties.Creator = "Przemek";

                var paragraph = document.AddParagraph("This paragraph starts with some text");
                paragraph.Text = "0th This paragraph started with some other text and was overwritten and made bold.";

                // lets add image to paragraph
                paragraph.AddImage(System.IO.Path.Combine(imagePaths, "PrzemyslawKlysAndKulkozaurr.jpg"), 22, 22);
                //paragraph.Image.WrapText = true; // WrapSideValues.Both;

                var paragraph5 = paragraph.AddText("and more text");
                paragraph5.Bold = true;


                document.AddParagraph("This adds another picture with 500x500");

                var filePathImage = System.IO.Path.Combine(imagePaths, "Kulek.jpg");
                WordParagraph paragraph2 = document.AddParagraph();
                paragraph2.AddImage(filePathImage, 500, 500);
                //paragraph2.Image.BlackWiteMode = BlackWhiteModeValues.GrayWhite;
                paragraph2.Image.Rotation = 180;
                paragraph2.Image.Shape = ShapeTypeValues.ActionButtonMovie;


                document.AddParagraph("This adds another picture with 100x100");

                WordParagraph paragraph3 = document.AddParagraph();
                paragraph3.AddImage(filePathImage, 100, 100);

                // we add paragraph with an image
                WordParagraph paragraph4 = document.AddParagraph();
                paragraph4.AddImage(filePathImage);

                // we can get the height of the image from paragraph
                Console.WriteLine("This document has image, which has height of: " + paragraph4.Image.Height + " pixels (I think) ;-)");

                // we can also overwrite height later on
                paragraph4.Image.Height = 50;
                paragraph4.Image.Width = 50;
                // this doesn't work
                paragraph4.Image.HorizontalFlip = true;

                // or we can get any image and overwrite it's size
                document.Images[0].Height = 200;
                document.Images[0].Width = 200;

                string fileToSave = System.IO.Path.Combine(imagePaths, "OutputPrzemyslawKlysAndKulkozaurr.jpg");
                document.Images[0].SaveToFile(fileToSave);

                document.Save(openWord);
            }
        }
    }
}