# Proyecto .NET MAUI: Ejercicios de la Actividad
**Autor:** Raul Gamero  
**Materia:** Desarrollo de Aplicaciones Móviles  
**Plataforma:** .NET MAUI (Multi-platform App UI) con C# en Visual Studio 2026 (.NET 10)

---

## 📱 Descripción del Proyecto
Este proyecto implementa en una solución unificada los 5 ejercicios prácticos solicitados en la actividad:
1. **Suma de Dos Números:** Variables, conversión de tipos numéricos (`double.TryParse`), operadores aritméticos y evento `Clicked`.
2. **Uso de RadioButtons:** Agrupación con `GroupName`, selección de opciones excluyentes y cálculo con evento `CheckedChanged`.
3. **Uso de CheckBox:** Selección múltiple, estados booleanos `IsChecked` y cálculo acumulativo dinámico.
4. **Calculadora con Picker:** Control desplegable `Picker`, evaluación con estructura `switch` y control de división por cero.
5. **Lista de Frutas (ListView):** Colecciones dinámicas (`ObservableCollection<string>`), enlace de datos (`ItemsSource`), adición (`Add()`), eliminación (`Remove()`) y vaciado (`Clear()`).

---

## 🛠️ Cómo Abrir y Ejecutar el Proyecto

### Opción A: Desde Visual Studio 2022
1. Abre **Visual Studio 2022**. Asegúrate de tener instalada la carga de trabajo:
   * **Desarrollo de interfaz de usuario de aplicaciones multiplataforma de .NET (.NET MAUI)**.
2. Abre la solución haciendo doble clic en el archivo:
   `ActividadMauiApp.sln`
3. En la barra superior de herramientas de Visual Studio:
   - Selecciona la plataforma de ejecución deseada (por ejemplo, **Windows Machine** para probarlo de inmediato en tu PC, o un **Emulador de Android**).
   - Presiona **F5** o haz clic en el botón verde **Iniciar Depuración**.

### Opción B: Desde la Consola de Comandos (.NET CLI)
```bash
# Navegar a la carpeta del proyecto
cd ActividadMauiApp

# Ejecutar en Windows Machine
dotnet build -t:Run -f net8.0-windows10.0.19041.0
```

---

## 📚 Respuestas a las Preguntas Teóricas para el Reporte

### 1. ¿Qué es .NET MAUI?
**.NET MAUI (.NET Multi-platform App UI)** es el framework moderno y multiplataforma de Microsoft (sucesor y evolución de Xamarin.Forms) que permite crear aplicaciones nativas para **Android, iOS, macOS y Windows** a partir de una única base de código compartida en C# y XAML. Utiliza una arquitectura de proyecto único ("Single Project"), optimizando el rendimiento mediante controles nativos en cada sistema operativo.

### 2. ¿Cómo se crea un proyecto de .NET MAUI multiplataforma?
Se puede crear de dos formas:
1. **Desde Visual Studio 2022:**
   - Abrir Visual Studio y seleccionar **"Crear un proyecto nuevo"**.
   - En la barra de búsqueda escribir **".NET MAUI"** y seleccionar la plantilla **"Aplicación .NET MAUI"**.
   - Asignar un nombre al proyecto, especificar la ruta de guardado y elegir la versión de .NET (por ejemplo, .NET 8.0).
   - Hacer clic en **"Crear"**.
2. **Desde la interfaz de línea de comandos (CLI):**
   ```bash
   dotnet new maui -n MiProyectoMaui
   ```

### 3. ¿Qué son los NuGet en Visual Studio?
**NuGet** es el gestor oficial de paquetes y dependencias para el ecosistema .NET. Permite a los desarrolladores incorporar, compartir, actualizar y reutilizar bibliotecas de código de terceros o de Microsoft (como librerías de interfaz, utilidades de red, bases de datos como SQLite, logging, etc.) en sus proyectos sin tener que compilar ni copiar archivos DLL manualmente.

### 4. ¿Qué son las colecciones en C#?
Las **colecciones** en C# son estructuras de datos dinámicas provistas por el namespace `System.Collections` y `System.Collections.Generic` que permiten almacenar, agrupar, recorrer y manipular conjuntos de elementos o referencias a objetos. A diferencia de los arreglos tradicionales (`Array`), que tienen un tamaño fijo definido al momento de su creación, las colecciones pueden crecer o reducir su tamaño dinámicamente en tiempo de ejecución.
* Ejemplos principales: `List<T>`, `Dictionary<TKey, TValue>`, `HashSet<T>` y `ObservableCollection<T>`.

### 5. ¿Cómo se crean, añaden y eliminan los elementos en una colección de datos?
En C#, utilizando por ejemplo una lista genérica `List<string>` o una colección observable `ObservableCollection<string>`:

* **Crear / Inicializar:**
  ```csharp
  List<string> frutas = new List<string>();
  // O con inicializador de colección:
  ObservableCollection<string> listaFrutas = new ObservableCollection<string> { "Manzana", "Pera" };
  ```
* **Añadir elementos:**
  ```csharp
  listaFrutas.Add("Fresa");
  ```
* **Eliminar elementos:**
  ```csharp
  // Por valor:
  listaFrutas.Remove("Pera");

  // Por índice:
  listaFrutas.RemoveAt(0);

  // Vaciar completamente la colección:
  listaFrutas.Clear();
  ```
