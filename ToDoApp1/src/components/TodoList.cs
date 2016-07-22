using System.Collections.Generic;
using System.Linq;
using NReact;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToDoApp1
{
	using static NFactory;

	

	public class TodoList : NClass
	{

		public IList<TodoListDataItem> Items
		{
			get
			{
				return Get<IList<TodoListDataItem>>(NFactory.Properties.Items, new List<TodoListDataItem>());
			}
			set
			{
				Set(NFactory.Properties.Items, value);
			}
		}

		/// <summary>
		/// Filters the items according to their status
		/// </summary>
		public IList<TodoListDataItem> GetItems()
		{
			if (this.Filter == null) return this.Items;
			else return this.Items.Where(i => i.Status == this.Filter).ToList();
		}

		public TodoListDataItem.Statuses? Filter { get; private set; }

		public override NElement Render()
		{
			return new NXaml<StackPanel>().
						  Children(GetItems().Select((item, idx) => new TodoItem(item)));
		} 

		public TodoList(TodoListDataItem.Statuses? filter, IList<TodoListDataItem> items)
		{
			Items = items;
			Filter = filter;
		}
	}
}