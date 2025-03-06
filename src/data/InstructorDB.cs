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

#if DEBUG
		private IEnumerable<Quiz> _quizzes = new List<Quiz>(){
				new Quiz{ ID = 1, UUID=Guid.NewGuid(), Name = "Quiz #1", Short = "Quiz_1", IsRandom = true, PPQ = 10, Time = 1024 }
				, new Quiz{ID = 3, UUID=Guid.NewGuid(), Name = "Quiz #2", Short = "Quiz_2", IsRandom = false, PPQ = 1, Time = 2048 }
				, new Quiz{ID = 5, UUID=Guid.NewGuid(), Name = "Quiz #3", Short = "Quiz_3", IsRandom = true, PPQ = 100, Time = 512 }
				, new Quiz{ID = 7, UUID=Guid.NewGuid(), Name = "Quiz #4", Short = "Quiz_4", IsRandom = false, PPQ = 5, Time = 4096 }
				, new Quiz{ID = 9, UUID=Guid.NewGuid(), Name = "Quiz #5", Short = "Quiz_5", IsRandom = false, PPQ = 5000, Time = 256 }
			};
#endif
		/// <summary>
		/// Returns all Quizzes currently available
		/// </summary>
		/// <returns></returns>
		public IEnumerable<QuizView> GetQuizzesView() {
#if DEBUG
			return this._quizzes;
#else
			return null;
#endif
		}

		public Quiz GetQuizDetails(long id) {
#if DEBUG
			return this._quizzes.FirstOrDefault(x => x.ID == id);
#else
			return null;
#endif
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
