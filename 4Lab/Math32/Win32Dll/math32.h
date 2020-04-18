#ifdef MATH32_EXPORTS
#define MATH32_API __declspec(dllexport)
#else
#define MATH32_API __declspec(dllimport)
#endif



extern "C" MATH32_API bool find_factor(double* pointX, double* pointY, int number_of_point, double epsilon);


extern "C" MATH32_API double f(double x);

extern "C" MATH32_API double get_tlit_angle();


extern "C" MATH32_API double get_factor_b();

