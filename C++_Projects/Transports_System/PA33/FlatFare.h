/* FlatFare.h
 * - the header file for the class declaration of FlatFare
 */

#ifndef _FLATFARE_H
#define _FLATFARE_H

#include "Transport.h"

class FlatFare: public Transport {

   // Add the data members and methods here

	protected:
	//the single trip fare
	double singleTripFare;

	//an STL vector of strings for storing stop names
	vector<string> stops;

	public:

	// the default constructor to initialize
	//the name and id to empty string and 0.
	FlatFare();

	//the constructor to initialize the name,
	//id and the data member fare by the corresponding parameters.
	FlatFare(string name, int id, double fare);


	virtual void readInfo(string filename);
	//the constructor to initialize the name,
	//id and fare by the given parameters, name,
	//id & fare; and read the input file, filename,
	//and store the data into the appropriate data members.
	FlatFare(string name, int id, double fare, string filename);

	//the copy constructor
	FlatFare(const FlatFare& other);

	//the equal-to operator
	bool operator==(const FlatFare& other) const;

	//the assignment operator
	FlatFare& operator=(const FlatFare& other);

	//return the singleTripFare
	double getFare() const;

	virtual void printInfo(ostream& os) const;

	virtual bool searchStop(string name) const;

	virtual void removeStop(string stopname);

	virtual list<string> findDestinations(string ori, double fare) const;


};

#endif
