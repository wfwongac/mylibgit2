//source: Sammy
//date: 20/2/2003

#include "List.h"

List::List()
{
  m_Head = NULL;
}

List::~List()
{
  sCity *ptrTemp;
  while (m_Head != NULL) {
	ptrTemp = m_Head;
	m_Head = m_Head->ptrNext;
	delete ptrTemp;
  }
}

void List::Init(string arrCity[], int intCity)
{
  int i;
  for(i=0; i<intCity; i++) {
	Insert(arrCity[i]);
  }
}

void List::Print()
{
  sCity *ptrTemp;
  ptrTemp = m_Head;
  while(ptrTemp != NULL) {
	cout << ptrTemp->strCity << " ";
	ptrTemp = ptrTemp->ptrNext;
  }
}

int List::Access(string strCity)
{
  int count = 0;
  sCity *ptrTemp;

  if (m_Head == NULL)		// empty list
	return -1;

  ptrTemp = m_Head;
  while (ptrTemp != NULL) {
	count++;
	if (ptrTemp->strCity == strCity)
	  break;
	ptrTemp = ptrTemp->ptrNext;
  }
  if(ptrTemp == NULL)
	return 0;

  return count;
}

bool List::Insert(string strCity)
{
  if (strCity == "q") {
	cerr << "invalid city name\n";
	return false;
  }

  if (m_Head == NULL) {	// empty list
	m_Head = new sCity;
	m_Head->strCity = strCity;
	m_Head->ptrNext = NULL;
  }
  else {
	//Create new node
	sCity *ptrCity;
	ptrCity = new sCity;
	ptrCity->strCity = strCity;
	ptrCity->ptrNext = NULL;

	sCity *ptrTemp;
	ptrTemp = m_Head;
	while (ptrTemp->ptrNext != NULL) {
	  if (ptrTemp->strCity == strCity)	// discard duplicated node
		return false;
	  ptrTemp = ptrTemp->ptrNext;
	}
	if (ptrTemp->strCity == strCity)	// checking the last node
	  return false;

	//Append to last
	ptrTemp->ptrNext = ptrCity;
  }
  return true;
}

bool List::Delete(string strCity)
{
  sCity *ptrTemp;
  sCity *ptrDelete;

  //Empty list
  if (m_Head == NULL)
	return false;

  //The fist one
  if (m_Head->strCity == strCity) {
	ptrDelete = m_Head;
	delete ptrDelete;
	ptrDelete = NULL;
	m_Head = m_Head->ptrNext;
	return true;
  }

  ptrTemp = m_Head;
  while (ptrTemp->ptrNext != NULL) {
	if (ptrTemp->ptrNext->strCity == strCity) {
	  ptrDelete = ptrTemp->ptrNext;
	  delete ptrDelete;
	  ptrDelete = NULL;
	  ptrTemp->ptrNext = ptrDelete->ptrNext;
	  return true;
	}
  }
  return false;
}

void List::Transpose(string city)
{
  sCity *ptrCurr = m_Head;
  sCity *ptrPrev = NULL;

  if(m_Head == NULL)
	return;

  while (ptrCurr != NULL) {
	if(ptrCurr->strCity == city && ptrPrev != NULL) {
	  // Transpose
	  ptrCurr->strCity = ptrPrev->strCity;
	  ptrPrev->strCity = city;
	  break;
	}
	ptrPrev = ptrCurr;
	ptrCurr = ptrCurr->ptrNext;
  }
  return;
}
