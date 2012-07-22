﻿using System;
using System.Collections.Generic;
using System.Linq;
using UCosmic.Domain;

namespace UCosmic
{
    public static class RevisableEntityQueries
    {
        public static TRevisableEntity By<TRevisableEntity>(this IEnumerable<TRevisableEntity> enumerable, Guid entityId)
            where TRevisableEntity : RevisableEntity
        {
            return enumerable.AsQueryable().By(entityId);
        }

        public static TRevisableEntity By<TRevisableEntity>(this IEnumerable<TRevisableEntity> enumerable, int revisionId)
            where TRevisableEntity : RevisableEntity
        {
            return enumerable.AsQueryable().By(revisionId);
        }

        internal static TRevisableEntity By<TRevisableEntity>(this IQueryable<TRevisableEntity> queryable, Guid entityId)
            where TRevisableEntity : RevisableEntity
        {
            if (entityId == Guid.Empty)
                throw new InvalidOperationException(string.Format("EntityId Guid is empty ({0}).", Guid.Empty));
            return queryable.SingleOrDefault(e => e.EntityId == entityId);
        }

        internal static TRevisableEntity By<TRevisableEntity>(this IQueryable<TRevisableEntity> queryable, int revisionId)
            where TRevisableEntity : RevisableEntity
        {
            return queryable.SingleOrDefault(e => e.RevisionId == revisionId);
        }

        internal static IQueryable<TRevisableEntity> Exclude<TRevisableEntity>(this IQueryable<TRevisableEntity> queryable, IEnumerable<Guid> entityIds)
            where TRevisableEntity : RevisableEntity
        {
            if (entityIds != null)
                queryable = queryable.Where(e => !entityIds.Contains(e.EntityId));
            return queryable;
        }
    }
}
