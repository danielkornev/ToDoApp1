using NReact;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace ToDoApp1
{
	using System.Windows.Input;
	using static NFactory;

	class TodoApp : NClass
	{
		protected string Text
		{
			get
			{
				return GetState(NFactory.Properties.Text, "");
			}
			set
			{
				SetState(NFactory.Properties.Text, value);
			}
		}
		
		protected string[] Items
		{
			get
			{
				return GetState(NFactory.Properties.Items, default(string[]));
			}
			set
			{
				SetState(NFactory.Properties.Items, value);
			}
		}
		
		public override NElement Render()
		{
			return
			  new NXaml<StackPanel>().
					HorizontalAlignment(HorizontalAlignment.Center).
					Children(new NXaml<TextBlock>().
									Text("TODO").
									FontSize(24).
									HorizontalAlignment(HorizontalAlignment.Center),

							new NXaml<StackPanel>().
									Orientation(Orientation.Horizontal).
									Children(new NXaml<TextBox>().
													Text(Text).
													TextChanged(OnChange).
													KeyDown(OnKeyDown).
													Width(200),

											 new NXaml<Button>().
													Content("Add #" + (Items.Length + 1)).
													Click(OnAdd)),

							 new TodoList { Items = this.Items }

							 );
		}

		protected override void InitState()
		{
			Items = new string[3] {"React", "Redux", "Immutable"};

			Text = "";
		}

		void OnChange(object sender)
		{
			Text = ((TextBox)sender).Text;
		}

		void OnAdd(object sender, EventArgs args)
		{
			Items = Items.Concat(Text);
			Text = "";
		}

		private void OnKeyDown(object sender, EventArgs e)
		{
			var args = e as KeyEventArgs;

			if (args != null)
			{
				if (args.Key == System.Windows.Input.Key.Enter)
				{
					Items = Items.Concat(Text);
					Text = "";
				}
			}
		}
	}
}
