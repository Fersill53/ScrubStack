namespace ScrubStack.Data.Models
{
    public class PreferenceCard
    {
        public int Id { get; set; }
        public string SurgeonName { get; set; }
        public string ProcedureName { get; set; }
        public List<string> Instruments { get; set; } = new();
    }
}
