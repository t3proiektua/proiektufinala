package com.apimongo.model.partida_t3;

import java.util.List;


import org.springframework.stereotype.Repository;


@Repository
public interface PartidakT3Repository  {
    List<PartidaT3> findAll();
    List<PartidaT3> bestGames();

    List<PartidaT3> worseGames();
}
