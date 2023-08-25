package main

import "fmt"

func rotarSecuencia(secuencia []string, rotacion int, direccion int) []string {
	length := len(secuencia)
	rotacion = rotacion % length // Manejar rotaciones mayores que la longitud
	if rotacion < 0 {
		rotacion += length
	}

	if direccion == 0 { // rotaciones a la izquierda
		return append(secuencia[rotacion:], secuencia[:rotacion]...)
	} else if direccion == 1 { // rotaciones a la izquierda
		return append(secuencia[length-rotacion:], secuencia[:length-rotacion]...)
	}

	return secuencia
}
func sec() {
	abece := []string{"a", "b", "c", "d", "e", "f", "g", "h"}

	izquierda := rotarSecuencia(abece, 2, 1)
	derecha := rotarSecuencia(abece, 2, 0)

	fmt.Println("Secuencia sin modificar:", abece)
	fmt.Println("Secuencia rotada a la izquierda:", izquierda)
	fmt.Println("Secuencia rotada a la derecha:", derecha)
}

func main() {
	sec()
}
