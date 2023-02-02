
using System.Data;
using System.Data.SqlClient;

namespace PDF_editor
{
    public class PDFrecord
    {
        public string FileName { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public List<string> Text { get; set; }
        public PDFrecord(string PDFname)
        {
            try
            {
                FileName = PDFname;
                string[] separate = PDFname.Split('_');
                Name = separate[0];
                ID = int.Parse(separate[1]);
                Month = int.Parse(separate[2]);
                Year = int.Parse(separate[3].Remove(separate[3].Length - 4)); // remove .pdf from string
            }
            catch
            {
                throw new Exception("Exeption 1 : The format of PDF file does not match the pattern name_id_m_y.pdf") { Source = "PDFrecord" };
            }
        }
        public bool GetText()
        {
            var query = $"SELECT * FROM esm_zakladniudaje WHERE sapid = 1";
            var result = new DataTable();
            var connString = DBConnector.GetBuilder().ConnectionString;

            using (SqlConnection connection = new(connString))
            {
                connection.Open();
                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            return true;
        }

    }
}
