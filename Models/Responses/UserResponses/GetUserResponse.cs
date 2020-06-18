using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Responses.UserResponses {
	public class User {
		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("identifier")]
		public string Identifier { get; set; }

		[JsonProperty("password")]
		public string Password { get; set; }

		[JsonProperty("id")]
		public string ID { get; set; }

		[JsonProperty("level")]
		public long Level { get; set; }

		[JsonProperty("isBanned")]
		public bool IsBanned { get; set; }

		[JsonProperty("app")]
		public App App { get; set; }

		[JsonProperty("license")]
		public UserLicense License { get; set; }

		[JsonProperty("membership")]
		public UserMembership Membership { get; set; }

		[JsonProperty("activatedOn")]
		public DateTime LastActivatedOn { get; set; }
	}

	public class App {
		[JsonProperty("useMemberships")]
		public bool UseMemberships { get; set; }

		[JsonProperty("isFree")]
		public bool IsFree { get; set; }		
	}

	public class UserLicense {
		[JsonProperty("createdAt")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("time")]
		public long Time { get; set; }

		[JsonProperty("id")]
		public string ID { get; set; }
	}

	public class UserMembership {
		[JsonProperty("time")]
		public long Time { get; set; }

		[JsonProperty("level")]
		public long Level { get; set; }
	}

	public class GetUserResponse : BaseResponse {
		[JsonProperty("user")]
		public User User { get; set; } = new User();
	}
}
