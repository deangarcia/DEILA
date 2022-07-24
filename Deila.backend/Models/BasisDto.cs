namespace deila.backend.Models
{
    public class BasisBaseDto
    {
        public string Category { get; set; } = string.Empty;
        public int Incidents { get; set; } = 0;

    }
    public class BasisDto : BasisBaseDto
    {
        public int Id { get; set; }
    }
    public class BasisCreateDto : BasisBaseDto { }
    public class BasisUpdateDto : BasisBaseDto { }
}
