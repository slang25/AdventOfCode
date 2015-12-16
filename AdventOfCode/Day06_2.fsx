#load "Day06.fs"

open System
open Day06

let lines = input.Split([| '\n' |])

let grid = Array2D.create 1000 1000 0

type Command = 
    | Toggle
    | TurnOn
    | TurnOff

let parseCommand (line : string) = 
    match line with
    | c when c.StartsWith("toggle") -> Toggle
    | c when c.StartsWith("turn on") -> TurnOn
    | c when c.StartsWith("turn off") -> TurnOff

let coords (line : string) = 
    line.Split([| "toggle"; "turn on"; "turn off"; "through" |], StringSplitOptions.RemoveEmptyEntries) |> Array.map (fun (s : string) -> 
                                                                                                                s.Trim()
                                                                                                                 .Split(',') |> (fun x -> 
                                                                                                                x
                                                                                                                |> Array.item 
                                                                                                                       0
                                                                                                                |> int, 
                                                                                                                x
                                                                                                                |> Array.item 
                                                                                                                       1
                                                                                                                |> int))

let runCommand (command, (x1, y1), (x2, y2)) = 
    for x in x1..x2 do
        for y in y1..y2 do
            match command with
            | TurnOn -> grid.[x, y] <- grid.[x, y] + 1
            | TurnOff -> grid.[x, y] <- max 0 (grid.[x, y] - 1)
            | Toggle -> grid.[x, y] <- grid.[x, y] + 2

lines |> Seq.iter (fun x -> runCommand (x |> parseCommand, (x |> coords |> Array.item 0), (x |> coords |> Array.item 1)))

let mutable sum = 0
grid |> Array2D.iter (fun c -> sum <- sum + c)

printf "%i" sum