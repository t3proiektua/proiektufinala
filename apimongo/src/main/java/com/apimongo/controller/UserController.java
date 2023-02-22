package com.apimongo.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.apimongo.model.comentarios.Comentario;
import com.apimongo.model.comentarios.ComentarioRepository;
import com.apimongo.model.user.User;
import com.apimongo.model.user.UserRepository;

public class UserController {
    @RestController // This means that this class is a Controller baina @Controller bakarrik
    // jarrita, PUT eta DELETEak ez dabiz
    @RequestMapping(path = "/erabiltzaileak") // This means URL's start with /demo (after Application path)
    public class ComentarioController {
        @Autowired // This means to get the bean called umeaRepository
        // Which is auto-generated by Spring, we will use it to handle the data
        private UserRepository userRepository;

        @GetMapping(path = "/erabiltzaileGuztiak")
        public @ResponseBody List<User> allUsers() {
            return userRepository.findAll();
        }

        @PostMapping(path = "/erabiltzaileBerria")
        public void new_user(@RequestParam String user, @RequestParam String contraseña) {
            User new_user = new User(user, contraseña);
            userRepository.newUser(new_user);
        }
        @GetMapping(path = "/erabiltzaileagatikBilatu")
        public @ResponseBody User findByUser(@RequestParam String user){
            User targetUser = userRepository.findByUser(user);
            return targetUser;
        }
    }

}