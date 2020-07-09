using CodePepperInterview.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CodePepperInterview.Tests.Helpers
{
    public class TestDataHelperTests
    {
        [Fact]
        public void LoadCharactersTest()
        {
            var data = TestDataHelper.LoadCharacters();

            Assert.NotNull(data);
            Assert.True(data.characters.Any());
        }
    }
}