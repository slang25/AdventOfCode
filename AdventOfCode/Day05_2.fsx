#load "Day05.fs"

open Day05

let lines = input.Split([| '\n' |])

let check1 (s : string) = 
    s
    |> Seq.windowed 3
    |> Seq.exists (fun l -> (l |> Array.item 0) = (l |> Array.item 2))

let grouped input =
    input
    |> Seq.fold (fun acc x ->
        match acc with
        | (x', n)::tl when x = x' ->
            (x', n+1)::tl
        | _ -> (x, 1)::acc) []
    |> Seq.sortByDescending snd

let stringToGrouped (s : string) = 
    s
    |> grouped

let hasDuplicates (s : seq<_>) = 
    s
    |> Seq.toList
    |> fun (l : list<_>) -> 
        ((l
          |> List.distinct
          |> List.length)
         <> (l |> List.length))

let check2FromGrouped (l : seq<char * int>) = 
    l |> Seq.cache
    |> Seq.exists (fun (_, n) -> n > 3)
    || l
       |> Seq.map fst
       |> Seq.windowed 2
       |> hasDuplicates
    || l
       |> Seq.filter (fun (_, n) -> n > 1)
       |> Seq.map fst
       |> hasDuplicates

let check2 (s : string) = 
    s
    |> stringToGrouped
    |> check2FromGrouped

let allChecks (s : string) = check1 s && check2 s

lines
|> Seq.filter allChecks
|> Seq.length
|> printf "%i"
