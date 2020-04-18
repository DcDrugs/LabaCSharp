using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GraphicMaker.Math32
{
    class Math32
    {
        [DllImport(@"math32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double f(double x);

        [DllImport(@"math32.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe public static extern bool find_factor(double* pointX, double* pointY, int number_of_point, double epsilon);

        [DllImport(@"math32.dll", CallingConvention = CallingConvention.Cdecl)]
        public  static extern double get_tlit_angle();

        [DllImport(@"math32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double get_factor_b();
    }
}
