
package src;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 *
 * @author elorza.karmele
 */
public class DBKonekzioaPostgresql {
    
    private String host = "127.0.0.1";
    private String port = "5432";
    private String database = "postgres";
    private String user = "admin";
    private String password = "admin";
    
    public Connection connect(){
        String url = "jdbc:postgresql://" + host + ":" + port + "/" + database;
        Connection connection = null;
        // Registramos el driver de PostgresSQL
        try {
            Class.forName("org.postgresql.Driver");
        } catch (ClassNotFoundException ex) {
            System.out.println("Errorea Postgresql-ko driverra erregistratzean: " + ex);
        }
        try{
            connection = DriverManager.getConnection(url, user, password);
        } catch (Exception ex){
            System.out.println("Errorea datu basearekin konektatzean: " + ex);
        }
        return connection;
    }
    public void insertGame(int id, String userName, Float puntuazioa, Date data) throws ClassNotFoundException, ParseException {
        String sql = "INSERT INTO partida (id, username, puntuazioa,data) VALUES (?,?,?,?)";
        //java.sql.Date data = new java.sql.Date(System.currentTimeMillis());
        try {
            Connection conn = this.connect();
            if (conn == null) {
                System.out.println("Ez da konektatu datu basearekin.");
            } else {
                PreparedStatement pstmt = conn.prepareStatement(sql);
                pstmt.setInt(1, id);
                pstmt.setString(2, userName);
                pstmt.setFloat(3, puntuazioa);
                SimpleDateFormat formato = new SimpleDateFormat("yyyy-MM-dd");
                String fechaString = formato.format(data);
                data = formato.parse(fechaString);
                java.sql.Date dataSQL = new java.sql.Date(data.getTime());
                pstmt.setDate(4, dataSQL);
                pstmt.executeQuery();               
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
    }
}