using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using NReact;
using NUnit.Framework;
using ToDoApp1;

namespace TodoApp1Tests
{
	[TestFixture]
	[Apartment(System.Threading.ApartmentState.STA)]
	public class TodoListTest
	{
		List<Dictionary<string, string>> _todos;

		[SetUp]
		public void Init()
		{
			#region Todos
			_todos = new List<Dictionary<string, string>>
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
		}

		[TearDown]
		public void Dispose()
		{

		}

		[Test(Description = "renders a list with only the active items if the filter is active")]
		public void RendersAlistWithOnlyTheActiveItemsIfTheFilterIsActive()
		{

			// filter to use
			const string filter = "active";

			var todolist = new TodoList(filter, _todos);

			var component = todolist.Render();

			var sp = component.RenderAsFrameworkElement() as StackPanel;

			Assert.AreEqual(2, sp.Children.Count);
			Assert.AreEqual("React", (sp.Children[0] as TextBlock)?.Text);
			Assert.AreEqual("Redux", (sp.Children[1] as TextBlock)?.Text);
		}

		[Test(Description = "supports 'all' filter")]
		public void RendersAllWhenAllFilterIsPassed()
		{
			const string filter = "all";
			var todolist = new TodoList(filter, _todos);
			var panel = todolist.Render().RenderAsFrameworkElement() as StackPanel;
			Assert.AreEqual(3, panel?.Children?.Count);
			Assert.AreEqual(new [] { "React", "Redux", "Immutable" }, panel.Children.OfType<TextBlock>().Map((elem, i) => elem.Text));
		}

	} // class
} // namespace