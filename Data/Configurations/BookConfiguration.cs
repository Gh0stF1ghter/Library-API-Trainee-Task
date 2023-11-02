using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(b => b.BookId);
            builder
                .Property(b => b.BookId)
                .UseIdentityColumn();
            builder
                .HasIndex(b => b.BookISBN)
                .IsUnique();
            builder
                .Property(b => b.BookName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(b => b.BookISBN)
                .IsRequired()
                .HasMaxLength(13);
            builder
                .Property(b => b.BookTakeDate)
                .HasColumnType("date");
            builder
                .Property(b => b.BookReturnDate)
                .HasColumnType("date");
            builder
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.BookAuthorId);
            builder
                .HasMany(b => b.BookGenres)
                .WithOne(bg => bg.Book)
                .HasForeignKey(bg => bg.BookId);
            builder
                .ToTable("Book");
            builder
                .HasData(
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
        }
    }
}
