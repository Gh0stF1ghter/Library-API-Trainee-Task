using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BookTakeDate",
                table: "Book",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookReturnDate",
                table: "Book",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "AuthorId", "AuthorFirstMidName", "AuthorLastName" },
                values: new object[,]
                {
                    { 1, "Douglas", "Adams" },
                    { 2, "Suzanne", "Collins" },
                    { 3, "Dan", "Brown" },
                    { 4, "Joanne", "Rowling" },
                    { 5, "Jerome David", "Salinger" },
                    { 6, "Harper", "Lee" },
                    { 7, "John", "Tolkien" },
                    { 8, "George", "Orwell" },
                    { 9, "Khaled", "Hosseini" },
                    { 10, "Stieg", "Larsson" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { 1, "Science fiction" },
                    { 2, "Action" },
                    { 3, "Thriller" },
                    { 4, "Detective novel" },
                    { 5, "Fantasy" },
                    { 6, "Realism" },
                    { 7, "Satire" },
                    { 8, "Bildungsroman" },
                    { 9, "Dystopian" },
                    { 10, "Horror" },
                    { 11, "Political fiction" },
                    { 12, "Social novel" },
                    { 13, "Southern Gothic" },
                    { 14, "Historical fiction" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookId", "BookAuthorId", "BookDescription", "BookISBN", "BookName", "BookReturnDate", "BookTakeDate" },
                values: new object[,]
                {
                    { 1, 1, "A hilarious science fiction comedy that follows the adventures of Arthur Dent, a hapless human who escapes the destruction of Earth with the help of an alien friend. The book is full of witty humor, absurd situations, and clever references to various aspects of culture and science.", "9780330258641", "The Hitchhiker’s Guide to the Galaxy", null, null },
                    { 2, 2, "A dystopian novel that depicts a brutal reality show where 24 teenagers are forced to fight to the death in a televised arena. The book explores themes of survival, rebellion, and morality through the perspective of Katniss Everdeen, a 16-year-old girl who volunteers to take her sister’s place in the deadly game.", "9780439023528", "The Hunger Games", null, null },
                    { 3, 3, "A thriller that revolves around a murder mystery involving a secret society, a religious conspiracy, and a hidden code in Leonardo da Vinci’s paintings. The book is full of suspense, puzzles, and historical facts that challenge the reader’s knowledge and beliefs.", "978030745454", "The Da Vinci Code", null, null },
                    { 4, 4, "A fantasy novel that introduces the magical world of Harry Potter, a young boy who discovers that he is a wizard and attends Hogwarts School of Witchcraft and Wizardry. The book is full of imagination, adventure, and friendship as Harry learns to master his powers and faces his nemesis, Lord Voldemort.", "9780141950432", "Harry Potter and the Philosopher’s Stone", null, null },
                    { 5, 5, "A classic novel that portrays the alienation and disillusionment of Holden Caulfield, a 17-year-old boy who runs away from his boarding school and wanders around New York City. The book captures the voice and emotions of a troubled teenager who struggles to find meaning and identity in a phony world.", "9791456789012", "The Catcher in the Rye", null, null },
                    { 6, 6, "A Pulitzer Prize-winning novel that depicts the racial injustice and social inequality in the American South during the 1930s. The book is narrated by Scout Finch, a 6-year-old girl who witnesses her father, Atticus Finch, defend a black man accused of raping a white woman in a court trial.", "9780060935467", "To Kill a Mockingbird", null, null },
                    { 7, 7, "An epic fantasy novel that tells the story of Frodo Baggins, a hobbit who inherits a powerful ring from his uncle Bilbo Baggins and embarks on a quest to destroy it in the fires of Mount Doom. The book is set in Middle-earth, a richly detailed world full of elves, dwarves, orcs, and other mythical creatures.", "9790345678904", "The Lord of the Rings", null, null },
                    { 8, 8, "A dystopian novel that depicts a totalitarian society where Big Brother, the leader of the Party, controls every aspect of life through propaganda, surveillance, and censorship. The book follows Winston Smith, a low-ranking member of the Party who secretly rebels against the system by writing a diary and falling in love with Julia.", "9781234567897", "Nineteen Eighty-Four ", null, null },
                    { 9, 9, "A historical fiction novel that traces the friendship and betrayal of Amir and Hassan, two boys from different social classes in Afghanistan. The book spans over three decades of war, violence, and migration as Amir tries to redeem himself for his past sins.", "9780123456789", "The Kite Runner", null, null },
                    { 10, 10, "A crime novel that involves the investigation of a 40-year-old disappearance case by Mikael Blomkvist, a journalist, and Lisbeth Salander, a hacker with a troubled past. The book is full of twists, turns, and secrets that expose the dark side of Swedish society.", "9781594631931", "The Girl with the Dragon Tattoo", null, null }
                });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 10, 3 },
                    { 10, 4 },
                    { 4, 5 },
                    { 7, 5 },
                    { 5, 6 },
                    { 5, 7 },
                    { 5, 8 },
                    { 6, 8 },
                    { 2, 9 },
                    { 8, 9 },
                    { 8, 10 },
                    { 8, 11 },
                    { 6, 12 },
                    { 9, 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 9, 12 });

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "GenreId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "AuthorId",
                keyValue: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookTakeDate",
                table: "Book",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookReturnDate",
                table: "Book",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }
    }
}
