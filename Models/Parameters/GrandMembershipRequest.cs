using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct GrandMembershipRequest {
		public readonly string Email;
		public readonly string MembershipID;
		public readonly string ApplicationSession;

		public GrandMembershipRequest(string _email, string _membershipID, string _session) {
			Email = _email;
			MembershipID = _membershipID;
			ApplicationSession = _session;
		}
	}
}
