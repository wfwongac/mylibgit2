/* DistanceBased.cpp
 * - the source file for the implementation of the methods of DistanceBased class
 */


#include "DistanceBased.h"

/* printing the info of the transport */
void DistanceBased::printInfo(ostream& os) const {
       os << "Name: " << transportName<< endl;
       os << "ID: " << id  << endl;		// have deleted a "endl"
       printFares(os);
}

// Add the rest of the implementation here

// the default constructor
DistanceBased::DistanceBased():Transport(){ }

//the constructor to initialize the name and
//id inherited from the Transport class
DistanceBased::DistanceBased(string name, int id):Transport(name, id){ }

// the destructor
DistanceBased::~DistanceBased()
{

}

