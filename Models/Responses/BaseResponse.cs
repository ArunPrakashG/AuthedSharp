using Newtonsoft.Json;
using System.Net;

namespace AuthedSharp.Models.Responses {
	public class BaseResponse {
		/// <summary>
		/// The response code as <see cref="int"/> send by the API.
		/// </summary>
		[JsonProperty("code")]		
		public int ResponseCode { get; set; }

		/// <summary>
		/// The <see cref="ResponseCode"/> as <see cref="HttpStatusCode"/>
		/// </summary>
		[JsonIgnore]
		public HttpStatusCode ResponseStatusCode => (HttpStatusCode) ResponseCode;

		/// <summary>
		/// Shorthand response for status of the request
		/// </summary>
		[JsonProperty("status")]
		public string Status { get; set; }

		/// <summary>
		/// Description of the status of the request
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }
	}
}
