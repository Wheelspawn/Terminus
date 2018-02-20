#include "stdafx.h"
#include "Items.h"

#include "stdafx.h"
#include <iostream>

Items::Items()
{
	const struct food {
		double kg;
		int healPoints;
		int cost;
		int frequency;
		string name;
		string description;
	};

	const struct food bread = { 0.5,10,15,23, "Loaf of bread", "A staple grain eaten around the world." };
	const struct food apple = { 0.2,6,10,23, "Apple", "A fruit eaten around the world. " };
	const struct food orange = { 0.2,6,15,22, "Orange", "A fruit eaten around the world." };
	const struct food potato = { 0.2,13,25,20, "Potato", "A hardy tuber with considerable nutritional value." };
	const struct food steak = { 0.3,10,25,15, "T-bone steak", "A roast steak, grilled over an open fire." };
	const struct food pork = { 0.4,12,28,15, "Pork rump", "A roast pork, grilled over an open fire." };
	const struct food rawfish = { 0.3,10,30,12, "Raw fish", "A raw fillet of fresh fish." };
	const struct food cookedfish = { 0.3,11,35,12, "Cooked fish", "A cooked fillet of fresh fish." };
	const struct food cheese = { 0.8,10,35,11, "Cheese", "A dairy product eaten around the world." };
	const struct food beer = { 0.6,5,15,10, "Beer", "A fermented beverage made with wheat and hops." };
	const struct food almonds = { 0.2,4,15,8, "Almonds", "Edible seeds from an almond tree." };
	const struct food candy = { 0.1,2,5,5, "Peppermint candy", "Provides glucose, keeps dentists in business." };
	const struct food spider = { 0.1,2,20,2, "Fried spider", "A delicacy in some parts of the world, inedible everywhere else." };
	const struct food seahorse = { 0.1,2,25,2, "Fried seahorse", "An unusual fish commonly found in street markets." };
	const struct food bile = { 1,1,10,2, "Jar of bile", "An illicit substance with properties largely unknown." };
	const struct food snakevenom = { 0.5,-20,50,1, "Snake venom", "A poisonous concentrate harvested from snakes." };
	const struct food curare = { 0.5,-25,60,1, "Curare", "A poisonous extract harvested from plants." };
}


Items::~Items()
{
}
