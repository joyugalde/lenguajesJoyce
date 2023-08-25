package main

import (
	"fmt"
	"strings"
)

func contarTexto() {
	text := "Haga un programa \n que cuente e indique el número \n de caracteres, el número de palabras \n y lineas"

	// Contadores para caracteres, palabras y líneas
	caracteres := 0
	palabras := 0
	lineas := 0

	// Dividir el texto en líneas
	lineass := strings.Split(text, "\n")
	lineas = len(lineass)

	// Contar caracteres y palabras en cada línea
	for _, linea := range lineass {
		caracteres += len(linea)
		palabra := strings.Fields(linea)
		palabras += len(palabra)
	}

	// Imprimir los resultados
	fmt.Printf("Número de caracteres: %d\n", caracteres)
	fmt.Printf("Número de palabras: %d\n", palabras)
	fmt.Printf("Número de líneas: %d\n", lineas)
}

func main() {
	contarTexto()
}
