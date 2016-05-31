namespace Playground.Models
{
    public struct Indices
    {
        public uint Start { get; set; }
        public uint End { get; set; }
        
        public override string ToString()
        {
            return string.Format("Start: {0}, End: {1}. ", this.Start, this.End);
        }
    }
}