namespace TodoMvc.Models.Csv
{
    /// (Title, DueDate).
    public class TodoCsvRow
    {
        public string Title { get; set; } = string.Empty;
        // Accepts blank values.
        public string? DueDate { get; set; }
    }
}
