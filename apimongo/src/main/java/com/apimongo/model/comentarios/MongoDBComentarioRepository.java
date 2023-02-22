package com.apimongo.model.comentarios;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.mongodb.BasicDBObject;
import com.mongodb.ReadConcern;
import com.mongodb.ReadPreference;
import com.mongodb.TransactionOptions;
import com.mongodb.WriteConcern;
import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoCollection;

@Repository
public class MongoDBComentarioRepository implements ComentarioRepository {
    private static final TransactionOptions txnOptions = TransactionOptions.builder()
            .readPreference(ReadPreference.primary())
            .readConcern(ReadConcern.MAJORITY)
            .writeConcern(WriteConcern.MAJORITY)
            .build();
    @Autowired
    private MongoClient client;
    private MongoCollection<Comentario> commentCollection;

    @PostConstruct
    void init() {
        commentCollection = client.getDatabase("proba").getCollection("comentarios", Comentario.class);

    }

    @Override
    public List<Comentario> allComments() {
       return (List<Comentario>) commentCollection.find().into(new ArrayList<>());
    }

    @Override
    public String newComment(Comentario comment) {
        int new_id;
        Comentario lastComment = commentCollection.find().sort(new BasicDBObject("_id", -1)).limit(1).first();
        if(lastComment==null){
            new_id=1;
            comment.set_Id(new_id);
        }else{
            new_id=lastComment.get_Id()+1;
            comment.set_Id(new_id);
        }
        commentCollection.insertOne(comment);
        return "saved";
        
    }
}