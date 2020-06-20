using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct RenewUserSessionRequest {
		public readonly string ApplicationSession;
		public readonly string UserSession;

		public RenewUserSessionRequest(string _session, string _userSession) {
			ApplicationSession = _session;
			UserSession = _userSession;
		}
	}
}
