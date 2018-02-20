#include "stdafx.h"
#include "Weapons.h"

#include <iostream>
#include <string>
#include <sstream>

Weapons::Weapons()
{
	const struct sword {
		double kg;
		int damage;
		int cost;
		int frequency;
		string name;
		string description;
	};

		const struct sword ironSword = { 4,45,70,35, "Iron Sword" "A sword manufactured from pure iron. It is stronger than bronze, but heavier." };
		const struct sword katana = { 1,110,600,3, "Katana", "The katana is light, fast and strong, and shows off the wealth of its owner." };

	const struct axe {
		double kg;
		int damage;
		int cost;
		int frequency;
		string name;
	};

		const struct axe steelAxe = { 3.5,22,80,30, "Steel Axe" };

	const struct polearm {
		double kg;
		int damage;
		int cost;
		int frequency;
		string name;
	};

		const struct polearm steelHalberd = { 6,80,320,7, "Steel Halberd" };
}