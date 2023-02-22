package com.apimongo.model.partida_t2;



import org.bson.types.ObjectId;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(value = { "_class","id" })
public class PartidaT2 {

    public  ObjectId _id;
    public String erabiltzailea;
    public String data;
    public int puntuazioa;





    public ObjectId getId() {
        return _id;
    }
    public void setId(ObjectId id) {
        this._id = id;
    }
    public String getErabiltzailea() {
        return erabiltzailea;
    }
    public void setErabiltzailea(String erabiltzailea) {
        this.erabiltzailea = erabiltzailea;
    }
    public int getPuntuazioa() {
        return puntuazioa;
    }
    public void setPuntuazioa(int puntuazioa) {
        this.puntuazioa = puntuazioa;
    }
    public String getData() {
        return data;
    }
    public void setData(String dataPartida) {
        this.data = dataPartida;
    }
}