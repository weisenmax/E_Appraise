using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using E_Appraise.Models;

namespace E_Appraise.Controllers
{
    public class AppraiserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AppraiserController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("E_Appraise_DB");

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string 'E_Appraise_DB' is not set. Check your appsettings.json.");
            }

        }

        public IActionResult Index()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                // SQL query to select required fields
                var query = "SELECT DateFrom, DateTo, Name, Email FROM Appraisers";  // Ensure the table name matches your database
                var appraisers = db.Query<Appraiser>(query).ToList(); // Convert to a list
                return View(appraisers);
            }
        }
    }
}
