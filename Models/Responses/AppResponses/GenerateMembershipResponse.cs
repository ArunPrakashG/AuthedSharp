using Newtonsoft.Json;

namespace AuthedSharp.Models.Responses.AppResponses {
	public class Membership {
		/// <summary>
		/// The identifier of this membership.
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
		/// The name of this membership.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }
	}

	public class GenerateMembershipResponse : BaseResponse {
		/// <summary>
		/// The membership object.
		/// </summary>
		[JsonProperty("membership")]
		public Membership Membership { get; set; } = new Membership();
	}
}
