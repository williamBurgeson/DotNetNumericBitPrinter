using System.Reflection;

namespace DotNetNumericBitPrinter.Infrastructure
{
    internal static class SupportedTypes
    {
        public static TypeInfo @sbyte = new()
        {
            Alias = nameof(@sbyte),
            TargetType = typeof(sbyte),
            Size = sizeof(sbyte),
            IsSigned = true,
            IsFractional = false
        };

        public static TypeInfo @byte = new()
        {
            Alias = nameof(@byte),
            TargetType = typeof(byte),
            Size = sizeof(byte),
            IsSigned = false,
            IsFractional = false
        };

        public static TypeInfo @short = new()
        {
            Alias = nameof(@short),
            TargetType = typeof(short),
            Size = sizeof(short),
            IsSigned = true,
            IsFractional = false
        };

        public static TypeInfo @ushort = new()
        {
            Alias = nameof(@ushort),
            TargetType = typeof(ushort),
            Size = sizeof(ushort),
            IsSigned = false,
            IsFractional = false
        };

        public static TypeInfo @int = new()
        {
            Alias = nameof(@int),
            TargetType = typeof(int),
            Size = sizeof(int),
            IsSigned = true,
            IsFractional = false
        };

        public static TypeInfo @uint = new()
        {
            Alias = nameof(@uint),
            TargetType = typeof(ushort),
            Size= sizeof(ushort),
            IsSigned = false,
            IsFractional = false
        };

        public static TypeInfo @long = new()
        {
            Alias = nameof(@long),
            TargetType = typeof(long),
            Size = sizeof(long),
            IsSigned = true,
            IsFractional = false
        };

        public static TypeInfo @ulong = new()
        {
            Alias = nameof(@ulong),
            TargetType = typeof(ulong),
            Size = sizeof(ulong),
            IsSigned = false,
            IsFractional = false
        };

        public static TypeInfo @float = new()
        {
            Alias = nameof(@float),
            TargetType = typeof(float),
            Size = sizeof(float),
            IsSigned = true,
            IsFractional = true
        };

        public static TypeInfo @double = new()
        {
            Alias = nameof(@double),
            TargetType = typeof(double),
            Size = sizeof(double),
            IsSigned = true,
            IsFractional = true
        };

        public static TypeInfo @decimal = new()
        {
            Alias = nameof(@decimal),
            TargetType = typeof(decimal),
            Size = sizeof(decimal),
            IsSigned = true,
            IsFractional = true
        };

        public static TypeInfo[] All =>
        [
            @byte,
        @sbyte,
        @short,
        @ushort,
        @int,
        @uint,
        @long,
        @ulong,
        @float,
        @double,
        @decimal
        ];

        public static class Names
        {
            public const string @byte = nameof(@byte);
            public const string @sbyte = nameof(@sbyte);
            public const string @short = nameof(@short);
            public const string @ushort = nameof(@ushort);
            public const string @int = nameof(@int);
            public const string @uint = nameof(@uint);
            public const string @long = nameof(@long);
            public const string @ulong = nameof(@ulong);
            public const string @float = nameof(@float);
            public const string @double = nameof(@double);
            public const string @decimal = nameof(@decimal);
        }
    }
}
