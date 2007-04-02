namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class ListItemWrapper<T> {
        private readonly string displayText;
        private readonly T value;


        public ListItemWrapper(string displayText, T value) {
            this.displayText = displayText;
            this.value = value;
        }

        public override string ToString() {
            return displayText;
        }

        public T Value {
            get { return value; }
        }
    }
}