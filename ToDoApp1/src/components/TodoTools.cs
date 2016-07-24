using System.Windows;
using System.Windows.Controls;
using NReact;

namespace ToDoApp1
{
    public class TodoTools : NClass
    {
        private string activeItems;

        public TodoTools(int nbActiveItems)
        {
            if (nbActiveItems == 0)
                activeItems = string.Empty;
            else if (nbActiveItems == 1)
                activeItems = "1 item left";
            else
                activeItems = nbActiveItems + " items left";        
        }

        public override NElement Render()
        {
            return
                new NXaml<StackPanel>().
                    HorizontalAlignment(HorizontalAlignment.Center).
                    Orientation(Orientation.Horizontal).
                    Children(

                        new NXaml<TextBlock>().
                            Text(this.activeItems).
                            Set(new NProperties().Name, "itemsNumber").
                            Style("itemsLeft")

                    );
        }
    }
}