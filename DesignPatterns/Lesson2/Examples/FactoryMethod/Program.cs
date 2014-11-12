using System;
using System.Collections.Generic;

namespace Factory
{
    abstract class DbConnection
    {
        abstract public string ExecuteSQL(string sql);

        public int GetINt()
        {
            return 1;
        }
    }

    class Label
    {
        string Name;
        string Weight;
        string Article;
        //...
        public static Label OhotaBeerLabel()
        {
            return new Lable("Ohota", "0.5 kg", "mega beer");
        }
    }
    
    class MSSqlConnection : DbConnection
    {
        public override string ExecuteSQL(string sql) { return "Executed on mssql " + sql; }
    }

    class OracleConnection : DbConnection
    {
        public override string ExecuteSQL(string sql) { return "Executed on oracle: " + sql; }
    }

    abstract class ConnectionCreator
    {
        public abstract DbConnection CreateConnection();
    }

    class MsSlqlCreator : ConnectionCreator
    {
        public override DbConnection CreateConnection() { return new MSSqlConnection(); }
    }

    class OracleCreator : ConnectionCreator
    {
        public override DbConnection CreateConnection() { return new OracleConnection(); }
    }

    public class MainApp
    {
        public static void Main()
        {
            ConnectionCreator[] creators = { new MsSlqlCreator(),
                                             new OracleCreator() };
            foreach (ConnectionCreator creator in creators)
            {
                ExecuteSql(creator);
            }

            Console.Read();
        }

        private static void ExecuteSql(ConnectionCreator creator)
        {
            DbConnection product = creator.CreateConnection();
            Console.WriteLine(product.ExecuteSQL("DROP TABLE STUDENTS"));
        }
    }
}

