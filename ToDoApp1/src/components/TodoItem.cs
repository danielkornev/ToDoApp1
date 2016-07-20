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
                return
              new NXaml<StackPanel>().
                    HorizontalAlignment(HorizontalAlignment.Left).
                    Orientation(Orientation.Horizontal).
                    Children(
                            new NXaml<TextBox>(todoListItem).
                                    Text(todoListItem.Title).
                                    HorizontalAlignment(HorizontalAlignment.Left).
                                    KeyDown(OnKeyDown)
                             );
			}

		    if (todoListItem.Status == TodoListItem.Statuses.Completed)
		    {
                return
              new NXaml<StackPanel>().
                    HorizontalAlignment(HorizontalAlignment.Left).
                    Orientation(Orientation.Horizontal).
                    Children(
                            new NXaml<CheckBox>(todoListItem).
                                    IsChecked(this.IsCompleted(todoListItem)).
                                    HorizontalAlignment(HorizontalAlignment.Left).
                                    Margin(0, 0, 10, 0).
                                    Click(todoListItem.ToggleCompleteAction),

                            new NXaml<ContentControl>().Content(

                                    new NXaml<TextBlock>(todoListItem).
                                            Text(todoListItem.Title).
                                            TextDecorations(TextDecorations.Strikethrough).
                                            HorizontalAlignment(HorizontalAlignment.Left).
                                            Margin(0,0,10,0)
                                            
                                            ).MouseDoubleClick(todoListItem.EditAction),

                            new NXaml<Button>(todoListItem).
                                    Key("deleteTodoListItem").
                                    Content("X").
                                    Click(todoListItem.DeleteAction)
                             );
            }

            return
             new NXaml<StackPanel>().
                   HorizontalAlignment(HorizontalAlignment.Left).
                   Orientation(Orientation.Horizontal).
                   Children(
                           new NXaml<CheckBox>(todoListItem).
                                   HorizontalAlignment(HorizontalAlignment.Left).
                                   Margin(0, 0, 10, 0).
                                   Click(todoListItem.ToggleCompleteAction),

                           new NXaml<ContentControl>().Content(

                                    new NXaml<TextBlock>(todoListItem).
                                            Text(todoListItem.Title).
                                            TextDecorations(TextDecorations.Strikethrough).
                                            HorizontalAlignment(HorizontalAlignment.Left).
                                            Margin(0, 0, 10, 0)

                                            ).MouseDoubleClick(todoListItem.EditAction),

                           new NXaml<Button>(todoListItem).
                                    Key("deleteTodoListItem").
                                    Content("X").
                                    Click(todoListItem.DeleteAction)
                            );
        }

        private bool IsCompleted(TodoListItem todoListItem)
        {
            return todoListItem.Status == TodoListItem.Statuses.Completed;
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