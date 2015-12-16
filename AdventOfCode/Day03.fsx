#load "Day03.fs"

open Day03

type ElfDirection = 
    | Up
    | Down
    | Left
    | Right

let parsedDirections = 
    directionsList |> Seq.map (fun c -> 
                          match c with
                          | '^' -> Up
                          | 'v' -> Down
                          | '<' -> Left
                          | '>' -> Right)

let startPoint = (0, 0)

let followDirection direction = 
    match direction with
    | Up -> (0, 1)
    | Down -> (0, -1)
    | Left -> (-1, 0)
    | Right -> (1, 0)

let combineDirections (x1, y1) (x2, y2) = (x1 + x2, y1 + y2)

parsedDirections
|> Seq.map followDirection
|> Seq.scan combineDirections startPoint
|> Seq.distinct
|> Seq.length
|> printf "%i"

let splitList list = List.foldBack (fun x (l, r) -> x :: r, l) list ([], [])

let splitDirections = 
    parsedDirections
    |> Seq.toList
    |> splitList

let takeDirections x = 
        x
        |> List.map followDirection
        |> List.scan combineDirections startPoint

splitDirections |> fun (s, rs) -> 
    List.append (s |> takeDirections) (rs |> takeDirections)
    |> List.distinct
    |> List.length
    |> printf "%i"