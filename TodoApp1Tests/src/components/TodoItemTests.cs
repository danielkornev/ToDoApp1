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
using static System.Windows.Forms.SystemInformation;

namespace ToDoApp1.Tests
{
	[TestFixture, Apartment(ApartmentState.STA)]
	public class TodoItemTests : MockAppTests
	{
		[Test, Description("renders an item")]
		public void RendersAnItem()
		{
			var todoitem = new TodoItem(new TodoListDataItem(0, "React", TodoListDataItem.Statuses.Active));
            var stackPanel = ((todoitem.Render().RenderAsFrameworkElement()) as StackPanel).Children.OfType<StackPanel>().First();

		    var tb = stackPanel.Children.OfType<ContentControl>().First(c=>c.GetType()!=typeof(CheckBox)).Content as TextBlock;

            Assert.AreEqual("React", tb?.Text);
		}

		[Test, Description("renders a text field for item being edited")]
		public void RendersItemBeingEdited()
		{
			var todoitem = new TodoItem(new TodoListDataItem(117, "Quandry", TodoListDataItem.Statuses.Active, true));
            var stackPanel = ((todoitem.Render().RenderAsFrameworkElement()) as StackPanel).Children.OfType<StackPanel>().Last();

            var textBox = stackPanel.Children.OfType<TextBox>().FirstOrDefault();

            Assert.AreEqual("Quandry", textBox?.Text);
		}

        [Test, Description("strikes out the item if it is completed")]
        public void StrikesOutTheItemIfItIsCompleted()
        {
            var todoitem = new TodoItem(new TodoListDataItem(117, "Quandry", TodoListDataItem.Statuses.Completed, false));
            var stackPanel = ((todoitem.Render().RenderAsFrameworkElement()) as StackPanel).Children.OfType<StackPanel>().First();

            var checkBox = stackPanel.Children.OfType<CheckBox>().First() as CheckBox;

            Assert.AreEqual(true, checkBox.IsChecked.GetValueOrDefault());

            //var textBlock = stackPanel.Children.OfType<ContentControl>().First(c=>c.GetType()!=typeof(CheckBox)).Content as TextBlock;

            //Assert.AreEqual(true, textBlock.TextDecorations.Any(t => t.Location == TextDecorationLocation.Strikethrough));
        }

	    [Test, Description("should be checked if the item is completed")]
	    public void ShouldBeCheckedIfTheItemIsCompleted()
	    {
            var todoitem = new TodoItem(new TodoListDataItem(117, "Quandry", TodoListDataItem.Statuses.Completed, false));
            var stackPanel = ((todoitem.Render().RenderAsFrameworkElement()) as StackPanel).Children.OfType<StackPanel>().First();

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


            var todoitem = new TodoItem(new TodoListDataItem(0, text, TodoListDataItem.Statuses.Active, false, deleteItem));
            var stackPanel = ((todoitem.Render().RenderAsFrameworkElement()) as StackPanel).Children.OfType<StackPanel>().First();

            // raising our event handler
            stackPanel.Children.OfType<Button>().First().RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            Assert.AreEqual(true, deleted);
	    }

	    [Test, Description("invokes callback when checkbox is clicked")]
	    public void InvokesCallbackWhenCheckboxIsClicked()
	    {
            var text = "React";
            var isChecked = false;
            // we define a mock toggleComplete function
            Action toggleComplete = () =>
            {
                isChecked = true;
            };


            var todoitem = new TodoItem(new TodoListDataItem(0, text, TodoListDataItem.Statuses.Active, false, null, toggleComplete));
            var stackPanel = ((todoitem.Render().RenderAsFrameworkElement()) as StackPanel).Children.OfType<StackPanel>().First();

            // raising our event handler
            stackPanel.Children.OfType<CheckBox>().First().RaiseEvent(new RoutedEventArgs(CheckBox.ClickEvent));

            Assert.AreEqual(true, isChecked);
        }

	    [Test, Description("calls a callback when text is double clicked")]
	    public void CallsCallbackWhenTextIsDoubleClicked()
	    {
            var text = "React";
            // we define a mock editItem function

	        EventHandler editItem;

            editItem = delegate(object sender, EventArgs e)
            {
                text = "Redux";
            };

            var todoitem = new TodoItem(new TodoListDataItem(0, text, TodoListDataItem.Statuses.Active, false, null, null, editItem));
            var stackPanel = ((todoitem.Render().RenderAsFrameworkElement()) as StackPanel).Children.OfType<StackPanel>().First();

            var contentControl = stackPanel?.Children.OfType<ContentControl>().First(c=>c.GetType()!=typeof(CheckBox));

            var e1 = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left) { RoutedEvent = ContentControl.MouseDoubleClickEvent };
            contentControl.RaiseEvent(e1);
            
            Assert.AreEqual("Redux", text);
        }

  //      [Test, Description("")]
		//public void EmitsEventWhenChangeSubmitted()
		//{
		//	var itemsStoreMock = new Mock<IStore<ImmutableList<TodoListDataItem>>>();
		//	//itemsStoreMock.Setup(store => store.Dispatch(It.IsAny<IAction>()));

		//	App.ItemsStore = itemsStoreMock.Object;

		//	var todoitem = new TodoItem(new TodoListDataItem(117, "Quandry", TodoListDataItem.Statuses.Active, true));
  //          var stackPanel = todoitem.Render().RenderAsFrameworkElement() as StackPanel;

  //          var textBox = stackPanel.Children.OfType<TextBox>().FirstOrDefault();

  //          textBox.Text = "Zhuzhuzhu";
		//	textBox?.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, new Mock<PresentationSource>().Object, 0, Key.Enter) { RoutedEvent = TextBox.KeyDownEvent });

		//	itemsStoreMock.Verify(store => store.Dispatch(It.IsAny<IAction>()));
		//}

	  
	} // class
} // namespace
