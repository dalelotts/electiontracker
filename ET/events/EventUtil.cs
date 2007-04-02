namespace edu.uwec.cs.cs355.group4.et.events {
    public delegate void GenericEventHandler<T, U>(T sender, U eventArgs);

    internal class EventUtil {
        public static void RaiseEvent<T, U>(GenericEventHandler<T, U> targetEvent, T sender, U args) {
            GenericEventHandler<T, U> temp = targetEvent;
            if (temp != null) {
                temp(sender, args);
            }
        }
    }
}