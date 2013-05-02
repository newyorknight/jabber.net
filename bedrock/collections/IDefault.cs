using System;

namespace Kixeye.Bedrock.Collections
{
    /// <summary>
    /// Represents an object where you can get a property with a default value
    /// returned if the desired property does not exist or has not been set. It
    /// is preferred to use the generic IDefault&lt;K&gt; interface when
    /// possible.
    /// </summary>
    public interface IDefault
    {
        /// <summary>
        /// Gets the value of a property with the given key. If the property
        /// does not exist, or it has not been set, the given default value is
        /// instead returned.
        /// </summary>
        /// <param name="key">The property key.</param>
        /// <param name="defaultValue">Default value to fallback to.</param>
        /// <returns>The value of the property or the given default value.</returns>
        object GetWithDefault(object key, object defaultValue);
    }

    /// <summary>
    /// Represents an object where you can get a property with a default value
    /// returned if the desired property does not exist or has not been set.
    /// </summary>
    /// <typeparam name="K">The expected type for property keys.</typeparam>
    public interface IDefault<K>
    {
        /// <summary>
        /// Gets the value of a property with the given key. If the property
        /// does not exist, or it has not been set, the given default value is
        /// instead returned.
        /// </summary>
        /// <typeparam name="T">The expected return value type.</typeparam>
        /// <param name="key">The property key.</param>
        /// <param name="defaultValue">Default value to fallback to.</param>
        /// <returns>The value of the property or the given default value.</returns>
        T GetWithDefault<T>(K key, T defaultValue);
    }
}
