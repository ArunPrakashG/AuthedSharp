using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Responses.AppResponses {
	public class VerifyResponse : BaseResponse {
		[JsonProperty("session")]
		public string Session { get; set; }
	}
}
