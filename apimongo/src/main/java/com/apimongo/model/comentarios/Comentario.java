package com.apimongo.model.comentarios;

public class Comentario {
    public int _id;
    public String user;
    public String filtro;
    public String comentario;
    public Comentario(){

    }
    public Comentario(String user,String filtro,String comentario){
        this.user = user;
        this.filtro=filtro;
        this.comentario=comentario;

    }

    public Comentario(int _id,String user, String filtro, String comentario){
        this._id=_id;
        this.user = user;
        this.filtro=filtro;
        this.comentario=comentario;
    }

    public String getFiltro(){
        return filtro;
    }
    public String getUser(){
        return user;
    }
    public String getComentario(){
        return comentario;
    }
    public void setFiltro(String filtro){
        this.filtro=filtro;
    }
    public void setUser(String user){
        this.user=user;
    }
    public void setComentario(String comentario){
        this.comentario=comentario;
    }

    public int get_Id() {
        return _id;
    }

    public void set_Id(int _id) {
        this._id=_id;
    }
}
