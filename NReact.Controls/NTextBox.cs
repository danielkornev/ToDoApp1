using System.Windows.Controls;

namespace NReact
{
	public class NTextBox : NClass
	{
		public string Text
		{
			get { return Get(NFactory.Properties.Text, ""); }
			set { Set(NFactory.Properties.Text, value); }
		}

		public override NElement Render()
		{
			return new NXaml<TextBox>().Text(Text);
		}
	} // class
} // namespace