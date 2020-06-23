namespace AuthedSharp.Models.Parameters {
	public struct GrandMembershipRequest {
		public readonly string Email;
		public readonly string MembershipID;
		public readonly string ApplicationSession;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="_email">Email address of the person who you want to grand membership.</param>
		/// <param name="_membershipID">The membership id.</param>
		/// <param name="_appSession">The application session.</param>
		public GrandMembershipRequest(string _email, string _membershipID, string _appSession) {
			Email = _email;
			MembershipID = _membershipID;
			ApplicationSession = _appSession;
		}
	}
}
