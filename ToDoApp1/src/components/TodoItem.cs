using System.Collections.Generic;
using NReact;
using System.Windows.Controls;

namespace ToDoApp1
{
	internal class TodoItem : NClass
	{
		private Dictionary<string, string> props;

		public TodoItem(Dictionary<string,string> props)
		{
			this.props = props;
		}

		public override NElement Render()
		{
			return new NXaml<TextBlock>(props).Text(props["text"]);
		}
	}
}