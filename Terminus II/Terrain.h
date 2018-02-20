#pragma once
#ifndef TERRAIN_H
#define TERRAIN_H

#include <iostream>
#include <random>

using namespace std;

class Terrain
{
public:
	Terrain();
	~Terrain();

	void Wilderness()
	{
		cout << " You are in the wilderness." << endl;
	}

	void Forest()
	{
		cout << " You are in the forest." << endl;
	}

	void Mountain()
	{
		cout << " You are in the mountains." << endl;
	}

	void Desert()
	{
		cout << " You are in the desert." << endl;
	}

private:
	int gold;
	int bread;
	int lootChance;
};

#endif