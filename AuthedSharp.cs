using AuthedSharp.Models.Parameters;
using AuthedSharp.Models.Responses.AppResponses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthedSharp {
	public class AuthedSharp {
		private readonly Requester Requester;

		public AuthedSharp(HttpClientHandler _handler) => Requester = new Requester(_handler, null);

		public AuthedSharp(IWebProxy _proxy) => Requester = new Requester(null, _proxy);

		public async Task<VerifyResponse> VerifyAsync(VerifyRequest request) {
			if (string.IsNullOrEmpty(request.AccessToken) || string.IsNullOrEmpty(request.ApplicationID)) {
				throw new ArgumentNullException(nameof(request));
			}

			using (HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, $"verify/{request.ApplicationID}")) {
				requestMsg.Content = new FormUrlEncodedContent(new Dictionary<string, string>
				{
					{ "access", request.AccessToken }
				});

				return await Requester.InternalRequestAsObject<VerifyResponse>(requestMsg, 1).ConfigureAwait(false);
			}
		}
	}
}
