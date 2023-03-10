//Copyright (c) 2007, Moq Contributors
//http://code.google.com/p/moq-contrib/
//All rights reserved.

//Redistribution and use in source and binary forms, 
//with or without modification, are permitted provided 
//that the following conditions are met:

//    * Redistributions of source code must retain the 
//    above copyright notice, this list of conditions and 
//    the following disclaimer.

//    * Redistributions in binary form must reproduce 
//    the above copyright notice, this list of conditions 
//    and the following disclaimer in the documentation 
//    and/or other materials provided with the distribution.

//    * Neither the name of the Moq Contributors nor the 
//    names of its contributors may be used to endorse 
//    or promote products derived from this software 
//    without specific prior written permission.

//THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND 
//CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
//INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF 
//MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
//DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
//CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
//SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
//BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR 
//SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
//INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
//WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
//NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE 
//OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF 
//SUCH DAMAGE.

//[This is the BSD license, see
// http://www.opensource.org/licenses/bsd-license.php]

using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace Moq.Mvc
{
	/// <summary>
	/// Mock the complete HttpResponseBase object hierarchy
	/// </summary>
	public class HttpResponseMock : Mock<HttpResponseBase>
	{
		/// <summary>
		/// 
		/// </summary>
		public HttpResponseMock()
		{
			this.Output = new Mock<TextWriter>();
			this.OutputStream = new Mock<Stream>();
			this.Cache = new HttpCachePolicyBaseMock();

			SetupGet(m => m.Output).Returns(this.Output.Object);
			SetupGet(m => m.OutputStream).Returns(this.OutputStream.Object);
			SetupGet(m => m.Cache).Returns(this.Cache.Object);
		    SetupGet(m => m.Cookies).Returns(new HttpCookieCollection());
		    SetupGet(m => m.Headers).Returns(new NameValueCollection());
		}

		// TODO: mock other properties.

		/// <summary>
		/// 
		/// </summary>
		public HttpCachePolicyBaseMock Cache { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public Mock<TextWriter> Output { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public Mock<Stream> OutputStream { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public new void Verify()
		{
			this.Cache.Verify();
			this.Output.Verify();
			this.OutputStream.Verify();

			base.Verify();
		}

		/// <summary>
		/// 
		/// </summary>
		public new void VerifyAll()
		{
			this.Cache.VerifyAll();
			this.Output.VerifyAll();
			this.OutputStream.VerifyAll();

			base.VerifyAll();
		}
	}
}
