using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NReact;

namespace ToDoApp1
{
    public class TextInput : NClass
    {
        private Action<string, string> propsDoneEditing;
        private Action<string> propsCancelEditing;
        private string propsText;
        private string propsItemId;





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

        public TextInput(string text, string itemId, Action<string, string> doneEditing = null, Action<string> cancelEditing = null)
        {
            this.propsText = text;
            this.propsDoneEditing = doneEditing;
            this.propsCancelEditing = cancelEditing;
            this.propsItemId = itemId;

            this.TextValue = text;
        }



        private void cancelEditing(string itemId)
        {
            this.TextValue = this.propsText;
            // we need to call analog of props.cancelediting

            this.propsCancelEditing(this.propsItemId);
        }

        public override NElement Render()
        {
            return new NXaml<TextBox>().
                Text(TextValue).
                HorizontalAlignment(HorizontalAlignment.Left).
                KeyDown(this._OnKeyDown).
                TextChanged(this._OnTextChanged);
        }

        private void _OnTextChanged(object sender)
        {
            var tb = sender as TextBox;

            this.TextValue = tb?.Text;
        }


        private void _OnKeyDown(object sender, EventArgs e)
        {
            var args = e as KeyEventArgs;

            var tb = sender as TextBox;

            if (args?.Key == System.Windows.Input.Key.Enter)
            {
                this.propsDoneEditing(this.propsItemId, this.TextValue);


                //App.ItemsStore.Dispatch(new TodoItemUpdateAction(_todoListDataItem.Id, tb?.Text));
            }
            else if (args?.Key == System.Windows.Input.Key.Escape)
            {
                this.cancelEditing(this.propsItemId);
            }
        }
        
        
    }
}