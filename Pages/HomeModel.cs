using DotNetNumericBitPrinter.Infrastructure;
using System.Collections;
using System.Collections.Generic;

namespace DotNetNumericBitPrinter.Pages
{
    public class HomeModel
    {
        public string Datatype { get; set; } = string.Empty;

        public string RawValuesString { get; set; } = string.Empty;

        public List<ResultOutput> ValueResults { get; set; } = new();

        public List<string> Errors { get; set;} = new();
    }
}
