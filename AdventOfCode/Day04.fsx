open System.Security.Cryptography
open System.Text
open System

let MD5 = new MD5CryptoServiceProvider()
let alignMD5 (md : string) = md.Replace("-", "").ToLower()

let md5 (s : string) = 
    s
    |> Encoding.UTF8.GetBytes
    |> MD5.ComputeHash
    |> BitConverter.ToString
    |> alignMD5

let key = "bgvyzdsvfsdffsd"

let result = 
    Seq.initInfinite id
    |> Seq.map (fun x -> x, sprintf "%s%i" key x)
    |> Seq.map (fun (i, x) -> i, x |> md5)
    |> Seq.find (fun (_, x) -> x.StartsWith "00000")
    |> fun (i, _) -> printf "%i" i
