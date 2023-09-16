// For more information see https://aka.ms/fsharp-console-apps       
// 1) Realizar ejercicio para desplazar (SHIFT) una lista de elementos n posiciones
// a la izquierda o la derecha según se indique por argumento.

let listaOriginal = [1; 2; 3; 4; 5]
let rec izquierda n lista =
    match n with
    | 0 -> lista
    | _ ->
        match lista with
        | [] -> []
        | hd::tl -> izquierda (n-1) (tl @ [0])
        

let rec derecha n lista =
    match n with
    | 0 -> lista
    | _ ->
        match lista with
        | [] -> []
        | lst ->
            let resto = List.init (List.length lst - 1) (fun i -> List.item i lst)
            derecha (n-1) (0::resto)

let desplazamiento direccion n lista =
    
    match direccion with
    | "izq" ->
         izquierda n lista
    | "der" ->
         derecha n lista
    | _ -> failwith "Dirección no válida"

let finalIzquierda = desplazamiento "izq" 3 listaOriginal
printfn "Desplazamiento a la izquierda 3 posiciones: %A" finalIzquierda

let finalDerecha = desplazamiento "der" 2 listaOriginal
printfn "Desplazamiento a la derecha 2 posiciones: %A" finalDerecha

let finalIzquierdab = desplazamiento "izq" 6 listaOriginal
printfn "Desplazamiento a la izquierda 6 posiciones: %A" finalIzquierdab
