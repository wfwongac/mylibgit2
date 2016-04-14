#include <iostream>
#include <fstream>
#include <string>
#include <stdlib.h>
#include <math.h>

#include "busRoute.h"

using namespace std;

int main(int argc, char* argv[])
{
   streambuf* buf;
   ofstream of;
   if (argc > 1) {
     of.open(argv[1]);
     buf = of.rdbuf();
   } else {
     buf = std::cout.rdbuf();
   }
   ostream out(buf);

   busRoute route1;

   out << "...Reading the input file: input2.txt ..." << endl;
   route1=readlist("input2.txt");

   out << "...Info of the route:" << endl;
   printRoute(route1, out);
   out << endl;

   out << "...The direct distance of the route is " << directDistance(route1) << endl;
   out << "...The path length of the route is " << pathLength(route1) << endl;
   out << endl;

   string currentStop = "Diamond Hill Station";
   out << "...Searching for the stop \"" << currentStop << "\"... " << endl;
   if (searchStop(route1, currentStop)) {
      out << "...The stop is found.\n";
      out << "...The next stop is: " << getNextStopName(route1, currentStop) << endl;
      out << "...The prev stop is: " << getPrevStopName(route1, currentStop) << endl;
   } else
      out << "...The stop is not found." << endl;
   out << endl;

   out << "...Inserting the stop \"Ka Keung Court\"..." << endl;
   insertStop(route1, "Ka Keung Court", 22.3430333333, 114.1852);

   out << "...Info of the updated route:" << endl;
   printRoute(route1, out);
   out << endl;

   out << "...Removing the stop \"Shek Kip Mei Park\"..." << endl;
   removeStop(route1, "Shek Kip Mei Park");

   out << "...Info of the updated route:" << endl;
   printRoute(route1, out);
   out << endl;

   out << "...Reversing the route..." << endl;
   reverseRoute(route1);
   printRoute(route1, out);
   out << endl;

   out << "...Inserting the stop \"Shek Kip Mei Park\"..." << endl;
   insertStop(route1, "Shek Kip Mei Park", 22.339333333, 114.171216667);
   out << "...Info of the updated route:" << endl;
   printRoute(route1, out);
   out << endl;

   string stopA = "Diamond Hill Station", stopB="Lantau Link Toll Plaza";
   out << "...Reversing the stops between \"" << stopA << "\" to \"" << stopB << "\"..." << endl;
   reverseList(route1, stopA, stopB);
   printRoute(route1, out);
   out << endl;

   string newStop = "Yu Tung Court";
   float newLatitude = 22.28655;
   float newLongitude = 113.94916667;
   out << "...Inserting the stop \"" << newStop << "\"..." << endl;
   insertStop(route1, newStop, newLatitude, newLongitude);
   out << "...Info of the updated route:" << endl;
   printRoute(route1, out);
   out << endl;

   currentStop = "Diamond Hill Station";
   out << "...Removing the stop \"" << currentStop << "\"..." << endl;
   removeStop(route1, currentStop);
   out << "...Info of the updated route:" << endl;
   printRoute(route1, out);
   out << endl;

   eraseRoute(route1);

   of.close();

   return(0);
}
