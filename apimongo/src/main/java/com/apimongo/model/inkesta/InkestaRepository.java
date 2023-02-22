package com.apimongo.model.inkesta;

import java.util.List;

import org.springframework.stereotype.Repository;

@Repository
public interface InkestaRepository {
    public List<Inkesta> allInkesta();

    public String newInkesta(Inkesta Inkesta);
}
