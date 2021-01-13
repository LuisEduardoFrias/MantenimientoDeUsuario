
namespace WcfService.ServiceBase
{
    using System.Data;
    using System.Data.SqlClient;
    //
    using WcfService.Connection;
    //

    public class ServiceBase_
    {
        private Connection_ Con_;
        public SqlDataReader sqlDReader;

        public ServiceBase_()
        {
            Con_ = Connection_.GetInstance();

            this.sqlDReader = Con_.SqlDReader;
        }

        public SqlCommand GetStoreProc(string procedureName, SqlParameter[] sqlParameters = null)
        {
            Con_.SqlComd.CommandText = procedureName;
            Con_.SqlComd.CommandType = CommandType.StoredProcedure;

            if(sqlParameters != null)
                Con_.SqlComd.Parameters.AddRange(sqlParameters);

            return Con_.SqlComd;
        }

        public void OpenConnection()
        {
            Con_.SqlCon.Open();
        }

        public void CloseConnection()
        {
            Con_.SqlCon.Close();
        }

    }
}