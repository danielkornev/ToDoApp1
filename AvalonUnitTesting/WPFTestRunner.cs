using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPFUnitTesting
{
	/// <summary>
	/// base class for unit test of wpf
	/// for more info visit
	/// http://marlongrech.wordpress.com/2007/10/14/wpf-unit-testing/
	/// </summary>
	public class WPFTestRunner
	{

		/// <summary>
		/// Runs a set of tests for data binding
		/// </summary>
		/// <param name="objectToTest"></param>
		public static void RunDataBindingTests(object objectToTest)
		{
			//get the window instance. This will create a wrapper window if a window is not passes as parameter
			Window windowToTest = WPFActivatorHelper.VerifyObjectType(objectToTest);
			if (windowToTest != null)
				WPFDataBindingTraceTester.TestDataBindingsForObject(windowToTest);

		}

		private static readonly STAOperationRunner runner = new STAOperationRunner();

		/// <summary>
		/// Runs a delegate in a STA thread
		/// </summary>
		/// <param name="userDelegate">The operation to run</param>
		public static void RunInSTA(ThreadStart userDelegate)
		{
			runner.RunInSTA(userDelegate);
		}
	} // class
} // namespace
