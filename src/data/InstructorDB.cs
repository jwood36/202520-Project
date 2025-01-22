using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace coding_lms.data {
	public class InstructorDB : RootDBContext {
		public InstructorDB() { }

		/// <summary>
		/// Returns all Attempts currently available
		/// </summary>
		/// <returns>A generic collection of Attempt</returns>
		public IEnumerable<Attempt> GetAttempts() {
			return null;
		}

		/// <summary>
		/// Returns a single Attempt record
		/// </summary>
		/// <param name="quiz">String value; The Quiz Short_Name value</param>
		/// <param name="student">String value; The Student's SRN value</param>
		/// <returns></returns>
		public Attempt GetAttempt(Int64 id) {
			return this.ExecuteSProc<Attempt>("dbo.ap_Quiz_Get @id=@aid",
					new SqlParameter("@aid", id)
				).Single();
		}

		/// <summary>
		/// Returns all Quizzes currently available
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Quiz> GetQuizzes() {
			return null;
		}

		/// <summary>
		/// Returns all the Questions for a given Quiz
		/// </summary>
		/// <param name="quiz">Guid value</param>
		/// <returns></returns>
		public IEnumerable<Question> GetQuestions(Guid quiz) {
			return null;
		}

		/// <summary>
		/// Return the Question details for the id passed
		/// </summary>
		/// <param name="id">Int64/long value</param>
		/// <returns></returns>
		public Question GetQuestion(Int64 id) { return null; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="quiz"></param>
		/// <returns></returns>
		public IEnumerable<QuizPool> GetQuizPools(Guid? quiz) {
			return null;
		}


	}
}
