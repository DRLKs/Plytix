import os
from flask import render_template, request, redirect, url_for

from app.forms import ProductoForm
from . import app, db
from .models import Producto, Cuenta

UPLOAD_FOLDER = 'assets/images'  # Carpeta donde se guardarán las imágenes
app.config['UPLOAD_FOLDER'] = UPLOAD_FOLDER

@app.route('/add_producto<int:id_cuenta>', methods=['GET','POST'])
def add_producto( id_cuenta ):
    
    form = ProductoForm()

    form.cuenta_id.choices = [(cuenta.id, cuenta.username) for cuenta in Cuenta.query.all()]

    if form.validate_on_submit():
        sku = form.sku.data
        gtin = request.gtin.data
        nombre = request.nombre.data
        imagen_file = form.thumbnail.data
        thumbnail_path = os.path.join(app.config['UPLOAD_FOLDER'], imagen_file.filename)
          # Guardar la imagen
        imagen_file.save( thumbnail_path )

        # Crear un nuevo producto
        nuevo_producto = Producto(SKU=sku, GTIN=gtin, NOMBRE=nombre, THUMBANIL=thumbnail_path, ID_CUENTA=id_cuenta )
        db.session.add(nuevo_producto)
        db.session.commit()
        
        return redirect(url_for('index'))  # Redirigir a la página principal después de agregar
    
    return render_template('add_product.html', form=form)


@app.route('/')
def index():
    productos = Producto.query.all()  # Obtener todos los usuarios de la base de datos
    return render_template('index.html', Productos=productos)  # Pasar la lista de usuarios a la plantilla

@app.route('/update_producto/<int:id_cuenta>,<String:sku>', methods=['POST'])
def update_producto(id_cuenta, sku):
    producto = Producto.query.get(sku, id_cuenta)
    if producto:
        producto.sku = request.form.get('SKU')
        producto.gtin = request.form.get('GTIN')
        producto.nombre = request.form.get('NOMBRE')
        producto.thumbnail = request.form.get('THUMBNAIL')
        db.session.commit()
    return redirect(url_for('index'))


@app.route('/delete_producto/<int:id_cuenta>,<String:sku>')
def delete_user(id_cuenta, sku):
    producto = Producto.query.get(sku, id_cuenta)
    if producto:
        db.session.delete(sku, id_cuenta)
        db.session.commit()
    return redirect(url_for('index'))
