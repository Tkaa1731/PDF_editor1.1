using Aspose.Pdf.LogicalStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_editor
{
    internal class LoadPDF
    {
        private string FolderPath { get; set; } // path to the directory Directory.Exist()
        private string[] PDFfiles { get; set; }
        public LoadPDF(string folderPath)
        {
            if (Directory.Exists(folderPath))// check if the path to the dir is exist
                FolderPath = folderPath;
            else
                throw new Exception("Exeption 0 : The path to the dir is not valid.") { Source = "LoadPDF"};
        }
        public List<string> GetAllPDF()
        {
            List<string> result = new();
            PDFfiles = Directory.GetFiles(FolderPath,"*.pdf"); // get name all file as string by pattern *.pdf including their path
            foreach(string file in PDFfiles)
            {
                result.Add(file.Remove(0,FolderPath.Length+1));
            }
            return result;
        }

    }
}
