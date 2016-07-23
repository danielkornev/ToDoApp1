using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Moq;
using NReact;
using NUnit.Framework;

namespace ToDoApp1.Tests
{
	[TestFixture]
	[Apartment(ApartmentState.STA)]
	public class TodoAppTests : MockAppTests
	{
		[Test, Description("It should allow adding an additional Todo item")]
		public void AllowAddingTodoItems()
		{
			var app = new TodoApp();
            
			var rendered = app.Render().RenderAsFrameworkElement() as StackPanel;

            var textBox = rendered.FindChild<TextBox>((elem) => true);
            textBox.Text = "Item007";

            textBox?.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, new Mock<PresentationSource>().Object, 0, Key.Enter) { RoutedEvent = TextBox.KeyDownEvent });


            //rendered.FindChild<Button>((elem) => elem.Content.ToString().StartsWith("Add")).RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

            Assert.AreEqual(1, app.Items.Count);
			Assert.AreEqual("Item007", app.Items.First().Title);
		}
	}
}