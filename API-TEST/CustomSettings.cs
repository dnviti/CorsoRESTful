namespace API_TEST
{
    public class CustomSettings
    {
        public string LocalDBConnectionString { get; set; }
        public string DefaultDatabase { get; set; }
        public AvailableDatabasesSetting AvailableDatabases { get; set; }
    }

    public class AvailableDatabasesSetting
    {
        public SQLSever SQLSever { get; set; }
        public SQLServerLocal SQLServerLocal { get; set; }
        public MySQL MySQL { get; set; }
        public MariaDB MariaDB { get; set; }
        public PostgreSQL PostgreSQL { get; set; }
        public Oracle Oracle { get; set; }
    }

    public class BaseConnectionString
    {
        public string Code { get; set; }
        public string ConnectionString { get; set; }
    }

    public class SQLSever : BaseConnectionString
    {
    }

    public class SQLServerLocal : BaseConnectionString
    {
    }

    public class MySQL : BaseConnectionString
    {
    }

    public class MariaDB : BaseConnectionString
    {
    }

    public class PostgreSQL : BaseConnectionString
    {
    }

    public class Oracle : BaseConnectionString
    {
    }
}