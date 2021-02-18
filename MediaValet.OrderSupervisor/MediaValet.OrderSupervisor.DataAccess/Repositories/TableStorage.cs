using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediaValet.OrderSupervisor.DataAccess.Entities;
using MediaValet.OrderSupervisor.DataAccess.Helpers;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;

namespace MediaValet.OrderSupervisor.DataAccess.Repositories
{
    public class TableStorage<T> : ITableStorage<T> where T : TableEntity
    {
        private readonly CloudTable _storageTable;
        public TableStorage(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            var account = CloudStorageAccount.Parse(connectionString);
            var client = account.CreateCloudTableClient();

            var table = client.GetTableReference(typeof(T).GetCustomAttribute<LabelAttribute>()?.Label);
            table.CreateIfNotExists();

            _storageTable = table;
        }
    }
}
