#load "Day05.fs"

open Day05

let lines = input.Split([| '\n' |])
let vowels = "aeiou".ToCharArray()

let check1 (s : string) = 
    s.ToCharArray()
    |> Array.filter (fun c -> Array.contains c vowels)
    |> Array.length
    |> fun n -> (n > 2)

let letters = [ 'a'..'z' ]

let check2 (s : string) = 
    letters
    |> Seq.ofList
    |> Seq.map (fun x -> 
           [ x; x ]
           |> Array.ofList
           |> System.String.Concat)
    |> Seq.exists s.Contains

let forbiddenContents = [ "ab"; "cd"; "pq"; "xy" ]

let check3 (s : string) = 
    forbiddenContents
    |> List.forall (fun x -> not (s.Contains x))

let allChecks (s : string) = check1 s && check2 s && check3 s

lines
|> Array.map allChecks
|> Array.sumBy (fun b -> 
       match b with
       | true -> 1
       | false -> 0)
|> printf "%i"
