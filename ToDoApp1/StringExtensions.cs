using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp1
{
	static class StringExtensions
	{
		public static string[] Concat(this string[] source, string element)
		{
			return source.Concat(new[] { element }).ToArray();
		}
	}
}
