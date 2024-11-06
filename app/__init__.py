from flask import Flask
import os
import base64

def create_app():
    app = Flask(__name__)
    
    app.secret_key = os.urandom(24)  # Genera una clave aleatoria cada vez que se ejecuta
    # Filtro personalizado para convertir bytes a Base64
    @app.template_filter('b64encode')
    def b64encode(data):
        return base64.b64encode(data).decode('utf-8') if data else ''
    
    # Importa las rutas desde routes.py
    from .routes import main
    app.register_blueprint(main)

    return app

