#load "Day05.fs"

open Day05

let lines = input.Split([| '\n' |])

let fold state value = 
    match state with
    | i :: _ when i = value -> state
    | _ -> value :: state

let check1 (s : string) = 
    s.ToCharArray()
    |> Seq.ofArray
    |> Seq.windowed 3
    |> Seq.exists (fun l -> (l |> Array.item 0) = (l |> Array.item 2))

let grouped (items : seq<_>) = 
    seq { 
        use e = items.GetEnumerator()
        if e.MoveNext() then 
            let prev = ref e.Current
            let count = ref 1
            while e.MoveNext() do
                if e.Current <> !prev then 
                    yield !prev, !count
                    prev := e.Current
                    count := 1
                else incr count
            yield !prev, !count
    }

let stringToGrouped (s : string) = 
    s.ToCharArray()
    |> Seq.ofArray
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
    l
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
|> Array.map allChecks
|> Array.sumBy (fun b -> 
       match b with
       | true -> 1
       | false -> 0)
|> printf "%i"
