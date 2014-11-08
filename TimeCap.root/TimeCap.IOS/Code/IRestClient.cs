using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Code
{
    /// <summary>
    /// The RestClient interface.
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// Gets or sets timeout
        /// </summary>
        TimeSpan Timeout { get; set; }

        /// <summary>
        /// Gets the base address.
        /// </summary>
        //Uri BaseAddress { get; }

        /// <summary>
        /// Add request header.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        void AddHeader(string key, string value);

        /// <summary>
        /// Remove request header.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        void RemoveHeader(string key);

        /// <summary>
        /// Async POST method.
        /// </summary>
        /// <returns>The async task.</returns>
        /// <param name="address">Address of the service.</param>
        /// <param name="dto">DTO to post.</param>
        /// <param name="format">Format of the request.</param>
        /// <typeparam name="T">The type of object to be returned.</typeparam>
        Task<ServiceResponse<T>> PostAsync<T>(string address, object dto, Format format);

        /// <summary>
        /// Async GET method
        /// </summary>
        /// <returns>The async task with .</returns>
        /// <param name="address">Address of the service.</param>
        /// <param name="format">Format of the request.</param>
        /// <typeparam name="T">The type of object to be returned.</typeparam>
        Task<ServiceResponse<T>> GetAsync<T>(string address, Format format);

        Task<ServiceResponse<T>> GetAsync<T>(string address, Dictionary<string, string> values, Format format);

        //void SetCustomSerializer<T>(ICustomSerializer<T> serializer);

        //bool RemoveCustomSerializer (Type type);
    }
}