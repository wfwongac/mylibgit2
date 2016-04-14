//source: Sammy
//date: 20/2/2003

#include "resource.h"

void ResBuild() {
	ifstream fin(CITY_FILE);
	if ( !fin ) {
		cerr << "error: unable to open input file " << CITY_FILE << "\n";
		exit (-1);
	}

	fin >> intNumCity;
	arrCity = new string[intNumCity];

	for(int i=0; i<intNumCity; i++)
	{
		fin >> arrCity[i];
	}
}
