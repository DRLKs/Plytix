package clasesNecesarias;
import java.util.List;

import javax.swing.ImageIcon;

public class Producto {
	
	// Atributos obligatorios
    private String SKU;
    private String nombre;
    private ImageIcon thumbnail;
    
    // Atributos No Obligatorios
    private String GTIN;
    private List<Producto> relaciones;
    private final int MAX_ATRIBUTOS = 5;
    private List<Atributo> atributos;
    
	public Producto(String sku, String nombre, ImageIcon thumbnail, String gtin, List<Producto> relaciones,
			List<Atributo> atributos) {
		super();
		SKU = sku;
		this.nombre = nombre;
		this.thumbnail = thumbnail;
		GTIN = gtin;
		this.relaciones = relaciones;
		this.atributos = atributos;
	}

	public String getSKU() {
		return SKU;
	}

	public void setSKU(String sKU) {
		SKU = sKU;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public ImageIcon getThumbnail() {
		return thumbnail;
	}

	public void setThumbnail(ImageIcon thumbnail) {
		this.thumbnail = thumbnail;
	}

	public String getGTIN() {
		return GTIN;
	}

	public void setGTIN(String gTIN) {
		GTIN = gTIN;
	}

	public List<Producto> getRelaciones() {
		return relaciones;
	}

	public void setRelaciones(List<Producto> relaciones) {
		this.relaciones = relaciones;
	}

	public List<Atributo> getAtributos() {
		return atributos;
	}

	public void setAtributos(List<Atributo> atributos) {
		this.atributos = atributos;
	}

	public int getMAX_ATRIBUTOS() {
		return MAX_ATRIBUTOS;
	}		

    

    
    
}
