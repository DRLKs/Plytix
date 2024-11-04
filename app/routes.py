from flask import Blueprint, render_template
import sqlite3

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
    cursor.execute("SELECT * FROM Producto WHERE IDCuenta = ?", (account_id,))
    products = cursor.fetchall()
    connection.close()
    return products

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


