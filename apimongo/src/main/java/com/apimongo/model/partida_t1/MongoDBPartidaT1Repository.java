package com.apimongo.model.partida_t1;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import javax.annotation.PostConstruct;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import com.mongodb.ReadConcern;
import com.mongodb.ReadPreference;
import com.mongodb.TransactionOptions;
import com.mongodb.WriteConcern;
import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.model.Sorts;

@Repository
public class MongoDBPartidaT1Repository implements PartidakT1Repository {
    private static final TransactionOptions txnOptions = TransactionOptions.builder()
    .readPreference(ReadPreference.primary())
    .readConcern(ReadConcern.MAJORITY)
    .writeConcern(WriteConcern.MAJORITY)
    .build();
@Autowired
private MongoClient client;
private MongoCollection<PartidaT1> partidaCollection;

@PostConstruct
void init() {
partidaCollection = client.getDatabase("proba").getCollection("partidak_t1", PartidaT1.class);

}

@Override
public List<PartidaT1> findAll() {
return partidaCollection.find().into(new ArrayList<>());
}

@Override
public List<PartidaT1> bestGames(){
    List<PartidaT1> orderedList = partidaCollection.find().sort(Sorts.descending("puntuazioa")).into(new ArrayList<>());
    return orderedList;

}
@Override
public List<PartidaT1> worseGames(){
    List<PartidaT1> orderedList = partidaCollection.find().sort(Sorts.ascending("puntuazioa")).into(new ArrayList<>());
    return orderedList;

}
}
