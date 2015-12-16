#load "Day05.fs"

open Day05

let lines = input.Split([| '\n' |])
let vowels = "aeiou".ToCharArray()

let check1 (s : string) = 
    s
    |> Seq.filter (fun c -> Seq.contains c vowels)
    |> Seq.length
    |> fun n -> (n > 2)

let letters = [ 'a'..'z' ]

let check2 (s : string) = 
    letters
    |> Seq.map (fun x -> System.String.Concat (x, x))
    |> Seq.exists s.Contains

let forbiddenContents = [ "ab"; "cd"; "pq"; "xy" ]

let check3 (s : string) = 
    forbiddenContents
    |> Seq.forall (s.Contains >> not)

let allChecks (s : string) = check1 s && check2 s && check3 s

lines
|> Seq.filter allChecks
|> Seq.length
|> printf "%i"
