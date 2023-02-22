
package ConnectPosgresql;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.Date;
import java.sql.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
/**
 *
 * @author elorza.karmele
 */
public class DBKonekzioaSqlite {
    public List<Partida> partidak = new ArrayList<>();

    private Connection connect() throws ClassNotFoundException  {
        String url = "jdbc:sqlite:C:/Users/karme/OneDrive/Escritorio/GitHub/multimediaProgramazioa/t3_Erronka/datubasea_jokoa.db";
        Connection conn = null;
        try {
            Class.forName("org.sqlite.JDBC");
            //DriverManager.registerDriver(new org.sqlite.JDBC());
            conn = DriverManager.getConnection(url);
        } catch (SQLException e) {
            System.out.println(e.getMessage());
            e.printStackTrace();
        }  
        return conn;
    }
     public List<Partida> getPartidak() throws ClassNotFoundException, ParseException  {
        String sql = "SELECT * FROM Partida;";
        try{  
            Connection conn = this.connect();
            PreparedStatement pstmt = conn.prepareStatement(sql);
            ResultSet rs = pstmt.executeQuery();
            
            while(rs.next()){
                Partida newPartida = new Partida();
                newPartida.setId(rs.getInt(1));
                newPartida.setUserName(rs.getString(2));
                newPartida.setPuntuazioa(rs.getFloat(3));
                String dateString = rs.getString(4);
                SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
                Date date = dateFormat.parse(dateString);
                newPartida.setData(date);
                partidak.add(newPartida);
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
         for(int i = 0; i < partidak.size(); i++){
             System.out.println("Partidak: " + partidak.get(i));
         }
        return partidak;
    }
}
