#load "Day01.fs"

open Day01

input
|> Seq.sumBy (fun c -> 
       match c with
       | ')' -> -1
       | '(' -> +1
       | _ -> 0)
|> printf "%i"