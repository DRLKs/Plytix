import javax.swing.*;

import clasesNecesarias.BD;
import clasesNecesarias.BD_Error;
import clasesNecesarias.Producto;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.List;

public class ProductoApp extends JFrame {
    private BD database;
    private DefaultListModel<Producto> modeloLista;
    private JList<Producto> listaProductos;
    private JTextField txtSKU, txtNombre, txtGTIN;
    private JLabel lblThumbnail;
    private ImageIcon imagenProducto;

    public ProductoApp(BD db) {
        this.database = db;

        setTitle("Gestión de Productos");
        setSize(600, 500);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        modeloLista = new DefaultListModel<>();
        listaProductos = new JList<>(modeloLista);
        listaProductos.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        JScrollPane scrollPane = new JScrollPane(listaProductos);

        txtSKU = new JTextField(15);
        txtNombre = new JTextField(15);
        txtGTIN = new JTextField(15);
        lblThumbnail = new JLabel();

        JButton btnAgregar = new JButton("Agregar Producto");
        JButton btnCargar = new JButton("Cargar Productos");

        btnAgregar.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                agregarProducto();
            }
        });

        btnCargar.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                cargarProductos();
            }
        });

        JPanel panelFormulario = new JPanel();
        panelFormulario.add(new JLabel("SKU:"));
        panelFormulario.add(txtSKU);
        panelFormulario.add(new JLabel("Nombre:"));
        panelFormulario.add(txtNombre);
        panelFormulario.add(new JLabel("GTIN:"));
        panelFormulario.add(txtGTIN);
        panelFormulario.add(lblThumbnail);
        panelFormulario.add(btnAgregar);
        panelFormulario.add(btnCargar);

        add(scrollPane, BorderLayout.CENTER);
        add(panelFormulario, BorderLayout.SOUTH);
    }

    private void agregarProducto() {
        String sku = txtSKU.getText();
        String nombre = txtNombre.getText();
        String gtin = txtGTIN.getText();

        // Agregar lógica para obtener thumbnail
        // Suponiendo que se agrega una ruta de imagen por simplicidad
        Producto producto = new Producto(sku, nombre, imagenProducto, gtin, null, null);

        try {
            database.agregarProducto(producto);
            modeloLista.addElement(producto);
            limpiarCampos();
        } catch (BD_Error e) {
            JOptionPane.showMessageDialog(this, "Error al agregar el producto: " + e.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    private void cargarProductos() {
        try {
            List<Producto> productos = database.obtenerProductos();
            modeloLista.clear();
            for (Producto p : productos) {
                modeloLista.addElement(p);
            }
        } catch (BD_Error e) {
            JOptionPane.showMessageDialog(this, "Error al cargar los productos: " + e.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
        }
    }

    private void limpiarCampos() {
        txtSKU.setText("");
        txtNombre.setText("");
        txtGTIN.setText("");
        lblThumbnail.setIcon(null);
        imagenProducto = null;
    }

    public static void main(String[] args) {
        try {
            Database db = new Database("jdbc:mysql://localhost:3306/tu_base_de_datos", "tu_usuario", "tu_contraseña");
            SwingUtilities.invokeLater(() -> {
                ProductoApp app = new ProductoApp(db);
                app.setVisible(true);
            });
        } catch (BD_Error e) {
            e.printStackTrace();
            JOptionPane.showMessageDialog(null, "Error al conectar a la base de datos: " + e.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
        }
    }
}
