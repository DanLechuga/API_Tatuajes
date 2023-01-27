using System.Collections.Generic;

namespace API_Tatuajes.Exceptions
{/// <summary>
/// 
/// </summary>
    public class CriticalException
    {
        /// <summary>
        /// 
        /// </summary>
        public string Origin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TrakingCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> Messages { get; set; }
    }
}
