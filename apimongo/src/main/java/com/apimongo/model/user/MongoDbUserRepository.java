package com.apimongo.model.user;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;

import com.apimongo.model.comentarios.Comentario;
import com.mongodb.ReadConcern;
import com.mongodb.ReadPreference;
import com.mongodb.TransactionOptions;
import com.mongodb.WriteConcern;
import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoCollection;

import static com.mongodb.client.model.Filters.eq;

public class MongoDbUserRepository implements UserRepository {
    private static final TransactionOptions txnOptions = TransactionOptions.builder()
            .readPreference(ReadPreference.primary())
            .readConcern(ReadConcern.MAJORITY)
            .writeConcern(WriteConcern.MAJORITY)
            .build();
    @Autowired
    private MongoClient client;
    private MongoCollection<User> userCollection;
    @PostConstruct
    void init() {
        userCollection = client.getDatabase("proba").getCollection("erabiltzailea", User.class);

    }

    @Override
    public List<User> findAll() {
        // TODO Auto-generated method stub
        return userCollection.find().into(new ArrayList<>());
    }

    @Override
    public User findByUser(String user) {
        User id_target_User=(User) userCollection.find(eq("user",user));
        return id_target_User;
    }

    @Override
    public void newUser(User newUser) {
        // TODO Auto-generated method stub
        userCollection.insertOne(newUser);
    }

}
