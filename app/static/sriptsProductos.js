const apiUrl = 'http://localhost:8080/api/products';  // Ajusta la URL según el endpoint del backend

document.addEventListener("DOMContentLoaded", function() {
    cargarProductos();
});

// Función para obtener y mostrar los productos
async function cargarProductos( numCuenta ) {
    const response = await fetch(apiUrl);
    const products = await response.json();
    const productTableBody = document.getElementById('productTable').querySelector('tbody');
    productTableBody.innerHTML = '';  // Limpiar tabla

    products.forEach(product => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${product.sku}</td>
            <td>${product.gtin}</td>
            <td>${product.nombre}</td>
            <td>${product.thumbnail}</td>
            <td>
                <button onclick="editProduct(${product. product.sku})">Editar</button>
                <button onclick="deleteProduct(${product.sku})">Eliminar</button>
            </td>
        `;
        productTableBody.appendChild(row);
    });
}

window.onload = function() {
    // Recupera los parámetros de la URL
    const numCuenta = localStorage.getItem("numCuenta");
    document.getElementById('tituloPagina').innerText = numCuenta === '1' ? "Productos-Cuenta 1" : "Productos-Cuenta 2";
    document.getElementById('numCuenta').innerText = numCuenta;
}

function confirmDeletion(event) {
    const confirmation = confirm("¿Estás seguro de que deseas eliminar este producto?");
    if (!confirmation) {
        event.preventDefault(); // Cancelar la acción de envío del formulario
    }
}

