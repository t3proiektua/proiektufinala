package com.consumeapi;

import com.mongodb.BasicDBObject;
import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoClients;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoDatabase;

import org.bson.BasicBSONObject;
import org.bson.Document;
import org.json.JSONArray;
import org.json.JSONObject;
import org.springframework.http.ResponseEntity;
import org.springframework.web.client.RestTemplate;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Logger;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;

public class App {
    public static void main(String[] args) throws IOException {
        final Logger LOGGER = Logger.getLogger(App.class.getName());
        // make an HTTP request to target server and save the output of the GET request
        // in a .json file
         createJson("http://192.168.65.11:8080//api/allPartidak", "t1",LOGGER);
         createJson("http://192.168.65.90:8081//demo/all_Partida", "t2",LOGGER);
         createJson("http://192.168.65.12:8080/demo/get", "t3",LOGGER);
         createJson("http://192.168.65.123:8080/Partidak/getPartidak", "t4",LOGGER);

        // connecting to a MongoDB server
        // MongoClients.create() method returns a new client instance, which can be used
        // to interact with the MongoDB database.
        MongoClient mongoClient = MongoClients.create("mongodb://localhost:27017");
        // used to get a reference to the "proba" database.
        MongoDatabase database = mongoClient.getDatabase("proba");
        // creating a reference to a MongoDB collection
        MongoCollection<Document> t1Collection = database.getCollection("partidak_t1");
        MongoCollection<Document> t2Collection = database.getCollection("partidak_t2");
        MongoCollection<Document> t3Collection = database.getCollection("partidak_t3");
        MongoCollection<Document> t4Collection = database.getCollection("partidak_t4");
        t1Collection.drop();
        t2Collection.drop();
        t3Collection.drop();
        t4Collection.drop();

        // the output List of documents from the json file
        List<Document> t1_documents = readJson("json/t1.json", "t1");
        List<Document> t2_documents = readJson("json/t2.json", "t2");
        List<Document> t3_documents = readJson("json/t3.json", "t3");
        List<Document> t4_documents = readJson("json/t4.json", "t4");

        // insert the documents in mongo
        t1Collection.insertMany(t1_documents);
        t2Collection.insertMany(t2_documents);
        t3Collection.insertMany(t3_documents);
        t4Collection.insertMany(t4_documents);

        // Close the MongoClient
        mongoClient.close();
    }

    // This code takes a JSON string as an input, creates a list of MongoDB
    // Documents,
    // populates that list with JSON objects contained in the input string
    public static List<Document> initializeDocuments(String txjsonString, String teamName)
            throws JsonMappingException, JsonProcessingException {
        List<Document> documents = new ArrayList<>();
        JSONArray array = new JSONArray(txjsonString);
        // loops through each JSON object in the JSONArray, and converts each one to a
        // MongoDB Document
        for (int i = 0; i < array.length(); i++) {
            JSONObject object = array.getJSONObject(i);
            object.remove("id");
            // adapt the json for a universal structure of the classes
            if (teamName == "t1" || teamName == "t4") {
                String new_erabiltzailea = object.getJSONObject("langilea").getString("erabiltzailea");
                object.remove("langilea");
                object.put("erabiltzailea", new_erabiltzailea);

            }
            // dds each newly created MongoDB Document
            documents.add(Document.parse(object.toString()));
        }
        return documents;

    }

    //
    public static List<Document> readJson(String jsonFileRoute, String teamName)
            throws IOException {
        // This code sets up a reference to a file in the "json" directory
        File file = new File(jsonFileRoute);
        // reads the contents of a file stores it in a byte array
        byte[] jsonData = Files.readAllBytes(file.toPath());
        // reading the content and storing it as a String
        // "UTF-8" argument specifies the character encoding
        String jsonString = new String(jsonData, "UTF-8");
        // initializing a list of Document objects using the "initializeDocuments"
        // passing in the string representation of the JSON data.
        List<Document> documents = initializeDocuments(jsonString, teamName);
        return documents;
    }

    public static void createJson(String targetUrl, String teamName, Logger logger) {
        // RestTemplate is part of the Spring Framework and provides a convenient way to
        // make HTTP requests to RESTful web services
        RestTemplate restTemplate = new RestTemplate();
        String url = targetUrl;
        // make a GET request to the specified url and expecting a response in the form
        // of a String
        // represents an HTTP response including the response body and response headers
        ResponseEntity<String> response = restTemplate.getForEntity(url, String.class);
        // checking if the HTTP response status code is in the 2xx success range.
        // If it is, it means the API request was successful, and the code continues to
        // process the response.
        if (response.getStatusCode().is2xxSuccessful()) {
            // The code retrieves the body of the HTTP response expected to contain a JSON
            // string
            String responseBody = response.getBody();
            logger.info(responseBody);
            // writes it to a json file
            try (FileWriter file = new FileWriter("json/" + teamName + ".json")) {
                file.write(responseBody);

            } catch (IOException e) {
                e.printStackTrace();
            }
        } else {
            logger.severe("Status code error!!!");
        }
    }

    // check the collection state if is created empty or does not exist
    public String emptyCollection(String colectionName, MongoDatabase database) {
        String message;
        boolean collectionExists = database.listCollectionNames().into(new ArrayList<String>()).contains(colectionName);
        if (collectionExists) {
            MongoCollection<Document> collection = database.getCollection(colectionName);
            long documentCount = collection.countDocuments();
            if (documentCount > 0) {
                message = "Collection is not empty";

            } else {
                message = "Collection is empty";
            }
        } else {
            message = "Collection do not exist";
        }
        return message;
    }
}