
function redirigirProductos() {
    window.location.href = "productos.html";
    localStorage.setItem("numCuenta", cuenta);
}

function redirigirAtributos() {
    window.location.href = "atributos.html";
    localStorage.setItem("numCuenta", cuenta);
}

function redirigirCategorias() {
    window.location.href = "categorias.html";
    localStorage.setItem("numCuenta", cuenta);
}

window.onload = function() {
    // Recupera los parámetros de la URL
    const cuenta = localStorage.getItem("cuenta");
    document.getElementById('tituloPagina').innerText = cuenta === '1' ? "Cuenta 1" : "Cuenta 2";
}
