
package ConnectPosgresql;
    import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
/**
 *
 * @author elorza.karmele
 */
public class Zerbitzaria {

 private static InputStream inputStream = null;
    private static ObjectInputStream objectInputStream = null;

    public static void main(String[] args) throws IOException, ClassNotFoundException {

        ServerSocket zerbitzaria = new ServerSocket(6006);
        System.out.println("Zerbitzaria martxan 6006 portuan");
        while (true) {
            Socket erabiltzailea = zerbitzaria.accept(); //Zerbitzaria erabiltzaileari itxaroten
            System.out.println(erabiltzailea + " konektatu da");

            // input-a hartu socket-etik
            inputStream = erabiltzailea.getInputStream();
            objectInputStream = new ObjectInputStream(inputStream);

            Haria haria = new Haria(erabiltzailea, objectInputStream);
            haria.start();

        }
    }
}
