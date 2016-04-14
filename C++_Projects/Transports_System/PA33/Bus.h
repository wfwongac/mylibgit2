/* Bus.h
 * - the header file for the class declaration of Bus
 */

#ifndef _BUS_H
#define _BUS_H

#include "DistanceBased.h"

class StopData {
  private:
   string name;
   double fare;
  public:
   StopData();
   StopData(string name, double fare);
   StopData(const StopData& other);
   string getName() const;
   void setName(string name);
   double getFare() const;
   void setFare(double fare);
   bool operator==(const StopData& other) const;
   StopData& operator=(const StopData& other);
 };

class Bus:public DistanceBased {
   // Add the data members and methods

protected:
	//an STL list of StopData objects
	//for storing the stopnames and fares
	list<StopData> stopNamesFares;

public:
	Bus();
	Bus(string name, int id);
	Bus(string name, int id, string filename);
	Bus(const Bus& other);
	~Bus();
	bool operator==(const Bus& other) const;
	Bus& operator=(const Bus& other);

	virtual void readInfo(string filename);

	void printInfo(ostream& os) const;

	virtual void printFares(ostream& os) const;

	virtual double findFare(string ori, string des) const;

	virtual void removeStop(string stopname);

	virtual bool searchStop(string name) const;

	virtual list<string> findDestinations(string ori, double fare) const;

};

#endif
