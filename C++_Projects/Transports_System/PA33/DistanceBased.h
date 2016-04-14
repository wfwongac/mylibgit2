/* DistanceBased.h
 * - the header file for the class declaration of DistanceBased
 */

#ifndef _DISTANCEBASED_H
#define _DISTANCEBASED_H

#include "Transport.h"

class DistanceBased:public Transport {

   public:
	/* printing the info of the transport */
	// implementing the inherited virtual function
	virtual void printInfo(ostream& os) const;

   // Add the data member and methods here

	// the default constructor
	DistanceBased();

	//the constructor to initialize the name and
	//id inherited from the Transport class
	DistanceBased(string name, int id);

	// the destructor
	~DistanceBased();

	//a pure virtual function to print the fares to the os output stream
	virtual void printFares(ostream& os) const = 0;

	//a pure virtual function
	//to return the fare between the stops with the names, ori & des.
	virtual double findFare(string ori, string des) const = 0;

};

#endif
