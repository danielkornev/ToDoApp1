using System;
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
    public class TextInputTests
    {
        [Test, Description(("calls a callaback when pressing enter"))]
        public void CallsCallbackWhenPressingEnter()
        {
            var text = "React";
            var hasDoneEditing = false;

            Action<string, string> doneEditing = (itemId, txt) =>
            {
                hasDoneEditing = true;
            };

            var textinput = new TextInput(text, string.Empty, doneEditing);

            var textBox = textinput.Render().RenderAsFrameworkElement() as TextBox;

            // raising our event handler
            textBox?.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, new Mock<PresentationSource>().Object, 0, Key.Enter) { RoutedEvent = TextBox.KeyDownEvent });

            Assert.AreEqual(true, hasDoneEditing);
        }

        [Test, Description(("calls a callback when pressing escape or losing focus"))]
        public void CallsCallbackWhenPressingEscapeOrLosingFocus()
        {
            var text = "React";
            var hasCanceledEditing = false;
            Action<string> cancelEditing = (itemId) =>
            {
                hasCanceledEditing = true;
            };

            var textinput = new TextInput(text, string.Empty, null, cancelEditing);

            var textBox = textinput.Render().RenderAsFrameworkElement() as TextBox;

            // raising our event handler
            textBox?.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, new Mock<PresentationSource>().Object, 0, Key.Escape) { RoutedEvent = TextBox.KeyDownEvent });

            Assert.AreEqual(true, hasCanceledEditing);
        }
    }
}
