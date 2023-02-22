package com.apimongo.model.partida_t2;

import java.util.List;

import org.springframework.stereotype.Repository;




@Repository
public interface PartidakT2Repository  {
    List<PartidaT2> findAll();
    List<PartidaT2> bestGames();

    List<PartidaT2> worseGames();
}
