using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NReact
{
	public class NButton : NClass
	{
		public string Text { get { return Get(NFactory.Properties.Text, ""); } set { Set(NFactory.Properties.Text, value); } }

		public override NElement Render()
		{
			if (Text.StartsWith("Text"))
				return new NXaml<TextBlock>().Text(Text);

			return new NXaml<Button>().Content(Text);
		}
	} // class
} // namespace
