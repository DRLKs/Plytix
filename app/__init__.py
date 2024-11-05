from flask import Flask
import os


def create_app():
    app = Flask(__name__)
    
    app.secret_key = os.urandom(24)  # Genera una clave aleatoria cada vez que se ejecuta

    # Importa las rutas desde routes.py
    from .routes import main
    app.register_blueprint(main)

    return app

