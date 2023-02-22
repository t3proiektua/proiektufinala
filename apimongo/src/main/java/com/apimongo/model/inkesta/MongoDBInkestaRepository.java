package com.apimongo.model.inkesta;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.PostConstruct;

import org.bson.Document;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.mongodb.BasicDBObject;
import com.mongodb.ReadConcern;
import com.mongodb.ReadPreference;
import com.mongodb.TransactionOptions;
import com.mongodb.WriteConcern;
import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.model.Sorts;

import static com.mongodb.client.model.Filters.eq;

@Repository
public class MongoDBInkestaRepository implements InkestaRepository {
    private static final TransactionOptions txnOptions = TransactionOptions.builder()
            .readPreference(ReadPreference.primary())
            .readConcern(ReadConcern.MAJORITY)
            .writeConcern(WriteConcern.MAJORITY)
            .build();
    @Autowired
    private MongoClient client;
    private MongoCollection<Inkesta> inkestaCollection;

    @PostConstruct
    void init() {
        inkestaCollection = client.getDatabase("proba").getCollection("inkesta", Inkesta.class);

    }

    @Override
    public List<Inkesta> allInkesta() {
        return (List<Inkesta>) inkestaCollection.find().into(new ArrayList<>());
    }

    @Override
    public String newInkesta(Inkesta inkesta) {
        int new_id;
        Inkesta lastInkesta = inkestaCollection.find().sort(new BasicDBObject("_id", -1)).limit(1).first();
        if(lastInkesta==null){
            new_id=1;
            inkesta.set_Id(new_id);
        }else{
            new_id=lastInkesta.get_Id()+1;
            inkesta.set_Id(new_id);
        }
        inkestaCollection.insertOne(inkesta);
        return "saved";

        
    }
}
