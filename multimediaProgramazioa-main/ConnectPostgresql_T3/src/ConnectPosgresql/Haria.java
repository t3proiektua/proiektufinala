
package ConnectPosgresql;
import java.io.*;
import java.net.*;
import java.text.ParseException;
import java.util.Date;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author elorza.karmele
 */
public class Haria extends Thread{
    static ObjectInputStream fentrada;
    static Socket socket = null;

    private static DBKonekzioaPostgresql conn;
    //constructor
    public Haria(Socket s, ObjectInputStream obj){
        this.socket = s;
        this.fentrada = obj;
    }
    @Override
    public void run() {
        try {
            datuakLortu();
        } catch (Exception ex) {
            Logger.getLogger("Errorea datuak Postgresqlra txertatzean");
        }
    }
    private static void datuakLortu() throws ParseException {
        String userName;
        Float puntuazioa;
        Date data;
        int id;
        try {
            conn = new DBKonekzioaPostgresql();
            List<Partida> partidaZerrenda = (List<Partida>) fentrada.readObject();

            for (Partida partida : partidaZerrenda) {
                id = partida.getId();
                userName = partida.getUserName();
                puntuazioa = partida.getPuntuazioa();
                data = partida.getData();
                conn.insertGame(id, userName, puntuazioa, data);
            }

            //closes
            System.out.println("Bukatu du.");
            fentrada.close();
            socket.close();
        } catch (IOException | ClassNotFoundException ex) {
            Logger.getLogger(Haria.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
