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

#include <iostream>
#include <cstdlib>
#include <vector>
#include <random>

using namespace std;

/*
 * 
 */

                          // ≈ ░ , , ¥ ^
vector<int> terrain_types = {0,1,2,3,4,5};
vector<string> terrain_disp = {"≈", "░", ",", ",", "¥", "^"};

void drawScreen(const vector<vector<int>>& world, const int& player_x, const int& player_y) {
    for (int i=player_x-5;i<player_x+6;i++) {
        for (int j=player_y-5;j<player_y+6;j++) {
            if ((i == player_x) && (j == player_y)) {
                cout << " ☺ " ;
            }
            else
                cout << " " << terrain_disp[world[i][j]] << " ";
        }
        cout << "\n";
    }
}

void generateMap(vector<vector<int>>& map, int& player_x, int& player_y, const char& diff) {
    
    if (player_x-5 < 0) {
        vector<int> new_x;
        
        for (int i=0;i<11;i++)
        {
            if (rand()%10 > 1) {
                new_x.push_back(map[0][i]);
            }
            else
            {
                new_x.push_back(rand()%6);
            }
        }
        map.insert(map.begin(),new_x);
        player_x = 5;
    }
    else if (player_y-5 < 0) {
        vector<int> new_y;
        
        for (int i=0;i<11;i++)
        {
            if (rand()%10 > 1) {
                map[i].insert(map[i].begin(),map[i][0]);
            }
            else
            {
                map[i].insert(map[i].begin(),rand()%6);
            }
        }
        player_y = 5;
    }
    else if (diff == 'e') {
        
        for (int i=0;i<11;i++)
        {
            if (rand()%10 > 1) {
                map[i].insert(map[i].end(),map[i][-1]);
            }
            else
            {
                map[i].insert(map[i].end(),rand()%6);
            }
        }
    }
    else if (diff == 's') {
        vector<int> new_x;
        
        for (int i=0;i<11;i++)
        {
            if (rand()%10 > 1) {
                new_x.push_back(map[-1][i]);
            }
            else
            {
                new_x.push_back(rand()%6);
            }
        }
        map.insert(map.end(),new_x);
    }
}

void gameLoop()
{
    
    vector<vector<int>> map = {
              {2,2,4,2,4,4,2,4,4,2,2},
              {2,2,2,2,2,2,4,2,2,2,2},
              {0,2,2,2,2,2,2,2,2,2,5},
              {0,2,4,2,2,2,2,2,4,2,5},
              {2,2,2,2,2,2,2,2,2,2,5},
              {0,0,2,2,2,2,2,2,2,2,2},
              {0,0,0,2,2,2,2,2,2,4,5},
              {0,0,2,2,2,2,2,2,2,5,5},
              {0,2,2,2,2,2,2,2,2,2,5},
              {2,2,2,1,1,2,2,1,2,2,2},
              {2,2,1,1,1,1,1,1,1,2,2} };
    
    int player_x = 5;
    int player_y = 5;
    
    drawScreen(map, player_x, player_y);
    
    char direction;
    
    do
    {
            cin >> direction;
            switch (direction)
            {
            case 'n':
                player_x -= 1;
                generateMap(map, player_x,player_y, 'n');
                drawScreen(map, player_x, player_y);
                break;
            case 's':
                player_x += 1;
                generateMap(map, player_x,player_y, 's');
                drawScreen(map, player_x, player_y);
                break;
            case 'e':
                player_y += 1;
                generateMap(map, player_x,player_y, 'e');
                drawScreen(map, player_x, player_y);
                break;
            case 'w':
                player_y -= 1;
                generateMap(map, player_x,player_y, 'w');
                drawScreen(map, player_x, player_y);
                break;
            case 'i':
                break;
            }

    } while (direction != 'q');
}

int main(int argc, char** argv)
{
    vector<vector<int>> map;    
    map.push_back( {1,2,3} );
    map.push_back( {4,5,6} );
    map.push_back( {7,8,9} );
    gameLoop();
}

