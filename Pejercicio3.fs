// For more information see https://aka.ms/fsharp-console-apps 
// 3)	Realizar una función que obtenga el n-esimo elemento de una lista pero utilizando solamente map 
//(sin recursión). 

let n_esimo n lista =
    let indices = [0..List.length lista - 1]
    let elementos = List.map2 (fun idx elem -> if idx = n then Some elem else None) indices lista
    match List.choose id elementos with
    | [] -> false
    | [x] -> true
    | _ -> false

let resultado1 = n_esimo 2 [1; 2; 3; 4; 5] 
let resultado2 = n_esimo 3 [1; 2; 3; 4; 5] 
let resultado3 = n_esimo 6 [1; 2; 3; 4; 5] 

printfn "%A" resultado1
printfn "%A" resultado2
printfn "%A" resultado3