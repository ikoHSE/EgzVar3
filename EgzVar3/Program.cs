
/*
ФИО: Костюченко Илья Игоревич
Группа: БПИ 171-1
Дата: 19.12.17
Вариант: 3
*/

using System;
using static Iko.Iko;
using Cars;
using System.Linq;

namespace EgzVar3 {
    class MainClass {
        private static Random rand = new Random();
        public static void Main() {
            Repeat(() => {
                var width = rand.Next(10, 31);
                var cars = new Car[5];
                for (var i = 0; i < cars.Length; i++) {
                    switch (rand.Next(0, 2)) {
                    case 0:
                        cars[i] = new SpeedCar(GenerateName(6));
                        break;
                    case 1:
                        cars[i] = new SlowCar(GenerateName(6));
                        break;
                    }
                }

                foreach (var c in cars) {
                    c.PrintOnMap(width);
                }

                Console.WriteLine();
                Console.Write("Press sace to move cars.");

                while (Console.ReadKey().Key == ConsoleKey.Spacebar) {
                    Console.WriteLine();
                    foreach (var c in cars) {
                        c.Step();
                        c.PrintOnMap(width);
                    }

                    // Можно без Linq с флагом.

                    if (cars.Select(c => c.X >= width).Aggregate(false, (arg1, arg2) => arg1 || arg2)) {
                        Console.WriteLine("A car has reached the end of the road!");
                        break;
                    }

                    Console.WriteLine();
                    Console.Write("Press sace to move cars.");
                }

            });
        }

        /// <summary>
        /// Generates a random name with the given number of symbols.
        /// </summary>
        /// <returns>The name.</returns>
        /// <param name="width">Width.</param>
        private static string GenerateName(int width) {
            char minChar = 'a';
            char maxChar = 'z';
            var name = "";
            for (var i = 0; i < width; i++) {
                char nextChar = (char) (minChar + rand.Next(0, maxChar - minChar + 1));
                if (i == 0) {
                    nextChar = Char.ToUpper(nextChar);
                }
                name += nextChar;
            }
            return name;
        }
    }
}
