using System;
using System.Collections.Generic;
using System.Text;

namespace RationalRepresentation
{
    struct Rational : IComparable, IConvertible
    {
        public const int MaxValue = 2147483647;
        public const int MinValue = -2147483648;


        private int _devidend;
        private int _divider;
        private double _quotient;

        public int GetDevidend() { return _devidend; }
        public int Divider() { return _divider; }
        public double Quotient() { return _quotient; }

        public Rational(int devidend, int divider)
        {
            _devidend = devidend;
            _divider = (divider > 0) ? divider : throw new Exception("Число должно быть натуральным!");
            _quotient = _devidend / _divider;
            Rational temp = FractionReduction(this);
        }
       
        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            if (_divider != 0)
                return true;
            else
                return false;
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_quotient);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(_quotient);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(_quotient);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(_quotient);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return _quotient;
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(_quotient);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(_quotient);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(_quotient);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(_quotient);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(_quotient);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return ToString();
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(_quotient, conversionType);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(_quotient);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(_quotient);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(_quotient);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Rational? otherRational = obj as Rational?;

            if (otherRational != null)
                return this._quotient.CompareTo(otherRational.GetValueOrDefault().Quotient());
            else
                throw new ArgumentException("Object is not a rational number");
        }

        public override Boolean Equals(Object obj)
        {
            if (obj == null) return false;

            Rational? otherRational = obj as Rational?;

            if (otherRational != null)
                return this._quotient.Equals(otherRational.GetValueOrDefault().Quotient());
            else
                throw new ArgumentException("Object is not a rational number");
        }

        public static Rational operator +(Rational rational1, Rational rational2)
        {
            int nok = Nok(rational1, rational2);
            Rational result = new Rational(1, 1);
            
            result._divider = nok;

            result._devidend = rational1._devidend * result._divider / rational1._divider + rational2._devidend * result._divider / rational2._divider;

            return FractionReduction(result);
        }

        public static Rational operator -(Rational rational1, Rational rational2)
        {
            int nok = Nok(rational1, rational2);
            Rational result = new Rational(1, 1);

            result._divider = nok;

            result._devidend = rational1._devidend * result._divider / rational1._divider - rational2._devidend * result._divider / rational2._divider;

            return FractionReduction(result);
        }

        public static bool operator !=(Rational rational1, float obj)
        {
            return (Math.Abs(rational1._quotient - obj) != 0.000001);
        }

        public static bool operator ==(Rational rational1, float obj)
        {
            return (Math.Abs(rational1._quotient - obj) == 0.000001);
        }

        public static bool operator >=(Rational rational1, float obj)
        {
            return (rational1._quotient >= obj);
        }

        public static bool operator <=(Rational rational1, float obj)
        {
            return (rational1._quotient <= obj);
        }

        public static bool operator >(Rational rational1, float obj)
        {
            return (rational1._quotient > obj);
        }

        public static bool operator <(Rational rational1, float obj)
        {
            return (rational1._quotient < obj);
        }

        public static bool operator !=(Rational rational1, double obj)
        {
            return (Math.Abs(rational1._quotient - obj) != 0.000001);
        }

        public static bool operator ==(Rational rational1, double obj)
        {
            return (Math.Abs(rational1._quotient - obj) != 0.000001);
        }

        public static bool operator >=(Rational rational1, double obj)
        {
            return (rational1._quotient >= obj);
        }

        public static bool operator <=(Rational rational1, double obj)
        {
            return (rational1._quotient <= obj);
        }

        public static bool operator >(Rational rational1, double obj)
        {
            return (rational1._quotient > obj);
        }

        public static bool operator <(Rational rational1, double obj)
        {
            return (rational1._quotient < obj);
        }

        public static bool operator !=(Rational rational1, Rational rational2)
        {
            return (rational1._quotient != rational2._quotient);
        }

        public static bool operator ==(Rational rational1, Rational rational2)
        {
            return (rational1._quotient == rational2._quotient);
        }

        public static bool operator >=(Rational rational1, Rational rational2)
        {
            return (rational1._quotient >= rational2._quotient);
        }

        public static bool operator <=(Rational rational1, Rational rational2)
        {
            return (rational1._quotient <= rational2._quotient);
        }

        public static bool operator >(Rational rational1, Rational rational2)
        {
            return (rational1._quotient > rational2._quotient);
        }

        public static bool operator <(Rational rational1, Rational rational2)
        {
            return (rational1._quotient < rational2._quotient);
        }

        public static Rational operator ++(Rational rational)
        {
            rational._devidend += rational._divider;
            return rational;
        }

        public static Rational operator --(Rational rational)
        {
            rational._devidend -= rational._divider;
            return rational;
        }

        public static Rational operator -(Rational rational)
        {
            rational._devidend = -rational._devidend;
            return rational;
        }

        public static Rational operator +(Rational rational)
        {
            return rational;
        }

        public static Rational operator *(Rational rational1, Rational rational2)
        {
            Rational result = new Rational(1, 1);

            result._devidend = rational1._devidend * rational2._devidend;
            result._divider = rational1._divider * rational2._divider;
            return FractionReduction(result);
        }

        public static Rational operator /(Rational rational1, Rational rational2)
        {
            Rational result = new Rational(1, 1);

            result._devidend = rational1._devidend * rational2._divider;
            result._divider = rational1._divider * rational2._devidend;
            return FractionReduction(result);
        }

        public static Rational operator %(Rational rational1, Rational rational2)
        {
            int nok = Nok(rational1, rational2);
            Rational result = new Rational(1, 1);

            result._divider = nok;

            result._devidend = (rational1._devidend * result._divider / rational1._divider) % (rational2._devidend * result._divider / rational2._divider);

            return FractionReduction(result);
        }

        public static Rational Pow(Rational obj, double power)
        {
            int devidend = (int)(Math.Pow(obj._devidend, power));
            int divider = (int)(Math.Pow(obj._divider, power));
            return new Rational(devidend, divider);
        }

        public void Pow(double power)
        {
            _devidend = (int)(Math.Pow(_devidend, power));
            _divider = (int)(Math.Pow(_divider, power));
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", _devidend, _divider);
        }

        public string ToStringFormat(int format)
        {
            string temp = _quotient.ToString();
            string result = "";
            int i = 0;
            while (temp[i] != ',' && temp[i] != '\0')
            {
                result += temp[i++];
            }

            if (format == 0)
                return result;

            result += temp[i++];
            int PointOfDot = i;
            while (temp[i] != '\0' && i < PointOfDot + format)
            {
                result += temp[i++];
            }
            return result;
        }

        public static Rational Parse(String obj)
        {
            Rational temp = new Rational(1, 1);
            string number = "";
            foreach(char tookDown in obj)
            {
                if (tookDown == '/')
                {
                    temp = new Rational(Int32.Parse(number), 1);
                    number = "";
                    continue;
                }
                number += tookDown;
            }
            temp._divider = Int32.Parse(number);
            return FractionReduction(temp);
        }

        public static bool TryParse(String obj, out Rational result)
        {
            result = new Rational(1, 1);
            string number = "";
            foreach (char tookDown in obj)
            {
                if (tookDown == '/')
                {
                    if (Int32.TryParse(number, out result._devidend) == false)
                        return false;

                    number = "";
                    continue;
                }
                number += tookDown;
            }
            int check;
            if (Int32.TryParse(number, out check) == false)
            {
                result._devidend = 1;
                result._divider = 1;
                return false;
            }
            else
            {
                result._divider = check;
                result = FractionReduction(result);
                return true;
            }
        }

        public override int GetHashCode()
        {
            return _quotient.GetHashCode();
        }
        
        private static Rational FractionReduction(Rational result)
        {
            int max = (Math.Abs(result._devidend) > result._divider) ? Math.Abs(result._devidend) : result._divider;
            for (int i = 1; i < max + 1; i++)
            {
                if (result._devidend % i == 0 && result._divider % i == 0)
                {
                    if (i != 1)
                    {
                        result._devidend /= (int)i;
                        result._divider /= i;
                    }
                }
            }
            result._quotient = (double)(result._devidend) / (double)(result._divider);
            return result;
        }
       
        private static int Nok(Rational rational1, Rational rational2)
        {
            int nok = 0;
            int i = (rational1._divider > rational2._divider) ? rational1._divider : rational2._divider;
            for (; i < (rational1._divider * rational2._divider + 1); i++)
            {
                if (i % rational2._divider == 0 && i % rational1._divider == 0)
                {
                    nok = i;
                    if (i != 0)
                    {
                        break;
                    }
                }
            }
            return nok;
        }


    }
}
