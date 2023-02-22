package com.apimongo.model.partida_t1;

import java.util.List;

import org.springframework.stereotype.Repository;

@Repository
public interface PartidakT1Repository  {
    List<PartidaT1> findAll();

    List<PartidaT1> bestGames();

    List<PartidaT1> worseGames();

}
