using System;
using System.Collections.Generic;
using System.Linq;
using NReact;
using System.Windows.Controls;

namespace ToDoApp1
{
	using static NFactory;

	public class TodoListItem
	{
		public enum Statuses
		{
			Active, Completed
		}

		public int Id { get; }
		public string Title { get; }
		public Statuses Status { get; }

		public TodoListItem(int id, string title, Statuses status)
		{
			Id = id;
			Title = title;
			Status = status;
		}
	}

	public class TodoList : NClass
	{

		public NList<TodoListItem> Items
		{
			get
			{
				return Get(NFactory.Properties.Items, new NList<TodoListItem>());
			}
			set
			{
				Set(NFactory.Properties.Items, value);
			}
		}

		/// <summary>
		/// Filters the items according to their status
		/// </summary>
		public NList<TodoListItem> GetItems()
		{
			if (this.Filter == null) return this.Items;
			else return this.Items.Where(i => i.Status == this.Filter).ToNList();
		}

		public TodoListItem.Statuses? Filter { get; private set; }

		public override NElement Render()
		{
			return new NXaml<StackPanel>().
						  Children(GetItems().Map((item, idx) => new TodoItem(item)));
		} 

		public TodoList(TodoListItem.Statuses? filter, NList<TodoListItem> items)
		{
			Items = items;
			Filter = filter;
		}
	}
}