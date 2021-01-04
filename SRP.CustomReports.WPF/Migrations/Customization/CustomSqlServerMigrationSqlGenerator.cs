/*
 * Borrowed from https://github.com/FlightNode/FlightNode.Api under terms of the MIT License
 * Copyright (c) Stephen A. Fuqua, 2015, except as noted in individual files.
 */

using System;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Utilities;
using System.Data.Entity.SqlServer;

namespace SRP.CustomReports.WPF.Migrations.Customization
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(MigrationOperation migrationOperation)
        {
            using (IndentedTextWriter writer = Writer())
            {
                writer.WriteLine(CreateSqlStatement(migrationOperation));
                Statement(writer);
            }
        }

        private string CreateSqlStatement(MigrationOperation migrationOperation)
        {
            if (migrationOperation is CreateViewOperation createViewOperation)
            {
                return $"CREATE VIEW {createViewOperation.ViewName} AS {createViewOperation.ViewDefinition} ; ";
            }

            if (migrationOperation is DropViewOperation dropViewOperation)
            {
                return $"DROP VIEW {dropViewOperation.ViewName};";
            }

            throw new InvalidOperationException("Invalid migration type: " + migrationOperation.GetType().FullName);
        }
    }
}
