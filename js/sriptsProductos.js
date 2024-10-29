// script.js

document.addEventListener("DOMContentLoaded", function() {
    cargarProductos();
});

function cargarProductos() {
    fetch('/api/productos')
        .then(response => response.json())
        .then(data => {
            const listaProductos = document.getElementById('listaProductos');
            listaProductos.innerHTML = ''; // Limpiar cualquier contenido anterior

            data.forEach(producto => {
                const productoDiv = document.createElement('div');
                productoDiv.classList.add('producto');
                productoDiv.innerHTML = `<h2>${producto.nombre}</h2>`;
                listaProductos.appendChild(productoDiv);
            });
        })
        .catch(error => console.error('Error al cargar productos:', error));
}
