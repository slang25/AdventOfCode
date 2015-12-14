// WIP just playing atm

let input = "toggle 237,91 through 528,164"

type Command =
    | Toggle
    | TurnOn
    | TurnOff

let x = match input with
        | c when c.StartsWith("toggle") -> Toggle
        | c when c.StartsWith("turn on") -> TurnOn
        | c when c.StartsWith("turn off") -> TurnOff

let coords = input.Split(" through ") 
  |> Array.collect (fun (s:string) -> s.Split(','))
  |> Array.map (fun (s:string) -> s.Trim("abcdefghijklmnopqrstuvwxyz ")
  |> Array.map int
  
let grid = Array2D.create 10 10 (byte 0)

grid.[0,0] <- (grid.[0,0] ||| byte 1)


