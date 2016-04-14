/* Transport.cpp
 * - the source file for the implementation of the methods of Transport class
 */

#include "Transport.h"

// Add your implementation below

Transport::Transport()
:transportName(""), id(0)
{

}

Transport::Transport(string name, int ID)
{
	transportName = name;
	id = ID;
}

Transport::~Transport()
{

}

void Transport::setName(string name)
{
	transportName = name;
}

void Transport::setId(int n)
{
	id = n;
}

string Transport::getName() const
{
	return transportName;
}

int Transport::getId() const
{
	return id;
}

