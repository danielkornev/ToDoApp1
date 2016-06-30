using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace System.Windows
{
	/// <summary>
	/// Source: http://www.hardcodet.net/2008/02/find-wpf-parent
	/// </summary>
	public static class DependencyObjectExtensions
	{
		/// <summary>
		/// Finds a parent of a given item on the visual tree.
		/// </summary>
		/// <typeparam name="T">The type of the queried item.</typeparam>
		/// <param name="child">A direct or indirect child of the
		/// queried item.</param>
		/// <returns>The first parent item that matches the submitted
		/// type parameter. If not matching item can be found, a null
		/// reference is being returned.</returns>
		public static T TryFindParent<T>(this DependencyObject child)
			where T : DependencyObject
		{
			//get parent item
			DependencyObject parentObject = GetParentObject(child);

			//we've reached the end of the tree
			if (parentObject == null) return null;

			//check if the parent matches the type we're looking for
			T parent = parentObject as T;
			if (parent != null)
			{
				return parent;
			}
			else
			{
				//use recursion to proceed with next level
				return TryFindParent<T>(parentObject);
			}
		}

		/// <summary>
		/// This method is an alternative to WPF's
		/// <see cref="VisualTreeHelper.GetParent"/> method, which also
		/// supports content elements. Keep in mind that for content element,
		/// this method falls back to the logical tree of the element!
		/// </summary>
		/// <param name="child">The item to be processed.</param>
		/// <returns>The submitted item's parent, if available. Otherwise
		/// null.</returns>
		public static DependencyObject GetParentObject(this DependencyObject child)
		{
			if (child == null) return null;

			//handle content elements separately
			ContentElement contentElement = child as ContentElement;
			if (contentElement != null)
			{
				DependencyObject parent = ContentOperations.GetParent(contentElement);
				if (parent != null) return parent;

				FrameworkContentElement fce = contentElement as FrameworkContentElement;
				return fce != null ? fce.Parent : null;
			}

			//also try searching for parent in framework elements (such as DockPanel, etc)
			FrameworkElement frameworkElement = child as FrameworkElement;
			if (frameworkElement != null)
			{
				DependencyObject parent = frameworkElement.Parent;
				if (parent != null) return parent;
			}

			//if it's not a ContentElement/FrameworkElement, rely on VisualTreeHelper
			return VisualTreeHelper.GetParent(child);
		}

		/// <summary>
		/// Finds a Child of a given item in the visual tree. 
		/// 
		/// http://stackoverflow.com/questions/636383/how-can-i-find-wpf-controls-by-name-or-type
		/// </summary>
		/// <param name="parent">A direct parent of the queried item.</param>
		/// <typeparam name="T">The type of the queried item.</typeparam>
		/// <param name="childName">x:Name or Name of child. </param>
		/// <returns>The first parent item that matches the submitted type parameter. 
		/// If not matching item can be found, 
		/// a null parent is being returned.</returns>
		public static T FindChild<T>(this DependencyObject parent, Func<T, bool> selector)
		   where T : DependencyObject
		{
			// Confirm parent and childName are valid. 
			if (parent == null) return null;

			T foundChild = null;

			int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
			for (int i = 0; i < childrenCount; i++)
			{
				var child = VisualTreeHelper.GetChild(parent, i);
				// If the child is not of the request child type child
				T childType = child as T;
				if (childType == null)
				{
					// recursively drill down the tree
					foundChild = FindChild<T>(child, selector);

					// If the child is found, break so we do not overwrite the found child. 
					if (foundChild != null) break;
				}
				else
				{
					var frameworkElement = child as FrameworkElement;
					// If the child's name is set for search
					if (frameworkElement != null && selector(frameworkElement as T))
					{
						// if the child's name is of the request name
						foundChild = (T)child;
						break;
					}
				}
			}

			return foundChild;
		}
	} // class
} // namespace
