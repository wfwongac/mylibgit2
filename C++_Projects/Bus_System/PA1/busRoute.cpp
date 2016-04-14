#include <iostream>
#include <fstream>
#include <string>
#include <stdlib.h>
#include <math.h>

#include "busRoute.h"

using namespace std;

/* To check if the route is empty.
   If the linked list, route, is empty, returns true, otherwise, returns false. */
bool isEmpty(busRoute route)
{
  return ((route.start)?false:true);
}

/* Given a bus stop name, find the next stop's name */
string getNextStopName(busRoute route, string stopName)
{
  string name = "";
  if (!isEmpty(route))
  {
    stop_pointer found = searchlist(route, stopName);
    if ((found!=NULL) && (found->next != NULL))
    {
       name = found->next->stop_name;
    }
  }
  return (name);
}

/* Given a bus stop name, find the previous stop's name */
string getPrevStopName(busRoute route, string stopName)
{
  string name = "";
  if (!isEmpty(route))
  {
    stop_pointer found = searchlist(route, stopName);
    if ((found!=NULL) && (found->prev != NULL))
    {
       name = found->prev->stop_name;
    }
  }

  return (name);
}

/* To print the information of a bus stop with the given stop_pointer */
void printStop(stop_pointer stop, ostream& os)
{
  if (stop != NULL)
    os << stop->stop_name << ", " << stop->latitude << ", " << stop->longitude << endl;
}

/* To print all the information of the bus route */
void printRoute(busRoute route, ostream& os)
{
  stop_pointer temp;
  temp = route.start;
  os << "The list of bus stops for Route No. " << route.routeNo << ":" << endl;
  int stopNum = 1;
  while (temp != NULL) {
    os << "Stop " << stopNum << ":";
    printStop(temp, os);
    temp = temp->next;
    stopNum++;
  }
}

/* To construct the linked list from the bus route information in the file */
busRoute readlist(const char* filename)
{

	  busRoute reRoute;
	  fstream inwf(filename);
	  if(!inwf){
		  cerr << "file could not be opened!" << endl;
		  inwf.close();
	  }else{

		  inwf >> reRoute.routeNo;
		  inwf.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
		  reRoute.start = new stop_node;
		  busRoute work_pt;
		  work_pt.start = reRoute.start;
		  reRoute.start->prev = NULL;	// first stop's prev must point to NULL

		  while(!inwf.eof()){

			  std::getline(inwf, work_pt.start->stop_name, ',');
			  inwf >> work_pt.start->latitude;
			  inwf.ignore();
			  inwf >> work_pt.start->longitude;

			  inwf.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

			  if(!inwf.eof()){
				  work_pt.start->next = new stop_node;	// create a new bus_stop_node
				  work_pt.start->next->prev = work_pt.start;
				  work_pt.start = work_pt.start->next;	//	wk_pt point to the new address
			  }
		  }
		  work_pt.start->next = NULL;	//	the last bus_stop_node's next pt to NULL
		  inwf.close();
	  }
	  return reRoute;
}

/* Erase the route object and deallocate all the nodes in the linked list */
void eraseRoute(busRoute& route)												//	Should I use a reverse function ????
{
	stop_pointer work_pt;
	work_pt = route.start;

	while(work_pt->next->next != NULL){
		work_pt = work_pt->next;
	}	// Go to the last 2 bus_stop_node

	while(work_pt->prev != route.start){
		delete work_pt->next;				//	delete the next bus_stop_node
		work_pt->next = NULL;
		work_pt = work_pt->prev;
	}

}

/* To search and return the pointer to the node of the linked list,
   stop_node,with the given name, stopName, in the route object */
stop_pointer searchlist(busRoute route, string stopName)
{
	if(searchStop(route, stopName)){
			stop_pointer temp;
			temp = route.start;
			while(temp->stop_name != stopName){
				temp = temp->next;
			}
			return temp;
	}
	cout << "No such Stop Name ! ";
	return 0;
}

/* To search if a bus stop with the given name existed in the route.
   If found, returns true, otherwise, returns false. */
bool searchStop(busRoute route, string stopName)
{
	  stop_pointer work_pt = route.start;

	  do{
		  if(work_pt->stop_name == stopName)
			  return true;

		  work_pt = work_pt->next;
	  }while(work_pt != NULL);

	  return false;
}

/* To remove a bus stop with the given name from the route */
void removeStop(busRoute& route, string stopName)
{
	stop_pointer q = route.start;
	stop_pointer temp;
	if(route.start->stop_name == stopName)
		route.start = route.start->next;
	else{
		while(q != NULL){
			if(q->next->stop_name == stopName)
			{
				temp = q->next;
				q->next = temp->next;
				temp->next->prev = q;
				delete temp;
				break;
			}
			q = q->next;
		}
	}
	return;
}

/* To find the displacement, i.e. the difference between the first and the last bus stops */
float directDistance(busRoute route)
{
	stop_node* _first = route.start;			//_first point to the 1st bus stop
	while(route.start->next != NULL)
		route.start = route.start->next;		//point to the next bus stop until the last one
	stop_node* _last = route.start;

	float _Dist = (_first->latitude - _last->latitude)*(_first->latitude - _last->latitude) + (_first->longitude - _last->longitude)*(_first->longitude - _last->longitude);

	return sqrt(_Dist);
}

/* To find the sum of displacements, i.e. differences,  between every two consecutive bus stops on the bus route */
float pathLength(busRoute route)
{
	stop_pointer _first = route.start;
	stop_pointer _next = route.start->next;
	float _sqrtDist = 0.0;

	while(_first->next != NULL){
		float _Dist = (_first->latitude - _next->latitude)*(_first->latitude - _next->latitude) + (_first->longitude - _next->longitude)*(_first->longitude - _next->longitude);
		_sqrtDist += sqrt(_Dist);
		_first = _next;
		_next = _next->next;
	}
	return _sqrtDist;
}

/* To reverse the doubly linked list of the route object */
void reverseRoute(busRoute& route)
{
  stop_pointer temp=route.start;
  if (temp->next != NULL)
  {
    while (temp->next != NULL)
    {
      temp = temp->next;
    }

    reverseList(route, route.start->stop_name, temp->stop_name);
  }
  return;
}

/* To reverse the nodes between stopA to stopB in the doubly linked list of the route object */
void reverseList(busRoute& route, string stopA, string stopB)
{
	stop_pointer StartPt = searchlist(route, stopA);
	stop_pointer EndPt = searchlist(route, stopB);

	stop_pointer prvStart = StartPt->prev;
	stop_pointer nxtEnd = EndPt->next;

	stop_pointer ptr = StartPt;
	while(ptr != NULL){
			stop_pointer temp = ptr->next;
			ptr->next = ptr->prev;
			ptr->prev = temp;
			if(temp == EndPt){
					temp->next = ptr;
					EndPt = StartPt;
					StartPt = temp;
					break;
			}
			ptr = temp;
	}
	if(route.start == EndPt){
			route.start = StartPt;
	}
	if(prvStart != NULL)
			prvStart->next = StartPt;
	StartPt->prev = prvStart;

	if(nxtEnd != NULL)
			nxtEnd->prev = EndPt;
	EndPt->next = nxtEnd;
}

/* To insert a bus stop in between two closest consecutive bus stops */
void insertStop(busRoute& route, string stopname, float latitude, float longitude){

	stop_pointer _insert;

	_insert = new stop_node;

	_insert->stop_name = stopname;
	_insert->latitude = latitude;
	_insert->longitude = longitude;
	_insert->next = NULL;
	_insert->prev = NULL;

	stop_pointer node_Ptr = route.start;

	if( node_Ptr->next == NULL)
	{
		_insert->next = NULL;
		node_Ptr->next = _insert;
		_insert->prev = node_Ptr;

		return;
	}

	float _array[10];
	float min = 20;
	stop_pointer bnode, anode=NULL;

	for(int i = 0; node_Ptr->next != NULL; i++, node_Ptr = node_Ptr->next){
		float d1 = (node_Ptr->latitude - latitude)*(node_Ptr->latitude - latitude)+(node_Ptr->longitude - longitude)*(node_Ptr->longitude - longitude);
		float d2 = (node_Ptr->next->latitude - latitude)*(node_Ptr->next->latitude - latitude)+(node_Ptr->next->longitude - longitude)*(node_Ptr->next->longitude - longitude);
		_array[i] = sqrt(d1)+sqrt(d2);


		if(_array[i] < min){			//find the shortest dist. and mark the node by _PrevT
			min = _array[i];
			bnode = node_Ptr;
			anode = bnode->next;
		}
	}

	_insert->prev = bnode;
	_insert->next = anode;
	anode->prev = _insert;
	bnode->next = _insert;
}

// End of file
