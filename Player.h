/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/* 
 * File:   Player.h
 * Author: nsage
 *
 * Created on March 30, 2018, 5:58 PM
 */

#ifndef PLAYER_H
#define PLAYER_H

using std::string;

class Player {
public:
    Player(int health, string name, char gender);
    Player(const Player& orig);
    int getHealth(); // gets player health
    void setHealth(int h); // sets player health
    void decHealth(int h); // decrements health, e.g. _health -= h
    
    string getName();
    void setName(string s);
    char getGender();
    void setGender(char g);
    
    
    virtual ~Player();
private:
    int _health;
    string _name;
    char _gender;

};

#endif /* PLAYER_H */

