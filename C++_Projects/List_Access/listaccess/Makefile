#
# COMP151 Lab 3
#

# Variables
EXE = listaccess
OBJS = resource.o List.o main.o
CFLAGS = -g

all: $(EXE)

resource.o: resource.h resource.cpp
	g++ $(CFLAGS) -c resource.cpp

List.o: List.h List.cpp
	g++ $(CFLAGS) -c List.cpp

main.o: List.h main.cpp
	g++ $(CFLAGS) -c main.cpp

$(EXE): $(OBJS)
	g++ $(CFLAGS) -o $(EXE) $(OBJS)

clean:
	@echo "Cleaning files..."
	rm -f core $(OBJS) $(EXE)
