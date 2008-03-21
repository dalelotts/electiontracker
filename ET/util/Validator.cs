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