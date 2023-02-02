using Aspose.Pdf.Examples;
using Aspose.Pdf.Facades;
using System.Text;

namespace PDF_editor
{
    internal class Program
    {
        private static readonly string _datadir = @"C:\Users\terez\OneDrive\Dokumenty\IVT - code\PDFeditor"; // CHANGE!! default directory
        public static void Main()
        {

            //List<CSV_item> items = CSV_reader.Run();
            //CSV_item csv_item;
            //List<string> project = new();
            //for (int i = 0; i < items.Count;)
            //{
            //    project.Clear();
            //    csv_item = items[i];
            //    project.Add(csv_item.Text);
            //    i++;
            //    if (i == items.Count)
            //        break;
            //    while (items[i].ID == csv_item.ID && items[i].Month == csv_item.Month && items[i].Year == csv_item.Year)
            //    {
            //        project.Add(items[i].Text);
            //        i++;
            //        if (i == items.Count)
            //            break;
            //    }
            //    Editor_PDF.AddProjects(_datadir + csv_item.ToString(), project);
            //    Console.WriteLine(csv_item.ID + " " + csv_item.Name + " PDF was copleted");
            //}
            //Console.WriteLine("Program finished successfully");

            List<string> files;
            try
            {
                LoadPDF loadPDF = new(_datadir);

                files = loadPDF.GetAllPDF();
                PrintInfo(_datadir, files);
                List<PDFrecord> record = new();
                foreach (var file in files)
                {
                    PDFrecord r = new(file);
                    r.GetText();
                    record.Add(r);
                    //TODO: function for connection to database
                    Editor_PDF.AddProjects($@"{_datadir}\{r.FileName}", r.Text);
                }
            }
            catch(Exception ex)
            {
                PrintInfo(ex);
            }
        }
        private static void PrintInfo(string dir, List<string>files)
        {
            Console.WriteLine($"In directory : {dir} \t [{files.Count}] *.pdf files was found.");
            foreach (string file in files)
                Console.WriteLine(file);
        }
        private static void PrintInfo(Exception ex)
        {
            Console.WriteLine($"{ex.Message} | source of the bug: {ex.Source}");
        }
    }
}
