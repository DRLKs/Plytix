package clasesNecesarias;
import java.util.List;

import javax.management.RuntimeErrorException;
import javax.swing.ImageIcon;


public class Producto{
	
	private final String BDSERVER = "localhost";
	private final String BDNOMBRE = "";
	
	// Atributos obligatorios
	private String cuentaId;
    private String SKU;
    private String nombre;
    private ImageIcon thumbnail;
    
    // Atributos No Obligatorios
    private String GTIN;
    private List<Producto> relaciones;
    private final int MAX_ATRIBUTOS = 5;
    private List<Atributo> atributos;
    
    public Producto( String sku ) {
    	BD baseDatos = new BD(BDSERVER, BDNOMBRE );
    	Object[] tupla = baseDatos.Select( "SELECT * FROM PRODUCTO WHERE SKU = '" + sku + "';" ).get(0);
    	this.SKU = sku;
    	this.nombre = tupla[0].toString();
    }
    
	public Producto(String cuentaId, String sku, String nombre, ImageIcon thumbnail, String gtin, List<Producto> relaciones, List<Atributo> atributos) throws BD_Error{

		if( sku == null || nombre == null || thumbnail == null ) {
			throw new BD_Error("Rellenar casillas obligatorias");
		}
		BD baseDatos = new BD(BDSERVER, BDNOMBRE );
		baseDatos.Insert( "INSERT INTO PRODUCTO VALUES(SKU,NOMBRE,THUMBNAIL,GTIN,)" );
		this.cuentaId = cuentaId;
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

	public void setSKU(String value) {
		this.SKU = value;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String value) {
		this.nombre = value;
	}

	public ImageIcon getThumbnail() {
		return thumbnail;
	}

	public void setThumbnail(ImageIcon value) {
		this.thumbnail = value;
	}

	public String getGTIN() {
		return GTIN;
	}

	public void setGTIN(String value) {
		this.GTIN = value;
	}

	public List<Producto> getRelaciones() {
		return relaciones;
	}

	public void setRelaciones(List<Producto> values) {
		this.relaciones = values;
	}

	public List<Atributo> getAtributos() {
		return atributos;
	}

	public void setAtributos(List<Atributo> values) {
		this.atributos = values;
	}

	public int getMAX_ATRIBUTOS() {
		return MAX_ATRIBUTOS;
	}		

    
    
}
