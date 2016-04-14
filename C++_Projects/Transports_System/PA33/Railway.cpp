/* Railway.cpp
 * - the source file for the implementation of the methods of Railway class
 */

#include "Railway.h"

// Add the implementation of the methods here
Railway::Railway():DistanceBased("", 0){ }


void Railway::readInfo(string filename)
{
	ifstream fin;
	fin.open(filename.c_str());
	
	if(!fin)
	{
		cerr << "File cannot open ! \n" ;
		exit(1);
	}else{
		int numStop;
		fin >> numStop;
		fin.ignore(std::numeric_limits<std::streamsize>::max(),'\n');

		//store StopNames
		for(int i=0; i<numStop; i++)
		{
			string tempName;
			getline(fin, tempName, '\n');
			stopNames.push_back(tempName);
		}
		//store 2D fares
		for(int i=0; i<numStop; i++)
		{
			vector<double> temp;
			temp.clear();
			for(int j=0; j<numStop; j++)
			{
				double tempFare;
				fin >> tempFare;
				temp.push_back(tempFare);

			}
			fin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
			fares.push_back(temp);
		}
	
		//end reading Information
		
	}

}


 /*the constructor to initialize the name and id
  * by the given parameters, name & id;
  * and read the input file, filename,
  * and store the data into the appropriate data members. */
Railway::Railway(string name, int id, string filename)
:DistanceBased(name, id)
{
	//read the input file
	readInfo(filename);

}

Railway::Railway(string name, int id):DistanceBased(name, id){ }

	 //the copy constructor (deep copy)
Railway::Railway(const Railway& other)
:DistanceBased(other.getName(), other.getId())
{
	this->stopNames.clear();
	this->stopNames = other.stopNames;
	for(unsigned int i=0; i<other.stopNames.size(); i++)
	{
		this->fares[i].clear();
		this->fares[i] = other.fares[i];
	}
}

Railway::~Railway()
{
	int temp = stopNames.size();
	stopNames.clear();			// delete ?? or
	for(int i=0; i<temp; i++)
	{
		fares[i].clear();
	}
}

int Railway::searchStopIndex(string stop) const
{
	int index = 0;
	for(unsigned int i=0; i<stopNames.size(); i++)
	{
		if(stopNames[i] == stop)
			index = i;
	}
	return index;
}

bool Railway::operator==(const Railway& other) const
{
	if(transportName == other.getName() && id == other.getId())
	{
		if(this->stopNames.size() != other.stopNames.size())
			return false;

		for(unsigned int i=0; i<this->stopNames.size(); i++)
		{
			if(this->stopNames[i] != other.stopNames[i])
				return false;

			for(unsigned int j=0; j<this->fares[i].size(); j++)
			{
				if(this->fares[i][j] != other.fares[i][j])
					return false;
			}
		}
		// all information equal return true
		return true;
	}else
		return false;
}

Railway& Railway::operator=(const Railway& other)
{
	int temp = stopNames.size();
	stopNames.clear();			// delete ?? or
	for(int i=0; i<temp; i++)
	{
		fares[i].clear();
	}
	transportName = other.getName();
	id = other.getId();
	stopNames = other.stopNames;
	for(unsigned int i=0; i<stopNames.size(); i++)
	{
		fares[i] = other.fares[i];
	}
	return *this;
}


void Railway::printFares(ostream& os) const
{

	for(unsigned int i=0; i<stopNames.size(); i++)
	{
		os << "\t" << stopNames[i] ;
	}
	os << endl;
	for(unsigned int i=0; i<fares.size(); i++)
	{
		os << stopNames[i] ;
		for(unsigned int j=0; j<fares[i].size(); j++)
		{
			os << "\t" << fares[i][j];
		}
		os <<endl;
	}

}

double Railway::findFare(string ori, string des) const
{
	int indexOfOri = searchStopIndex(ori);
	int indexOfDes = searchStopIndex(des);
	return fares[indexOfOri][indexOfDes];
}
void Railway::printInfo(ostream& os) const 
{
	os << transportName << endl;
	os << id << endl;
	printFares(std::cout);

}

bool Railway::searchStop(string name) const
{
	for(unsigned int i=0; i<stopNames.size(); i++)
	{
		if(stopNames[i] == name)
			return true;
	}
	return false;
}

void Railway::removeStop(string stopname)
{

	int index = this->searchStopIndex(stopname);
	this->stopNames.erase(stopNames.begin()+index);

	// remove the fare with found index
	for(unsigned int i=0; i<this->fares.size(); i++)
	{
		this->fares[i].erase(fares[i].begin()+index);
	}

	this->fares.erase(fares.begin()+index);


}

list<string> Railway::findDestinations(string ori, double fare) const
{
	list<string> result;
	for(unsigned int i=0; i<stopNames.size();i++)
	{
		if(findFare(ori, stopNames[i]) <= fare)
			result.push_back(stopNames[i]);
	}

	return result;
}
