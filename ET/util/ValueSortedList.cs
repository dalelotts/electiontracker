using System;
using System.Collections;

namespace edu.uwec.cs.cs355.group4.et.util {
    public class ValueSortedList : ICollection, IDictionary, IEnumerable {
        private readonly IComparer comparer;

        private ArrayList mItems = new ArrayList();

        public ValueSortedList(IComparer comparer) {
            this.comparer = comparer;
        }

        public void Add(object key, object value) {
            // do some validation
            if (key == null)
                throw new ArgumentNullException("key is a null reference");
            else if (Contains(key))
                throw new ArgumentException("An element with the same key already exists");

            // add the new item
            ValueSortedListEntry newEntry = new ValueSortedListEntry();

            newEntry.Key = key;
            newEntry.Value = value;

            mItems.Add(newEntry);
            mItems.Sort(comparer);
        }

        //---------------------------------------------------------------------
        // Clear
        //---------------------------------------------------------------------
        public void Clear() {
            mItems.Clear();
        }

        //---------------------------------------------------------------------
        // Contains
        //---------------------------------------------------------------------
        public bool Contains(object key) {
            return (GetByKey(key) != null);
        }

        //---------------------------------------------------------------------
        // CopyTo
        //---------------------------------------------------------------------
        public void CopyTo(Array array, int index) {
            mItems.CopyTo(array, index);
        }

        //---------------------------------------------------------------------
        // GetEnumerator (1)
        //---------------------------------------------------------------------
        public IDictionaryEnumerator GetEnumerator() {
            return new ValueSortedListEnumerator(mItems);
        }

        //---------------------------------------------------------------------
        // GetEnumerator (2)
        //---------------------------------------------------------------------
        IEnumerator IEnumerable.GetEnumerator() {
            return new ValueSortedListEnumerator(mItems);
        }

        //---------------------------------------------------------------------
        // Remove
        //---------------------------------------------------------------------
        public void Remove(object key) {
            if (key == null)
                throw new ArgumentNullException("key is a null reference");

            ValueSortedListEntry deleteItem = GetByKey(key);
            if (deleteItem != null) {
                mItems.Remove(deleteItem);
                mItems.Sort();
            }
        }

        //=====================================================================
        // PRIVATE
        //=====================================================================
        private ValueSortedListEntry GetByKey(object key) {
            ValueSortedListEntry result = null;
            ArrayList keys = (ArrayList) Keys;

            if (mItems.Count > 0) {
                int keyIndex = keys.IndexOf(key);

                if (keyIndex >= 0) {
                    result = (ValueSortedListEntry) mItems[keyIndex];
                }
            }

            return result;
        }

        //=====================================================================
        // PROPERTIES
        //=====================================================================
        public int Count {
            get { return mItems.Count; }
        }

        public bool IsSynchronized {
            get { return false; }
        }

        public object SyncRoot {
            get { return this; }
        }

        public bool IsFixedSize {
            get { return false; }
        }

        public bool IsReadOnly {
            get { return false; }
        }

        public object this[object key] {
            get {
                if (key == null)
                    throw new ArgumentNullException("key is a null reference");

                object result = null;

                ValueSortedListEntry entry = GetByKey(key);
                if (entry != null) {
                    result = entry.Value;
                }

                return result;
            }
            set { }
        }

        public ValueSortedListEntry this[int index] {
            get {
                ValueSortedListEntry result = null;
                if (index >= 0) {
                    result = (ValueSortedListEntry) mItems[index];
                }
                return result;
            }
        }

        public ICollection Keys {
            get {
                ArrayList result = new ArrayList();

                mItems.Sort();

                foreach (ValueSortedListEntry curItem in mItems) {
                    result.Add(curItem.Key);
                }

                return result;
            }
        }

        public ICollection Values {
            get {
                ArrayList result = new ArrayList();

                foreach (ValueSortedListEntry curItem in mItems) {
                    result.Add(curItem.Value);
                }

                return result;
            }
        }
    }

    public class ValueSortedListEntry : IComparable {
        private object mKey;
        private object mValue;

        //---------------------------------------------------------------------
        // Default Constructor
        //---------------------------------------------------------------------
        public ValueSortedListEntry() : this(null, null) {}

        //---------------------------------------------------------------------
        // Overloaded Constructor
        //---------------------------------------------------------------------
        public ValueSortedListEntry(object key, object value) {
            Key = key;
            Value = value;
        }

        //---------------------------------------------------------------------
        // CompareTo
        //---------------------------------------------------------------------
        public int CompareTo(object obj) {
            int result = 0;

            if (obj is ValueSortedListEntry) {
                result = ((IComparable) Value).CompareTo(((ValueSortedListEntry) obj).Value);
            }

            return result;
        }

        //---------------------------------------------------------------------
        // ToDictionaryEntry
        //---------------------------------------------------------------------
        public DictionaryEntry ToDictionaryEntry() {
            return new DictionaryEntry(Key, Value);
        }

        //=====================================================================
        // PROPERTIES
        //=====================================================================
        public object Key {
            get { return mKey; }
            set {
                if (mKey != value) {
                    mKey = value;
                }
            }
        }

        public object Value {
            get { return mValue; }
            set {
                if (mValue != value) {
                    mValue = value;
                }
            }
        }
    }

    public class ValueSortedListEnumerator : IDictionaryEnumerator {
        private int index = -1;
        private ArrayList items;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------
        public ValueSortedListEnumerator(ArrayList list) {
            items = list;
        }

        //---------------------------------------------------------------------
        // MoveNext
        //---------------------------------------------------------------------
        public bool MoveNext() {
            index++;
            if (index >= items.Count)
                return false;

            return true;
        }

        //=====================================================================
        // PROPERTIES
        //=====================================================================
        //---------------------------------------------------------------------
        // Reset
        //---------------------------------------------------------------------
        public void Reset() {
            index = -1;
        }

        //---------------------------------------------------------------------
        // Current
        //---------------------------------------------------------------------
        public object Current {
            get {
                if (index < 0 || index >= items.Count)
                    throw new InvalidOperationException();

                return items[index];
            }
        }

        //---------------------------------------------------------------------
        // Entry
        //---------------------------------------------------------------------
        public DictionaryEntry Entry {
            get { return ((ValueSortedListEntry) Current).ToDictionaryEntry(); }
        }

        //---------------------------------------------------------------------
        // Key
        //---------------------------------------------------------------------
        public object Key {
            get { return Entry.Key; }
        }

        //---------------------------------------------------------------------
        // Value
        //---------------------------------------------------------------------
        public object Value {
            get { return Entry.Value; }
        }
    }
}