#load "Day01.fs"

open Day01

input
|> Seq.map (fun c -> 
       match c with
       | ')' -> -1
       | '(' -> +1
       | _ -> 0)
|> Seq.scan (+) 0
|> Seq.findIndex (fun x -> x < 0)
|> printf "%i"