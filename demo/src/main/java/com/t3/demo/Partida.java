package com.t3.demo;

import java.sql.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonProperty;

@Entity // This tells Hibernate to make a table out of this class
@Table(name="partida_t1")
public class Partida {
  @Id
  @Column(name="_id")
  @JsonProperty("_id")
  private int _id;
  @Column(name="partida_user")
  private String erabiltzailea;
  @Column
  private float puntuazioa;
  @Column(name="partida_data")
  private Date data;

  public Integer getId() {
    return _id;
  }

  public void setId(Integer _id) {
    this._id = _id;
  }

  public String geterabiltzailea() {
    return erabiltzailea;
  }

  public void seterabiltzailea(String erabiltzailea) {
    this.erabiltzailea = erabiltzailea;
  }

  public float getPuntuazioa() {
    return puntuazioa;
  }

  public void setPuntuazioa(float puntuazioa) {
    this.puntuazioa = puntuazioa;
  }
  public Date getData(){
    return data;
  }
  public void setData(Date data){
    this.data=data;
  }
}
