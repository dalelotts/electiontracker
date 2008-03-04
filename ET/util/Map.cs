/**
 *  Copyright (C) 2007 Knight Rider Consulting, Inc.
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
using System.Collections;
using System.Collections.Generic;

namespace KnightRider.ElectionTracker.util {
    /// <summary>
    ///     Wrapper class for a Dictionary to the API is a little more reasonable.
    /// </summary>
    internal class Map<T, V> : IDictionary<T, V> where V : class {
        private readonly IDictionary<T, V> dictionary = new Dictionary<T, V>();


        /// <summary>
        /// Sets the value of the specified key to the specified value, even if the key already exists.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public V Put(T key, V value) {
            V oldValue = Get(key);
            dictionary.Remove(key);
            dictionary.Add(key, value);
            return oldValue;
        }

        /// <summary>
        /// Returns the value of the specified key. 
        /// </summary>
        /// <param name="key">the key to locate.</param>
        /// <returns>the value of the key, or null if the key does not exist.</returns>
        public V Get(T key) {
            if (dictionary.ContainsKey(key)) {
                return dictionary[key];
            }
            return null;
        }

        ///<summary>
        ///Determines whether the <see cref="T:System.Collections.Generic.IDictionary`2"></see> contains an element with the specified key.
        ///</summary>
        ///
        ///<returns>
        ///true if the <see cref="T:System.Collections.Generic.IDictionary`2"></see> contains an element with the key; otherwise, false.
        ///</returns>
        ///
        ///<param name="key">The key to locate in the <see cref="T:System.Collections.Generic.IDictionary`2"></see>.</param>
        ///<exception cref="T:System.ArgumentNullException">key is null.</exception>
        public bool ContainsKey(T key) {
            return dictionary.ContainsKey(key);
        }

        ///<summary>
        ///Adds an element with the provided key and value to the <see cref="T:System.Collections.Generic.IDictionary`2"></see>.
        ///</summary>
        ///
        ///<param name="value">The object to use as the value of the element to add.</param>
        ///<param name="key">The object to use as the key of the element to add.</param>
        ///<exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IDictionary`2"></see> is read-only.</exception>
        ///<exception cref="T:System.ArgumentException">An element with the same key already exists in the <see cref="T:System.Collections.Generic.IDictionary`2"></see>.</exception>
        ///<exception cref="T:System.ArgumentNullException">key is null.</exception>
        public void Add(T key, V value) {
            dictionary.Add(key, value);
        }

        ///<summary>
        ///Removes the element with the specified key from the <see cref="T:System.Collections.Generic.IDictionary`2"></see>.
        ///</summary>
        ///
        ///<returns>
        ///true if the element is successfully removed; otherwise, false.  This method also returns false if key was not found in the original <see cref="T:System.Collections.Generic.IDictionary`2"></see>.
        ///</returns>
        ///
        ///<param name="key">The key of the element to remove.</param>
        ///<exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IDictionary`2"></see> is read-only.</exception>
        ///<exception cref="T:System.ArgumentNullException">key is null.</exception>
        public bool Remove(T key) {
            return dictionary.Remove(key);
        }

        public bool TryGetValue(T key, out V value) {
            return dictionary.TryGetValue(key, out value);
        }

        ///<summary>
        ///Gets or sets the element with the specified key.
        ///</summary>
        ///
        ///<returns>
        ///The element with the specified key.
        ///</returns>
        ///
        ///<param name="key">The key of the element to get or set.</param>
        ///<exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.Generic.IDictionary`2"></see> is read-only.</exception>
        ///<exception cref="T:System.ArgumentNullException">key is null.</exception>
        ///<exception cref="T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and key is not found.</exception>
        public V this[T key] {
            get { return dictionary[key]; }
            set { dictionary[key] = value; }
        }

        ///<summary>
        ///Gets an <see cref="T:System.Collections.Generic.ICollection`1"></see> containing the keys of the <see cref="T:System.Collections.Generic.IDictionary`2"></see>.
        ///</summary>
        ///
        ///<returns>
        ///An <see cref="T:System.Collections.Generic.ICollection`1"></see> containing the keys of the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"></see>.
        ///</returns>
        ///
        public ICollection<T> Keys {
            get { return dictionary.Keys; }
        }

        ///<summary>
        ///Gets an <see cref="T:System.Collections.Generic.ICollection`1"></see> containing the values in the <see cref="T:System.Collections.Generic.IDictionary`2"></see>.
        ///</summary>
        ///
        ///<returns>
        ///An <see cref="T:System.Collections.Generic.ICollection`1"></see> containing the values in the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"></see>.
        ///</returns>
        ///
        public ICollection<V> Values {
            get { return dictionary.Values; }
        }

        ///<summary>
        ///Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        ///</summary>
        ///
        ///<param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        ///<exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
        public void Add(KeyValuePair<T, V> item) {
            dictionary.Add(item);
        }

        ///<summary>
        ///Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        ///</summary>
        ///
        ///<exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only. </exception>
        public void Clear() {
            dictionary.Clear();
        }

        ///<summary>
        ///Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> contains a specific value.
        ///</summary>
        ///
        ///<returns>
        ///true if item is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.
        ///</returns>
        ///
        ///<param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        public bool Contains(KeyValuePair<T, V> item) {
            return dictionary.Contains(item);
        }

        ///<summary>
        ///Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"></see> to an <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
        ///</summary>
        ///
        ///<param name="array">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"></see>. The <see cref="T:System.Array"></see> must have zero-based indexing.</param>
        ///<param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        ///<exception cref="T:System.ArgumentOutOfRangeException">arrayIndex is less than 0.</exception>
        ///<exception cref="T:System.ArgumentNullException">array is null.</exception>
        ///<exception cref="T:System.ArgumentException">array is multidimensional.-or-arrayIndex is equal to or greater than the length of array.-or-The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"></see> is greater than the available space from arrayIndex to the end of the destination array.-or-Type T cannot be cast automatically to the type of the destination array.</exception>
        public void CopyTo(KeyValuePair<T, V>[] array, int arrayIndex) {
            dictionary.CopyTo(array, arrayIndex);
        }

        ///<summary>
        ///Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        ///</summary>
        ///
        ///<returns>
        ///true if item was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false. This method also returns false if item is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        ///</returns>
        ///
        ///<param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        ///<exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.</exception>
        public bool Remove(KeyValuePair<T, V> item) {
            return dictionary.Remove(item);
        }

        ///<summary>
        ///Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        ///</summary>
        ///
        ///<returns>
        ///The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        ///</returns>
        ///
        public int Count {
            get { return dictionary.Count; }
        }

        ///<summary>
        ///Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
        ///</summary>
        ///
        ///<returns>
        ///true if the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only; otherwise, false.
        ///</returns>
        ///
        public bool IsReadOnly {
            get { return dictionary.IsReadOnly; }
        }

        ///<summary>
        ///Returns an enumerator that iterates through the collection.
        ///</summary>
        ///
        ///<returns>
        ///A <see cref="T:System.Collections.Generic.IEnumerator`1"></see> that can be used to iterate through the collection.
        ///</returns>
        ///<filterpriority>1</filterpriority>
        public IEnumerator<KeyValuePair<T, V>> GetEnumerator() {
            return dictionary.GetEnumerator();
        }

        #region IEnumerable Members

        ///<summary>
        ///Returns an enumerator that iterates through a collection.
        ///</summary>
        ///
        ///<returns>
        ///An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator() {
            return dictionary.GetEnumerator();
        }

        #endregion
    }
}