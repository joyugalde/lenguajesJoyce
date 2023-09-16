//4) Modifique l código de profundidad visto en clase e implemente una función que encuentre el camino más corto en la búsqueda en profundidad basándose en la
//sumatoria de pesos. Implica cambiar la búsqueda en profundidad para que se lleven los pesos además de los vértices.
let grafo = [
    (["i"], ["a"; "b"], ["3"; "6"]);
    (["a"], ["i"; "c"; "d"], ["3"; "2"; "4"]);
    (["b"], ["i"; "c"; "d"], ["6"; "1"; "5"]);
    (["c"], ["a"; "b"; "x"], ["2"; "1"; "3"]);
    (["d"], ["a"; "b"; "f"], ["4"; "5"; "2"]);
    (["f"], ["d"], ["2"]);
    (["x"], ["c"], ["3"]);
]
let rec vecinos_con_pesos nodo grafo =
    match grafo with
    | [] -> []
    | (head, neighbors) :: rest ->
        if head = nodo then neighbors
        else vecinos_con_pesos nodo rest

let extender_con_pesos ruta grafo = 
    List.filter
        (fun (x, _) -> not (miembro x ruta))
        (List.map  (fun (x, peso) -> (x, peso)) (vecinos_con_pesos (fst (List.head ruta)) grafo))

let rec prof2_con_pesos ini fin grafo =
    let rec prof_aux_con_pesos fin ruta peso grafo =
        if List.isEmpty ruta then [], 0 // No se encontró una ruta
        elif (fst (List.head ruta)) = fin then
            let peso_ruta = List.foldBack (fun (_, peso) acc -> peso + acc) ruta 0
            ruta, peso_ruta
        else
            let extensiones = extender_con_pesos (List.head ruta) grafo
            let rutas_extendidas = List.map (fun (x, peso) -> (x, peso + snd (List.head ruta))) extensiones
            let rutas_filtradas = List.filter (fun (x, _) -> (x <> "")) rutas_extendidas
            let rutas_ordenadas = List.sortBy snd rutas_filtradas
            prof_aux_con_pesos fin (rutas_ordenadas @ (List.tail ruta)) grafo
    let ruta, peso = prof_aux_con_pesos fin [(ini, 0)] grafo
    List.map fst ruta, peso
