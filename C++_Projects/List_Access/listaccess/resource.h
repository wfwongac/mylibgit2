//source: Sammy
//date: 20/2/2003

#ifndef RESOURCE_H
#define RESOURCE_H

#include <fstream>
#include <iostream>
#include <string>
using namespace std;

#define CITY_FILE "city.txt"

// number of citys
int intNumCity;

// array of city name
string* arrCity;

// reading content for citys.txt
void ResBuild();

#endif
