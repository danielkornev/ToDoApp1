using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
                            Text("TODOS").
                            Style("todoHeaderH1").
                            HorizontalAlignment(HorizontalAlignment.Center).
                            Margin(0, 0, 0, 50),

                        new NXaml<TextBlock>().
                            Text("What needs to be done?").
                            HorizontalAlignment(HorizontalAlignment.Center).
                            Margin(0, 0, 0, 10),

                        new NXaml<TextBox>().
                            Key("addTodoInput").
                            Text("").
                            HorizontalAlignment(HorizontalAlignment.Stretch).
                            Margin(0, 0, 0, 10).
                            KeyDown(this._OnKeyDown)
                    );
        }

        private void _OnKeyDown(object sender, EventArgs e)
        {
            var args = e as KeyEventArgs;
            var addTodoInput = sender as TextBox;

            if (args?.Key == System.Windows.Input.Key.Enter 
                && 
                addTodoInput!=null
                &&
                addTodoInput.Text.Length>0)
            {
                this.addItem(addTodoInput.Text);
            }
        }
    }
}