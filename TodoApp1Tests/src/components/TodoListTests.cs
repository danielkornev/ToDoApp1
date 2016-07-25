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
	public class TodoListTests : MockAppTests
	{
		List<TodoListDataItem> _todos;

		[SetUp]
		public void Init()
		{
			_todos = new List<TodoListDataItem>
			{
				new TodoListDataItem(1, "React", TodoListDataItem.Statuses.Active),
				new TodoListDataItem(1, "Redux", TodoListDataItem.Statuses.Active),
				new TodoListDataItem(1, "Immutable", TodoListDataItem.Statuses.Completed)
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
			TodoListDataItem.Statuses filter = TodoListDataItem.Statuses.Active;

			var todolist = new TodoList(filter, _todos);

			var component = todolist.Render();

            var sp = (component.RenderAsFrameworkElement() as Border).Child as StackPanel;


            Assert.AreEqual(2, sp.Children.Count);
			Assert.AreEqual("React", ((((sp.Children[0] as StackPanel).Children[0] as StackPanel).Children[1] as ContentControl).Content as TextBlock)?.Text);
			Assert.AreEqual("Redux", ((((sp.Children[1] as StackPanel).Children[0] as StackPanel).Children[1] as ContentControl).Content as TextBlock)?.Text);
		}

        [Test, Description("supports 'completed' filter")]
        public void RendersOnlyOneWhenCompletedFilterIsPassed()
        {
            const TodoListDataItem.Statuses filter = TodoListDataItem.Statuses.Completed;
            var todolist = new TodoList(filter, _todos);
            var panel = (todolist.Render().RenderAsFrameworkElement() as Border).Child as StackPanel;
            Assert.AreEqual(1, panel?.Children?.Count);

            var txt =
            ((panel.Children.OfType<StackPanel>()
                .First()
                .Children.OfType<StackPanel>()
                .First()
                .Children.OfType<ContentControl>()
                .First(c => c.GetType() != typeof(CheckBox))).Content as TextBlock).Text;

            Assert.AreEqual("Immutable", txt);
        }

        [Test, Description("supports 'all' filter")]
		public void RendersAllWhenAllFilterIsPassed()
		{
			var todolist = new TodoList(null, _todos);
			var panel = (todolist.Render().RenderAsFrameworkElement() as Border).Child as StackPanel;
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
                Select((elem, i) => (elem.Children.OfType<StackPanel>().First().Children.OfType<ContentControl>().First(c=>c.GetType()!=typeof(CheckBox)).Content as TextBlock).Text)
                     );
        }

		

	} // class
} // namespace