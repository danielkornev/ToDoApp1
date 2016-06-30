using System.Collections.Generic;
using NReact;
using System.Windows.Controls;

namespace ToDoApp1
{
	public class TodoItem : NClass
	{
		private TodoListItem todoListItem;

		public TodoItem(TodoListItem todoListItem)
		{
			this.todoListItem = todoListItem;
		}

		public override NElement Render()
		{
			if (todoListItem.Editing)
			{
				return new NXaml<TextBox>(todoListItem).Text(todoListItem.Title);
			}
			return new NXaml<TextBlock>(todoListItem).Text(todoListItem.Title);
		}
	}
}