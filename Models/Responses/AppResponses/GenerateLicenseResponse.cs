using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Responses.AppResponses {
	public class License {
		[JsonProperty("id")]
		public string ID { get; set; }

		[JsonProperty("time")]
		public int Time { get; set; }

		[JsonProperty("level")]
		public int Level { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }
	}

	public class GenerateLicenseResponse : BaseResponse {
		[JsonProperty("licenses")]
		public List<License> Licenses { get; set; } = new List<License>();
	}
}
