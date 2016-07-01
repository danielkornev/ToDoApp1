using System.Collections.Generic;
using System.Collections.Immutable;
using NReact;
using System.Windows;
using Redux;

namespace ToDoApp1
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static IStore<ImmutableList<TodoListItem>> ItemsStore { get; protected internal set; }

		void Application_Startup(object sender, StartupEventArgs e)
		{
			MainWindow.Render(new TodoApp());
			MainWindow.Show();

			var initialItems = new List<TodoListItem>
			{
				new TodoListItem(1, "React", TodoListItem.Statuses.Active),
				new TodoListItem(2, "Redux", TodoListItem.Statuses.Active, true),
				new TodoListItem(3, "Immutable", TodoListItem.Statuses.Completed)
			}.ToImmutableList();

			ItemsStore = new Store<ImmutableList<TodoListItem>>(TodoItemsReducer.Execute, initialItems);
		}
	} // class
} // namespace
