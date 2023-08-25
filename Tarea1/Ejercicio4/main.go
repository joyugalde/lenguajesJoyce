package main

import (
	"fmt"
)

type calzado struct {
	modelo string
	precio int
	talla  int
	stock  int
}

func vender(zapato *calzado) bool {
	if zapato.stock > 0 {
		zapato.stock--
		return true
	}
	return false
}

func main() {
	inventario := []calzado{
		{"Nike", 60000, 42, 5},
		{"Adidas", 55000, 40, 3},
		{"Puma", 50000, 38, 0}, // Sin stock
	}

	// Vender algunos zapatos
	fmt.Println("Inventario inicial:")
	for i, zapato := range inventario {
		fmt.Printf("%d. Modelo: %s, Talla: %d, Precio: %d colones, Stock: %d\n", i+1, zapato.modelo, zapato.talla, zapato.precio, zapato.stock)
	}

	fmt.Println("\nVentas:")
	for i := range inventario {
		if vender(&inventario[i]) {
			fmt.Printf("Venta realizada - Modelo: %s, Talla: %d, Precio: %d colones, Stock restante: %d\n", inventario[i].modelo, inventario[i].talla, inventario[i].precio, inventario[i].stock)
		} else {
			fmt.Printf("No se puede realizar la venta - Modelo: %s, Talla: %d\n", inventario[i].modelo, inventario[i].talla)
		}
	}
}
