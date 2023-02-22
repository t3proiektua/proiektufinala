package com.apimongo.model.user;

public class User {
    public String user;
    public String contraseña;


    public User(){

    }
    public User(String user,String contraseña){
        this.user=user;
        this.contraseña=contraseña;
    }
    public String getUser(){
        return this.user;
    }
    public String getContraseña(){
        return this.contraseña;
    }
    public void SetUser(String user){
        this.user=user;
    }
    public void SetContrasela(String contraseña){
        this.contraseña=contraseña;
    }
}
