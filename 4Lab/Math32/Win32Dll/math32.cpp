
#include "pch.h" 
#include <utility>
#include <limits.h>
#include "math32.h"


static double k_ = 0;  
static double b_ = 0;              


double f(double x)
{
    if (x == 0)
    {
        return 1;
    }

    return k_ * x + b_;
}


double summ(double* point,int number_of_point)
{
    double result = 0;
    for (int i = 0; i < number_of_point; i++)
    {
        result += point[i];
    }
    return result;
}

bool find_error_point(double* pointX, double* pointY, int &number_of_point, double epsilon)
{
    if (epsilon < 0)
    {
        return false;
    }
    double max = 0;
    int index = -1;
    for (int i = 0; i < number_of_point; i++)
    {
        double temp = fabs(f(pointX[i]) - pointY[i]);
        if (temp > epsilon && max < temp)
        {
            max = temp;
            index = i;
        }
    }

    if (index != -1)
    {
        double reverse = pointX[index];
        pointX[index] = pointX[number_of_point - 1];
        pointX[number_of_point - 1] = pointX[index];
        reverse = pointY[index];
        pointY[index] = pointY[number_of_point - 1];
        pointY[number_of_point - 1] = pointY[index];
        number_of_point--;
        return true;
    }
    return false;
}



bool find_factor(double* const_PointX, double* const_PointY, int number_of_point, double epsilon)
{
    double average_array[] = { 0,0,0,0 };
    double* temp = new double[number_of_point];
    double* pointX = new double[number_of_point];
    double* pointY = new double[number_of_point];
    for (int i = 0; i < number_of_point; i++)
    {
        pointX[i] = const_PointX[i];
        pointY[i] = const_PointY[i];
    }
    do
    {
        for (int i = 0; i < number_of_point; i++)
        {
            temp[i] = pointX[i] * pointY[i];
        }
        average_array[0] = summ(temp, number_of_point) / number_of_point;

        average_array[1] = (summ(pointX, number_of_point) / number_of_point) * (summ(pointY, number_of_point) / number_of_point);

        for (int i = 0; i < number_of_point; i++)
        {
            temp[i] = pointX[i] * pointX[i];
        }

        average_array[2] = summ(temp, number_of_point) / number_of_point;

        average_array[3] = (summ(pointX, number_of_point) / number_of_point) * (summ(pointX, number_of_point) / number_of_point);

        k_ = (average_array[0] - average_array[1]) / (average_array[2] - average_array[3]);
        b_ = (summ(pointY, number_of_point) / number_of_point) - k_ * (summ(pointX, number_of_point) / number_of_point);
    } while (find_error_point(pointX, pointY, number_of_point, epsilon));
    delete[] temp;
    return true;
}


double get_tlit_angle()
{
    return k_;
}


double get_factor_b()
{
    return b_;
}
