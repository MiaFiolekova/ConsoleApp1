


Car[] cars = new Car[]
{
    new Car() { Make = "Toyota", Model = "Corolla", Seats = 4, CarTypeID = 1 },
    new Car() { Make = "Seat", Model = "Ibiza", Seats = 4, CarTypeID = 1 },
    new Car() { Make = "Audi", Model = "A5", Seats = 5, CarTypeID = 1 },
    new Car() { Make = "Skoda", Model = "Superb", Seats = 5, CarTypeID = 1 },
    new Car() { Make = "Mercedes", Model = "E350", Seats = 5, CarTypeID = 1 },
    new Car() { Make = "Volvo", Model = "XC60", Seats = 5, CarTypeID = 2 },
    new Car() { Make = "Nissan", Model = "Leaf", Seats = 4, CarTypeID = 3 }
};

CarType[] types = new CarType[]
{
    new CarType() { ID = 1, Name = "Sedan" },
    new CarType() { ID = 2, Name = "SUV" },
    new CarType() { ID = 3, Name = "Plugin" }
};

var result = from car in cars
             join type in types
             on car.CarTypeID equals type.ID
             where type.Name == "Sedan"
             orderby car.Make
             select car;

var resultFluent = cars
    .Join(types, c => c.CarTypeID, t => t.ID, (c, t) => new { car = c, type = t })
    .Where(c => c.type.Name == "Sedan")
    .OrderBy(c => c.car.Make)
    .Select(c => c.car);
                        

foreach (var car in resultFluent)
{
    Console.WriteLine($"{car.Make} {car.CarTypeID}");
}

class Car
{
    public string Model { get; set; }
    public string Make { get; set; }
    public int Seats { get; set; }
    public int CarTypeID { get; set; }
}

class CarType
{
    public int ID { get; set; }
    public string Name { get; set; }
}
