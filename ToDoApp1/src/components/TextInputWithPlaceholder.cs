using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NReact;

namespace ToDoApp1
{
    public class TextInputWithPlaceholder : NClass
    {
        private Action<string> notifyTextInput;

        protected string TextValue
        {
            get
            {
                return GetState(NFactory.Properties.Text, "");
            }
            set
            {
                SetState(NFactory.Properties.Text, value);
            }
        }

        public TextInputWithPlaceholder(Action<string> notifyTextInput)
        {
            this.notifyTextInput = notifyTextInput;
        }

        public override NElement Render()
        {
            return new NXaml<Grid>().
                Children(
                    new NXaml<TextBox>().
                        Key("input").
                        Style("todoHeaderInput").
                        Text(TextValue).
                        TextChanged(this._TextChanged).
                        KeyDown(this._OnKeyDown),

                    new NXaml<TextBlock>().
                        Key("placeholder").
                        Style("todoHeaderPlaceholder").
                        IsHitTestVisible(false).
                        Text("What needs to be done?")
                );
        }

        private void _TextChanged(object sender)
        {
            var tb = sender as TextBox;
            var grid = tb?.Parent as Grid;
            var placeholder = grid?.Children.OfType<TextBlock>().First();

            if (tb?.Text.Length > 0)
            {
                placeholder.Visibility = Visibility.Collapsed;
            }
            else
            {
                placeholder.Visibility = Visibility.Visible;
            }
        }

        private void _OnKeyDown(object sender, EventArgs args)
        {
            var tb = sender as TextBox;
            var e = args as KeyEventArgs;
            var grid = tb?.Parent as Grid;
            var placeholder = grid?.Children.OfType<TextBlock>().First();

            if (e.Key == System.Windows.Input.Key.Enter)
            {
                this.notifyTextInput?.Invoke(tb?.Text);

                tb.Text = string.Empty;
                placeholder.Visibility = Visibility.Visible;
            }

            
        }
    }
}
