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
		public static IStore<ImmutableList<TodoListDataItem>> ItemsStore { get; protected internal set; }

		void Application_Startup(object sender, StartupEventArgs e)
		{
			MainWindow.Render(new TodoApp());
			MainWindow.Show();
		    MainWindow.Style = Application.Current.FindResource("mainWindow") as Style;

			var initialItems = new List<TodoListDataItem>
			{
				new TodoListDataItem(1, "React", TodoListDataItem.Statuses.Active),
				new TodoListDataItem(2, "Redux", TodoListDataItem.Statuses.Active, true),
				new TodoListDataItem(3, "Immutable", TodoListDataItem.Statuses.Completed)
			}.ToImmutableList();

			ItemsStore = new Store<ImmutableList<TodoListDataItem>>(TodoItemsReducer.Execute, initialItems);
		}
	} // class
} // namespace
