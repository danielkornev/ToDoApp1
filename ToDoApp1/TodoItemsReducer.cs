using System.Collections.Generic;
using System.Collections.Immutable;
using Redux;

namespace ToDoApp1
{
	public static class TodoItemsReducer
	{
		public static ImmutableList<TodoListItem> Execute(ImmutableList<TodoListItem> previousstate, IAction action)
		{
			return previousstate;
		}
	}
}