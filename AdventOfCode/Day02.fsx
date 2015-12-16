#load "Day02.fs"

open Day02

let lines = dimensionList.Split([| '\n' |])

let parsedDimensions = 
    lines
    |> Seq.map (fun x -> 
           x.Split('x') |> Seq.map int |> (fun x -> 
           x
           |> Seq.item 0,
           x
           |> Seq.item 1,
           x
           |> Seq.item 2))

let area = (*)
let boxSurface (l, w, h) = 2 * area l w + 2 * area w h + 2 * area h l

let minArea (l, w, h) = 
    [ l; w; h ]
    |> List.sort
    |> List.truncate 2
    |> (fun x -> area (x |> List.item 0) (x |> List.item 1))

let requiredWrappingPapper (l, w, h) = boxSurface (l, w, h) + minArea (l, w, h)

let shortestCircumferance (l, w, h) = 
    [ l; w; h ]
    |> List.sort
    |> List.truncate 2
    |> List.sum
    |> (fun x -> 2 * x)

let volume (l, w, h) = l * w * h
let requiredRibbon (l, w, h) = shortestCircumferance (l, w, h) + volume (l, w, h)

parsedDimensions
|> Seq.map (fun x -> x |> requiredRibbon)
|> Seq.sum
|> printf "%i"