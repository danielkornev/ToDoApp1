using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Windows.Input;
using Moq;
using NReact;

namespace ToDoApp1.Tests
{
    [TestFixture, Apartment(ApartmentState.STA)]
    public class TodoHeaderTests : MockAppTests
    {
        [Test, Description("calls a callback on submit")]
        public void CallsCallbackOnSubmit()
        {
            var addedItem = "";

            Action<string> addItem = (item) =>
            {
                addedItem = item;
            };

            var component = new TodoHeader(addItem).Render().RenderAsFrameworkElement() as StackPanel;

            var textBox = component.FindChild<TextBox>((elem)=>true);

            textBox.Text = "This is a new item";

            textBox?.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, new Mock<PresentationSource>().Object, 0, Key.Enter) { RoutedEvent = TextBox.KeyDownEvent });

            Assert.AreEqual(addedItem, "This is a new item");
        }
    }
}