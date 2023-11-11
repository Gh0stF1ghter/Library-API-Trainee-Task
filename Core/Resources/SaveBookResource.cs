namespace Core.Resources
{
    public class SaveBookResource
    {
        public int BookAuthorId { get; set; }

        public string BookName { get; set; } = null!;
        public string BookISBN { get; set; } = null!;
        public string? BookDescription { get; set; }
        public DateTime BookTakeDate { get; set; }
        public DateTime BookReturnDate { get; set; }
    }
}
