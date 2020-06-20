using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct GetUserRequest {
		public readonly string ApplicationSession;
		public readonly string UserSession;

		public GetUserRequest(string _session, string _userSession) {
			ApplicationSession = _session;
			UserSession = _userSession;
		}
	}
}
