using Redux;

namespace ToDoApp1
{
	internal class TodoItemUpdateAction : IAction
	{
		private int _id;
		private string _text;

		public TodoItemUpdateAction(int id, string text)
		{
			this._id = id;
			this._text = text;
		}
	}
}