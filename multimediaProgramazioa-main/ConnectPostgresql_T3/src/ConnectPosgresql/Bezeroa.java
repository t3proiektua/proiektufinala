
package ConnectPosgresql;
import java.io.*;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;
/**
 *
 * @author elorza.karmele
 */
public class Bezeroa {
     private static List<Partida> partidak;
    private static DBKonekzioaSqlite connection;
    private static OutputStream outputStream;
    private static ObjectOutputStream objectOutputStream;

    public static void main(String[] args) throws IOException, ClassNotFoundException {

        try ( Socket socket = new Socket("127.0.0.1", 6006)) {
            // Partiden lista sortu
            partidak = new ArrayList<>();
            connection = new DBKonekzioaSqlite();
            partidak = connection.getPartidak();

            // Zerbitzariari lista bidaltzeko output-a
            outputStream = socket.getOutputStream();
            objectOutputStream = new ObjectOutputStream(outputStream);

            //Bidali zerbitzariari list-a
            objectOutputStream.writeObject(partidak);
            System.out.println("Bidalita");

            outputStream.close();
            objectOutputStream.close();
            socket.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
