namespace MyCar.Models
{
    public class EmailModel
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Receiver { get; set; } = string.Empty;
        public int CodeValidation { get; set; }
    }
}
