CXX=g++
CXXFLAGS=-Wall
SRCS=Transport.cpp DistanceBased.cpp Bus.cpp Railway.cpp FlatFare.cpp CableCar.cpp main.cpp
OBJS=$(SRCS:.cpp=.o)
LIBS=
TARGET=pa3

all: $(SRCS) $(TARGET)

$(TARGET): $(OBJS)
	$(CXX) $(CXXFLAGS) $(OBJS) -o $@

.cpp.o:
	$(CXX) $(CXXFLAGS) -c $< -o $@

clean:
	rm -f $(OBJS) $(TARGET)

