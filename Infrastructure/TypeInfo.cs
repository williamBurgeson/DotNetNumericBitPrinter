namespace DotNetNumericBitPrinter.Infrastructure
{
    public class TypeInfo
    {
        public required string Alias { get; init; }
        public required Type TargetType { get; init; }
        public required int Size { get; init; }
        public required bool IsSigned { get; init; }
        public required bool IsFractional { get; init; }
    }
}
