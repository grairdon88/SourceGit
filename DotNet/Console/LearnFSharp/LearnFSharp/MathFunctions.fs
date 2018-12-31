module MathFunctions

open System

let multiply num multiplier  =
    num * multiplier

let divide numerator denominator =

    if denominator = 0
        then 0
    else
        numerator / denominator

let raisetopower (number : int32) (powernumber : int32) =
    pown number powernumber

let rec FibonacciSequence n =
    if n < 2 then 1
    else FibonacciSequence (n - 1) + FibonacciSequence (n - 2)