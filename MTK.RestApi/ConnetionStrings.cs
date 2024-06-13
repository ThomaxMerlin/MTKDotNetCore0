using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNet.RestApi;
internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "DESKTOP-4LL7LAJ",
        InitialCatalog = "DotNetTrainingBatch4",
        // InitialCatalog = "TestDb",
        UserID = "sa",
        Password = "sasa@123",
        TrustServerCertificate = true
    };
}