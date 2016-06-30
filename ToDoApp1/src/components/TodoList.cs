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
		public bool Editing { get; }

		public TodoListItem(int id, string title, Statuses status, bool editing = false)
		{
			Id = id;
			Title = title;
			Status = status;
			Editing = editing;
		}
	}

	public class TodoList : NClass
	{

		public IList<TodoListItem> Items
		{
			get
			{
				return Get<IList<TodoListItem>>(NFactory.Properties.Items, new List<TodoListItem>());
			}
			set
			{
				Set(NFactory.Properties.Items, value);
			}
		}

		/// <summary>
		/// Filters the items according to their status
		/// </summary>
		public IList<TodoListItem> GetItems()
		{
			if (this.Filter == null) return this.Items;
			else return this.Items.Where(i => i.Status == this.Filter).ToList();
		}

		public TodoListItem.Statuses? Filter { get; private set; }

		public override NElement Render()
		{
			return new NXaml<StackPanel>().
						  Children(GetItems().Select((item, idx) => new TodoItem(item)));
		} 

		public TodoList(TodoListItem.Statuses? filter, IList<TodoListItem> items)
		{
			Items = items;
			Filter = filter;
		}
	}
}