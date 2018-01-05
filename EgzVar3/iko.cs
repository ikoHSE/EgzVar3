using System;
using static System.Console;

namespace Iko {
    static class Iko {
        /// <summary>
        /// Gets a double value from the user.
        /// </summary>
        /// <returns>The double.</returns>
        /// <param name="text">Prompt</param>
        /// <param name="validate">A validation function</param>
        /// <param name="falseText">Text to print if user fails</param>
        public static double GetDouble(string text, Func<double, bool> validate, string falseText) {
            Write(text);
            double res;
            while (true) {
                if (double.TryParse(ReadLine(), out res) && validate(res)) {
                    return res;
                } else {
                    WriteLine(falseText);
                    Write(text);
                }
            }
        }

        /// <summary>
        /// Gets a double value from the user.
        /// </summary>
        /// <returns>The double.</returns>
        /// <param name="text">Prompt</param>
        /// <param name="falseText">Text to print if user fails</param>
        public static double GetDouble(string text, string falseText) {
            return GetDouble(text, _ => { return true; }, falseText);
        }

        /// <summary>
        /// Gets a float value from the user.
        /// </summary>
        /// <returns>The double.</returns>
        /// <param name="text">Prompt</param>
        /// <param name="validate">A validation function</param>
        /// <param name="falseText">Text to print if user fails</param>
        public static float GetFloat(string text, Func<float, bool> validate, string falseText) {
            Write(text);
            float res;
            while (true) {
                if (float.TryParse(ReadLine(), out res) && validate(res)) {
                    return res;
                } else {
                    WriteLine(falseText);
                    Write(text);
                }
            }
        }

        /// <summary>
        /// Gets a float value from the user.
        /// </summary>
        /// <returns>The double.</returns>
        /// <param name="text">Prompt</param>
        /// <param name="falseText">Text to print if user fails</param>
        public static float GetFloat(string text, string falseText) {
            return GetFloat(text, _ => { return true; }, falseText);
        }

        /// <summary>
        /// Gets an int value from the user.
        /// </summary>
        /// <returns>The double.</returns>
        /// <param name="text">Prompt</param>
        /// <param name="validate">A validation function</param>
        /// <param name="falseText">Text to print if user fails</param>
        public static int GetInt(string text, Func<int, bool> validate, string falseText) {
            Write(text);
            int res;
            while (true) {
                if (int.TryParse(ReadLine(), out res) && validate(res)) {
                    return res;
                } else {
                    WriteLine(falseText);
                    Write(text);
                }
            }
        }

        /// <summary>
        /// Gets an int value from the user.
        /// </summary>
        /// <returns>The double.</returns>
        /// <param name="text">Prompt</param>
        /// <param name="falseText">Text to print if user fails</param>
        public static int GetInt(string text, string falseText) {
            return GetInt(text, _ => { return true; }, falseText);
        }

        /// <summary>
        /// Repeats a given function.
        /// </summary>
        /// <param name="f">the function to be repeated</param>
        public static void Repeat(Action f) {
            do {
                f();
                Write("Press Enter to repeat program. Press any other key to quit.");
            } while (ReadKey().Key == ConsoleKey.Enter);
        }
    }
}