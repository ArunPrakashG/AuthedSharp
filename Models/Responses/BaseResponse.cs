using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Responses {
	public class BaseResponse {
		[JsonProperty("code")]
		public int ResponseCode { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }
	}
}
