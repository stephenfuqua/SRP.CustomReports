/*
 * Borrowed from https://github.com/FlightNode/FlightNode.Api under terms of the MIT License
 * Copyright (c) Stephen A. Fuqua, 2015, except as noted in individual files.
 */

using System.Data.Entity.Migrations.Model;

namespace SRP.CustomReports.WPF.Migrations.Customization
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class DropViewOperation : MigrationOperation
    {
        public DropViewOperation(string viewName)
            : base(null)
        {
            ViewName = viewName;
        }

        public string ViewName { get; }


        public override bool IsDestructiveChange => false;
    }
}
