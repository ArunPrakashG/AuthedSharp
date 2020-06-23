using Newtonsoft.Json;
using System.Collections.Generic;

namespace AuthedSharp.Models.Responses.AppResponses {
	public class License {
		/// <summary>
		/// The Identifier of the license.
		/// </summary>
		[JsonProperty("id")]
		public string ID { get; set; }

		/// <summary>
		/// The time period of the license after which it expires.
		/// </summary>
		[JsonProperty("time")]
		public int Time { get; set; }

		/// <summary>
		/// The level of the license.
		/// </summary>
		[JsonProperty("level")]
		public int Level { get; set; }

		/// <summary>
		/// The license code.
		/// </summary>
		[JsonProperty("code")]
		public string Code { get; set; }
	}

	public class GenerateLicenseResponse : BaseResponse {
		/// <summary>
		/// The <see cref="List{T}"/> containing all the licenses.
		/// </summary>
		[JsonProperty("licenses")]
		public List<License> Licenses { get; set; } = new List<License>();
	}
}
