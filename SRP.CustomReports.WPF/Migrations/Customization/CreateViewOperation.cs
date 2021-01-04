/*
 * Adapted from https://github.com/FlightNode/FlightNode.Api under terms of the MIT License
 * Copyright (c) Stephen A. Fuqua, 2015, except as noted in individual files.
 */

using System;
using System.Data.Entity.Migrations.Model;

namespace SRP.CustomReports.WPF.Migrations.Customization
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class CreateViewOperation : MigrationOperation
    {
        public CreateViewOperation(string viewName, string viewDefinition)
            : base(null)
        {
            ViewName = viewName ?? throw new ArgumentNullException(nameof(viewName));
            ViewDefinition = viewDefinition ?? throw new ArgumentNullException(nameof(viewDefinition));
        }
        
        public string ViewName { get; }
        
        public string ViewDefinition { get; }

        public override bool IsDestructiveChange => false;
    }
}
