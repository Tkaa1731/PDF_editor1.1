using System.Data.SqlClient;
namespace PDF_editor
{
        public static class DBConnector
        {
            public static SqlConnectionStringBuilder GetBuilder()
            {
            SqlConnectionStringBuilder builder = new()
            {
                DataSource = @"pobytne.cz,3341",
                UserID = "UserSmenovnice",
                Password = "SmEIcE654",
                InitialCatalog = "Smenovnice"
            };
            //TODO: Doplnit pripojeni k DB
            return builder;
            }
        }
}

