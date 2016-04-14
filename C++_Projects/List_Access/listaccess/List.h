//source: Chau Ming Kit
//date: 23/9/2000

#ifndef LIST_H
#define LIST_H

#include <iostream>
#include <string>
using namespace std;

class List {
private:
  struct sCity {
	string strCity;
	sCity* ptrNext;
  };
  sCity* m_Head;

public:
  List();
  ~List();

  void Init(string arrCity[], int intCity);
  bool Insert(string strCity);
  bool Delete(string strCity);
  void Print();

  int Access(string strCity);
  void Transpose(string strCity);
};

#endif
