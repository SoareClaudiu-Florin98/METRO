using METROAssignment.Application.Article.Commands;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;
using Moq;

namespace METROAssignment.UnitTests
{
    public class CreateArticleCommandhandlerTest
    {
        private readonly Mock<IArticleRepository> _articleRepositoryMock;

        public CreateArticleCommandhandlerTest()
        {
            _articleRepositoryMock = new Mock<IArticleRepository>();
        }


        [Test]
        [TestCase("", 20)]
        [TestCase("", -1)]
        [TestCase(null, 23)]
        [TestCase("name", -2)]
        public void CreateArticleCommandhandlerShouldThrowException(string? name, int inventory)
        {
            //Arrange 

            var createArticleCommand = new CreateArticleCommand(name, inventory);
            var createArticleCommandHandler = new CreateArticleCommandHandler(_articleRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () => await createArticleCommandHandler.Handle(createArticleCommand, default));
        }

        [Test]
        [TestCase("name1", 20)]
        [TestCase("name2", 2)]
        [TestCase("name3", 1)]
        [TestCase("name4", 0)]
        public void CreateArticleCommandhandlerShouldNotThrowException(string? name, int inventory)
        {
            //Arrange 

            var createArticleCommand = new CreateArticleCommand(name, inventory);
            var createArticleCommandHandler = new CreateArticleCommandHandler(_articleRepositoryMock.Object);

            //Act && Assert
            Assert.DoesNotThrowAsync(async () => await createArticleCommandHandler.Handle(createArticleCommand, default));
        }
    }
}