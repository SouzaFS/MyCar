namespace MyCar.DTOs
{
    public class EmailDTO
    {
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Receiver { get; set; } = string.Empty;
        public int CodeValidation { get; set; }
    }
}
