using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContosEMS.Data.GraphQL
{
    public class CreateDatabaseCollationInterceptor : IDbCommandInterceptor
    {
        private readonly string _collation;

        public CreateDatabaseCollationInterceptor(string collation)
        {
            _collation = collation;
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext) { }
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            // Works for SQL Server
            if (Regex.IsMatch(command.CommandText, @"^create database \[.*]$"))
            {
                command.CommandText += " COLLATE " + _collation;
            }
        }
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) { }
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) { }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) { }
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext) { }
    }
}
