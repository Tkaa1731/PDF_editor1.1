using Aspose.Pdf.Text;

namespace Aspose.Pdf.Examples
{
    public static class Editor_PDF
    {
        private static readonly Position _position= new(35,410); // position where the text is added
        public static void AddProjects(string file, List<string> project)
        {
            Position position = new Position(_position.XIndent,_position.YIndent);
            foreach (var p in project)
            {
                WriteProject(file, p, position);
                position.YIndent -= 15;
            }

        }
        private static void WriteProject(string file, string project, Position position)
        {
            try
            {
                Document document = new(file);

                Page page = document.Pages[1];

                TextBuilder textBuilder = new(page);
                TextParagraph paragraph = new();
                TextFragment textFragment = new()
                {
                    Text = project
                };
                textFragment.TextState.Font = FontRepository.FindFont("Times New Roman");
                textFragment.TextState.FontSize = 11;
                paragraph.AppendLine(textFragment);
                paragraph.Position = position;

                textBuilder.AppendParagraph(paragraph);

                document.Save(file);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}

