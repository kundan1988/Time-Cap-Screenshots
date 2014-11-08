using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;

namespace TimeCap.iOS.Code
{
    public interface ITextSerializer
    {
        /// <summary>
        /// Gets the text format
        /// </summary>
        Format Format { get; }

        /// <summary>
        /// Serializes object to a string
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>Serialized string of the object</returns>
        string Serialize<T>(T obj);

        /// <summary>
        /// Serializes object to a stream
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <param name="stream">Stream to serialize to</param>
        void Serialize<T>(T obj, Stream stream);

        /// <summary>
        /// Deserializes string into an object
        /// </summary>
        /// <typeparam name="T">Type of object to serialize to</typeparam>
        /// <param name="data">Serialized object</param>
        /// <returns>Object of type T</returns>
        T Deserialize<T>(string data);

        /// <summary>
        /// Deserializes stream into an object
        /// </summary>
        /// <typeparam name="T">Type of object to serialize to</typeparam>
        /// <param name="stream">Stream to deserialize from</param>
        /// <returns>Object of type T</returns>
        T Deserialize<T>(Stream stream) where T : class;

        object Deserialize(string data, Type type);
    }
}