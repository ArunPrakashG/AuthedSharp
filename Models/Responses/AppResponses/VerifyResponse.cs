using Newtonsoft.Json;

namespace AuthedSharp.Models.Responses.AppResponses {
	/// <summary>
	/// Response received when sending Verify request for the application.
	/// </summary>
	public class VerifyResponse : BaseResponse {
		/// <summary>
		/// The application session.
		/// <br>Used for all followed up requests.</br>
		/// </summary>
		[JsonProperty("session")]
		public string Session { get; set; }
	}
}
