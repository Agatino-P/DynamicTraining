using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace DerivedDynamicLib.Test
{
    [TestClass]
    public class DerDynShould
    {
        [Fact]
        public void StoreTagName()
        {
            const string tn = "img";
            DerDyn derDyn = new(tn);

            derDyn.TagName.Should().Be(tn);
        }

        [Fact]
        public void AddAttribute()
        {
            const string source= "my.src";
            dynamic derDyn = new DerDyn("");
            derDyn.src = source;
            derDyn.src.Should().Be(source);
        }

    }
}
