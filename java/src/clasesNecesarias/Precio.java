package clasesNecesarias;

public class Precio implements Atributo{
	
	private double precio;
	
	public Precio( double precio) {
		this.precio = precio;
	}

	@Override
	public String toString() {
		return precio + " €";
	}

	public double getPrecio() {
		return precio;
	}

	public void setPrecio(double precio) {
		this.precio = precio;
	}
	
	
	
}
