using Prototype.Interfaces;

namespace Prototype.Models
{
    // Машина с указанием страны производителя
    internal class CarWithCountry : Car, IMyClonable<CarWithCountry>, ICloneable
    {
        public string Contry { get; set; }

        public CarWithCountry(string number, int year, int mileage, string contry) : base(number, year, mileage)
        {
            Contry = contry;
        }

        public CarWithCountry(CarWithCountry copy) : base(copy)
        {
            Contry = copy.Contry;
        }

        public new CarWithCountry MyClone()
        {
            return new CarWithCountry(this);
        }

        public new object Clone() => MyClone();

        public override string ToString()
        {
            return $"Number={Number}, Year={Year}, Mileage={Mileage}, Contry = {Contry}";
        }
    }
}
