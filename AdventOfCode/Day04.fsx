open System.Security.Cryptography
open System.Text
open System

let MD5 = new MD5CryptoServiceProvider()

let md5 (s : string) = 
    s
    |> Encoding.UTF8.GetBytes
    |> MD5.ComputeHash

let key = "bgvyzdsvfsdffsd"

let result = 
    Seq.initInfinite id
    |> Seq.map (fun x -> x, (sprintf "%s%i" key x) |> md5)
    |> Seq.find (fun (_, x) -> x.[0] = 0uy && x.[1] = 0uy && x.[2] < 16uy)
    |> fst
    |> printf "%i"
