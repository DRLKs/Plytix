package clasesNecesarias;

public class Descripcion implements Atributo{
	
	private String descripcion;
	
	public Descripcion( String descripcion ) {
		this.descripcion = descripcion;
	}
	
	public String getDescripcion() {
		return descripcion;
	}

	public void setDescripcion(String descripcion) {
		this.descripcion = descripcion;
	}
	
	public String toString() {
		return descripcion;
	}
}
