
package src;

import java.io.Serializable;
import java.util.Date;

/**
 *
 * @author elorza.karmele
 */
public class Partida implements Serializable{
    public int Id;
    public String UserName;
    public float Puntuazioa;
    public Date Data;

    public Partida() {
    }
    public Partida(int id, String UserName, float Puntuazioa, Date Data) {
        this.Id = id;
        this.UserName = UserName;
        this.Puntuazioa = Puntuazioa;
        this.Data = Data;
    }
    public int getId() {
        return Id;
    }
    
     public void setId(int id) {
        this.Id = id;
    }
     
    public String getUserName() {
        return UserName;
    }

    public void setUserName(String UserName) {
        this.UserName = UserName;
    }

    public float getPuntuazioa() {
        return Puntuazioa;
    }

    public void setPuntuazioa(float Puntuazioa) {
        this.Puntuazioa = Puntuazioa;
    }

    public Date getData() {
        return Data;
    }

    public void setData(Date Data) {
        this.Data = Data;
    }

    @Override
    public String toString() {
        return "Partida{" + "Id=" + Id + ", UserName=" + UserName + ", Puntuazioa=" + Puntuazioa + ", Data=" + Data + '}';
    } 
}
