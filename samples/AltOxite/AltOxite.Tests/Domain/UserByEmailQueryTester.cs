using System.Globalization;
using System.Threading;
using AltOxite.Core.Domain;
using NUnit.Framework;

namespace AltOxite.Tests.Domain
{
    [TestFixture]
    public class UserByEmailQueryTester
    {
        private CultureInfo _originalCulture;
        private string _capitalARing;
        private string _aRing;
        private string _email;
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _originalCulture = Thread.CurrentThread.CurrentCulture;

            // Define a target string to search for.
            // U+00c5 = LATIN CAPITAL LETTER A WITH RING ABOVE
            _capitalARing = "\u00c5";

            // Define a string to search. 
            // The result of combining the characters LATIN SMALL LETTER A and COMBINING 
            // RING ABOVE (U+0061, U+030a) is linguistically equivalent to the character 
            // LATIN SMALL LETTER A WITH RING ABOVE (U+00e5).
            _aRing = "\u0061\u030a";

            _email = "TESTEMAIL";
            _user = new User { Email = _email.ToLower() };
        }

        [TearDown]
        public void TearDown()
        {
            Thread.CurrentThread.CurrentCulture = _originalCulture;
        }

        [Test]
        public void should_be_case_insensitive()
        {
            new UserByEmail(_email).Expression.Compile()(_user).ShouldBeTrue();
        }

        [Test]
        public void should_be_culture_agnostic_en_US()
        {
            var query = new UserByEmail(_capitalARing);
            _user.Email = _aRing;
            
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            query.Expression.Compile()(_user).ShouldBeTrue();
        }

        [Test]
        public void should_be_culture_agnostic_sv_SE()
        {
            var query = new UserByEmail(_capitalARing);
            _user.Email = _aRing;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("sv-SE");

            query.Expression.Compile()(_user).ShouldBeTrue();
        }
    }
}