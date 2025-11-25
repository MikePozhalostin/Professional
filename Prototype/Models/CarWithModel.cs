using Prototype.Interfaces;

namespace Prototype.Models
{
    // Машина с указанием модели
    internal class CarWithModel : CarWithCountry, IMyClonable<CarWithModel>, ICloneable
    {
        public string Model { get; set; }

        public CarWithModel(string number, int year, int mileage, string contry, string model) : base(number, year, mileage, contry)
        {
            Model = model;
        }

        public CarWithModel(CarWithModel copy) : base(copy)
        {
            Model = copy.Model;
        }

        public new CarWithModel MyClone()
        {
            return new CarWithModel(this);
        }

        public new object Clone() => MyClone();

        public override string ToString()
        {
            return $"Number={Number}, Year={Year}, Mileage={Mileage}, Contry = {Contry}, Model = {Model}";
        }
    }
}
