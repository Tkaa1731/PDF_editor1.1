using System.Data.SqlClient;
namespace PDF_editor
{
        public static class DBConnector
        {
            public static SqlConnectionStringBuilder GetBuilder()
            {
            SqlConnectionStringBuilder builder = new()
            {
                DataSource = @"", //TODO: doplnit udaje pro pripojeni
                UserID = "",
                Password = "",
                InitialCatalog = ""
            };
            return builder;
            }
        }
}

