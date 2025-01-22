using System.Web.Http;

namespace quiz.Controllers {
	[RoutePrefix("/api/submit")]
	public class SubmitController : ApiController {

		// POST api/<controller>
		public void Post([FromBody] string value) {

		}

		// PUT api/<controller>/5
		//public void Put(int id, [FromBody] string value) {
		//}

		//// DELETE api/<controller>/5
		//public void Delete(int id) {
		//}
	}
}