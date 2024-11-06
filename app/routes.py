from flask import Blueprint, render_template
from flask import request, redirect, url_for
from flask import flash


import sqlite3
import base64

# Define el Blueprint para las rutas principales
main = Blueprint('main', __name__)

# Función para obtener todas las cuentas desde la base de datos
def get_all_accounts():
    connection = sqlite3.connect('IngenieriaRequisitos.db')
    cursor = connection.cursor()
    cursor.execute("SELECT * FROM Cuenta")  # Obtenemos los datos de las cuentas
    accounts = cursor.fetchall()
    connection.close()
    return accounts

# Función para obtener detalles de una cuenta específica por ID
def get_account_details(account_id):
    connection = sqlite3.connect('IngenieriaRequisitos.db')
    cursor = connection.cursor()
    cursor.execute("SELECT * FROM Cuenta WHERE ID = ?", (account_id,))
    account = cursor.fetchone()
    connection.close()
    return account

# Ruta principal donde se muestran los botones para cada cuenta
@main.route('/')
def index():
    accounts = get_all_accounts()
    return render_template('index.html', accounts=accounts)

# Ruta para mostrar detalles de una cuenta específica
@main.route('/cuenta/<int:account_id>')
def cuenta(account_id):
    account = get_account_details(account_id)
    if account is None:
        # Si no se encuentra la cuenta, redirige o muestra un error adecuado
        return "Cuenta no encontrada", 404
    return render_template('cuenta.html', account=account)

######### PRODUCTOS ###############

def get_products_by_account(account_id):
    connection = sqlite3.connect('IngenieriaRequisitos.db')
    cursor = connection.cursor()
    cursor.execute("SELECT SKU, GTIN, NOMBRE, THUMBNAIL FROM Producto WHERE IDCuenta = ?", (account_id,))
    products = cursor.fetchall()
    connection.close()

    # Convertir los blobs a Base64 para los productos con miniaturas
    product_list = []
    for product in products:
        sku, gtin, nombre, thumbnail_blob = product
        if thumbnail_blob:
            # Convertir BLOB a base64
            thumbnail_base64 = base64.b64encode(thumbnail_blob).decode('utf-8')
        else:
            thumbnail_base64 = None
        product_list.append((sku, gtin, nombre, thumbnail_base64))
    
    return product_list

@main.route('/productos/<int:account_id>')
def productos(account_id):
    # Obtener la información de la cuenta, si es necesario, para mostrarla en la página
    account = get_account_details(account_id)
    if account is None:
        return "Cuenta no encontrada", 404
    
    # Obtener los productos asociados a la cuenta
    products = get_products_by_account(account_id)
    
    # Renderizar la plantilla productos.html con los productos y la información de la cuenta
    return render_template('productos.html', account=account, products=products)

@main.route('/productos/<int:account_id>/add', methods=['POST'])
def add_product(account_id):
    gtin = request.form['gtin']
    nombre = request.form['nombre']
    
    #Comprobaciones imágenes
    thumbnail = request.files.get('thumbnail')
    thumbnail_data = None
    if thumbnail and thumbnail.filename != '':  # Verificar si el archivo es válido
        try:
            thumbnail_data = thumbnail.read()  # Leer el archivo como bytes
        except Exception as e:
            flash(f"Error al leer la imagen: {str(e)}", "error")
            return redirect(url_for('main.productos', account_id=account_id))

    connection = sqlite3.connect('IngenieriaRequisitos.db')
    cursor = connection.cursor()
    
    # Comprobar si el SKU ya existe para evitar conflictos de unicidad
    if gtin != '':      # Si no da error, igual GTIN cuando 2 no tienen GTIN
        cursor.execute("SELECT GTIN FROM Producto WHERE GTIN = ?", (gtin,))
        exists = cursor.fetchone()
        if exists:
            flash(f"Error: El producto: {nombre}, tiene un GTIN({gtin}), que está usando otro producto")
            connection.close()
            return redirect(url_for('main.productos', account_id=account_id))
    else :
        gtin = None 
    cursor.execute(
        "INSERT INTO Producto (GTIN, NOMBRE, THUMBNAIL, IDCuenta) VALUES (?, ?, ?, ?)",
        (gtin, nombre, thumbnail_data, account_id)
    )
    connection.commit()
    connection.close()

    flash("Producto añadido exitosamente.")
    return redirect(url_for('main.productos', account_id=account_id))

