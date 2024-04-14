using API.Services;
using AutoMapper;
using Core;
using Core.Models;
using FluentAssertions;
using Moq;

namespace Tests;

public class AuthorTests
{
    private readonly Mock<IUnitOfWork> _mockUnitWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly AuthorService authorService;

    public AuthorTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockUnitWork = new Mock<IUnitOfWork>();
        authorService = new AuthorService(_mockUnitWork.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAllAuthorsAsync__ValidValue()
    {
        //Arrange
        var authors = new List<Author>
        {
            Data.author
        };

        _mockUnitWork.Setup(x => x.Authors.GetAllAsync()).ReturnsAsync(authors);

        //Act

        var result = await authorService.GetAllAuthorsAsync();

        //Assert 
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetAuthorByIdAsync__ValidValue()
    {
        //Arrange
        var author = Data.author;
        var authorResource = Data.authorResource;

        _mockUnitWork.Setup(x => x.Authors.GetByIdAsync(author.AuthorId)).ReturnsAsync(author);
        SetupMapper(authorResource, author);

        //Act
        var result = await authorService.GetAuthorByIdAsync(author.AuthorId);

        //Arrange
        result.Should().NotBeNull();
        result.Should().Be(authorResource);
    }

    [Fact]
    public async Task CreateAuthorAsync__ValidValue()
    {
        //Arrange
        var saveAuthorResource = Data.saveAuthorResource;

        var author = Data.author;

        var authorResource = Data.authorResource;

        SetupMapper(authorResource, author);
        SetupMapper(author, saveAuthorResource);

        _mockUnitWork.Setup(x => x.Authors.AddAsync(author));
        _mockUnitWork.Setup(x => x.CommitAsync());

        //Act
        var result = await authorService.CreateAuthorAsync(saveAuthorResource);

        //Assert
        _mockUnitWork.Verify(x => x.Authors.AddAsync(author), Times.Once());
        _mockUnitWork.Verify(x => x.CommitAsync(), Times.Once());
        result.Should().Be(authorResource);
    }

    [Fact]
    public async Task UpdateAuthorAsync__TimesOnce()
    {
        //Arrange
        var saveAuthorResource = Data.saveAuthorResource;

        var author = Data.author;

        SetupMapper(author, saveAuthorResource);
        _mockUnitWork.Setup(x => x.Authors.GetByIdAsync(author.AuthorId)).ReturnsAsync(author);
        _mockUnitWork.Setup(x => x.CommitAsync());

        //Act
        await authorService.UpdateAuthorAsync(author.AuthorId, saveAuthorResource);

        //Assert
        _mockUnitWork.Verify(x => x.Authors.GetByIdAsync(author.AuthorId), Times.Once());
    }

    [Fact]
    public async Task DeleteAuthor__TimesOnce()
    {
        //Arrange
        var author = Data.author;

        var authorResource = Data.authorResource;

        SetupMapper(author, authorResource);
        _mockUnitWork.Setup(x => x.Authors.Remove(author));
        _mockUnitWork.Setup(x => x.CommitAsync());

        //Act
        await authorService.DeleteAuthor(authorResource);

        //Assert
        _mockUnitWork.Verify(x => x.Authors.Remove(author), Times.Once);
        _mockUnitWork.Verify(x => x.CommitAsync(), Times.Once);
    }

    private void SetupMapper<T1, T2>(T1 returnElement, T2 startElement)
    {
        _mockMapper.Setup(x => x.Map<T1>(startElement)).Returns(returnElement);
    }
}