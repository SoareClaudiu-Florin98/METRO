using METROAssignment.Application.Article.Commands;
using METROAssignment.Domain.Models;
using METROAssignment.Infrastructure.Persistence.Repositories.Interfaces;
using Moq;


namespace METROAssignment.UnitTests
{
    public class DeleteArticleCommandHandlerTests
    {
        private readonly Mock<IArticleRepository> _articleRepositoryMock;

        public DeleteArticleCommandHandlerTests()
        {
            _articleRepositoryMock = new Mock<IArticleRepository>();
        }

        [Test]
        [TestCase(1, 6)]
        [TestCase(1, 5)]
        [TestCase(1, 3)]
        [TestCase(3, 2)]
        public void DeleteArticleCommandHandlerShouldThrowException(int id, int findId)
        {
            //Arrange 

            _articleRepositoryMock
                .Setup(x => x.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => id == findId ? new Article { Name = "name1", Inventory = 20 } : null);

            var deleteArticleCommand = new DeleteArticleCommand(id);
            var deleteArticleCommandHandler = new DeleteArticleCommandHandler(_articleRepositoryMock.Object);

            //Act && Assert
            Assert.ThrowsAsync<Exception>(async () => await deleteArticleCommandHandler.Handle(deleteArticleCommand, default));
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        public void DeleteArticleCommandHandlerShouldNotThrowException(int id, int findId)
        {
            //Arrange 

            _articleRepositoryMock
                .Setup(x => x.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => id == findId ? new Article { Name = "name1", Inventory = 20 } : null);

            var deleteArticleCommand = new DeleteArticleCommand(id);
            var deleteArticleCommandHandler = new DeleteArticleCommandHandler(_articleRepositoryMock.Object);

            //Act && Assert
            Assert.DoesNotThrowAsync(async () => await deleteArticleCommandHandler.Handle(deleteArticleCommand, default));
        }
    }
}
