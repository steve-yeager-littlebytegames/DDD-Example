namespace DddExample.Domain.General
{
    public readonly struct Range
    {
        public int Min { get; }
        public int Max { get; }

        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public bool IsValid(int value) => value >= Min && value <= Max;
    }
}