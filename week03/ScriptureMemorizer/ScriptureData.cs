public class ScriptureData
{
    public class ReferenceData
    {
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        public int VerseEnd { get; set; }
    }

    public ReferenceData Reference { get; set; }
    public string Text { get; set; }
}