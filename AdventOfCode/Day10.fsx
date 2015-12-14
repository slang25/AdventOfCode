let input = "1113122113"

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

let onePass (s : seq<char>) = 
    s
    |> grouped
    |> Seq.map (fun (c, n) -> 
           match n with
           | x when x > 9 -> failwith "oh teh noes"
           | _ -> (c, n))
    |> Seq.collect (fun (c, n) -> 
           seq { 
               yield char (n + 48)
               yield c
           })

let multiPass a b = 
    let rec loop acc counter = 
        if counter > 0 then loop (onePass acc) (counter - 1)
        else acc
    loop a b

let something = input.ToCharArray() |> Seq.ofArray

multiPass something 50
|> Seq.length
|> printf "%i"
