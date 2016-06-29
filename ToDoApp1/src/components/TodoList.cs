using System.Collections.Generic;
using NReact;
using System.Windows.Controls;

namespace ToDoApp1
{
	using static NFactory;

	class TodoList : NClass
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

		public override NElement Render()
		{
			return new NXaml<StackPanel>().
						  Children(Items.Map((i, idx) => new TodoItem(i)));
		} 

		public TodoList()
		{
			Items = new List<Dictionary<string, string>>();
		}
	}
}