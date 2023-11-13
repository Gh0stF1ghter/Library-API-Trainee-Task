using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder) => _modelBuilder = modelBuilder;

        public void Seed()
        {
            _modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, AuthorFirstMidName = "Douglas", AuthorLastName = "Adams" },
                new Author { AuthorId = 2, AuthorFirstMidName = "Suzanne", AuthorLastName = "Collins" },
                new Author { AuthorId = 3, AuthorFirstMidName = "Dan", AuthorLastName = "Brown" },
                new Author { AuthorId = 4, AuthorFirstMidName = "Joanne", AuthorLastName = "Rowling" },
                new Author { AuthorId = 5, AuthorFirstMidName = "Jerome David", AuthorLastName = "Salinger" },
                new Author { AuthorId = 6, AuthorFirstMidName = "Harper", AuthorLastName = "Lee" },
                new Author { AuthorId = 7, AuthorFirstMidName = "John", AuthorLastName = "Tolkien" },
                new Author { AuthorId = 8, AuthorFirstMidName = "George", AuthorLastName = "Orwell" },
                new Author { AuthorId = 9, AuthorFirstMidName = "Khaled", AuthorLastName = "Hosseini" },
                new Author { AuthorId = 10, AuthorFirstMidName = "Stieg", AuthorLastName = "Larsson" }
                );

            _modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, BookAuthorId = 1, BookName = "The Hitchhiker’s Guide to the Galaxy", BookISBN = "9780330258641", BookDescription = "A hilarious science fiction comedy that follows the adventures of Arthur Dent, a hapless human who escapes the destruction of Earth with the help of an alien friend. The book is full of witty humor, absurd situations, and clever references to various aspects of culture and science." },
                new Book { BookId = 2, BookAuthorId = 2, BookName = "The Hunger Games", BookISBN = "9780439023528", BookDescription = "A dystopian novel that depicts a brutal reality show where 24 teenagers are forced to fight to the death in a televised arena. The book explores themes of survival, rebellion, and morality through the perspective of Katniss Everdeen, a 16-year-old girl who volunteers to take her sister’s place in the deadly game." },
                new Book { BookId = 3, BookAuthorId = 3, BookName = "The Da Vinci Code", BookISBN = "978030745454", BookDescription = "A thriller that revolves around a murder mystery involving a secret society, a religious conspiracy, and a hidden code in Leonardo da Vinci’s paintings. The book is full of suspense, puzzles, and historical facts that challenge the reader’s knowledge and beliefs." },
                new Book { BookId = 4, BookAuthorId = 4, BookName = "Harry Potter and the Philosopher’s Stone", BookISBN = "9780141950432", BookDescription = "A fantasy novel that introduces the magical world of Harry Potter, a young boy who discovers that he is a wizard and attends Hogwarts School of Witchcraft and Wizardry. The book is full of imagination, adventure, and friendship as Harry learns to master his powers and faces his nemesis, Lord Voldemort." },
                new Book { BookId = 5, BookAuthorId = 5, BookName = "The Catcher in the Rye", BookISBN = "9791456789012", BookDescription = "A classic novel that portrays the alienation and disillusionment of Holden Caulfield, a 17-year-old boy who runs away from his boarding school and wanders around New York City. The book captures the voice and emotions of a troubled teenager who struggles to find meaning and identity in a phony world." },
                new Book { BookId = 6, BookAuthorId = 6, BookName = "To Kill a Mockingbird", BookISBN = "9780060935467", BookDescription = "A Pulitzer Prize-winning novel that depicts the racial injustice and social inequality in the American South during the 1930s. The book is narrated by Scout Finch, a 6-year-old girl who witnesses her father, Atticus Finch, defend a black man accused of raping a white woman in a court trial." },
                new Book { BookId = 7, BookAuthorId = 7, BookName = "The Lord of the Rings", BookISBN = "9790345678904", BookDescription = "An epic fantasy novel that tells the story of Frodo Baggins, a hobbit who inherits a powerful ring from his uncle Bilbo Baggins and embarks on a quest to destroy it in the fires of Mount Doom. The book is set in Middle-earth, a richly detailed world full of elves, dwarves, orcs, and other mythical creatures." },
                new Book { BookId = 8, BookAuthorId = 8, BookName = "Nineteen Eighty-Four ", BookISBN = "9781234567897", BookDescription = "A dystopian novel that depicts a totalitarian society where Big Brother, the leader of the Party, controls every aspect of life through propaganda, surveillance, and censorship. The book follows Winston Smith, a low-ranking member of the Party who secretly rebels against the system by writing a diary and falling in love with Julia." },
                new Book { BookId = 9, BookAuthorId = 9, BookName = "The Kite Runner", BookISBN = "9780123456789", BookDescription = "A historical fiction novel that traces the friendship and betrayal of Amir and Hassan, two boys from different social classes in Afghanistan. The book spans over three decades of war, violence, and migration as Amir tries to redeem himself for his past sins." },
                new Book { BookId = 10, BookAuthorId = 10, BookName = "The Girl with the Dragon Tattoo", BookISBN = "9781594631931", BookDescription = "A crime novel that involves the investigation of a 40-year-old disappearance case by Mikael Blomkvist, a journalist, and Lisbeth Salander, a hacker with a troubled past. The book is full of twists, turns, and secrets that expose the dark side of Swedish society." }
                );

            _modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, GenreName = "Science fiction" },
                new Genre { GenreId = 2, GenreName = "Action" },
                new Genre { GenreId = 3, GenreName = "Thriller" },
                new Genre { GenreId = 4, GenreName = "Detective novel" },
                new Genre { GenreId = 5, GenreName = "Fantasy" },
                new Genre { GenreId = 6, GenreName = "Realism" },
                new Genre { GenreId = 7, GenreName = "Satire" },
                new Genre { GenreId = 8, GenreName = "Bildungsroman" },
                new Genre { GenreId = 9, GenreName = "Dystopian" },
                new Genre { GenreId = 10, GenreName = "Horror" },
                new Genre { GenreId = 11, GenreName = "Political fiction" },
                new Genre { GenreId = 12, GenreName = "Social novel" },
                new Genre { GenreId = 13, GenreName = "Southern Gothic" },
                new Genre { GenreId = 14, GenreName = "Historical fiction" }
                );

            _modelBuilder.Entity<BookGenre>().HasData(
                new BookGenre { BookId = 1, GenreId = 1 },
                new BookGenre { BookId = 2, GenreId = 2 },
                new BookGenre { BookId = 2, GenreId = 9 },
                new BookGenre { BookId = 3, GenreId = 3 },
                new BookGenre { BookId = 4, GenreId = 5 },
                new BookGenre { BookId = 5, GenreId = 8 },
                new BookGenre { BookId = 5, GenreId = 6 },
                new BookGenre { BookId = 5, GenreId = 7 },
                new BookGenre { BookId = 6, GenreId = 8 },
                new BookGenre { BookId = 6, GenreId = 12 },
                new BookGenre { BookId = 7, GenreId = 5 },
                new BookGenre { BookId = 9, GenreId = 12 },
                new BookGenre { BookId = 8, GenreId = 9 },
                new BookGenre { BookId = 8, GenreId = 10 },
                new BookGenre { BookId = 8, GenreId = 11 },
                new BookGenre { BookId = 10, GenreId = 4 },
                new BookGenre { BookId = 10, GenreId = 3 }
                );
        }
    }
}
