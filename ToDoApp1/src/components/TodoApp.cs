using NReact;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToDoApp1
{
	using static NFactory;

	public class TodoApp : NClass
	{
		public ImmutableList<TodoListDataItem> Items
		{
			get
			{
				return GetState(NFactory.Properties.Items, new List<TodoListDataItem>().ToImmutableList());
			}
			set
			{
				SetState(NFactory.Properties.Items, value);
			}
		}

		public override NElement Render()
		{
			return
			  new NXaml<StackPanel>().
                    HorizontalAlignment(HorizontalAlignment.Center).
					Children(
                            new TodoHeader(AddItem),
                            
							new TodoList(TodoListDataItem.Statuses.Active, Items)

							 );
		}

        private void AddItem(string Text)
        {
            // so we need to find the max index
            int idx = Items.Count;
            Items = Items.Add(new TodoListDataItem(idx, Text, TodoListDataItem.Statuses.Active));
        }
	}
}
