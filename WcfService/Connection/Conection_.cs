
namespace WcfService.Connection
{
    using System.Configuration;
    using System.Data.SqlClient;

    public class Connection_
    {
        #region singletom

        private static readonly Connection_ Instance;

        public static Connection_ GetInstance() =>
            Instance ?? new Connection_();

        #endregion

        public readonly SqlConnection SqlCon;
        public readonly SqlCommand SqlComd;
        public  SqlDataReader SqlDReader;

        private Connection_()
        {
            SqlCon = new SqlConnection()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaulConnection"].ConnectionString
            };

            SqlComd = new SqlCommand
            {
                Connection = SqlCon
            };
        }

    }
}