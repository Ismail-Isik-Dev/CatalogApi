using System.Linq.Expressions;

namespace Catalog.Application.Utilities
{
    public static class SearchPredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expOne,
                                                             Expression<Func<T, bool>> expTwo)
        {
            var invokedExpr = Expression.Invoke(expTwo, expOne.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expOne.Body, invokedExpr), expOne.Parameters);
        }
    }
}
