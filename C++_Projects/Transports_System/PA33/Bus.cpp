/*
 * Bus.cpp
 * -- the implementation of the StopData class & Bus class
 */

#include "Bus.h"

StopData::StopData(): name(""), fare(0.0)
{
}

StopData::StopData(string name, double fare)
{
      this->name = name;
      this->fare = fare;
}

StopData::StopData(const StopData& other)
{
      this->name = other.name;
      this->fare = other.fare;
}

string StopData::getName() const
{
   return name;
}
void StopData::setName(string name)
{
   this->name = name;
}
double StopData::getFare() const
{
   return fare;
}

void StopData::setFare(double fare)
{
  this->fare = fare;
}

bool StopData::operator==(const StopData& other) const
{
       if ((name == other.name) && (fare == other.fare))
           return true;
       else
           return false;
}

StopData& StopData::operator=(const StopData& other)
{
      this->name = other.name;
      this->fare = other.fare;
      return (*this);
}

// Add the implementation of the methods of Bus below
Bus::Bus():DistanceBased("", 0)
{
	stopNamesFares = (list<StopData>) (0);
}

Bus::Bus(string name, int id):DistanceBased(name, id)
{
	stopNamesFares = (list<StopData>) (0);
}

void Bus::readInfo(string filename)
{
	ifstream fin(filename.c_str());
	if(!fin)
	{
		cout << "File cannot be opened! \n" ;
	}else{
		int numStop = 0;
		fin >> numStop;
		fin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
	
		for(int i=0; i<numStop; i++)
		{
		// start store the stopName :
			StopData tempstop;
			string tempName;
			double tempFare;
			getline(fin, tempName, ',');
			fin >> tempFare;
			fin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			tempstop.setName(tempName);
			tempstop.setFare(tempFare);
			stopNamesFares.push_back(tempstop);
		}
	}
}

Bus::Bus(string name, int id, string filename):DistanceBased(name, id)
{
	readInfo(filename);
}
Bus::Bus(const Bus& other):DistanceBased(other.getName(), other.getId())
{
	list<StopData>::const_iterator _that;
	for(_that = other.stopNamesFares.begin(); _that != other.stopNamesFares.end(); _that++)
				stopNamesFares.push_back(*(_that));

}
Bus::~Bus()
{
	stopNamesFares.clear();
}
bool Bus::operator==(const Bus& other) const
{
	if(this->transportName == other.transportName && this->id == other.id)
	{
		list<StopData>::const_iterator _that;
		list<StopData>::const_iterator _it;
		_that = other.stopNamesFares.begin();
		_it = this->stopNamesFares.begin();
		for(; _that != other.stopNamesFares.end() , _it != stopNamesFares.end() ; _that++, _it++)
			if(!( *_it == *_that))
				return false;

		return true;

	}else
		return false;

}
Bus& Bus::operator=(const Bus& other)
{
	this->setName(other.getName());
	this->setId(other.getId());
	list<StopData>::const_iterator _that;
		for(_that = other.stopNamesFares.begin(); _that != other.stopNamesFares.end(); _that++)
					this->stopNamesFares.push_back(*(_that));
	return *this;
}

void Bus::printFares(ostream& os) const
{
	list<StopData>::const_iterator it;
	it = this->stopNamesFares.begin();
	for(; it != this->stopNamesFares.end();it++)
	{
		os << it->StopData::getName() << "," << it->getFare() << endl ;
	}
	cout << endl;
}

void Bus::printInfo(ostream& os) const
{
	os << "Name: " << transportName<< endl;
	os << "ID: " << id  << endl;
	printFares(std::cout);

}

double Bus::findFare(string ori, string des) const
{
	if(searchStop(ori) && searchStop(des))
	{
		list<StopData>::const_iterator it;
		it = this->stopNamesFares.begin();
		while(it->getName() != ori)
			it++;
		// 'it' points to the ori StopData
		return it->getFare();

	}else
		return 0.0;
}

void Bus::removeStop(string stopname)
{

	list<StopData>::iterator it;
	it = this->stopNamesFares.begin();
	for(; it != this->stopNamesFares.end();it++)
	{

			if((*it).getName() == stopname)
			{
				this->stopNamesFares.erase(it);
				break;
			}
	}
	
}

bool Bus::searchStop(string name) const
{

	list<StopData>::const_iterator it;
	it = this->stopNamesFares.begin();
	for(; it != this->stopNamesFares.end();it++)
		{

			if((*it).getName() == name)
				return true;
		}
	return false;
}

list<string> Bus::findDestinations(string ori, double fare) const
{
	list<string> result;

	list<StopData>::const_iterator it;
	it = this->stopNamesFares.begin();
	for(; it != this->stopNamesFares.end(); it++)
	{
		if(findFare(ori, it->getName()) <= fare)
			result.push_back(it->getName());
	}

	return result;
}
