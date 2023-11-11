from datetime import datetime

class Socio:
    def __init__(self, numero_socio, nombre, direccion):
        self.numero_socio = numero_socio
        self.nombre = nombre
        self.direccion = direccion
        self.libros_prestados = []

    def __str__(self):
        return f"Socio: {self.numero_socio}, Nombre: {self.nombre}, Dirección: {self.direccion}"

    def prestar_libro(self, libro):
        if libro.disponible:
            libro.disponible = False
            prestamo = Prestamo(libro, self)
            self.libros_prestados.append(prestamo)
            return True
        else:
            return False

class Libro:
    def __init__(self, codigo, titulo, autor):
        self.codigo = codigo
        self.titulo = titulo
        self.autor = autor
        self.disponible = True

    def __str__(self):
        estado = "Disponible" if self.disponible else "Prestado"
        return f"Libro: {self.titulo}, Autor: {self.autor}, Estado: {estado}"

class Prestamo:
    def __init__(self, libro, socio):
        self.libro = libro
        self.socio = socio
        self.fecha = datetime.now()

# Función para encontrar socios con más de 3 libros prestados
def socios_con_mas_de_3_libros(socios):
    return list(filter(lambda socio: len(socio.libros_prestados) > 3, socios))

# Escenario de uso del sistema
if __name__ == '__main__':
    # Crear socios
    socio1 = Socio(1, "Juan Perez", "123 Calle Principal")
    socio2 = Socio(2, "Maria Garcia", "456 Calle Secundaria")

    # Crear libros
    libro1 = Libro(101, "La Odisea", "Homero")
    libro2 = Libro(102, "1984", "George Orwell")
    libro3 = Libro(103, "El Principito", "Antoine de Saint-Exupéry")
    libro4 = Libro(104, "Cien años de soledad", "Gabriel García Márquez")

    # Prestar libros a socios
    socio1.prestar_libro(libro1)
    socio1.prestar_libro(libro2)
    socio2.prestar_libro(libro3)
    socio2.prestar_libro(libro4)

    # Mostrar información de socios y libros
    print(socio1)
    print(socio2)

    print(libro1)
    print(libro2)
    print(libro3)
    print(libro4)

    # Encontrar socios con más de 3 libros prestados
    socios = [socio1, socio2]
    socios_mas_de_3_libros = socios_con_mas_de_3_libros(socios)
    
    if socios_mas_de_3_libros:
        print("Socios con más de 3 libros prestados:")
        for socio in socios_mas_de_3_libros:
            print(socio)
    else:
        print("Ningún socio tiene más de 3 libros prestados.")