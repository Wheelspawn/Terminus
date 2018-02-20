#pragma once
#ifndef PLAYER_H
#define PLAYER_H

#include "stdafx.h"
#include <iostream>

using namespace std;

class Player
{
public:
	Player();
	void setHealth(int x)
	{
		health = x;
	}
	int getHealth()
	{
		return health;
	}

	int setGold(int x)
	{
		gold = x;
		return gold;
	}
	int getGold()
	{
		return gold;
	}

	void setPlayerXCoord(int x)
	{
		playerXCoord = x;

		if (playerXCoord > 10)
		{
			playerXCoord = 10;

		}
		if (playerXCoord < 1)
		{
			playerXCoord = 1;
		}
	}
	int getPlayerXCoord()
	{
		return playerXCoord;
	}

	void setPlayerYCoord(int x)
	{
		playerYCoord = x;

		if (playerYCoord > 8)
		{
			playerYCoord = 8;
		}
		if (playerYCoord < 1)
		{
			playerYCoord = 1;
		}
	}
	int getPlayerYCoord()
	{
		return playerYCoord;
	}


private:

	int health = 100;
	int gold = 100;

	int playerXCoord = 4;
	int playerYCoord = 6;

	int swordAmount = 0;
	int katanaAmount = 0;
	int steelAxeAmount = 0;

};

#endif