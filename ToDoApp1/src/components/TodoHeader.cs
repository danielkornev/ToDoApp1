using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using NReact;

namespace ToDoApp1
{
    public class TodoHeader : NClass
    {
        private Action<string> addItem;

        public TodoHeader(Action<string> addItem)
        {
            this.addItem = addItem;
        }

        public override NElement Render()
        {
            return
                new NXaml<StackPanel>().
                    Key("todoHeader").
                    HorizontalAlignment(HorizontalAlignment.Stretch).
                    Orientation(Orientation.Vertical).
                    Children(

                        new NXaml<TextBlock>().
                            Text("todos").
                            Style("todoHeaderH1"),
                        
                        new TextInputWithPlaceholder(_ProcessTextInput),

                        new NXaml<Rectangle>().
                        Key("line").
                        Style("line")
                    );
        }

        private void _ProcessTextInput(string input)
        {
            this.addItem(input);
        }
    }
}