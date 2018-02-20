// Terminus II.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Player.h"
#include "Forest.h"
#include "World.h"
#include "Wilderness.h"
#include "Terrain.h"
#include "Weapons.h"
#include "InventoryScreen.h"
#include <string>
#include <iostream>
#include <stdlib.h>
#include <random>

using namespace std;

Player sObj;
Player *objPointer = &sObj;
World worldObj;
World *worldObjPointer = &worldObj;
Terrain terrainObj;
Weapons weaponObj;
InventoryScreen inventoryScreen;

void gameLoop(); // this gets the functions ready
void weaponLottery();
void drawScreen();

void Map()
{
	for (int i = sObj.getPlayerXCoord() - 1; i < sObj.getPlayerXCoord() + 2; i++)
	{
		cout << " | ";
		for (int j = sObj.getPlayerYCoord() - 1; j < sObj.getPlayerYCoord() + 2; j++)
		{
			cout << worldObj.worldArray[i][j];
		}
		cout << " |" << endl;
	}
}

void findGoldChance() // find gold + weapons
{
	int random = rand();
	int isThereWeapon = random % 100;
	int isThereGold = random % 100;
	int goldAmount = random % 15;

	if (isThereGold > 90)
	{
		sObj.setGold(sObj.getGold() + goldAmount);
		cout << " You found: " << goldAmount << " pieces of gold" << endl;
	}

	if (isThereWeapon > 95)
	{
		cout << " You found a weapon: " << endl;
		weaponLottery();
	}
	else
	{
		cout << "";
	}
}

void weaponLottery()
{
	int random = rand();

	int weaponRange = random % 131;
	int weaponAmount = random % 3;

	for (int i = 0; i <= 7; i++)
	{
		if (weaponRange >= weaponObj.weapons[i - 1][4] && weaponRange < weaponObj.weapons[i][4])
		{
			if (weaponObj.getLoad() + weaponObj.weapons[i][0] < 30)
			{
				weaponObj.setWeapon(weaponAmount, i);
				cout << " " << weaponObj.weaponNames[i] << endl;
			}
			else if (weaponObj.getLoad() + weaponObj.weapons[i][0] >= 30)
			{
				cout << " You found a(n) " << weaponObj.weaponNames[i] << " but you cannot carry it." << endl;
			}
		}
	}
}

void drawScreen(int printInv)
{
	if (printInv == 0)
	{
		system("CLS");
		cout << "	 TERMINVS II\n\n ~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
		cout << "\n Health: " << sObj.getHealth() << "\n Gold: " << sObj.getGold() << endl;

		cout << "\n Weapons: " << endl;

		for (int i = 0; i <= 7; i++) // 7 is all the weapons there are
		{
			if (weaponObj.getWeapon(i) > 0)
			{
				cout << " " << weaponObj.getWeaponName(i) << ": ";
				cout << weaponObj.getWeapon(i) << endl;
			}
		}

		cout << "\n Carrying: " << weaponObj.getLoad() << " Kg" << endl;

		cout << "\n Map:" << endl;
		Map();
		cout << "\n [L]ook" << endl;
		cout << " [T]ake" << endl;
		cout << " [I]nventory" << endl;
		cout << " [S]ave\n" << endl;
		cout << " ~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" << endl;
	}
	else (printInv == 1);
	{
		cout << "Hi there. This screen should not display." << endl;
	}
}

void gameLoop()
{
	char direction;
	do
	{
		drawScreen(0);

		if (worldObj.worldArray[sObj.getPlayerXCoord()][sObj.getPlayerYCoord()] == 'O')
		{
			cout << " You are in the ocean." << endl;
			findGoldChance();
		}
		else if (worldObj.worldArray[sObj.getPlayerXCoord()][sObj.getPlayerYCoord()] == 'W')
		{
			terrainObj.Wilderness();
			findGoldChance();
		}
		else if (worldObj.worldArray[sObj.getPlayerXCoord()][sObj.getPlayerYCoord()] == 'F')
		{
			terrainObj.Forest();
			findGoldChance();
		}
		else if (worldObj.worldArray[sObj.getPlayerXCoord()][sObj.getPlayerYCoord()] == 'M')
		{
			terrainObj.Mountain();
			findGoldChance();
		}
		else if (worldObj.worldArray[sObj.getPlayerXCoord()][sObj.getPlayerYCoord()] == 'D')
		{
			terrainObj.Desert();
			findGoldChance();
		}

		else
		{
			cout << " You are in a town." << endl;
		}

		// cout << sObj.getPlayerXCoord() << ", " << sObj.getPlayerYCoord() << endl;

		cin >> direction;
		switch (direction)
		{
		case 'n':
			objPointer->setPlayerXCoord(sObj.getPlayerXCoord() - 1);
			break;
		case 's':
			objPointer->setPlayerXCoord(sObj.getPlayerXCoord() + 1);
			break;
		case 'e':
			objPointer->setPlayerYCoord(sObj.getPlayerYCoord() + 1);
			break;
		case 'w':
			objPointer->setPlayerYCoord(sObj.getPlayerYCoord() - 1);
			break;
		case 'i':
			drawScreen(1);
		}

	} while (direction != 'q');
}

int main()
{
	gameLoop();
}
