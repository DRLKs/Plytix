from . import db
    
class Cuenta(db.Model):
    ID = db.Column(db.Integer, primary_key=True)
    NOMBRE = db.Column(db.String(120), unique=True, nullable=False)

    productos = db.relationship('Producto', backref='Cuenta', lazy=True)

    def __repr__(self):
        return f'<Cuenta {self.NOMBRE}>'
    
    
class Producto(db.Model):
    SKU = db.Column(db.String(10), primary_key=True)
    GTIN = db.Column(db.String(10), unique=True, nullable=True)
    NOMBRE = db.Column(db.String(120), unique=True, nullable=False)
    THUMBANAIL = db.Column(db.String(200)) # Llevo la URL de la imagen
    IDCUENTA = db.Column(db.Integer, db.ForeignKey('Cuenta.id'), nullable=False)

    def __repr__(self):
        return f'<Producto {self.NOMBRE}>'