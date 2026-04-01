using System;
using System.Collections.Generic;

/// <summary>
/// Приложение "Galaxy News" для демонстрации отладки сложных объектов.
/// </summary>
class galaxies
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Galaxy News!");
        IterateThroughList();
        Console.ReadKey();
    }

    /// <summary>
    /// Выводит информацию о галактиках из списка.
    /// </summary>
    private static void IterateThroughList()
    {
        var theGalaxies = new List<Galaxy>
        {
            new Galaxy() { Name = "Tadpole", MegaLightYears = 400, GalaxyType = new GType('S')},
            new Galaxy() { Name = "Pinwheel", MegaLightYears = 25, GalaxyType = new GType('S')},
            new Galaxy() { Name = "Cartwheel", MegaLightYears = 500, GalaxyType = new GType('L')},
            new Galaxy() { Name = "Small Magellanic Cloud", MegaLightYears = .2, GalaxyType = new GType('I')},
            new Galaxy() { Name = "Andromeda", MegaLightYears = 3, GalaxyType = new GType('S')},
            new Galaxy() { Name = "Maffei 1", MegaLightYears = 11, GalaxyType = new GType('E')}
        };

        foreach (Galaxy theGalaxy in theGalaxies)
        {
            /// Исправленный вывод: выводим MyGType вместо объекта
            Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears + ", " + theGalaxy.GalaxyType.MyGType);
        }
    }
}

public class Galaxy
{
    public string Name { get; set; }
    public double MegaLightYears { get; set; }
    public GType GalaxyType { get; set; }   ///Исправлено с object на GType
}

public class GType
{
    public GType(char type)
    {
        switch (type)
        {
            case 'S': MyGType = Type.Spiral; break;
            case 'E': MyGType = Type.Elliptical; break;
            case 'I': MyGType = Type.Irregular; break;   /// Исправлено с 'l' на 'I'
            case 'L': MyGType = Type.Lenticular; break;
            default: break;
        }
    }

    public object MyGType { get; set; }

    private enum Type { Spiral, Elliptical, Irregular, Lenticular }
}