CCC = g++ -g
SRCS = main.cpp tri_func.cpp poly_func.cpp impulse_func.cpp exp_func.cpp func.cpp
OBJS = main.o tri_func.o poly_func.o impulse_func.o exp_func.o func.o
EXE = lab11 

%.o: %.cpp
	$(CCC) -c $<

all: $(EXE)

$(EXE): $(OBJS)
	$(CCC) -o $@ $(OBJS) -lm

clean:
	rm -f core $(OBJS) $(EXE)

depend:
	makedepend -- $(INCLUDE) -- $(SRCS)
# DO NOT DELETE

main.o: func.h tri_func.h poly_func.h impulse_func.h exp_func.h
tri_func.o: tri_func.h func.h
poly_func.o: poly_func.h func.h
impulse_func.o: impulse_func.h func.h
exp_func.o: exp_func.h func.h
func.o: func.h
