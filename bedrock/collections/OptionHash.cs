using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kixeye.Bedrock.Collections
{
    /// <summary>
    /// A dictionary of String => Object pairs. Contains extension methods to
    /// the standard set of Dictionary methods.
    /// </summary>
    [Serializable]
    public class OptionHash : Dictionary<string, object>, IDefault<string>
    {
        #region Initialization
        /// <summary>
        /// Create a new, empty options hash.
        /// </summary>
        public OptionHash() : base() { }

        /// <summary>
        /// Create a new, empty options hash with the starting capacity.
        /// </summary>
        /// <param name="capacity">Initial storage capacity.</param>
        public OptionHash(int capacity) : base(capacity) { }

        /// <summary>
        /// Creates an option hash from serialization data.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected OptionHash(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion


        #region IDefault
        /// <summary>
        /// Gets the value of an option with the given key. If the option
        /// has not been set, the given default value is returned instead.
        /// </summary>
        /// <typeparam name="T">The expected return value type.</typeparam>
        /// <param name="key">The option key.</param>
        /// <param name="defaultValue">Default value to fallback to.</param>
        /// <returns>The value of the option or the given default value.</returns>
        public T GetWithDefault<T>(string key, T defaultValue)
        {
            if (ContainsKey(key))
            {
                return (T)this[key];
            }
            return defaultValue;
        }
        #endregion


        #region Merge Hashes
        /// <summary>
        /// Merges the other options with this one; this is a destructive
        /// operation. For a non-destructive alternative, see the class-level
        /// method OptionHash.Merge(OptionHash, OptionHash). Matching keys from
        /// the other hash will overwrite values in this one.
        /// </summary>
        /// <param name="opts">A hash to merge into this one.</param>
        public void Merge(OptionHash opts)
        {
            IEnumerator<KeyValuePair<string, object>> e = opts.GetEnumerator();
            while (e.MoveNext())
            {
                this[e.Current.Key] = e.Current.Value;
            }
        }

        /// <summary>
        /// Merges two option hashes into one. This is a non-destructive
        /// operation, meaning the original two hashes will not be modified.
        /// Matching keys will use the value from the second hash as the final
        /// value.
        /// </summary>
        /// <param name="one">Hash to merge.</param>
        /// <param name="two">Hash to merge.</param>
        /// <returns>A new OptionHash object.</returns>
        public static OptionHash Merge(OptionHash one, OptionHash two)
        {
            OptionHash merge = new OptionHash(Math.Max(one.Count, two.Count));
            // TODO: Optimize this?
            merge.Merge(one);
            merge.Merge(two);
            return merge;
        }
        #endregion
    }
}
