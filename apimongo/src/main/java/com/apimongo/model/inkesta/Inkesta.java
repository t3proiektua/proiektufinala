package com.apimongo.model.inkesta;

public class Inkesta {
    public int _id;
    public String user;
    public String jokua;
    public int question1;
    public int question2;
    public int question3;
    public int question4;
    public float total;
    public Inkesta(){
        
    }
    public Inkesta(String user,String jokua,int question1,int question2,int question3,int question4){
        this.user= user;
        this.jokua=jokua;
        this.question1=question1;
        this.question2=question2;
        this.question3=question3;
        this.question4=question4;
        this.total= (float)(question1+question2+question3+question4)/4;

    }
    public Inkesta(int _id,String user,String jokua, int question1,int question2,int question3,int question4){
        this._id=_id;
        this.user= user;
        this.jokua=jokua;
        this.question1=question1;
        this.question2=question2;
        this.question3=question3;
        this.question4=question4;
        this.total= (float)(question1+question2+question3+question4)/4;
    }
    public int get_Id(){
        return _id;
    }
    public String getUser(){
        return user;
    }
    public String getJokua(){
        return jokua;
    }
    public int getQuestion1(){
        return question1;
    }
    public int getQuestion2(){
        return question2;
    }
    public int getQuestion3(){
        return question3;
    }
    public int getQuestion4(){
        return question4;
    }
    public float getTotal(){
        return total;
    }
    public void set_Id(int _id){
        this._id=_id;
    }
    public void setUser(String user){
        this.user=user;
    }
    public void setJokua(String jokua){
        this.jokua=jokua;
    }
    public void setQuestion1(int question1){
        this.question1=question1;
    }
    public void setQuestion2(int question2){
        this.question2=question2;
    }
    public void setQuestion3(int question3){
        this.question3=question3;
    }
    public void setQuestion4(int question4){
        this.question4=question4;
    }
    public void setTotal(float total){
        this.total=total;
    }
}
