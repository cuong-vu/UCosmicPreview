﻿using System;
using System.Linq;

namespace UCosmic.Domain.Email
{
    internal static class EmailTemplateQueries
    {
        internal static EmailTemplate ByName(this IQueryable<EmailTemplate> queryable, string name, int? establishmentId)
        {
            return establishmentId.HasValue
                ? queryable.SingleOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && t.EstablishmentId == establishmentId.Value)
                : queryable.SingleOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && t.EstablishmentId == null);
        }
    }
}
