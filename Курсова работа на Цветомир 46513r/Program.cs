using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace Курсова_работа_на_Цветомир_46513r
{
    enum galaxyType { elliptical, lenticular, spiral, irregular };
    class Galaxies
    {
        public string name;
        public string age;
        public galaxyType gtype;
        public List<Stars> starsInGalaxy = new List<Stars>();
    }


    class Stars : Galaxies
    {
        public double brightness;
        public double mass;
        public double size;
        public int temperature;
        public string grade;
        //public Galaxies starBelongsTo;
        public string starBelongsTo;
        public List<Planets> planetsInStar = new List<Planets>();

        public void starClass( double massiveness, double starSize, int hottness, double bright)
        {

            if (bright >= 30000 && massiveness >= 16 && starSize >= 6.6 && hottness >= 30000)
            {
                this.grade = "O";
            }
            else if (bright >= 25 && massiveness >= 2.1 && starSize >= 1.8 && hottness >= 10000)
            {
                this.grade = "B";
            }
            else if (bright >= 5 && massiveness >= 1.4 && starSize >= 1.4 && hottness >= 7500)
            {
                this.grade = "A";
            }
            else if (bright >= 1.5 && massiveness >= 1.04 && starSize >= 1.55 && hottness >= 6000)
            {
                this.grade = "F";
            }
            else if (bright >= 0.6 && massiveness >= 0.8 && starSize >= 0.96 && hottness >= 5200)
            {
                this.grade = "G";
            }
            else if (bright >= 0.08 && massiveness >= 0.45 && starSize >= 0.7 && hottness >= 3700)
            {
                this.grade = "K";
            }
            else if (bright < 0.08 && massiveness < 0.45 && starSize < 0.7 && hottness < 3700)
            {
                this.grade = "M";
            }
            else
            {
                Console.WriteLine("Invalid argument, please try again!");
            }
        }
       


        

    }

    public enum planetType { terrestrial, giant_planet, ice_giant, mesoplanet, mini_neptune, planetar, super_earth, super_jupiter, sub_earth };
    class Planets : Stars
    {
        public string planetBelongsTo;
        public planetType pType;
        public bool supportLife;
        public List<Moons> moonsInPlanet = new List<Moons>();

    }

    class Moons : Planets
    {
        public string moonBelongsTo;
    }
    class Program
    {
        public static List<Galaxies> galaxyList = new List<Galaxies>();
        public static List<Stars> starList = new List<Stars>();
        public static List<Planets> planetList = new List<Planets>();
        public static List<Moons> moonList = new List<Moons>();
        public static string gName;//used for output purposes only
        public static string sName;
        public static string pName;
        public static string mName;
        
        public static void Main()
        {

            Console.WriteLine("Here are some examples of commands:\n" +
                "add galaxy Milky_Way spiral 13.3B\n" +
                "add star Milky_Way Sun 0.99 1.98 5778 1.00 \n" +
                "add planet Sun Earth ice_giant false\n" +
                "add moon Earth Moon \n" +
                "print Milky_Way\n");
            CallReadline();
        }

        public static void ReadCommand(string command)
        {
            
            string[] text = command.Split(' ');
            //if (text.IndexOf('s') >= 0) != -1)
            //{

            //}
            //Console.WriteLine(text[0]);
            if (text[0] == "add")
            {
                Add(text);
            }
            else if (text[0] == "list")
            {
                List(text);
            }
            else if (text[0] == "stats")
            {
                Console.WriteLine("--- Stats ---");
                Console.WriteLine("Galaxies: " + galaxyList.Count);
                Console.WriteLine("Stars: " + starList.Count);
                Console.WriteLine("Planets: " + planetList.Count);
                Console.WriteLine("Moons: " + moonList.Count);
                Console.WriteLine("--- End of stats ---");
            }
            else if (text[0] == "print")
            {
                Print(text);
            }
            else if (text[0] == "exit")
            {
                System.Environment.Exit(0);
            }
        }
        public static void Print(string[] info)
        {
            foreach(Galaxies galaxy in galaxyList)
            {
                if(galaxy.name == info[1])
                {
                    Console.WriteLine($"--- Data for {galaxy.name} galaxy ---");
                    Console.WriteLine($"Type: {galaxy.gtype}");
                    Console.WriteLine($"Age: {galaxy.age}");
                    Console.WriteLine("Stars: ");
                    foreach (Stars star in galaxy.starsInGalaxy)
                    {
                        Console.WriteLine($"Name: {star.name}");
                        star.starClass(star.mass, star.size, star.temperature, star.brightness);
                        Console.WriteLine($"Class: {star.grade} ({star.mass}, {star.size}, {star.temperature}, {star.brightness})");
                        Console.WriteLine("Planets: ");
                        foreach (Planets planet in star.planetsInStar)
                        {
                            Console.WriteLine($"Name: {planet.name}");
                            Console.WriteLine($"Type: {planet.pType}");
                            Console.WriteLine($"Support Life: {planet.supportLife}");
                 
                            foreach (Moons moon in planet.moonsInPlanet)
                            {
                                Console.WriteLine($"{moon.name}");
                            }
                        }

                    }
                    
                }
            }
            foreach(Stars star in starList)
            {
                if(star.name == info[1])
                {
                    Console.WriteLine($"Name: {star.name}");
                    star.starClass(star.mass, star.size, star.temperature, star.brightness);
                    Console.WriteLine($"Class: {star.grade} ({star.mass}, {star.size}, {star.temperature}, {star.brightness})");
                    Console.WriteLine("Planets: ");
                    foreach (Planets planet in star.planetsInStar)
                    {
                        Console.WriteLine($"Name: {planet.name}");
                        Console.WriteLine($"Type: {planet.pType}");
                        Console.WriteLine($"Support Life: {planet.supportLife}");

                        foreach (Moons moon in planet.moonsInPlanet)
                        {
                            Console.WriteLine($"{moon.name}");
                        }
                    }
                }
            }
            foreach (Planets planet in planetList)
            {
                if (planet.name == info[1])
                {
                    Console.WriteLine($"Name: {planet.name}");
                    Console.WriteLine($"Type: {planet.pType}");
                    Console.WriteLine($"Support Life: {planet.supportLife}");

                    foreach (Moons moon in planet.moonsInPlanet)
                    {
                        Console.WriteLine($"{moon.name}");
                    }
                }
            }
            foreach (Moons moon in moonList)
            {
                if (moon.name == info[1])
                {
                    Console.WriteLine($"{moon.name}");
                }
            }
            CallReadline();
        }

        public static void List(string[] info)
        {
            if (info[1] == "galaxies") 
            {
                Console.WriteLine("--- List of all researched galaxies ---");
                gName = "";
                foreach (var galaxy in galaxyList)
                {
                    if(galaxy == galaxyList.Last<Galaxies>())
                    {
                        gName += galaxy.name;
                    } else
                    {
                        gName += galaxy.name + ", ";
                    } 
                }
                Console.WriteLine(gName);
                Console.WriteLine("--- End of galaxies list ---");
            }
            else if (info[1] == "stars")
            {
                Console.WriteLine("--- List of all researched stars ---");
                sName = "";
                foreach (var star in starList)
                {
                    if (star == starList.Last<Stars>())
                    {
                        sName += star.name;
                    }
                    else
                    {
                        sName += star.name + ", ";
                    }
                }
                Console.WriteLine(sName);
                Console.WriteLine("--- End of stars list ---");
            }
            else if (info[1] == "planets")
            {
                Console.WriteLine("--- List of all researched planets ---");
                pName = "";
                foreach (var planet in planetList)
                {
                    if (planet == planetList.Last<Planets>())
                    {
                        pName += planet.name;
                    }
                    else
                    {
                        pName += planet.name + ", ";
                    }
                }
                Console.WriteLine(pName);
                Console.WriteLine("--- End of planets list ---");
            }
            else if (info[1] == "moons")
            {
                Console.WriteLine("--- List of all researched moons ---");
                mName = "";
                foreach (var moon in moonList)
                {
                    if (moon == moonList.Last<Moons>())
                    {
                        mName += moon.name;
                    }
                    else
                    {
                        mName += moon.name + ", ";
                    }
                }
                Console.WriteLine(mName);
                Console.WriteLine("--- End of moons list ---");
            } else
            {
                Console.WriteLine("Invalid use of the List command, please use List galaxies, List stars, List planets or List moons!");
            }


            CallReadline();
        }
        public static void Add(string[] info) 
        { 
            if (info[1] == "galaxy") 
            {
                Galaxies g1 = new Galaxies();
                g1.name = info[2];
                if(Enum.IsDefined(typeof(galaxyType), info[3]))
                {
                    g1.gtype = (galaxyType)Enum.Parse(typeof(galaxyType), info[3]);
                } else
                {
                    Console.WriteLine("Invalid Galaxy Type; please use the follow: spiral///");
                }
                
                g1.age = info[4];
                galaxyList.Add(g1);

                
               
            }
            else if (info[1] == "star")
            {
                Stars s1 = new Stars();
                s1.starBelongsTo = info[2];
                s1.name = info[3];
                s1.mass = Double.Parse(info[4]);
                s1.size = Double.Parse(info[5]);
                s1.temperature = Int32.Parse(info[6]);
                s1.brightness = Double.Parse(info[7]);
                starList.Add(s1);
                foreach (Galaxies galaxy in galaxyList)
                {
                    if (galaxy.name == info[2])
                    {
                        //Console.WriteLine(galaxy.starsInGalaxy.Length);
                 
                        galaxy.starsInGalaxy.Add(s1);
                    }
                }




            }
            else if (info[1] == "planet")
            {
                Planets p1 = new Planets();
                p1.planetBelongsTo = info[2];
                p1.name = info[3];
                p1.pType = (planetType)Enum.Parse(typeof(planetType), info[4]);
                p1.supportLife = bool.Parse(info[5]);
                planetList.Add(p1);
                foreach (Stars star in starList)
                {
                    if (star.name == info[2])
                    {
                        //Console.WriteLine(galaxy.starsInGalaxy.Length);

                        star.planetsInStar.Add(p1);
                    }
                }


            }
            else if (info[1] == "moon")
            {
                Moons m1 = new Moons();
                m1.moonBelongsTo = info[2];
                m1.name = info[3];
                moonList.Add(m1);
                foreach (Planets planet in planetList)
                {
                    if (planet.name == info[2])
                    {
                        //Console.WriteLine(galaxy.starsInGalaxy.Length);

                        planet.moonsInPlanet.Add(m1);
                    }
                }
            } else
            {
                Console.WriteLine("Add needs to be followed by galaxy, star, planet or moon! \nExample add galaxy...");
            }

            CallReadline();
        }

        public static void CallReadline()
        {
            string enter = Console.ReadLine();
            ReadCommand(enter);
        }
    }
}

