using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Moq;
using NReact;
using NUnit.Framework;

namespace ToDoApp1.Tests
{
    [TestFixture, Apartment(ApartmentState.STA)]
    public class TextInputWithPlaceholderTests : MockAppTests
    {
        [Test, Description("hides placeholder when text is added")]
        public void HidesPlaceholderWhenTextIsAdded()
        {
            var text = "React";

            var component = new TextInputWithPlaceholder(null);

            var grid = (component.Render().RenderAsFrameworkElement() as Border).Child as Grid;

            var textBox = grid.FindChild<TextBox>((elem) => true);

            textBox.Text = text;

            var placeholder = grid.FindChild<TextBlock>((elem) => true);

            Assert.AreEqual(true, placeholder.Visibility == Visibility.Collapsed);
        }

    }
}