using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using NReact;

namespace ToDoApp1
{
    public class TodoTools : NClass
    {
        private string activeItems;
        private int nbActiveItems;
        private string filter;

        public TodoTools(int nbActiveItems, string filter = "All")
        {
            this.nbActiveItems = nbActiveItems;

            if (nbActiveItems == 0)
                activeItems = "0 items left";
            else if (nbActiveItems == 1)
                activeItems = "1 item left";
            else
                activeItems = nbActiveItems + " items left";

            this.filter = filter;
        }

        public override NElement Render()
        {
            return
                new NXaml<StackPanel>().
                    Children(

                    new NXaml<Border>().
                        Set(new NProperties().SnapsToDevicePixels, true).
                        Set(new NProperties().DataContext, nbActiveItems).
                        BorderBrush("#FFC7C7C7").
                        BorderThickness(1, 0, 1, 1).
                        Child(
                        
                        #region Grid
                        new NXaml<Grid>().
                            Style("todoTools").     
                            ColumnDefinitions(
                                new NXaml<ColumnDefinition>().
                                    Width("1*"),

                                new NXaml<ColumnDefinition>().
                                    Width("1*"),

                                new NXaml<ColumnDefinition>().
                                    Width("1*")
                            ).
                            Children(

            #region Todo Tools
                                new NXaml<TextBlock>().
                                    GridColumn(0).
                                    Text(this.activeItems).
                                    Set(new NProperties().Name, "itemsNumber").
                                    Style("itemsLeft"),

                                new NXaml<StackPanel>().
                                    GridColumn(1).
                                    Set(new NProperties().Name, "filtersPanel").
                                    Style("filtersPanel").
                                    Orientation(Orientation.Horizontal).
                                    Children(

                                        new NXaml<RadioButton>().
                                            Style("radioAsToggleButtonStyle").
                                            Content("All").
                                            IsChecked(filter == "All").
                                            Set(new NProperties().GroupName, "Filters"),

                                        new NXaml<RadioButton>().
                                            Style("radioAsToggleButtonStyle").
                                            Content("Active").
                                            IsChecked(filter == "Active").
                                            Set(new NProperties().GroupName, "Filters"),

                                        new NXaml<RadioButton>().
                                            Style("radioAsToggleButtonStyle").
                                            Content("Completed").
                                            IsChecked(filter == "Completed").
                                            Set(new NProperties().GroupName, "Filters")
                                    ),

                                new NXaml<TextBlock>().
                                    GridColumn(2).
                                    Text("Clear completed").
                                    Style("clearCompleted")
            #endregion
                                    )

                        #endregion

                        ),

                        //new NXaml<Border>().
                        //    BorderBrush("#FF4d4d4d").
                        //    BorderThickness(0, 1, 0, 0).
                        //    Set(new NProperties().SnapsToDevicePixels, true).
                        //    Width(550).
                        //    Height(1),

                    new NXaml<Border>().
                    Background("#FFF6F6F6").
                    Set(new NProperties().SnapsToDevicePixels, true).
                    Width(540).
                    Height(5).
                    BorderThickness(1, 0, 1, 1).
                    BorderBrush("#FFC7C7C7"),

                    new NXaml<Border>().
                    Background("#FFF6F6F6").
                    Set(new NProperties().SnapsToDevicePixels, true).
                    Width(530).
                    Height(5).
                    BorderThickness(1, 0, 1, 1).
                    BorderBrush("#FFC7C7C7")
                    );
        }
    }
}