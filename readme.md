.NET Numeric Bit Printer

This is a tool implemented as a Blazor WASM app which allows the user to select one of the basic C#.net numeric types (int, double, decimal etc - including signed and unsigned types), then to enter values in the text area, separated either by spaces or new lines (or both) and to see the bits representing that value, both as hexidecimal and binary (formatted with spaces for readability). In French-speaking locales (sorry, haven't tested this in Quebec or Wallonia), labels are in French and the app expects a comma instead of decimal point - that's just the default behaviour of the TryParse method for the types.

It was particularly interesting while testing to note the binary representation of the floating point types. This functionality is documented so I won't explain too much here, however in broad terms, the left-most bit is set to 0 for positive values and 1 for negative values, the next X bits represent the exponent, where X is a number dependent on the data type (again, consult the docs), and the mantissa make the rest. Try entering NaN, or 0 and -0 and note the representation, as well as other more regular values. The app also supports the decimal types which is fairly different from float and double. Have a play and see how different values are stored. Integer values are probably more well-known in terms of the principles of storage - 2s complement for negative values.

I initially built the engine as a console app - it was so small that I just created the helper classes as static classes as I didn't plan to use DI, just to get the thing done. On reflection I felt it would be better to implement the app as a Blazor WASM app as I can host in gitlabs, which I will do after writing this ReadMe. Considerably easier than downloading the code to the run the thing! I converted the static worker classes to DI-able to make the code a little nicer and so that anhybody reviewing the code doesn-t think I don't know how to use DI!!

It was built using VS 2026 in October 2025 and therefore the Insiders edition, with a prerelease build of .NET 10. Given it's pure WASM it should work fine as the relevant runtime is downloaded into the browser together with it.

For front end SPA apps I would often go to Angular or Reabt, but clearly given the entire point is to dig into .NET internals this by definition wouldn't work in JS.

Happy bitting!
