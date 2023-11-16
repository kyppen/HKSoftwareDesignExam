using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.UIColor {
	public class UIColorController {
		public static void ColorWriteRed(string text) {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(text);
			Console.ResetColor();
		}

		public static void ColorWriteGreen(string text) {
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(text);
			Console.ResetColor();
		}

		public static void ColorWriteBlue(string text) {
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write(text);
			Console.ResetColor();
		}

		public static void ColorWriteYellow(string text) {
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write(text);
			Console.ResetColor();
		}
	}
}
