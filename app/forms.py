from flask_wtf import FlaskForm
from wtforms import StringField, FileField, SelectField, SubmitField
from wtforms.validators import DataRequired, Optional

class ProductoForm(FlaskForm):      # Formulario Agregar Productos
    sku = StringField('SKU', validators=[DataRequired()])
    gtin = StringField('GTIN', validators=[Optional()])
    nombre = StringField('Nombre', validators=[DataRequired()])
    thumbnail = FileField('thumbnail', validators=[DataRequired()])
     # Selección de cuenta
    submit = SubmitField('Agregar Producto')
