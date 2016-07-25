using System.Threading;
using System.Windows;
using System.Windows.Controls;
using NReact;
using NUnit.Framework;
using System.Linq;

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

        [Test, Description("Highlights the active filter")]
        public void HighlightsActiveFilter()
        {
            var filter = "Active";

            var component = new TodoTools(0, filter).Render().RenderAsFrameworkElement() as StackPanel;

            var filters =
                (component.FindChild<StackPanel>(s => s.Name == "filtersPanel") as StackPanel).Children
                    .OfType<RadioButton>().ToList();

            Assert.AreEqual(false, filters[0].IsChecked);
            Assert.AreEqual(true, filters[1].IsChecked);
            Assert.AreEqual(false, filters[2].IsChecked);
        }
    }
}