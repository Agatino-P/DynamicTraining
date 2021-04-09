using FluentAssertions;
using Microsoft.CSharp.RuntimeBinder;
using System.Collections.Generic;
using Xunit;




namespace DerivedDynamicLib.Test
{
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
            Assert.Equal(derDyn.src, source);
            //derDyn.src.Should().Be(source);
        }

        [Fact]
        public void ErrorOnNonSetAttribute()
        {
            dynamic derDyn = new DerDyn("");
            Assert.Throws<RuntimeBinderException>(() => derDyn.scr);
        }

        [Fact]
        public void ReturnMemberNames()
        {
            const string alt = "alt.alt";
            const string source = "my.src";

            dynamic derDyn = new DerDyn("");
            derDyn.alt = alt;
            derDyn.src = source;

            List<string> members = new(derDyn.GetDynamicMemberNames());

            members.Count.Should().Be(2);
            Assert.Equal("alt", members[0]);
            Assert.Equal("src",members[1]);
        }

        [Fact]
        public void OutputHtmlTag()
        {
            dynamic derDyn = new DerDyn("img");
            derDyn.alt = "a blue car";
            derDyn.src = "car.png";

            string expectedString = @"<img alt='a blue car' src='car.png' />";
            Assert.Equal(expectedString, derDyn.ToString());

        }
    }
}
