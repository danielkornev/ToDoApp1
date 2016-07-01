using System.Collections.Immutable;
using NReact;
using NUnit.Framework;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Moq;
using Redux;

namespace ToDoApp1.Tests
{
	[TestFixture, Apartment(ApartmentState.STA)]
	public class TodoItemTests
	{
		[Test, Description("renders an item")]
		public void RendersAnItem()
		{
			var todoitem = new TodoItem(new TodoListItem(0, "React", TodoListItem.Statuses.Active));

			var tb = todoitem.Render().RenderAsFrameworkElement() as TextBlock;

			Assert.AreEqual("React", tb?.Text);
		}

		[Test, Description("renders a text field for item being edited")]
		public void RendersItemBeingEdited()
		{
			var todoitem = new TodoItem(new TodoListItem(117, "Quandry", TodoListItem.Statuses.Active, true));
			var textBox = todoitem.Render().RenderAsFrameworkElement() as TextBox;
			Assert.AreEqual("Quandry", textBox?.Text);
		}

		[Test]
		public void EmitsEventWhenChangeSubmitted()
		{
			var itemsStoreMock = new Mock<IStore<ImmutableList<TodoListItem>>>();
			//itemsStoreMock.Setup(store => store.Dispatch(It.IsAny<IAction>()));

			App.ItemsStore = itemsStoreMock.Object;

			var todoitem = new TodoItem(new TodoListItem(117, "Quandry", TodoListItem.Statuses.Active, true));
			var textBox = todoitem.Render().RenderAsFrameworkElement() as TextBox;
			textBox.Text = "Zhuzhuzhu";
			textBox?.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, new Mock<PresentationSource>().Object, 0, Key.Enter) { RoutedEvent = TextBox.KeyDownEvent });

			itemsStoreMock.Verify(store => store.Dispatch(It.IsAny<IAction>()));
		}
	} // class
} // namespace
