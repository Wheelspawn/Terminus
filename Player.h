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

#include <string>

using std::string;

class Player {
public:
    Player(string name);
    Player(const Player& orig);
    Player();

    int getHealth(); // gets player health
    void setHealth(int h); // sets player health
    void incHealth(int h); // increments health, e.g. _health += h

    string getName();
    void setName(string s);

    void Update();

    virtual ~Player();
private:
    string _name;
    int _health;
    int _maxhealth;
    int _tick;
};

#endif /* PLAYER_H */

