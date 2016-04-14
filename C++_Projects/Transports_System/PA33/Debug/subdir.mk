################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
O_SRCS += \
../Bus.o \
../CableCar.o \
../DistanceBased.o \
../FlatFare.o \
../Railway.o \
../Transport.o \
../main.o 

CPP_SRCS += \
../Bus.cpp \
../CableCar.cpp \
../DistanceBased.cpp \
../FlatFare.cpp \
../Railway.cpp \
../Transport.cpp \
../main.cpp 

OBJS += \
./Bus.o \
./CableCar.o \
./DistanceBased.o \
./FlatFare.o \
./Railway.o \
./Transport.o \
./main.o 

CPP_DEPS += \
./Bus.d \
./CableCar.d \
./DistanceBased.d \
./FlatFare.d \
./Railway.d \
./Transport.d \
./main.d 


# Each subdirectory must supply rules for building sources it contributes
%.o: ../%.cpp
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C++ Compiler'
	g++ -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o"$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


