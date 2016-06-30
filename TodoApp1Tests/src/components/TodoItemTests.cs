using NReact;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using ToDoApp1;

namespace TodoApp1Tests
{
	[TestFixture, Apartment(ApartmentState.STA)]
	public class TodoItemTests
	{
		[Test, Description("renders an item")]
		public void RendersAnItem()
		{
			var todoitem = new TodoItem(new TodoListItem(0, "React", TodoListItem.Statuses.Active));

			var component = todoitem.Render();

			var tb = component.RenderAsFrameworkElement() as TextBlock;

			Assert.AreEqual("React", tb?.Text);
		}
	} // class
} // namespace
