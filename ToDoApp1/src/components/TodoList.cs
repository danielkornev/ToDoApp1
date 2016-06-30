using System.Collections.Generic;
using System.Linq;
using NReact;
using System.Windows.Controls;

namespace ToDoApp1
{
	using static NFactory;

	internal class TodoList : NClass
	{
		public List<Dictionary<string,string>> Items
		{
			get
			{
				return Get(NFactory.Properties.Items, new List<Dictionary<string, string>>());
			}
			set
			{
				Set(NFactory.Properties.Items, value);
			}
		}

		/// <summary>
		/// Filters the items according to their status
		/// </summary>
		public List<Dictionary<string, string>> GetItems()
		{
			if (this.Filter == "all")
			{
				return this.Items;
			}
			return this.Items.Where(i => i["status"] == this.Filter).ToList(); 
		}

		public string Filter { get; private set; }

		public override NElement Render()
		{
			return new NXaml<StackPanel>().
						  Children(GetItems().Map((i, idx) => new TodoItem(i)));
		} 

		public TodoList(string filter, List<Dictionary<string,string>> items)
		{
			Items = items;
			Filter = filter;
		}
	}
}