using System.Windows.Controls;

namespace NReact
{
	public class NTextBlock : NClass
	{

		public string Text
		{
			get { return Get(NFactory.Properties.Text, ""); }
			set { Set(NFactory.Properties.Text, value); }
		}

		public override NElement Render()
		{
			return new NXaml<TextBlock>().Text(Text);
		}
	}
}