#load "Day12.fs"
#r "..\packages\FSharp.Data.2.2.5\lib\portable-net40+sl5+wp8+win8\FSharp.Data.dll"

open Day12
open FSharp.Data;

let rec numbersOnly = function
    | JsonValue.Number  n -> seq [n]
    | JsonValue.Array  a -> a |> Seq.collect numbersOnly
    | JsonValue.Record r -> r |> Seq.collect (snd >> numbersOnly)
     | _ -> seq []

