using System.Windows.Controls;
using System.Windows.Documents;
using NReact;

namespace ToDoApp1
{
    public class Footer : NClass
    {
        public void foo()
        {

        }

        public override NElement Render()
        {
            return new NXaml<StackPanel>().
                Margin(0, 40, 0, 0).
                Children(

                    new NXaml<TextBlock>().
                    Style("footer").
                    Text("Double-click to edit a todo"),

                    new NXaml<ContentControl>().
                    Style("footerLinkToPhacks"),

                    new NXaml<ContentControl>().
                    Style("footerLinkToTodoMvc")
                );
        }
    }
}