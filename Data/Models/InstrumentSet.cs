public class InstrumentSet
{
    public int Id { get; set; }
    public string SetName { get; set; }

    public List<Instrument> Instruments { get; set; } = new();
}
