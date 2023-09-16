// For more information see https://aka.ms/fsharp-console-apps  
// 2)	Haciendo uso de la función filter, implemente una función que, a partir de una lista de cadenas de parámetro, 
//filtre aquellas que contengan una subcadena que el usuario indique en otro argumento. 

let sub_cadenas subcadena lista =
    List.filter (fun cadena -> cadena.Contains(subcadena)) lista
let lista = ["la casa"; "el perro"; "pintando la cerca"]
let subcadena = "la"
let resultado = sub_cadenas subcadena lista

printfn "%A" resultado
