/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * File:   main.cpp
 * Author: nsage
 *
 * Created on March 26, 2018, 1:37 PM
 */

using namespace std;

#include "Player.h"

#include <iostream>
#include <cstdlib>
#include <vector>
#include <random>

#include <unistd.h>
#include <termios.h>

/*
 * This was not written by me but by some guy named Falcon Momot on stackoverflow
 * https://stackoverflow.com/questions/421860/capture-characters-from-standard-input-without-waiting-for-enter-to-be-pressed/11379566
 */

char getch() {
        char buf = 0;
        struct termios old = {0};
        if (tcgetattr(0, &old) < 0)
                perror("tcsetattr()");
        old.c_lflag &= ~ICANON;
        old.c_lflag &= ~ECHO;
        old.c_cc[VMIN] = 1;
        old.c_cc[VTIME] = 0;
        if (tcsetattr(0, TCSANOW, &old) < 0)
                perror("tcsetattr ICANON");
        if (read(0, &buf, 1) < 0)
                perror ("read()");
        old.c_lflag |= ICANON;
        old.c_lflag |= ECHO;
        if (tcsetattr(0, TCSADRAIN, &old) < 0)
                perror ("tcsetattr ~ICANON");
        return (buf);
}

/*
 *
 */

                          // ≈ ░ , , ¥ ^
vector<int> terrain_types = {0,1,2,3,4,5};
vector<string> terrain_disp = {"≈≈≈", "   ", " ` ", "` `", " ¥ ", " ^ ", "vVv"};

Player p;
int ticks = 0;

void prompt() {
    cout << "What is thy name, O traveler?" << "\n";
    string name;
    cin >> name;
    cout << "I dub thee: Sir " << name << "\n";
    p.setName(name);
    p.setHealth(55);
    getch();
}

void take() {
    cout << "\n\n\n\n\n\n\n\n\n\n";
    cout << "There is nothing here to take." << "\n";
    getch();
}

void inspect() {
    cout << "\n\n\n\n\n\n\n\n\n\n";
    cout << "This appears to be a very fine piece of ground." << "\n";
    getch();
}

void drawScreen(const vector<vector<int>>& world, const int& player_x, const int& player_y) {
    cout << "\n\n\n\n\n\n\n\n\n\n";
    cout << "Ticks: " << ticks << "\n";
    cout << "use the wasd keys to explore." << "\n";
    for (int i=player_x-5;i<player_x+6;i++) {
        for (int j=player_y-5;j<player_y+6;j++) {
            if ((i == player_x) && (j == player_y)) {
                cout << " ☺ ";
            }
            else
                cout << "" << terrain_disp[world[i][j]] << "";
        }

        if (i==player_x-2)
            cout << "   (i)nspect";
        if (i==player_x)
            cout << "   (t)ake";
        if (i==player_x+2)
            cout << "   (r)est";

        cout << "\n";
    }
    cout << "Name: " << p.getName() << "    " << "Health: " << p.getHealth() << "\n";
}

void generateMap(vector<vector<int>>& map, int& player_m, int& player_n, const char& diff) {

    int t_types = terrain_disp.size();

    // player goes north but new north terrain hasn't been generated
    if (player_m-5 < 0) {
        vector<int> new_x;

        for (int i=0;i<map[0].size();i++)
        {
            if (rand()%10 > 1) {
                if ((i == 0) || (i == map[0].size()-1)) // if not at the border
                {
                    new_x.push_back(map[0][i]); // push back the previously drawn terrain type
                }
                else
                {
                    int r_neighbor = rand()%3;
                    new_x.push_back(map[0][i-1+r_neighbor]); // push back randomly from a list of neighbors of the terrain
                }
            }
            else // pick an entirely new terrain
            {
                new_x.push_back(rand()%t_types);
            }
        }
        map.insert(map.begin(),new_x);
        player_m = 5;
    }
    // player goes west but new west terrain hasn't been generated
    else if (player_n-5 < 0) {
        vector<int> new_y;
        for (int i=0;i<map.size();i++)
        {
            if (rand()%10 > 1) {
                if ((i == 0) || (i == map.size()-1)) // if not at the border
                {
                    map[i].insert(map[i].begin(),map[i][0]);
                }
                else
                {
                    int r_neighbor = rand()%3;
                    map[i].insert(map[i].begin(),map[i-1+r_neighbor][0]);
                }
            }
            else
            {
                map[i].insert(map[i].begin(),rand()%t_types);
            }
        }
        player_n = 5;
    }
    // player goes east but new east terrain hasn't been generated
    else if (diff == 'e') {

        for (int i=0;i<map.size();i++)
        {
            if (rand()%10 > 1)
            {
                if ((i == 0) || (i >= map.size()-2)) // if not at the border
                    {
                        map[i].push_back(map[i][map[i].size()-1]);
                    }
                    else
                    {
                        int r_neighbor = rand()%3;
                        map[i].push_back(map[i-1+r_neighbor][map[i].size()-1]);
                    }
            }
            else
            {
                map[i].push_back(rand()%t_types);
            }
        }
    }
    // player goes south but new south terrain hasn't been generated
    else if (diff == 's') {
        vector<int> new_x;

        for (int i=0;i<map[0].size();i++)
        {
            if (rand()%10 > 1) {
                if ((i == 0) || (i >= map.size()-2)) // if not at the border
                {
                    new_x.push_back(map[map.size()-1][i]);
                }
                else
                {
                    int r_neighbor = rand()%3;
                    new_x.push_back(map[map.size()-1][i-1+r_neighbor]);
                }
            }
            else
            {
                new_x.push_back(rand()%t_types);
            }
        }
        map.insert(map.end(),new_x);
    }
}

bool checkForImpasse(vector<vector<int>> map, int player_m, int player_n) {
    if (map[player_m][player_n] == 5) {
        return true;
    }
    return false;
}

void gameLoop()
{
    prompt();
    vector<vector<int>> map = {
              {2,3,4,2,4,4,2,4,4,3,2},
              {2,3,2,2,2,2,4,3,2,2,2},
              {0,2,2,3,2,2,2,2,3,2,5},
              {0,3,4,2,2,3,2,2,4,2,5},
              {2,2,3,2,3,2,3,3,2,2,5},
              {0,0,2,2,2,2,3,2,3,2,2},
              {0,0,0,2,2,3,3,2,2,4,5},
              {0,0,2,3,2,2,2,3,2,5,5},
              {0,2,3,2,2,2,3,2,2,2,5},
              {2,3,2,1,1,2,2,1,2,3,2},
              {3,3,1,1,1,1,1,1,1,2,3} };

    int player_m = 5;
    int player_n = 5;

    drawScreen(map, player_m, player_n);

    char direction;

    do
    {
        ticks += 1;
        char ch = getch();

            switch (ch)
            {
            case 'w':
                if (checkForImpasse(map,player_m-1,player_n)==false)
                {
                    player_m -= 1;
                    generateMap(map, player_m,player_n, 'n');
                }
                drawScreen(map, player_m, player_n);
                break;
            case 's':
                if (checkForImpasse(map,player_m+1,player_n)==false)
                {
                    player_m += 1;
                    generateMap(map, player_m,player_n, 's');
                }
                drawScreen(map, player_m, player_n);
                break;
            case 'd':
                if (checkForImpasse(map,player_m,player_n+1)==false)
                {
                    player_n += 1;
                    generateMap(map, player_m,player_n, 'e');
                }
                drawScreen(map, player_m, player_n);
                break;
            case 'a':
                if (checkForImpasse(map,player_m,player_n-1)==false)
                {
                    player_n -= 1;
                    generateMap(map, player_m,player_n, 'w');
                }
                drawScreen(map, player_m, player_n);
                break;
            case 'i':
                inspect();
                break;

            case 't':
                take();
                break;

            case 'r':
                drawScreen(map, player_m, player_n);
                break;
            }

        p.Update();

    } while (direction != 'q');
}

int main(int argc, char** argv)
{
    gameLoop();
}
