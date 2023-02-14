using Microsoft.AspNetCore.Hosting;
using System.Collections;
using System.Data;

namespace AAI.Repository
{
    public class Utility
    {
        private static int Pkey;  //Key for Hashtable//
        public static Hashtable theParams = new Hashtable();
        private static IHostingEnvironment _env;
        public Utility(IHostingEnvironment env)
        {
            _env = env;
        }
        public enum ObjectEnum
        {
            DataSet, DataTable, DataRow, ExecuteNonQuery
        }
        public static void Init_Hashtable()
        {
            theParams.Clear();
            Pkey = 0;
        }
        public static void AddParameters(string FieldName, SqlDbType FieldType, string FieldValue)
        {
            Pkey = Pkey + 1;
            theParams.Add(Pkey, FieldName);
            Pkey = Pkey + 1;
            theParams.Add(Pkey, FieldType);
            Pkey = Pkey + 1;
            theParams.Add(Pkey, FieldValue);
        }
        public static void AddParameters(string FieldName, SqlDbType FieldType, DataTable FieldValue)
        {
            Pkey = Pkey + 1;
            theParams.Add(Pkey, FieldName);
            Pkey = Pkey + 1;
            theParams.Add(Pkey, FieldType);
            Pkey = Pkey + 1;
            theParams.Add(Pkey, FieldValue);
        }
        public static void AddParameters(string FieldName, SqlDbType FieldType, int FieldValue)
        {
            Pkey = Pkey + 1;
            theParams.Add(Pkey, FieldName);
            Pkey = Pkey + 1;
            theParams.Add(Pkey, FieldType);
            Pkey = Pkey + 1;
            theParams.Add(Pkey, FieldValue);
        }

    }
}
