/*
 * Borrowed from https://github.com/FlightNode/FlightNode.Api under terms of the MIT License
 * Copyright (c) Stephen A. Fuqua, 2015, except as noted in individual files.
 */

using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;

namespace SRP.CustomReports.WPF.Migrations.Customization
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public static class MigrationExtensions
    {
        public static void CreateView(this DbMigration migration, string viewName, string viewQueryString)
        {

            ((IDbMigration)migration)
              .AddOperation(new CreateViewOperation(viewName,
                 viewQueryString));
        }

        public static void DropView(this DbMigration migration, string viewName)
        {
            ((IDbMigration) migration).AddOperation(new DropViewOperation(viewName));
        }
    }
}
