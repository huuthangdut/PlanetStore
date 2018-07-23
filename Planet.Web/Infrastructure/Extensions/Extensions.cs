using System;
using System.Linq.Expressions;
using AutoMapper;

namespace Planet.Web.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreMember<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> map, Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }
    }
}