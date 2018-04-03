/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * File:   Player.cpp
 * Author: nsage
 *
 * Created on March 30, 2018, 5:58 PM
 */

#include <string>
#include "Player.h"

Player::Player(string name="Dave") {
    _name = name;
    _health=100;
    _maxhealth=100;
    _tick=0;
}

Player::Player(const Player& orig) {
}

Player::Player() {
    _health = 100;
    _name = "Dave";
    _maxhealth=100;
    _tick=0;
}

Player::~Player() {
}

int Player::getHealth() {
    return _health;
}

void Player::setHealth(int h) {
    _health = h;
}

void Player::incHealth(int h) {
    if (_health < _maxhealth) {
        _health += h;

        if (_health > _maxhealth)
            _health = _maxhealth;
        }
}

void Player::Update() {
    _tick += 1;
    if (_tick%10==0)
        this->incHealth(1);
}

string Player::getName() {
    return _name;
}

void Player::setName(string n) {
    _name = n;
}
