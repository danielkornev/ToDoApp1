using System.Windows.Controls;

namespace NReact
{
	public class NStackPanel : NClass
	{
		public override NElement Render()
		{
			return new NXaml<StackPanel>().Children(Children);
		}
	} // class
} // namespace