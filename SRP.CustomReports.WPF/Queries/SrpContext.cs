using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using SRP.CustomReports.WPF.Entities;

namespace SRP.CustomReports.WPF.Queries
{
    public class SrpContext : DbContext
    {
        private static string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Properties.Settings.Default.PathToSrp))
                {
                    Properties.Settings.Default.PathToSrp =
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SRP");
                }

                var srpMdf = Path.Combine(Properties.Settings.Default.PathToSrp, "SRP.mdf");
                return $"Data Source=(localdb)\\SRP;Initial Catalog={srpMdf};Integrated Security=SSPI";
            }
        }

        public DbSet<Cluster> Clusters { get; set; }

        public DbSet<Grouping> Groupings { get; set; }

        public DbSet<ClusterGrouping> ClusterGroupings { get; set; }

        public DbSet<YouthContinuum> YouthOnContinuum { get; set; }

        public SrpContext() : base(ConnectionString)
        {
        }


        /// <summary>
        /// Executes the given DDL/DML command against the database.
        /// 
        /// As with any API that accepts SQL it is important to parameterize any user input to protect against a SQL injection attack. You can include parameter place holders in the SQL query string and then supply parameter values as additional arguments. Any parameter values you supply will automatically be converted to a DbParameter.
        /// context.Database.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor);
        /// Alternatively, you can also construct a DbParameter and supply it to SqlQuery. This allows you to use named parameters in the SQL query string.
        /// context.Database.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <remarks>
        /// If there isn't an existing local or ambient transaction a new transaction will be used
        /// to execute the command.
        /// </remarks>
        /// <param name="sql"> The command string. </param>
        /// <param name="parameters"> The parameters to apply to the command string. </param>
        /// <returns> The result returned by the database after executing the command. </returns>
        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sql, parameters);
        }

        /// <summary>
        /// Creates a raw SQL query that will return elements of the given generic type.
        /// The type can be any type that has properties that match the names of the columns returned
        /// from the query, or can be a simple primitive type.  The type does not have to be an
        /// entity type. The results of this query are never tracked by the context even if the
        /// type of object returned is an entity type.  Use the <see cref="M:System.Data.Entity.DbSet`1.SqlQuery(System.String,System.Object[])" />
        /// method to return entities that are tracked by the context.
        /// 
        /// As with any API that accepts SQL it is important to parameterize any user input to protect against a SQL injection attack. You can include parameter place holders in the SQL query string and then supply parameter values as additional arguments. Any parameter values you supply will automatically be converted to a DbParameter.
        /// context.Database.SqlQuery&lt;Post&gt;("SELECT * FROM dbo.Posts WHERE Author = @p0", userSuppliedAuthor);
        /// Alternatively, you can also construct a DbParameter and supply it to SqlQuery. This allows you to use named parameters in the SQL query string.
        /// context.Database.SqlQuery&lt;Post&gt;("SELECT * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <typeparam name="TElement"> The type of object returned by the query. </typeparam>
        /// <param name="sql"> The SQL query string. </param>
        /// <param name="parameters">
        /// The parameters to apply to the SQL query string. If output parameters are used, their values will
        /// not be available until the results have been read completely. This is due to the underlying behavior
        /// of DbDataReader, see http://go.microsoft.com/fwlink/?LinkID=398589 for more details.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.Data.Entity.Infrastructure.DbRawSqlQuery`1" /> object that will execute the query when it is enumerated.
        /// </returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            var query = Database.SqlQuery<TElement>(sql, parameters);
            return query.ToList();
        }

        public DbContextTransaction BeginTransaction()
        {
            return Database.BeginTransaction();
        }
    }
}
