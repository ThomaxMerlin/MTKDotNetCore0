using System.Data.SqlClient;

namespace DotNetTrainingBatch4.ConsoleApp.Services
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-4LL7LAJ",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };
    }
}