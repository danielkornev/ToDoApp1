using NReact;
using System.Windows;

namespace ToDoApp1
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		void Application_Startup(object sender, StartupEventArgs e)
		{
			MainWindow.Render(new TodoApp());
			MainWindow.Show();
		}
	} // class
} // namespace
