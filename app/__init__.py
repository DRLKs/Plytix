from flask import Flask
from flask_sqlalchemy import SQLAlchemy

db = SQLAlchemy()

def create_app():
    app = Flask(__name__)
    app.config.from_object('config')  # Configuración desde config.py

    db.init_app(app)

    with app.app_context():
        from . import routes  # Importar rutas aquí para evitar problemas de referencia circular

    return app
