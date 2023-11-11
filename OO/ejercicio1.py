class ObjetoRepresentable:
    def __init__(self, nombre):
        self._nombre = nombre

    def representar(self):
        pass

    def get_nombre(self):
        return self._nombre

    def set_nombre(self, nuevo_nombre):
        self._nombre = nuevo_nombre

class Texto(ObjetoRepresentable):
    def __init__(self, nombre, contenido):
        super().__init__(nombre)
        self.contenido = contenido

    def representar(self):
        return f"Texto: {self.get_nombre()}, Contenido: {self.contenido}"

class ObjetoGeometrico(ObjetoRepresentable):
    def __init__(self, nombre, tipo):
        super().__init__(nombre)
        self.tipo = tipo

    def representar(self):
        return f"Objeto Geométrico: {self.get_nombre()}, Tipo: {self.tipo}"

class Grupo(ObjetoRepresentable):
    def __init__(self, nombre):
        super().__init__(nombre)
        self.objetos = []

    def representar(self):
        representacion = f"Grupo: {self.get_nombre()}, Objetos:"
        for objeto in self.objetos:
            representacion += f"\n - {objeto.representar()}"
        return representacion

    def agregar_objeto(self, objeto):
        self.objetos.append(objeto)

    def eliminar_objeto(self, objeto):
        self.objetos.remove(objeto)

    def get_objetos(self):
        return self.objetos

    def set_objetos(self, nuevos_objetos):
        self.objetos = nuevos_objetos

# Ejemplo de uso exhaustivo
if __name__ == '__main__':
    # Crear objetos
    texto1 = Texto("Texto 1", "Hola, mundo!")
    circulo = ObjetoGeometrico("Círculo", "Círculo")
    rectangulo = ObjetoGeometrico("Rectángulo", "Rectángulo")
    grupo1 = Grupo("Grupo 1")
    
    # Agregar objetos al grupo
    grupo1.agregar_objeto(texto1)
    grupo1.agregar_objeto(circulo)
    
    # Crear un segundo grupo
    grupo2 = Grupo("Grupo 2")
    grupo2.agregar_objeto(rectangulo)
    
    # Agregar el segundo grupo al primer grupo
    grupo1.agregar_objeto(grupo2)
    
    # Mostrar representación
    print(grupo1.representar())

    # Acceder a un objeto dentro del grupo
    print(f"\nAcceder al objeto circulo dentro del Grupo 1: {grupo1.get_objetos()[1].representar()}")
