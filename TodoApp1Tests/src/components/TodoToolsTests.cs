using System.Threading;
using System.Windows;
using System.Windows.Controls;
using NReact;
using NUnit.Framework;

namespace ToDoApp1.Tests
{
    [TestFixture, Apartment(ApartmentState.STA)]
    public class TodoToolsTests : MockAppTests
    {
        [Test, Description("displays the number of items left")]
        public void DisplaysNumberOfItemsLeft()
        {
            var nbActiveItems = 3;
            var component = new TodoTools(nbActiveItems).Render().RenderAsFrameworkElement() as StackPanel;

            var tb = component.FindChild<TextBlock>(e => e.Name == "itemsNumber");

            Assert.AreEqual(true, tb.Text.Contains(nbActiveItems.ToString()));
        }
    }
}