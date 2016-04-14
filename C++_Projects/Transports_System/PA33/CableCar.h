/* CableCar.h
 * - the header file for the class declaration of CableCar
 */

#ifndef _CABLECAR_H
#define _CABLECAR_H

#include "FlatFare.h"

class CableCar:public FlatFare {

   // Add the data member and methods here
	protected:
	// the round trip fare
	double roundTripFare;

	public:

	CableCar();

	CableCar(string name, int id, double sfare, double rfare);

	CableCar(string name, int id, double sfare, double rfare, string filename);

	CableCar(const CableCar& other);

	~CableCar();

	bool operator==(const CableCar& other) const;

	CableCar& operator=(const CableCar& other);

	double getRoundTripFare() const;

	virtual void printInfo(ostream& os) const;

	virtual void removeStop(string stopname);

	virtual bool searchStop(string name) const;

	virtual list<string> findDestinations(string ori, double fare) const;



};

#endif
