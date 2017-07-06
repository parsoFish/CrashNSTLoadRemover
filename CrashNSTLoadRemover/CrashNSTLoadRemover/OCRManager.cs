using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tesseract;

namespace CrashNSTLoadRemover
{
    /*
     * This class is in charge of the OCR engine. It starts the OCR engine, and preforms ocr when given a Bitmap, and returns text about what was found.
     */
    public class OCRManager
    {
        public OCRManager()
        {

        }

        public string GetStringFromBitmap(Bitmap bitmap)
        {
            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "eng", EngineMode.Default))
                {
                    using (var img = PixConverter.ToPix(bitmap))
                    {
                        using (var page = engine.Process(img))
                        {
                            return page.GetText();
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Unexpected Error: " + e.Message);
                Console.WriteLine("Details: ");
                Console.WriteLine(e.ToString());
            }

            return "";
        }
    }
}
