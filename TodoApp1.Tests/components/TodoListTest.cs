using NReact;
using NUnit.Framework;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ToDoApp1.tests
{
	using System;
	using System.Windows;
	using static NFactory;

	[TestFixture]
	[Apartment(System.Threading.ApartmentState.STA)]
	public class TodoListTest
	{
		[SetUp]
		public void Init()
		{
		}

		[TearDown]
		public void Dispose()
		{

		}

		[Test(Description = "renders a list with only the active items if the filter is active")]
		public void RendersAlistWithOnlyTheActiveItemsIfTheFilterIsActive()
		{
			#region Todos
			var todos = new List<Dictionary<string, string>>
			{
				new Dictionary<string, string>
				{
					["id"] = "1",
					["text"] = "React",
					["status"] = "active"
				},
				new Dictionary<string, string>
				{
					["id"] = "2",
					["text"] = "Redux",
					["status"] = "active"
				},
				new Dictionary<string, string>
				{
					["id"] = "3",
					["text"] = "Immutable",
					["status"] = "completed"
				}
			};
			#endregion

			// filter to use
			var filter = "active";

			var todolist = new TodoList(filter, todos);

			var component = todolist.Render();

			var sp = component.RenderAsFrameworkElement() as StackPanel;

			Assert.AreEqual(2, sp.Children.Count);
			Assert.AreEqual("React", (sp.Children[0] as TextBlock).Text);
			Assert.AreEqual("Redux", (sp.Children[1] as TextBlock).Text);
		}
	} // class
} // namespace