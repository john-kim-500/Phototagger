using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Phototagger.UserOptions;
namespace PhototaggerTests
{
    [TestClass]
    public class OptionRunnerFactoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Build_OnUnsupportedOption_ThrowsArgumentException()
        {
            // Configure
            string[] args = { "exe", "WILL_NEVER_BE_SUPPORTED_OPTION" };

            // Act
            OptionRunnerFactory.Build(args);
        }
    }
}
