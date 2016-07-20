using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Castle.Core.Internal;
using NReact;
using NUnit.Framework;
using ToDoApp1;

namespace ToDoApp1.Tests
{
	[TestFixture]
	[Apartment(System.Threading.ApartmentState.STA)]
	public class TodoListTests
	{
		List<TodoListItem> _todos;

		[SetUp]
		public void Init()
		{
			_todos = new List<TodoListItem>
			{
				new TodoListItem(1, "React", TodoListItem.Statuses.Active),
				new TodoListItem(1, "Redux", TodoListItem.Statuses.Active),
				new TodoListItem(1, "Immutable", TodoListItem.Statuses.Completed)
			};
		}

		[TearDown]
		public void Dispose()
		{

		}

		[Test, Description("renders a list with only the active items if the filter is active")]
		public void RendersAlistWithOnlyTheActiveItemsIfTheFilterIsActive()
		{

			// filter to use
			TodoListItem.Statuses filter = TodoListItem.Statuses.Active;

			var todolist = new TodoList(filter, _todos);

			var component = todolist.Render();

			var sp = component.RenderAsFrameworkElement() as StackPanel;

			Assert.AreEqual(2, sp.Children.Count);
			Assert.AreEqual("React", ((sp.Children[0] as StackPanel).Children[1] as TextBlock)?.Text);
			Assert.AreEqual("Redux", ((sp.Children[1] as StackPanel).Children[1] as TextBlock)?.Text);
		}

        [Test, Description("supports 'completed' filter")]
        public void RendersOnlyOneWhenCompletedFilterIsPassed()
        {
            const TodoListItem.Statuses filter = TodoListItem.Statuses.Completed;
            var todolist = new TodoList(filter, _todos);
            var panel = todolist.Render().RenderAsFrameworkElement() as StackPanel;
            Assert.AreEqual(1, panel?.Children?.Count);


            Assert.AreEqual(new[] { "Immutable" }, (panel?.Children?.OfType<StackPanel>().First()).Children.OfType<TextBlock>().Select((elem, i) => elem.Text));
        }

        [Test, Description("supports 'all' filter")]
		public void RendersAllWhenAllFilterIsPassed()
		{
			var todolist = new TodoList(null, _todos);
			var panel = todolist.Render().RenderAsFrameworkElement() as StackPanel;
			Assert.AreEqual(3, panel?.Children?.Count);

		    Assert.AreEqual(new[]
                     {
                         "React",
                         "Redux",
                         "Immutable"
                     },
                     panel?.
                Children?.
                OfType<StackPanel>().
                Select((elem, i) => elem.Children.OfType<TextBlock>().First().Text)
                     );
        }

		

	} // class
} // namespace