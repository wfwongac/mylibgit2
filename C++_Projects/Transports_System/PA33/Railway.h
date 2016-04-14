/* Railway.h
 * - the header file for the class declaration of Railway
 */

#ifndef _RAILWAY_H
#define _RAILWAY_H

#include "DistanceBased.h"

class Railway:public DistanceBased {

   // Add the data member and methods here

protected:
	//an STL vector of strings for storing
	//the list of stop names
	vector<string> stopNames;

	//an two-dimensional STL vector of
	//doubles for storing the fares between stops
	vector< vector<double> > fares;

	//to find the index (starting at 0) of
	//the corresponding stop,
	//e.g. the index of ��Choi Hung�� is 1 in
	//a list of stops {��Diamond Hill��, ��Choi Hung��}
	 int searchStopIndex(string stop) const;

public:
	 // the default constructor to initialize
	 //the name & id to empty string and 0.
	 Railway();

	 virtual void readInfo(string filename);
	 /*the constructor to initialize the name and id
	  * by the given parameters, name & id;
	  * and read the input file, filename,
	  * and store the data into the appropriate data members. */
	 Railway(string name, int id, string filename);

	 Railway(string name, int id);

	 //the copy constructor (deep copy)
	 Railway(const Railway& other);

	 ~Railway();

	 bool operator==(const Railway& other) const;

	 Railway& operator=(const Railway& other);

	 virtual void printInfo(ostream& os) const;

	 virtual void printFares(ostream& os) const;

	 virtual double findFare(string ori, string des) const;

	 virtual void removeStop(string stopname);

	 virtual bool searchStop(string name) const;

	 virtual list<string> findDestinations(string ori, double fare) const;
};

#endif
