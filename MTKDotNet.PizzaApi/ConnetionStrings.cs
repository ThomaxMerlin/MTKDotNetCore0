using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNet.PizzaApi;
internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "DESKTOP-4LL7LAJ",
        InitialCatalog = "DotNetTrainingBatch4",
        // InitialCatalog = "TestDb",
        UserID = "sa",
        Password = "sa@123",
        TrustServerCertificate = true
    };
}