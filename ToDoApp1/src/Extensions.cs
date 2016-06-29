using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp1
{
	static class Extensions
	{
		public static string[] Concat(this string[] source, string element)
		{
			return source.Concat(new[] { element }).ToArray();
		}

		public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector) => source.Select(selector);
	}
}
