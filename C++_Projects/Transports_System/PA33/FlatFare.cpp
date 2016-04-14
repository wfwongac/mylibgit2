/* FlatFare.cpp
* - the source file for the implementation of the methods of FlatFare class
*/

#include "FlatFare.h"

// Add the implementation of the methods here

// the default constructor to initialize
//the name and id to empty string and 0.
FlatFare::FlatFare()
:Transport("", 0){ }

//the constructor to initialize the name,
//id and the data member fare by the corresponding parameters.
FlatFare::FlatFare(string name, int id, double fare)
:Transport(name, id), singleTripFare(fare){ }


void FlatFare::readInfo(string filename)
{
	ifstream fin;
	fin.open(filename.c_str());
	if(fin)
	{
		int tempNum;
		fin >> tempNum;
		
		fin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
		for(int i=0; i<tempNum; i++)
		{
			string tempStop;

			getline(fin, tempStop, '\n');
			stops.push_back(tempStop);
		}
	}else{
		cout << "File cannot be opened !\n" ;
	}

	fin.close();
}
//the constructor to initialize the name,
//id and fare by the given parameters, name,
//id & fare; and read the input file, filename,
//and store the data into the appropriate data members.
FlatFare::FlatFare(string name, int id, double fare, string filename)
:Transport(name, id), singleTripFare(fare)
{
	//read the input file
	readInfo(filename);
}

//the copy constructor
FlatFare::FlatFare(const FlatFare& other)
:Transport(other.getName(), other.getId()), singleTripFare(other.getFare())
{
	stops = other.stops;
}

//the equal-to operator
bool FlatFare::operator==(const FlatFare& other) const
{
	if(this->getName() == other.getName() && this->getId() == other.getId() && this->getFare() == other.getFare())
	{
		if(this->stops.size() != other.stops.size())
			return false;

		// check for stops
		for(unsigned int i=0; i<this->stops.size(); i++)
		{
			if(this->stops[i] != other.stops[i])
				return false;
		}

		// all informatio are equal
		return true;

	}else
		return false;

}

//the assignment operator
FlatFare& FlatFare::operator=(const FlatFare& other)
{
	this->setName(other.getName());
	this->setId(other.getId());
	this->singleTripFare = other.getFare();
	this->stops.clear();

	this->stops = other.stops;

	return *this;
}

//return the singleTripFare
double FlatFare::getFare() const
{
	return singleTripFare;
}

void FlatFare::printInfo(ostream& os) const
{
	os << "Name: " << getName() << endl;
	os << "ID: " << getId() << endl;
	os << "Single Trip Fare: " << getFare() << endl;

	vector< string >::const_iterator it = stops.begin();

	for(; it != stops.end(); it++)
		os << (*it) << endl;

}
bool FlatFare::searchStop(string name) const
{
	vector<string>::const_iterator it;
	it = this->stops.begin();
	for(; it != this->stops.end(); it++)
		if(name == *(it))
			return true;
	// No stop with the given name
	return false;
}
void FlatFare::removeStop(string stopname)
{

	// stopname must exist by checking in main()

	vector<string>::iterator it;
	it = this->stops.begin();
	while(*it != stopname)
		it++;

	this->stops.erase(it);
}

list<string> FlatFare::findDestinations(string ori, double fare) const
{
	list<string> result;

	if(this->getFare() <= fare)
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
