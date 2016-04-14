#include <cmath>
#include <cfloat>
#include "exp_func.h"

using namespace std;

ExpFunc::ExpFunc(double _scale, double _exp_scale)
: Func("exp", false), scale(_scale), exp_scale(_exp_scale)
{
}

// TODO: override ...
// ...
 bool ExpFunc::IsDifferentiable(double d) const
 {
     return true;

 }

 double ExpFunc::EvaluateAt(double d) const
 {
	 double result = scale*exp(exp_scale*d);
	 return result;
 }

 double ExpFunc::DerivativeAt(double d) const
 {
	 double result = scale*exp_scale*exp(exp_scale*d);
	 return result;

 }

void ExpFunc::Print(ostream& os, double x) const {
	const char* const T = "true";
	const char* const F = "false";

	os << "name = " << GetName() << endl
		<< "is periodic = " << (IsPeriodic()? T: F) << endl
		<< "value at " << x << " = ";
		if(fabs(EvaluateAt(x)-DBL_MAX)<0.000001)
            os << F<<endl;
        else
            os << EvaluateAt(x) << endl;
	os << "is differentiable at " << x << " = "
		<< (IsDifferentiable(x)? T: F) << endl;

	if (IsDifferentiable(x)) {
		os << "derivative at " << x << " = " << DerivativeAt(x) << endl;
	}
}

ExpFunc* CreateExpFunc(ostream& os, istream& is) {
	os << "scale and exponent scale? (separate them with a space)" << endl;
	os << "> ";
	double i, m;
	ExpFunc* ex = NULL;
	if ((is >> i) && (is >> m)) {
		ex = new ExpFunc(i, m);
	}

	return ex;
}
