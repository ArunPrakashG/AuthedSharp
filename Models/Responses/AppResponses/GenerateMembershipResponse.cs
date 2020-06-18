using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Responses.AppResponses {
	public class Membership {
		[JsonProperty("id")]
		public string ID { get; set; }

		[JsonProperty("time")]
		public int Time { get; set; }

		[JsonProperty("level")]
		public int Level { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}

	public class GenerateMembershipResponse : BaseResponse {
		[JsonProperty("membership")]
		public Membership Membership { get; set; } = new Membership();
	}
}
