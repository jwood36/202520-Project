using System;
using System.Data.SqlClient;
using System.Linq;

namespace coding_lms.data {
	public class TestDB : RootDBContext {
		public TestDB() { }

		public Quiz GetTest(int term, string crn, string name) {
			Quiz ret;

#if DEBUG
			ret = new Quiz(term, crn, name) {
				UUID = Guid.NewGuid(),
				Time = 1024,
				IsRandom = true,
				PPQ = 1
			};
#else

#endif

			// Return Value Result
			return ret;
		}
		#region Attempt ONLY Method/Functions
		/// <summary>
		/// Returns a single Attempt record
		/// </summary>
		/// <param name="id">Long Type; the ID value for the Attempt</param>
		/// <returns></returns>
		public Attempt GetAttempt(Int64 id) {
			return null;
		}

		/// <summary>
		/// Returns a single Attempt record
		/// </summary>
		/// <param name="quiz">String value; The Quiz Short_Name value</param>
		/// <param name="student">String value; The Student's SRN value</param>
		/// <returns></returns>
		public Attempt GetAttempt(string quiz, string student) {
			return this.ExecuteSProc<Attempt>("dbo.ap_Quiz_Get @quizid=@qid, @studentid=@sid",
				new SqlParameter("@qid", quiz)
				, new SqlParameter("@sid", student)
					).Single();
		}

		/// <summary>
		/// Returns a single Question record
		/// </summary>
		/// <param name="quiz">GUID type; the Quiz UID value</param>
		/// <returns></returns>
		public Question GetQuestions(Guid quiz) {
			return null;
		}


		public ResultPool GetTestResult() {
			return null;
		}

		#endregion
	}
}
