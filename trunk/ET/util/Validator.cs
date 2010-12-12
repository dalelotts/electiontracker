/**
 *  Copyright (C) 2008 Knight Rider Consulting, Inc.
 *  support@knightrider.com
 *  http://www.knightrider.com
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see http://www.gnu.org/licenses/
 **/
using System.Windows.Forms;

namespace KnightRider.ElectionTracker.util {
    internal class Validator {
        public static void notEmpty(string name, MaskedTextBox textBox) {
            notEmpty(name, textBox.Text);
        }

        public static void notEmpty(string name, TextBox textBox) {
            notEmpty(name, textBox.Text);
        }

        public static void notEmpty(string name, ComboBox comboBox) {
            if (comboBox.SelectedItem == null) throw new ValidationFailedException("Empty: " + name);
            notEmpty(name, comboBox.SelectedItem.ToString());
        }

        public static void notEmpty(string name, string value) {
            if (value == null || value.Length == 0) throw new ValidationFailedException("Empty: " + name);
        }
    }
}