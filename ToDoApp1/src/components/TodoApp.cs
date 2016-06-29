using NReact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToDoApp1
{
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
		
		protected List<Dictionary<string, string>> Items
		{
			get
			{
				return GetState(NFactory.Properties.Items, new List<Dictionary<string, string>>());
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
													Content("Add #" + (Items.Count + 1)).
													Click(OnAdd)),

							 new TodoList { Items = this.Items }

							 );
		}

		protected override void InitState()
		{
			Items = new List<Dictionary<string, string>>
				{
					new Dictionary<string, string>
						{
							["id"] = "1",
							["text"] = "React",
							["status"] = "active"
						},
					new Dictionary<string, string>
					{
						["id"] = "2",
						["text"] = "Redux",
						["status"] = "active"
					},
					new Dictionary<string, string>
					{
						["id"] = "3",
						["text"] = "Immutable",
						["status"] = "complete"
					}
				};

			Text = "";
		}

		void OnChange(object sender)
		{
			Text = ((TextBox)sender).Text;
		}

		void OnAdd(object sender, EventArgs args)
		{
			AddItem();
		}

		void AddItem()
		{
			// so we need to find the max index
			var idx = Items.Count - 1;
			Items.Add(new Dictionary<string, string>
				{
					["id"] = idx.ToString(),
					["text"] = Text,
					["status"] = "active"
				}
			);
			Text = "";
		}

		private void OnKeyDown(object sender, EventArgs e)
		{
			var args = e as KeyEventArgs;

			if (args?.Key == System.Windows.Input.Key.Enter)
			{
				AddItem();
			}
		}
	}
}
