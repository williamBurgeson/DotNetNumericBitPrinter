using System.Collections;

namespace DotNetNumericBitPrinter.Infrastructure
{
    public static class ValuesParser
    {
        public static string[] TokeniseValues(string rawInput) =>
            (rawInput ?? string.Empty)
                .Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .SelectMany(line => line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
                .Select(val => val.Trim())
                .ToArray();

        public static List<object> TryParseValues(TypeInfo selectedType, string[] rawStringValues, 
            out List<string> errors)
        {
            List<object> values = new();
            errors = new List<string>(); 

            foreach (string valueString in rawStringValues)
            {
                object? parsedValue = null;

                if (TryParseValue(valueString, selectedType, out parsedValue))
                {
                    values.Add(parsedValue);
                }
                else
                {
                    errors.Add(string.Format(Messages.InvalidValueMessage, valueString, selectedType.Alias));
                }
            }

            return values;
        }
        private static bool TryParseValue(string valueString, TypeInfo selectedType, out object? parsedValue)
        {
            bool parseSuccessful = false;

            switch (selectedType.Alias)
            {
                case SupportedTypes.Names.@sbyte:
                    parseSuccessful = sbyte.TryParse(valueString, out sbyte sbyteResult);
                    parsedValue = parseSuccessful ? sbyteResult : null;
                    break;
                case SupportedTypes.Names.@byte:
                    parseSuccessful = byte.TryParse(valueString, out byte byteResult);
                    parsedValue = parseSuccessful ? byteResult : null;
                    break;
                case SupportedTypes.Names.@short:
                    parseSuccessful = short.TryParse(valueString, out short shortResult);
                    parsedValue = parseSuccessful ? shortResult : null;
                    break;
                case SupportedTypes.Names.@ushort:
                    parseSuccessful = ushort.TryParse(valueString, out ushort ushortResult);
                    parsedValue = parseSuccessful ? ushortResult : null;
                    break;
                case SupportedTypes.Names.@int:
                    parseSuccessful = int.TryParse(valueString, out int intResult);
                    parsedValue = parseSuccessful ? intResult : null;
                    break;
                case SupportedTypes.Names.@uint:
                    parseSuccessful = uint.TryParse(valueString, out uint uintResult);
                    parsedValue = parseSuccessful ? uintResult : null;
                    break;
                case SupportedTypes.Names.@long:
                    parseSuccessful = long.TryParse(valueString, out long longResult);
                    parsedValue = parseSuccessful ? longResult : null;
                    break;
                case SupportedTypes.Names.@ulong:
                    parseSuccessful = ulong.TryParse(valueString, out ulong ulongResult);
                    parsedValue = parseSuccessful ? ulongResult : null;
                    break;
                case SupportedTypes.Names.@float:
                    parseSuccessful = float.TryParse(valueString, out float floatResult);
                    parsedValue = parseSuccessful ? floatResult : null;
                    break;
                case SupportedTypes.Names.@double:
                    parseSuccessful = double.TryParse(valueString, out double doubleResult);
                    parsedValue = parseSuccessful ? doubleResult : null;
                    break;
                case SupportedTypes.Names.@decimal:
                    parseSuccessful = decimal.TryParse(valueString, out decimal decimalResult);
                    parsedValue = parseSuccessful ? decimalResult : null;
                    break;
                default:
                    parsedValue = null;
                    break;
            }

            return parseSuccessful;
        }

        public static TypeInfo GetSelectedType(string selectedTypeName)
        {
            TypeInfo? selectedType = null;

            if (!SupportedTypes.All.Select(x => x.Alias).Contains(selectedTypeName))
            {
                throw new ArgumentException(string.Format(Messages.InvalidTypeNameMessage, selectedTypeName));
            }

            selectedType = SupportedTypes.All.First(x => x.Alias == selectedTypeName);

            return selectedType;
        }
    }
}
