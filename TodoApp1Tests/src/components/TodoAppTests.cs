using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using NReact;
using NUnit.Framework;

namespace ToDoApp1.Tests
{
	[TestFixture]
	[Apartment(ApartmentState.STA)]
	public class TodoAppTests
	{
		[Test(Description = "It should allow adding an additional Todo item")]
		public void AllowAddingTodoItems()
		{
			var app = new TodoApp();
			var rendered = app.Render().RenderAsFrameworkElement() as StackPanel;

			rendered.FindChild<TextBox>((elem) => true).Text = "Item007";
			rendered.FindChild<Button>((elem) => elem.Content.ToString().StartsWith("Add")).RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

			Assert.AreEqual(1, app.Items.Count);
			Assert.AreEqual("Item007", app.Items.First().Title);
		}
	}
}