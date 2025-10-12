
namespace DotNetNumericBitPrinter.Infrastructure
{
    public record ResultOutput(object OriginalValue, 
        string BinaryRepresentation, 
        string HexRepresentation, 
        string DecimalRepresentation)
    { }
}
