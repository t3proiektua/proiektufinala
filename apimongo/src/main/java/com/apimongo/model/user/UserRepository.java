package com.apimongo.model.user;

import java.util.List;

import org.springframework.stereotype.Repository;

@Repository
public interface UserRepository {
    List<User> findAll();

    User findByUser(String user);

    void newUser(User newUser);
}
