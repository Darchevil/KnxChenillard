using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChenillardWebApp
{
    interface ICookie
    {

        /// <summary>  
        ///   
        /// </summary>  
        ICollection<string> Keys { get; }

        /// <summary>  
        /// Gets a cookie item associated with key  
        /// </summary>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        string Get(string key);

        /// <summary>  
        /// Sets the cookie   
        /// </summary>  
        /// <param name="key">key</param>  
        /// <param name="value">value of the key</param>  
        /// <param name="expireTime">cookie expire time</param>  
        void Set(string key, string value, int? expireTime);

        /// <summary>  
        /// Sets the cookie   
        /// </summary>  
        /// <param name="key">key</param>  
        /// <param name="value">value of the key</param>  
        /// <param name="expireTime">cookie expire time</param>  
        void Set(string key, string value, CookieOptions option);

        /// <summary>  
        /// Contain the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        /// <returns>bool</returns>  
        bool Contains(string key);

        /// <summary>  
        /// delete the key from cookie   
        /// </summary>  
        /// <param name="key"></param>  
        void Remove(string key);
    }
}
