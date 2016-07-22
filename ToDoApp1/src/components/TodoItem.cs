using System;
using System.Collections.Generic;
using System.Windows;
using NReact;
using System.Windows.Controls;
using System.Windows.Input;

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
                        HorizontalAlignment(HorizontalAlignment.Stretch).
                        Orientation(Orientation.Horizontal).
                        Children(
                            
                             new NXaml<CheckBox>(_todoListDataItem).
                                Key("toggle").
                                IsChecked(this.IsCompleted(_todoListDataItem)).
                                HorizontalAlignment(HorizontalAlignment.Left).
                                Margin(0, 0, 10, 0).
                                Click(_todoListDataItem.ToggleCompleteAction),

                            new NXaml<ContentControl>().Content(

                                new NXaml<TextBlock>(_todoListDataItem).
                                    Set(new NProperties().DataContext, IsCompleted(_todoListDataItem)).
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
                        HorizontalAlignment(HorizontalAlignment.Left).
                        Orientation(Orientation.Horizontal).
                        Children(
                            new NXaml<TextBox>(_todoListDataItem).
                                Text(_todoListDataItem.Title).
                                HorizontalAlignment(HorizontalAlignment.Left).
                                Margin(30, 0, 0, 0).
                                KeyDown(_todoListDataItem.OnKeyDownAction)
                        )
                    );



                



            //if (_todoListDataItem.Editing)
            //{
            //    return
            //        new NXaml<StackPanel>().
            //            HorizontalAlignment(HorizontalAlignment.Left).
            //            Orientation(Orientation.Horizontal).
            //            Children(
            //                new NXaml<TextBox>(_todoListDataItem).
            //                    Text(_todoListDataItem.Title).
            //                    HorizontalAlignment(HorizontalAlignment.Left).
            //                    KeyDown(_todoListDataItem.OnKeyDownAction)
            //            );
            //}

            //if (_todoListDataItem.Status == TodoListDataItem.Statuses.Completed)
            //{
            //    return
            //        new NXaml<StackPanel>().
            //            HorizontalAlignment(HorizontalAlignment.Left).
            //            Orientation(Orientation.Horizontal).
            //            Children(
            //                new NXaml<CheckBox>(_todoListDataItem).
            //                    IsChecked(this.IsCompleted(_todoListDataItem)).
            //                    HorizontalAlignment(HorizontalAlignment.Left).
            //                    Margin(0, 0, 10, 0).
            //                    Click(_todoListDataItem.ToggleCompleteAction),

            //                new NXaml<ContentControl>().Content(

            //                    new NXaml<TextBlock>(_todoListDataItem).
            //                        Text(_todoListDataItem.Title).
            //                        TextDecorations(TextDecorations.Strikethrough).
            //                        HorizontalAlignment(HorizontalAlignment.Left).
            //                        Margin(0, 0, 10, 0)

            //                ).MouseDoubleClick(_todoListDataItem.EditAction),

            //                new NXaml<Button>(_todoListDataItem).
            //                    Key("deleteTodoListItem").
            //                    Content("X").
            //                    Click(_todoListDataItem.DeleteAction)
            //            );
            //}

            //return
            //    new NXaml<StackPanel>().
            //        HorizontalAlignment(HorizontalAlignment.Left).
            //        Orientation(Orientation.Horizontal).
            //        Children(
            //            new NXaml<CheckBox>(_todoListDataItem).
            //                HorizontalAlignment(HorizontalAlignment.Left).
            //                Margin(0, 0, 10, 0).
            //                Click(_todoListDataItem.ToggleCompleteAction),

            //            new NXaml<ContentControl>().Content(

            //                new NXaml<TextBlock>(_todoListDataItem).
            //                    Text(_todoListDataItem.Title).
            //                    HorizontalAlignment(HorizontalAlignment.Left).
            //                    Margin(0, 0, 10, 0)

            //            ).MouseDoubleClick(_todoListDataItem.EditAction),

            //            new NXaml<Button>(_todoListDataItem).
            //                Key("deleteTodoListItem").
            //                Content("X").
            //                Click(_todoListDataItem.DeleteAction)
            //        );
        }

        private bool IsCompleted(TodoListDataItem todoListDataItem)
        {
            return todoListDataItem.Status == TodoListDataItem.Statuses.Completed;
        }
    }
}