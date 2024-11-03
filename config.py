import os

class Config:
    SQLALCHEMY_DATABASE_URI = os.getenv('C:\Users\David\Desktop\IngenieriaRequisitos.db') or 'sqlite:///site.db'
    SQLALCHEMY_TRACK_MODIFICATIONS = False
