//using System;

namespace CsharpTest
{
    public class Money
    {
        private double faceValue;
        private Currency currency;

        const double EUR2RMB = 8.0;
        const double USD2RMB = 7.0;
        private double RealValue
        {
            get
            {
                if (currency == Currency.RMB)
                {
                    return faceValue;
                }
                else if (currency == Currency.EUR)
                {
                    return faceValue * EUR2RMB;
                }
                else
                {
                    return faceValue * USD2RMB;
                }
            }

        }

        public Money() : this(0, Currency.RMB) { }
        public Money(double faceValue) : this(faceValue, Currency.RMB) { }
        public Money(double faceValue, Currency currency)
        {
            this.faceValue = faceValue;
            this.currency = currency;
        }

        // type convesion
        public static implicit operator Money(double x)
        {
            return new Money(x);
        }

        // operator overload
        public static Money operator +(Money x, Money y)
        {
            double realValue = x.RealValue + y.RealValue;
            double newFaceValue;
            if (x.currency == Currency.EUR){
                newFaceValue = realValue / EUR2RMB;
            }
            else if ( x.currency == Currency.USD){
                newFaceValue = realValue / USD2RMB;
            }
            else{
                newFaceValue = realValue;
            }
            
            return new Money(newFaceValue, x.currency);
        }
        public static Money operator -(Money x, Money y)
        {
            double realValue = x.RealValue - y.RealValue;
            double newFaceValue;
            if (x.currency == Currency.EUR){
                newFaceValue = realValue / EUR2RMB;
            }
            else if ( x.currency == Currency.USD){
                newFaceValue = realValue / USD2RMB;
            }
            else{
                newFaceValue = realValue;
            }
            
            return new Money(newFaceValue, x.currency);
        }

        public override string ToString()
        {
            return this.faceValue.ToString() + " " + this.currency.ToString();
            // return "about " + this.RealValue + " RMB";
        }

    }
}