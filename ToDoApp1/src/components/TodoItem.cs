using System;
using System.Collections.Generic;
using System.Windows;
using NReact;
using System.Windows.Controls;
using System.Windows.Input;

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
				return new NXaml<TextBox>(todoListItem).Text(todoListItem.Title).KeyDown(OnKeyDown);
			}

		    if (todoListItem.Status == TodoListItem.Statuses.Completed)
		    {
		        return new NXaml<TextBlock>(todoListItem).Text(todoListItem.Title).TextDecorations(TextDecorations.Strikethrough);
		    }
			return new NXaml<TextBlock>(todoListItem).Text(todoListItem.Title);
		}

		private void OnKeyDown(object sender, EventArgs e)
		{
			var args = e as KeyEventArgs;

			var tb = sender as TextBox;

			if (args?.Key == System.Windows.Input.Key.Enter)
			{
				App.ItemsStore.Dispatch(new TodoItemUpdateAction(todoListItem.Id, tb?.Text));
			}

		}
	}
}