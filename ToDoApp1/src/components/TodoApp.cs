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
		protected string Text
		{
			get
			{
				return GetState(NFactory.Properties.Text, "");
			}
			set
			{
				SetState(NFactory.Properties.Text, value);
			}
		}

		public ImmutableList<TodoListItem> Items
		{
			get
			{
				return GetState(NFactory.Properties.Items, new List<TodoListItem>().ToImmutableList());
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
					Children(new NXaml<TextBlock>().
									Text("TODO").
									FontSize(24).
									HorizontalAlignment(HorizontalAlignment.Center),

							new NXaml<StackPanel>().
									Orientation(Orientation.Horizontal).
									Children(new NXaml<TextBox>().
													Key("addItemTextBox").
													Text(Text).
													TextChanged(OnChange).
													KeyDown(OnKeyDown).
													Width(200),

											 new NXaml<Button>().
													Key("addItemButton").
													Content("Add #" + (Items.Count + 1)).
													Click(OnAdd)),

							 new TodoList(TodoListItem.Statuses.Active, Items)

							 );
		}

		protected override void InitState()
		{
			Items = new List<TodoListItem>
			{
				new TodoListItem(1, "React", TodoListItem.Statuses.Active),
				new TodoListItem(2, "Redux", TodoListItem.Statuses.Active),
				new TodoListItem(3, "Immutable", TodoListItem.Statuses.Completed)
			}.ToImmutableList();

			Text = "";
		}

		void OnChange(object sender)
		{
			Text = ((TextBox)sender).Text;
		}

		void OnAdd(object sender, EventArgs args)
		{
			AddItem();
		}

		void AddItem()
		{
			// so we need to find the max index
			int idx = Items.Count;
			Items = Items.Add(new TodoListItem(idx, Text, TodoListItem.Statuses.Active));
			Text = "";
		}

		private void OnKeyDown(object sender, EventArgs e)
		{
			var args = e as KeyEventArgs;

			if (args?.Key == System.Windows.Input.Key.Enter)
			{
				AddItem();
			}
		}
	}
}
