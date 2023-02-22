package com.apimongo.model.comentarios;

import java.util.List;

import javax.xml.stream.events.Comment;

import org.springframework.stereotype.Repository;

@Repository
public interface ComentarioRepository {
    public List<Comentario> allComments();

    public String newComment(Comentario comment);


}
