using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkerExtensions.MathExtensions.Combinatorics;

namespace ThinkerExtensions.MathExtensions.Combinatorics.Tests
{
    [TestFixture]
    public class PermutationsTests
    {
        [Test]
        public void PermutationsTest()
        {
            var intPermutations = new Permutations<int>(new[] { 1, 2, 3 });
            Assert.Equals(intPermutations.Count(), 6);
            Assert.IsTrue(
                intPermutations.Contains(new List<int>{ 1,2,3 })
                && intPermutations.Contains(new List<int>{ 1,3,2 })
                && intPermutations.Contains(new List<int>{ 2,1,3 })
                && intPermutations.Contains(new List<int> { 2,3,1 })
                && intPermutations.Contains(new List<int> { 3,2,1 })
                && intPermutations.Contains(new List<int>{ 3,1,2 }));

            var duplicatePermutations = new Permutations<string>(new []{"duplicate", "duplicate"}); //expect only one possible permutation
            Assert.Equals(duplicatePermutations.Count(), 1);
        }

        [Test]
        public void GetEnumeratorTest()
        {
            Assert.Fail();
        }
    }
}