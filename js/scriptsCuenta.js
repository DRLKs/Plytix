
function redirigirProductos() {
    window.location.href = "productos.html";
}

function redirigirAtributos() {
    window.location.href = "atributos.html";
}

function redirigirCategorias() {
    window.location.href = "categorias.html";
}

window.onload = function() {
    // Recupera los parámetros de la URL
    const urlParams = new URLSearchParams(window.location.search);
    const cuenta = urlParams.get('cuenta');
    document.getElementById('tituloPagina').innerText = cuenta === '1' ? "Cuenta 1" : "Cuenta 2";

}
