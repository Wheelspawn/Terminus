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

Player::Player(int health=100, string name="Dave", char gender='m') {
    _health = health;
    _name = name;
    _gender = gender;
}

Player::Player(const Player& orig) {
    
}

Player::~Player() {
}

int Player::getHealth() {
    return _health;
}

void Player::setHealth(int h) {
    _health = h;
}

void Player::decHealth(int h) {
    _health -= h;
}

string Player::getName() {
    return _name;
}

void Player::setName(string n) {
    _name = n;
}

char Player::getGender() {
    return _gender;
}

void Player::setGender(char g) {
    _gender -= g;
}