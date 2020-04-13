using System;

namespace Day06CarsWithDialog
{
    public class Car
    {
        private static int num = 1;

        public enum FuelTypeEnum
        {
            Gasoline, Diesel, Hybrid, Electric, Other
        }

        private int id;

        public int Id
        {
            get
            {
                if (0 == id)
                {
                    id = num++;
                }
                return id;
            }
            set { id = value; }
        }

        private string makeModel;

        public string MakeModel
        {
            get => makeModel;
            set
            {
                if (value.Length < 2 || value.Length > 50 || value.Contains(";"))
                {
                    throw new ArgumentOutOfRangeException("Make and Model must be 2-50, and no semicolons be included.");
                }
                makeModel = value;
            }
        }

        private double engineSizeL;

        public double EngineSizeL
        {
            get => engineSizeL;
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("Engine size must be 0-20.");
                }
                engineSizeL = value;
            }
        }

        private FuelTypeEnum fuelType;

        public FuelTypeEnum FuelType
        {
            get => fuelType;
            set
            {
                if (!Enum.IsDefined(typeof(FuelTypeEnum), value))
                {
                    throw new ArgumentOutOfRangeException("Fuel type must be Gasoline, Diesel, Hybrid, Electric or Other.");
                }
                fuelType = value;
            }
        }

        public Car(string makeModel, double engineSizeL, FuelTypeEnum fuelType)
        {
            MakeModel = makeModel;
            EngineSizeL = engineSizeL;
            FuelType = fuelType;
        }

        public Car()
        {
        }

        public override string ToString()
        {
            return string.Format("Make and Model: {0}; Engine Size (L): {1}; Fuel Type: {2}", MakeModel, EngineSizeL, FuelType);
        }
    }
}