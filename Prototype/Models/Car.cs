using Prototype.Interfaces;

namespace Prototype.Models
{
    // Объект машина
    internal class Car : IMyClonable<Car>, ICloneable
    {
        private string _number;

        private int _year;

        private int _mileage;

        public string Number { get { return _number; } set { _number = value; } }

        public int Year { get { return _year; } set { _year = value; } }

        public int Mileage { get { return _mileage; } set { _mileage = value; }}

        public Car(string number, int year, int mileage)
        {
            _mileage = mileage;
            _number = number;
            _year = year;
        }

        public Car(Car copy)
        {
            _mileage = copy._mileage;
            _number = copy._number;
            _year = copy._year;
        }

        public Car MyClone()
        {
            return new Car(this);
        }

        public override string ToString()
        {
            return $"Number={Number}, Year={Year}, Mileage={Mileage}";
        }

        public object Clone() => MyClone();
    }
}
