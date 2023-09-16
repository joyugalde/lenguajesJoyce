// 5)	Construya un programa que resuelva el problema de encontrar la o las rutas de un laberinto con datos quemados.
// Dicho problema se puede resolver exactamente igual que un problema de grafos, entendiendo que cada casilla del laberinto puede verse como un “vecino” adjunto de otra,
// siempre que no haya pared

let grafo1 = [
    ("Inicio", ["2"]);
    ("2", ["3"; "8"]);
    ("3", ["2"; "9"; "4"]);
    ("4", ["3"; "10"]);
    ("5", ["11"; "6"]);
    ("6", ["5"]);
    ("7", ["13"; "1"]);
    ("8", ["2"; "9"]);
    ("9", ["8"; "3"]);
    ("10", ["4"; "16"]);
    ("11", ["17"; "5"]);
    ("12", ["18"])
    ("13", ["14"; "7"; "1"]);
    ("14", ["15"; "20"; "13"]);
    ("15", ["21"; "14"]);
    ("16", ["10"; "22"]);
    ("17", ["23"; "11"]);
    ("18", ["24"; "12"]);
    ("19", ["25"]);
    ("20", ["14"; "26"]);
    ("21", ["22"; "15"]);
    ("22", ["16"; "21"]);
    ("23", ["29"; "17"]);
    ("24", ["30"; "18"]);
    ("25", ["31"; "19"]);
    ("26", ["20"; "27"]);
    ("27", ["26"; "28"]);
    ("28", ["27"; "34"; "29"]);
    ("29", ["28"; "23"]);
    ("30", ["36"; "24"]);
    ("31", ["32"; "25"]);
    ("32", ["33"; "31"; "Fin"]);
    ("33", ["34"; "32"]);
    ("34", ["28"; "33"; "35"]);
    ("35", ["34"; "36"]);
    ("36", ["35"; "30"]);
    ("1", ["7";]);
    ("Fin", ["32"]);  
]
let grafo2 = [
    ("Inicio", ["2"]);
    ("2", ["3"; "8"]);
    ("3", ["2"; "9"; "4"]);
    ("4", ["3"; "10"]);
    ("5", ["11"; "6"]);
    ("6", ["5"]);
    ("7", ["13"; "1"]);
    ("8", ["2"; "9"]);
    ("9", ["8"; "3"]);
    ("10", ["4"; "16"]);
    ("11", ["17"; "5"]);
    ("12", ["18"])
    ("13", ["14"; "7"; "1"]);
    ("14", ["15"; "20"; "13"]);
    ("15", ["21"; "14"]);
    ("16", ["10"; "22"]);
    ("17", ["23"; "11"]);
    ("18", ["24"; "12"]);
    ("19", ["25"]);
    ("20", ["14"; "26"]);
    ("21", ["22"; "15"]); 
    ("22", ["16"; "21"; "28"]);
    ("23", ["29"; "17"]);
    ("24", ["30"; "18"]);
    ("25", ["31"; "19"]);
    ("26", ["20"; "27"]);
    ("27", ["26"; "28"]);
    ("28", ["27"; "34"; "29"; "22"]);
    ("29", ["28"; "23"]);
    ("30", ["36"; "24"]);
    ("31", ["32"; "25"]);
    ("32", ["33"; "31"; "Fin"]);
    ("33", ["34"; "32"]);
    ("34", ["28"; "33"; "35"]);
    ("35", ["34"; "36"]);
    ("36", ["35"; "30"]);
    ("1", ["7";]);
    ("Fin", ["32"]);    
]
//--------------------------------------------------------------------------------------------
let existeEnLista elem lista =
    List.exists (fun x -> x = elem) lista

let rec obtenerVecinos nodo grafo =
    match grafo with
    | [ ] -> [ ]
    | (head, neighbors) :: rest ->
        if head = nodo then neighbors
        else obtenerVecinos nodo rest

let extenderRuta ruta grafo = 
    List.filter
        (fun x -> x <> [])
        (List.map  (fun x -> if (existeEnLista x ruta) then [] else x::ruta) (obtenerVecinos (List.head ruta) grafo)) 

let rec profundidad ini fin grafo =
    let rec profundidadAux fin ruta grafo =
        if List.isEmpty ruta then []
        elif (List.head (List.head ruta)) = fin then
            List.rev (List.head ruta) :: profundidadAux fin ((extenderRuta (List.head ruta) grafo) @ (List.tail ruta)) grafo       
        else
            profundidadAux fin ((List.tail ruta) @ (extenderRuta (List.head ruta) grafo)) grafo

    let resultado = profundidadAux fin [[ini]] grafo
    List.iter (fun ruta -> printfn "Ruta: %A" ruta) resultado
    resultado

let rutaOriginal = profundidad "Inicio" "Fin" grafo1
printfn"\n"

let rutaModificada = profundidad "Inicio" "Fin" grafo2
printfn"\n"

let shortestPath ini fin grafo =

    let rec bfs cola visitados =
        match cola with
        | [] -> None 
        | (nodoActual, camino) :: resto ->
            if nodoActual = fin then
                Some (List.rev (nodoActual :: camino)) 
            else

                let vecinos = obtenerVecinos nodoActual grafo

                let nuevasRutas =
                    vecinos
                    |> List.filter (fun vecino -> not (existeEnLista vecino visitados))
                    |> List.map (fun vecino -> (vecino, nodoActual :: camino))
                bfs (resto @ nuevasRutas) (nodoActual :: visitados)

    let colaInicial = [(ini, [])] 
    match bfs colaInicial [] with
    | Some resultadoRuta -> resultadoRuta
    | None -> [] 

let rutaCorta = shortestPath "Inicio" "Fin" grafo1
match rutaCorta with
| [] -> printfn "No se encontró una ruta desde Inicio hasta Fin."
| _ -> printfn "Ruta encontrada: %A" rutaCorta