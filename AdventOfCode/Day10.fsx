let input = "1113122113"

let grouped =
    function
    | [] -> []
    | x :: xs -> 
        ([ (x, 1) ], xs)
        ||> List.fold (fun ((y, c) :: acc) x -> 
                if x = y then (y, c + 1) :: acc
                else (x, 1) :: (y, c) :: acc)
        |> List.rev

let onePass (s : seq<char>) = 
    s |> List.ofSeq
    |> grouped
    // only supporting 1 digit count so that we can easily yield chars for perf
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

multiPass input 50
|> Seq.length
|> printf "%i"
