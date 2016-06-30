using System.Collections.Generic;
using NReact;
using System.Windows.Controls;

namespace ToDoApp1
{
	internal class TodoItem : NClass
	{
		private TodoListItem todoListItem;

		public TodoItem(TodoListItem todoListItem)
		{
			this.todoListItem = todoListItem;
		}

		public override NElement Render()
		{
			return new NXaml<TextBlock>(todoListItem).Text(todoListItem.Title);
		}
	}
}