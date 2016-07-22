using System;

namespace ToDoApp1
{
    public class TodoListDataItem
    {
        public enum Statuses
        {
            Active, Completed
        }

        public int Id { get; }
        public string Title { get; }
        public Statuses Status { get; }
        public bool Editing { get; }

        public Action ToggleCompleteAction { get; }

        public Action DeleteAction { get; }
        public EventHandler EditAction { get; }
        public EventHandler OnKeyDownAction { get; }

        public TodoListDataItem(int id, string title, Statuses status, bool editing = false, Action deleteAction = null, Action toggleCompleteAction = null, EventHandler editAction = null, EventHandler onKeyDownAction = null)
        {
            Id = id;
            Title = title;
            Status = status;
            Editing = editing;
            DeleteAction = deleteAction;
            ToggleCompleteAction = toggleCompleteAction;
            EditAction = editAction;
            OnKeyDownAction = onKeyDownAction;
        }

    }
}