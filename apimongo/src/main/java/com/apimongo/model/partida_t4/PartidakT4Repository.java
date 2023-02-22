package com.apimongo.model.partida_t4;

import java.util.List;


import org.springframework.stereotype.Repository;


@Repository
public interface PartidakT4Repository  {
    List<PartidaT4> findAll();
    List<PartidaT4> bestGames();

    List<PartidaT4> worseGames();

}
