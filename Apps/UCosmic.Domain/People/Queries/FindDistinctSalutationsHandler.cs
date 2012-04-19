﻿using System;
using System.Linq;

namespace UCosmic.Domain.People
{
    public class FindDistinctSalutationsHandler : IHandleQueries<FindDistinctSalutationsQuery, string[]>
    {
        private readonly IQueryEntities _entities;

        public FindDistinctSalutationsHandler(IQueryEntities entities)
        {
            _entities = entities;
        }

        public string[] Handle(FindDistinctSalutationsQuery query)
        {
            if (query == null) throw new ArgumentNullException("query");

            var results = _entities.People
                .WithNonEmptySalutation()
                .SelectSalutations()
                .Distinct()
            ;

            if (query.Exclude != null && query.Exclude.Length > 0)
                results = results.Where(s => !query.Exclude.Contains(s));

            return results.ToArray();
        }
    }
}
