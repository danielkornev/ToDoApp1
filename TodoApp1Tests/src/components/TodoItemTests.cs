using System.Collections.Immutable;
using System.Linq;
using System;
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

            var stackPanel = todoitem.Render().RenderAsFrameworkElement() as StackPanel;

            var tb = stackPanel.Children.OfType<TextBlock>().FirstOrDefault();

			Assert.AreEqual("React", tb?.Text);
		}

		[Test, Description("renders a text field for item being edited")]
		public void RendersItemBeingEdited()
		{
			var todoitem = new TodoItem(new TodoListItem(117, "Quandry", TodoListItem.Statuses.Active, true));
            var stackPanel = todoitem.Render().RenderAsFrameworkElement() as StackPanel;
            var textBox = stackPanel.Children.OfType<TextBox>().FirstOrDefault();
			Assert.AreEqual("Quandry", textBox?.Text);
		}

        [Test, Description("strikes out the item if it is completed")]
        public void StrikesOutTheItemIfItIsCompleted()
        {
            var todoitem = new TodoItem(new TodoListItem(117, "Quandry", TodoListItem.Statuses.Completed, false));

            var stackPanel = todoitem.Render().RenderAsFrameworkElement() as StackPanel;
            var textBlock = stackPanel.Children.OfType<TextBlock>().FirstOrDefault();
            Assert.AreEqual(true, textBlock.TextDecorations.Any(t => t.Location == TextDecorationLocation.Strikethrough));
        }

	    [Test, Description("should be checked if the item is completed")]
	    public void ShouldBeCheckedIfTheItemIsCompleted()
	    {
            var todoitem = new TodoItem(new TodoListItem(117, "Quandry", TodoListItem.Statuses.Completed, false));
            var stackPanel = todoitem.Render().RenderAsFrameworkElement() as StackPanel;

	        var checkBox = stackPanel.Children.OfType<CheckBox>().FirstOrDefault();
            Assert.AreEqual(true, checkBox.IsChecked.GetValueOrDefault());
        }

	    [Test, Description("invokes callback when the delete button is clicked")]
        public void InvokesCallbackWhenTheDeleteButtonIsClicked()
	    {
	        var text = "React";
	        var deleted = false;
            // we define a mock deleteItem function
	        Action deleteItem = () =>
	        {
	            deleted = true;
	        };


            var todoitem = new TodoItem(new TodoListItem(0, text, TodoListItem.Statuses.Active, false, deleteItem));

            var stackPanel = todoitem.Render().RenderAsFrameworkElement() as StackPanel;

            // raising our event handler
	        stackPanel.Children.OfType<Button>().First().RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            Assert.AreEqual(true, deleted);
	    }

        [Test, Description("")]
		public void EmitsEventWhenChangeSubmitted()
		{
			var itemsStoreMock = new Mock<IStore<ImmutableList<TodoListItem>>>();
			//itemsStoreMock.Setup(store => store.Dispatch(It.IsAny<IAction>()));

			App.ItemsStore = itemsStoreMock.Object;

			var todoitem = new TodoItem(new TodoListItem(117, "Quandry", TodoListItem.Statuses.Active, true));
            var stackPanel = todoitem.Render().RenderAsFrameworkElement() as StackPanel;

            var textBox = stackPanel.Children.OfType<TextBox>().FirstOrDefault();

            textBox.Text = "Zhuzhuzhu";
			textBox?.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, new Mock<PresentationSource>().Object, 0, Key.Enter) { RoutedEvent = TextBox.KeyDownEvent });

			itemsStoreMock.Verify(store => store.Dispatch(It.IsAny<IAction>()));
		}

	  
	} // class
} // namespace
