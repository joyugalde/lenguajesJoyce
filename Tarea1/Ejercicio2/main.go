package main

import "fmt"

func figura(num int) {
	asteriscos := 1
	espacio := num / 2

	for i := 0; i < num; i++ {
		for j := 0; j < espacio; j++ {
			fmt.Print(" ")
		}
		for j := 0; j < asteriscos; j++ {
			fmt.Print("* ")
		}
		fmt.Println()

		if i < num/2 {
			espacio--
			asteriscos += 2
		} else {
			espacio++
			asteriscos -= 2
		}
	}
}

func main() {
	numElementos := 5 // Cantidad de elementos en la línea del centro (impar)
	figura(numElementos)
}
