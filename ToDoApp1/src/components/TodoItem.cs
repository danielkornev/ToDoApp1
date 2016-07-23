using System;
using System.Collections.Generic;
using System.Windows;
using NReact;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Linq;

namespace ToDoApp1
{
    public class TodoItem : NClass
    {
        private TodoListDataItem _todoListDataItem;

        public TodoItem(TodoListDataItem _todoListDataItem)
        {
            this._todoListDataItem = _todoListDataItem;
        }

        public override NElement Render()
        {
            return
                new NXaml<StackPanel>().
                    Key("view").
                    HorizontalAlignment(HorizontalAlignment.Stretch).
                    Orientation(Orientation.Vertical).
                    Children(
                    
                        new NXaml<StackPanel>().
                        Key("viewing").
                        Style("viewingTodoItemStyle").
                        Set(new NProperties().Name, "viewing").
                        Set(new NProperties().DataContext, _todoListDataItem).
                        HorizontalAlignment(HorizontalAlignment.Stretch).
                        Orientation(Orientation.Horizontal).
                        Children(
                            
                             new NXaml<CheckBox>(_todoListDataItem).
                                Key("toggle").
                                Style("todomvcToggle").
                                IsChecked(this.IsCompleted(_todoListDataItem)).
                                HorizontalAlignment(HorizontalAlignment.Left).
                                Margin(10, 0, -2, 0).
                                Click(_todoListDataItem.ToggleCompleteAction),

                            new NXaml<ContentControl>().Content(

                                new NXaml<TextBlock>(_todoListDataItem).
                                    Set(new NProperties().DataContext, _todoListDataItem).
                                    Text(_todoListDataItem.Title).
                                    Style("TodoListItemTextBlockStyle").
                                    HorizontalAlignment(HorizontalAlignment.Left).
                                    Margin(0, 0, 10, 0)

                            ).MouseDoubleClick(_todoListDataItem.EditAction),

                            new NXaml<Button>(_todoListDataItem).
                                Key("destroy").
                                Content("X").
                                Click(_todoListDataItem.DeleteAction)
                        ),

                        new NXaml<StackPanel>().
                        Key("editing").
                        Style("editingTodoItemStyle").
                        Set(new NProperties().Name, "editing").
                        Set(new NProperties().DataContext, _todoListDataItem).
                        HorizontalAlignment(HorizontalAlignment.Left).
                        Orientation(Orientation.Horizontal).
                        Children(
                            new NXaml<TextBox>(_todoListDataItem).
                                Text(_todoListDataItem.Title).
                                Style("todoHeaderInput").
                                HorizontalAlignment(HorizontalAlignment.Left).
                                Margin(0, 0, 0, 0).
                                KeyDown(_todoListDataItem.OnKeyDownAction)
                        ),

                        new NXaml<Rectangle>().
                        Key("line").
                        Style("line")
                    );
        }
        

        private bool IsCompleted(TodoListDataItem todoListDataItem)
        {
            return todoListDataItem.Status == TodoListDataItem.Statuses.Completed;
        }
    }
}