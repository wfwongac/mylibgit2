//source: Sammy
//date: 20/2/2003

#include <iostream>
#include <string>
#include "List.h"
using namespace std;

extern string *arrCity;
extern int intNumCity;
extern void ResBuild();

int main()
{
  string strCity;
  int intCost;
  int intTotal;
  List list;

  ResBuild();
  list.Init(arrCity, intNumCity);
  list.Insert("Seoul");
  list.Delete("Beijing");
  list.Delete("Athens");

  cout << "List Accessing Problem\n";
  cout << "Type Cities to Access and end with '#' (q to exit)\n";
  cout << " e.g. London HongKong Paris ... HongKong #\n\n";

  while (true) {
	intCost = 0;
 
	list.Print();
	cout << "\nCities > ";

	while(cin >> strCity) {
	  if (strCity == "q" || strCity == "#")
		break;

	  intCost += list.Access(strCity);
	  list.Transpose(strCity);
	}

	if(intCost != 0)
	  cout << "Cost:" << intCost << "\n\n";
	
	if (strCity == "q")
	  return 0;
  }
  return 0;
}
