using System.Reflection;
using System.Text;

namespace DotNetNumericBitPrinter.Infrastructure
{
    internal static class ByteFormatter
    {
        const string HEX_FORMAT = "x2", BINARY_FORMAT = "b8";

        public static ResultOutput GetResultOutput(object value, TypeInfo typeInfo)
        {
            string binaryRepresentation = GetRepresentation(value, typeInfo, hex: false);
            string hexRepresentation = GetRepresentation(value, typeInfo, hex: true);

            return new ResultOutput(value, binaryRepresentation, hexRepresentation, value.ToString() ?? string.Empty);
        }

        private static string GetRepresentation(object value, TypeInfo typeInfo, bool hex)
        {
            string formatter = hex ? HEX_FORMAT : BINARY_FORMAT;

            switch (typeInfo.Alias)
            {
                case SupportedTypes.Names.@sbyte:
                    sbyte sbyteValue = (sbyte)value;
                    return sbyteValue.ToString(formatter);
                case SupportedTypes.Names.@byte:
                    byte byteValue = (byte)value;
                    return byteValue.ToString(formatter);
                case SupportedTypes.Names.@short:
                    short shortValue = (short)value;
                    var rawBytesFromShort = BitConverter.GetBytes(shortValue);
                    rawBytesFromShort = NormaliseByteOrder(rawBytesFromShort);
                    return RenderBytes(rawBytesFromShort, hex);
                case SupportedTypes.Names.@ushort:
                    ushort ushortValue = (ushort)value;
                    var rawBytesFromUshort = BitConverter.GetBytes(ushortValue);
                    rawBytesFromUshort = NormaliseByteOrder(rawBytesFromUshort);
                    return RenderBytes(rawBytesFromUshort, hex);
                case SupportedTypes.Names.@int:
                    int intValue = (int)value;
                    var rawBytesFromInt = BitConverter.GetBytes(intValue);
                    rawBytesFromInt = NormaliseByteOrder(rawBytesFromInt);
                    return RenderBytes(rawBytesFromInt, hex);
                case SupportedTypes.Names.@uint:
                    uint uintValue = (uint)value;
                    var rawBytesFromUint = BitConverter.GetBytes(uintValue);
                    rawBytesFromUint = NormaliseByteOrder(rawBytesFromUint);
                    return RenderBytes(rawBytesFromUint, hex);
                case SupportedTypes.Names.@long:
                    long longValue = (long)value;
                    var rawBytesFromLong = BitConverter.GetBytes(longValue);
                    rawBytesFromLong = NormaliseByteOrder(rawBytesFromLong);
                    return RenderBytes(rawBytesFromLong, hex);
                case SupportedTypes.Names.@ulong:
                    ulong ulongValue = (ulong)value;
                    var rawBytesFromUlong = BitConverter.GetBytes(ulongValue);
                    rawBytesFromUlong = NormaliseByteOrder(rawBytesFromUlong);
                    return RenderBytes(rawBytesFromUlong, hex);
                case SupportedTypes.Names.@float:
                    float floatValue = (float)value;
                    var rawBytesFromFloat = BitConverter.GetBytes(floatValue);
                    rawBytesFromFloat = NormaliseByteOrder(rawBytesFromFloat);
                    return RenderBytes(rawBytesFromFloat, hex);
                case SupportedTypes.Names.@double:
                    double doubleValue = (double)value;
                    var rawBytesFromDouble = BitConverter.GetBytes(doubleValue);
                    rawBytesFromDouble = NormaliseByteOrder(rawBytesFromDouble);
                    return RenderBytes(rawBytesFromDouble, hex);
                case SupportedTypes.Names.@decimal:
                    decimal decimalValue = (decimal)value;
                    var intsFromDec = decimal.GetBits(decimalValue);
                    if (BitConverter.IsLittleEndian)
                    {
                        intsFromDec = intsFromDec.Reverse().ToArray();
                    }

                    StringBuilder decSb = new StringBuilder();

                    for (int i = 0; i < intsFromDec.Length; i++)
                    {
                        decSb.Append(GetRepresentation(intsFromDec[i], SupportedTypes.@int, hex));
                    }

                    return decSb.ToString();
                default:
                    return string.Format(Messages.InvalidTypeNameMessage, typeInfo.Alias);
            }
        }

        private static string RenderBytes(byte[] bytes, bool hex)
        {
            string formatter = hex ? HEX_FORMAT : BINARY_FORMAT;

            string spacerFor1 = hex ? string.Empty : " "; // spacer entre 2 octets pour binaire, pas pour hex
            string spacerFor2 = " ";

            if (bytes.Length == 0)
                return string.Empty;

            if (bytes.Length == 1)
                return bytes[0].ToString(formatter);

            var sb = new StringBuilder();

            if (bytes.Length %  2 == 1)
            {
                sb.Append(bytes[0].ToString(formatter));
                bytes = [.. bytes.Skip(1)];
            }

            for (int i = 0; i <= bytes.Length - 1; i+=2)
            {
                sb.Append(bytes[i].ToString(formatter));
                sb.Append(spacerFor1);
                sb.Append(bytes[i + 1].ToString(formatter));
                sb.Append(spacerFor2);
            }

            return sb.ToString();
        }

        private static byte[] NormaliseByteOrder(byte[] inBytes)
        {
            var outBytes = new byte[inBytes.Length];
            inBytes.CopyTo(outBytes, 0);

            if (BitConverter.IsLittleEndian)
                outBytes = outBytes.Reverse().ToArray();

            return outBytes;
        }
    }
}
