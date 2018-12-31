// Learn more about F# at http://fsharp.org

open System

open MathFunctions

[<EntryPoint>]
let main argv =
    Console.WriteLine("Hello World from F#!")
    Console.WriteLine("{0}", multiply 5 2)
    Console.WriteLine("{0}", divide 1 0)
    Console.WriteLine("{0}", raisetopower 10 2)
    for i = 1 to 10 do
       Console.WriteLine("Fibonacci {0}: {1}", i, FibonacciSequence i)
    Console.ReadKey()
    0 // return an integer exit code
