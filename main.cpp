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
vector<string> terrain_disp = {"≈≈≈", "░░░", " ` ", "` `", " ¥ ", " ^ "};

void drawScreen(const vector<vector<int>>& world, const int& player_x, const int& player_y) {
    cout << "\n\n\n";
    cout << "use the wasd keys to explore." << "\n";
    for (int i=player_x-5;i<player_x+6;i++) {
        for (int j=player_y-5;j<player_y+6;j++) {
            if ((i == player_x) && (j == player_y)) {
                cout << " ☺ ";
            }
            else
                cout << "" << terrain_disp[world[i][j]] << "";
        }
        cout << "\n";
    }
}

void generateMap(vector<vector<int>>& map, int& player_m, int& player_n, const char& diff) {
    
    // player goes north but new north terrain hasn't been generated
    if (player_m-5 < 0) {
        vector<int> new_x;
        
        for (int i=0;i<map[0].size();i++)
        {
            if (rand()%10 > 2) {
                new_x.push_back(map[0][i]);
            }
            else
            {
                new_x.push_back(rand()%6);
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
            if (rand()%10 > 2) {
                map[i].insert(map[i].begin(),map[i][0]);
            }
            else
            {
                map[i].insert(map[i].begin(),rand()%6);
            }
        }
        player_n = 5;
    }
    // player goes east but new east terrain hasn't been generated
    else if (diff == 'e') {
        
        for (int i=0;i<map.size();i++)
        {
            if (rand()%10 > 2) {
                map[i].push_back(map[i][map[i].size()-1]);
            }
            else
            {
                map[i].push_back(rand()%6);
            }
        }
    }
    // player goes south but new south terrain hasn't been generated
    else if (diff == 's') {
        vector<int> new_x;
        
        for (int i=0;i<map[0].size();i++)
        {
            if (rand()%10 > 2) {
                new_x.push_back(map[map.size()-1][i]);
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
    char ch = getch();
    
    do
    {
        char ch = getch();
        
            switch (ch)
            {
            case 'w':
                player_m -= 1;
                generateMap(map, player_m,player_n, 'n');
                drawScreen(map, player_m, player_n);
                break;
            case 's':
                player_m += 1;
                generateMap(map, player_m,player_n, 's');
                drawScreen(map, player_m, player_n);
                break;
            case 'd':
                player_n += 1;
                generateMap(map, player_m,player_n, 'e');
                drawScreen(map, player_m, player_n);
                break;
            case 'a':
                player_n -= 1;
                generateMap(map, player_m,player_n, 'w');
                drawScreen(map, player_m, player_n);
                break;
            case 'i':
                break;
            }
            

    } while (direction != 'q');
}

int main(int argc, char** argv)
{
    gameLoop();
}

