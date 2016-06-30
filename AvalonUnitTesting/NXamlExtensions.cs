using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NReact
{
	public static class NXamlExtensions
	{
		public static FrameworkElement RenderAsFrameworkElement(this NElement nelement)
		{
			var cc = new ContentControl();
			cc.Render(nelement);

			return cc.Content as FrameworkElement;
		}
	} // class
} // namespace
