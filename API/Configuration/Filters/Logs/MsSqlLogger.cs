using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace API.Configuration.Filters.Logs
{

    public class MsSqlLogger
    {
        public ILogger LoggerManager;
        public MsSqlLogger(IConfiguration configuration)
        {
            // Ms Seril log oluşturduk.
            var sinkOpt = new MSSqlServerSinkOptions()
            {
                TableName = "Logs",  // log kayıtlarını tutacak tablonun adı
                AutoCreateSqlTable = true  // Tablo yoksa otomatik olarak oluşturacaktır
            };

            var columnOpts = new ColumnOptions();
            columnOpts.Store.Remove(StandardColumn.Message);
            columnOpts.Store.Remove(StandardColumn.Properties);

            var seriLogConf = new LoggerConfiguration().WriteTo
                .MSSqlServer(
                    connectionString: configuration.GetConnectionString("MsComm"),
                    sinkOptions: sinkOpt,
                    columnOptions: columnOpts); //builder deseni

            // Bu ms serilogu da dışarı da kullanabilmek için Loggermanager interface atadık.
            LoggerManager = seriLogConf.CreateLogger(); 
        }
    }
}
