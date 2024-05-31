namespace proiect.Models
{
    public class FilterCriteria
    {
        public string Nume { get; set; }
        public decimal? PretMin { get; set; }
        public decimal? PretMax { get; set; }
        public int? MemorieMin { get; set; }
        public int? MemorieMax { get; set; }
        public string Dimensiune { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
