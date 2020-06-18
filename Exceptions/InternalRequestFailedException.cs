using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Exceptions {
	public class InternalRequestFailedException : Exception {
		public InternalRequestFailedException(string reason) : base(reason) {

		}

		public InternalRequestFailedException() : base("An internal request failed.") {

		}
	}
}
