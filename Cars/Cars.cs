using System;
using static System.Console;

namespace Cars {

    /// <summary>
    /// A generic car.
    /// </summary>
    public abstract class Car {

        /// <summary>
        /// A random number generator.
        /// </summary>
        protected static Random rand = new Random();

        /// <summary>
        /// The field storing x.
        /// </summary>
        private int _x = 1;

        /// <summary>
        /// The x position of the car. Must be >= 1.
        /// </summary>
        /// <value>x.</value>
        public int X {
            get => _x;
            set {
                if (value < 1) {
                    throw new Exception("X must be larger than 1");
                }
                _x = value;
            }
        }

        /// <summary>
        /// The name of the car.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// The symbol represnting the car on screen.
        /// </summary>
        /// <value>The symbol.</value>
        public abstract Char Symbol { get; }

        /// <summary>
        /// Moves the car a set random number of units.
        /// </summary>
        public abstract void Step();

        /// <summary>
        /// Prints the car to the console.
        /// </summary>
        /// <param name="width">The width of the road.</param>
        public void PrintOnMap(int width) {
            if (width < 0) {
                throw new Exception("Width can not be negative");
            }
            var map = $"{Name}:\t [";
            for (var i = 0; i < width; i++) {
                if (i == X - 1) {
                    map += Symbol;
                } else {
                    map += '-';
                }
            }
            map += ']';
            WriteLine(map);
        }
    }

    /// <summary>
    /// a speed car.
    /// </summary>
    public class SpeedCar: Car {
        /// <summary>
        /// The symbol represnting the car on screen.
        /// </summary>
        /// <value>The symbol.</value>
        public override char Symbol => '>';

        /// <summary>
        /// Moves the car form 3 to 5 units in the positive x direction.
        /// </summary>
        public override void Step() {
            X += rand.Next(3, 6);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cars.SpeedCar"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        public SpeedCar(string name) {
            this.Name = name;
        }
    }

    /// <summary>
    /// A slow car.
    /// </summary>
    public class SlowCar: Car {
        /// <summary>
        /// The symbol represnting the car on screen.
        /// </summary>
        /// <value>The symbol.</value>
        public override char Symbol => 'o';

        /// <summary>
        /// Moves the car form 0 to 2 units in the positive x direction.
        /// </summary>
        public override void Step() {
            X += rand.Next(0, 3);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Cars.SlowCar"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        public SlowCar(string name) {
            this.Name = name;
        }
    }
}
