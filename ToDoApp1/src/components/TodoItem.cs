using NReact;
using System.Windows.Controls;

namespace ToDoApp1
{
	class TodoItem : NClass
	{
		private string i;

		public TodoItem(string i)
		{
			this.i = i;
		}

		public override NElement Render()
		{
			return new NXaml<TextBlock>(i).Text("*" + i);
		}
	}
}