using Core.Models;
using Core.Resources;

namespace Tests;
internal static class Data
{
    internal static Author author = new Author
    {
        AuthorId = 1,
        AuthorFirstMidName = "Test",
        AuthorLastName = "Test"
    };

    internal static SaveAuthorResource saveAuthorResource = new SaveAuthorResource
    {
        AuthorFirstMidName = "Test",
        AuthorLastName = "Test"
    };
    
    internal static AuthorResource authorResource = new AuthorResource
    {
        AuthorId = 1,
        AuthorFirstMidName = "Test",
        AuthorLastName = "Test"
    };
}
