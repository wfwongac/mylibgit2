/* CableCar.cpp
 * - the source file for the implementation of the methods of CableCar class
 */

#include "CableCar.h"

// Add the implementation of the methods here
CableCar::CableCar():FlatFare("", 0, 0.0){ }

CableCar::CableCar(string name, int id, double sfare, double rfare)
:FlatFare(name,id,sfare), roundTripFare(rfare){ }

CableCar::CableCar(string name, int id, double sfare, double rfare, string filename)
:FlatFare(name,id,sfare), roundTripFare(rfare)
{
	//read file like FlatFare
	FlatFare::readInfo(filename);
}

CableCar::CableCar(const CableCar& other)
{
	this->setName(other.getName());
	this->setId(other.getId());
	this->singleTripFare = other.getFare();
	this->roundTripFare = other.getRoundTripFare();

	this->stops.clear();
	stops = other.stops;
}

CableCar::~CableCar()
{
	stops.clear();
}


bool CableCar::operator==(const CableCar& other) const
{
	if(this->getName() == other.getName() && this->getId() == other.getId() &&
			this->singleTripFare == other.getFare() && this->roundTripFare == other.getRoundTripFare())
	{
		for(unsigned int i=0; i<this->stops.size(); i++)
		{
			if(!(this->stops == other.stops))
				return false;
		}

		return true;
	}else
		return true;
}


CableCar& CableCar::operator=(const CableCar& other)
{
	this->setName(other.getName());
	this->setId(other.getId());
	this->singleTripFare = other.getFare();
	this->roundTripFare = other.getRoundTripFare();
	this->stops = other.stops;

	return *this;
}

double CableCar::getRoundTripFare() const
{
	return roundTripFare;
}

void CableCar::printInfo(ostream& os) const
{
	cout << "Name: " << getName() << endl;
	cout << "ID: " << getId() << endl;
	cout << "Single Trip Fare: " << getFare() << endl;
	cout << "Round Trip Fare: " << getRoundTripFare() << endl;

	vector< string >::const_iterator it = stops.begin();

	for(; it != stops.end(); it++)
		cout << (*it) << endl;

}
bool CableCar::searchStop(string name) const
{
	if(FlatFare::searchStop(name))
		return true;
	else
		return false;
}

list<string> CableCar::findDestinations(string ori, double fare) const
{
	list<string> result;

	if(this->getRoundTripFare() <= fare)
		{
			for(unsigned int i=0; i<stops.size(); i++)
			{
				// No need to give the ori stop name
				if(stops[i] != ori)
					result.push_back(stops[i]);

			}
		}

	return result;

}

void CableCar::removeStop(string stopname)
{
	// Invoke printInfo() before removing
	this->printInfo(std::cout);
	
	// just similar to FlatFare
	vector<string>::iterator it;
	it = this->stops.begin();
	while(*it != stopname)
		it++;
	
	this->stops.erase(it);
	
	this->printInfo(std::cout);
}	// end removeStop()
