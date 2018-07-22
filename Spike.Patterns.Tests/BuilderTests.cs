using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spike.Patterns.Builder;

namespace Spike.Patterns.Tests
{
    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void BasicBuilderTests()
        {
            var builder = new BookBuilder().CrucialCOnversations();
            var sampleBook = builder.Build();

            Assert.AreEqual(builder.Title, sampleBook.Title);
        }

        [TestMethod]
        public void BuildAllBooksTest()
        {
            var books = new BookBuilder().BuildAll();

            Assert.IsTrue(books.Count() > 1);
        }

        [TestMethod]
        public void BuildBookWithDifferentReleaseDate()
        {
            var normalBook = new BookBuilder().FiveDysfunctions().Build();
            var updatedBook = new BookBuilder().FiveDysfunctions().UpdateReleaseDate(DateTime.Now).Build();

            Assert.AreNotEqual(normalBook.ReleaseDate, updatedBook.ReleaseDate);
        }

        [TestMethod]
        public void TestDataWithStaticIdsTest()
        {
            var authorList = new AuthorBuilder().BuildAll();

            // Builders & Repositories generate new IDs so it is important to be able to match with different ID
            var findAuthorThatWasCreatedUsingBuilder = authorList.FirstOrDefault(auth => auth.Surname.Contains("Gold"));
            var comparisonAuthor = new AuthorBuilder(findAuthorThatWasCreatedUsingBuilder?.Id).EliyahuGoldratt().Build();

            Assert.IsTrue(comparisonAuthor.Equals(findAuthorThatWasCreatedUsingBuilder));
        }
    }
}
