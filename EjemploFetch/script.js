document.addEventListener("DOMContentLoaded", function () {
    // Obtener la referencia de la tabla
    const table = document.getElementById("libreriaTable");
    const id = document.getElementById("id");
    // Realizar la solicitud Fetch a la API
    fetch('http://localhost:5034/api/libros', {
      method: 'GET'
    })
      .then(response => response.json())
      .then(data => {
        // Iterar sobre los datos y agregar filas a la tabla
        data.forEach(libro => {
          const row = table.insertRow();
          row.insertCell(0).textContent = libro.titulo;
          row.insertCell(1).textContent = libro.autor;
          row.insertCell(2).textContent = libro.capitulos;
          row.insertCell(3).textContent = libro.paginas;
          row.insertCell(4).textContent = libro.precio;
          
        });
      })
      .catch(error => console.error("Error al obtener datos de la API:", error));
      const Params = {
        "id": id.value
      }
      fetch('http://localhost:5034/api/libroT',{
        method: "POST",
        body: JSON.stringify(Params)
      })
      .then(response => response.json())
      .then(data => {
        alert(`Autor agregado con éxito: ${JSON.stringify(data, null, 2)}`);
      })
    /*
    fetch('http://localhost:5034/api/libros',{
    method: 'GET'
    })
    .then((response) => response.json())
    .then((data) => {
        console.log(data);
    })*/
    
  
    // Agregar listeners a los botones (simplemente muestra un mensaje por ahora)
    document.getElementById("agregarAutor").addEventListener("click", agregarAutor);
    
    document.getElementById("agregarLibro").addEventListener("click", () => alert("Funcionalidad Agregar Libro no implementada aún."));
    
    // Agrega un evento para mostrar el formulario cuando se hace clic en el botón
  mostrarFormularioBtn.addEventListener("click", function () {
    agregarAutorForm.style.display = "block";
  });

  // Agrega un evento para manejar el envío del formulario
  agregarAutorForm.addEventListener("submit", function (event) {
    event.preventDefault();

    // Obtén el valor del campo "Nombre del Nuevo Autor"
    const nuevoAutor = document.getElementById("nuevoAutor").value;

    // Realiza la lógica de agregar autor aquí (puedes utilizar fetch u otro método)
    //Fetch para buscar un libro por nombre
    const Params = {
      "nuevoAutor": nuevoAutor.value
    }
    fetch('http://localhost:5034/api/libro',{
      method: "POST",
      body: JSON.stringify(Params)
    })
    .then(response => response.json())
    .then(data => {
      alert(`Autor agregado con éxito: ${JSON.stringify(data, null, 2)}`);
    })
    // Muestra el mensaje de éxito o cualquier otra lógica que desees
    alert(`Autor agregado con éxito: ${nuevoAutor}`);
    // O puedes ocultar el formulario nuevamente
    agregarAutorForm.style.display = "none";
  });
});
  