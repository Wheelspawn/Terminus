#pragma once
#ifndef WEAPONS_H
#define WEAPONS_H

#include "stdafx.h"
#include "Player.h"
#include <iostream>

using namespace std;

class Weapons
{
public:
	Weapons();

	const int weapons[8][5] =
	{

		// int kg; int damage; int defense; int cost; int frequency;
		{ 1, 40, 5, 50, 30 },			// Dagger
		{ 2, 35, 25, 100, 60 },			// Sword
		{ 4, 50, 10, 175, 80 },			// Axe
		{ 3, 50, 35, 200, 100 },		// Claymore
		{ 5, 30, 65, 125, 110 },		// Spear
		{ 6, 55, 35, 190, 125 },		// Glaive
		{ 7, 60, 50, 200, 130 },		// Halberd
		{ 1, 100, 85, 300, 131 } };		// Katana

	const string weaponNames[8] = { "Dagger", "Sword", "Axe", "Claymore", "Spear", "Glaive", "Halberd", "Katana" };

	void setWeapon(int addWeaponAmount, int index )
	{
		weaponAmount[index] = weaponAmount[index] + addWeaponAmount;
	}

	void removeWeapon(int addWeaponAmount, int index)
	{
		weaponAmount[index] = weaponAmount[index] - addWeaponAmount;
		load = load - (weaponAmount[index] * weapons[index][0]);
	}

	int getWeapon(int x)
	{
		return weaponAmount[x];
	}
	string getWeaponName(int x)
	{
		return weaponNames[x];
	}

	int getLoad()
	{
		for (int i = 0; i <= 6; i++)
		{
			int a = 0;
			a = (weaponAmount[i] * weapons[i][0]);
		}
		return load;
	}

private:

	int load ; // how much the player carries in kg

	int weaponAmount[7] = { 1, 0, 0, 0, 0, 0, 0 };
	// weapon amounts are stored in this array. From left to right, dagger, sword, axe, claymore, spear, glaive, halberd
	// to use the array, take an argument like weaponAmount[3]++, which will increment the third value of the array, adding 1 to the player's axe amount

};

#endif