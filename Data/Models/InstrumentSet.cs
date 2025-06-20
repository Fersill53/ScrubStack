public class InstrumentSet
{
    public int Id { get; set; }
    public string SetName { get; set; } = string.Empty;

    public List<Instrument> Instruments { get; set; } = new();
}
