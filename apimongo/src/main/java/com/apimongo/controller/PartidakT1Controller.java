package com.apimongo.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.apimongo.model.partida_t1.PartidaT1;
import com.apimongo.model.partida_t1.PartidakT1Repository;

@RestController // This means that this class is a Controller baina @Controller bakarrik
				// jarrita, PUT eta DELETEak ez dabiz
@RequestMapping(path = "/partidak_t1") // This means URL's start with /demo (after Application path)
public class PartidakT1Controller {
	@Autowired // This means to get the bean called umeaRepository
				// Which is auto-generated by Spring, we will use it to handle the data
	private PartidakT1Repository partidaRepository;
    @GetMapping(path = "/partidaGuztiak")
	public @ResponseBody List<PartidaT1> partidakAll() {
		// This returns a JSON or XML with the users
		return partidaRepository.findAll();
	}
	@GetMapping(path = "/partidaOnenak")
	public @ResponseBody List<PartidaT1> bestPartidakT1(){
		return partidaRepository.bestGames();
	}
	@GetMapping(path = "/partidaOkerrenak")
	public @ResponseBody List<PartidaT1> worsePartidakT1(){
		return partidaRepository.worseGames();
	}
}
