using System;
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

        [Test, Description("highlights the active filter")]
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

        [Test, Description("calls a callback when the user clicks on Clear Completed button")]
        public void CallsCallbackWhenUserClicksOnClearCompletedButton()
        {
            var cleared = false;
            Action clearCompleted = () =>
            {
                cleared = true;
            };

            var component = new TodoTools(0, "All", clearCompleted).Render().RenderAsFrameworkElement() as StackPanel;

            var clearComBtn = component.FindChild<Button>(b => b.Name == "clearCompletedButton");

            // clicking on a button
            clearComBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            Assert.AreEqual(true, cleared);
        }
    }
}