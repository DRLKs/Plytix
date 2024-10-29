package clasesNecesarias;

import java.util.ArrayList;
import java.util.List;

public class Cuenta {
	
	private final String BDSERVER = "localhost";
	private final String BDNOMBRE = "";
	
	private String id;
	
	public Cuenta( String id ) {
		this.id = id;
	}
	
	public List<Producto> listaProductos(){
		
		BD baseDatos = new BD(BDSERVER, BDNOMBRE );
		List<Object[]> tuplas  = baseDatos.Select( "SELECT SKU FROM PRODUCTO WHERE CUENTAID =  '" + getId() +"';" );
		List<Producto> productos = new ArrayList<>();
		for(  ) {
			
		}
		return null;
	}

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}
	
}
