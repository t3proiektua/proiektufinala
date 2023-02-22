package com.t3.demo;

import java.sql.Date;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping(path="/demo")
public class MainController {
    @Autowired
    private PartidaRepository partidaRepository;

    @GetMapping(path="/get")
    public @ResponseBody Iterable<Partida> getAllGames(){

        return partidaRepository.findAll();
    }

    @PostMapping(path="/post")
    public @ResponseBody String newGame(@RequestParam int _id,@RequestParam String erabiltzailea, @RequestParam float puntuazioa,@RequestParam Date data ){
        Partida n = new Partida();
        n.setId(_id);
        n.seterabiltzailea(erabiltzailea);
        n.setPuntuazioa(puntuazioa);
        n.setData(data);
        partidaRepository.save(n);
        return "Saved";

    }
}
