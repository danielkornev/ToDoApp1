using System;
using System.IO;
using System.Reflection;
using System.Windows;
using NUnit.Framework;

namespace ToDoApp1.Tests
{
    [TestFixture]
    public class MockAppTests
    {
        private static Application MockApp;

        public MockAppTests()
        {
            string path = Path.Combine(NUnit.Framework.TestContext.CurrentContext.TestDirectory, "ToDoApp1.exe");

            MockApp = new Application()
            {
                ShutdownMode = ShutdownMode.OnExplicitShutdown
            };


            Assembly.LoadFrom(path);
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("pack://application:,,,/ToDoApp1;component/src/resources/ToDoAppResources.xaml");

            MockApp.Resources = rd;

        }
  }

}