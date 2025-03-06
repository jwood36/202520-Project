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

#if DEBUG
		private IEnumerable<Question> _quests = new List<Question>() {
				new Question(Guid.NewGuid()) {
					ID = 1,
					Type = QuestionEnum.TF,
					Body = "This is Question #1 Body",
					IsRandom = true,
					Answers = new List<Answer>() {
						new Answer(Guid.NewGuid()){ Text = "Answer 1.1", IsCorrect=true, Ordinal=1}
						, new Answer(Guid.NewGuid()){Text = "Answer 1.2", IsCorrect=false, Ordinal=2}
					}
				},
				new Question(Guid.NewGuid()) {
					ID = 2,
					Type = QuestionEnum.MAL,
					Body = "This is Question #2 Body",
					IsRandom = true,
					Answers = new List<Answer>() {
						new Answer(Guid.NewGuid()){Key="A", Text="Answer 2.1", IsCorrect=false, Ordinal=1 },
						new Answer(Guid.NewGuid()){Key="B", Text="Answer 2.2", IsCorrect=true, Ordinal=2 },
						new Answer(Guid.NewGuid()){Key="C", Text="Answer 2.3", IsCorrect=true, Ordinal=3 },
						new Answer(Guid.NewGuid()){Key="D", Text="Answer 2.4", IsCorrect=false, Ordinal=4 },
						new Answer(Guid.NewGuid()){Key="E", Text="Answer 2.5", IsCorrect=true, Ordinal=5 },
						new Answer(Guid.NewGuid()){Key="F", Text="Answer 2.6", IsCorrect=false, Ordinal=6 },
					}
				},
				new Question(Guid.NewGuid()) {
					ID = 3,
					Type = QuestionEnum.MAN,
					Body = "This is Question #3 Body",
					IsRandom = true,
					Answers = new List<Answer>() {
						new Answer(Guid.NewGuid()){Key="1", Text="Answer 3.1", IsCorrect=false, Ordinal=1 },
						new Answer(Guid.NewGuid()){Key="2", Text="Answer 3.2", IsCorrect=false, Ordinal=2 },
						new Answer(Guid.NewGuid()){Key="3", Text="Answer 3.3", IsCorrect=true, Ordinal=3 },
						new Answer(Guid.NewGuid()){Key="4", Text="Answer 3.4", IsCorrect=true, Ordinal=4 },
						new Answer(Guid.NewGuid()){Key="5", Text="Answer 3.5", IsCorrect=true, Ordinal=5 },
						new Answer(Guid.NewGuid()){Key="6", Text="Answer 3.6", IsCorrect=false, Ordinal=6 },
					}
				},
				new Question(Guid.NewGuid()) {
					ID = 5,
					Type = QuestionEnum.MCN,
					Body = "This is Question #4 Body",
					IsRandom = true,
					Answers = new List<Answer>() {
						new Answer(Guid.NewGuid()){Key="1", Text="Answer 4.1", IsCorrect=false, Ordinal=1 },
						new Answer(Guid.NewGuid()){Key="2", Text="Answer 4.2", IsCorrect=false, Ordinal=2 },
						new Answer(Guid.NewGuid()){Key="3", Text="Answer 4.3", IsCorrect=true, Ordinal=3 },
						new Answer(Guid.NewGuid()){Key="4", Text="Answer 4.4", IsCorrect=false, Ordinal=4 },
						new Answer(Guid.NewGuid()){Key="5", Text="Answer 4.5", IsCorrect=false, Ordinal=5 },
						new Answer(Guid.NewGuid()){Key="6", Text="Answer 4.6", IsCorrect=false, Ordinal=6 },
						new Answer(Guid.NewGuid()){Key="7", Text="Answer 4.7", IsCorrect=false, Ordinal=7 },
						new Answer(Guid.NewGuid()){Key="8", Text="Answer 4.8", IsCorrect=false, Ordinal=8 },
						new Answer(Guid.NewGuid()){Key="9", Text="Answer 4.9", IsCorrect=false, Ordinal=9 },
					}
				},
				new Question(Guid.NewGuid()) {
					ID = 7,
					Type = QuestionEnum.MCL,
					Body = "This is Question #5 Body",
					IsRandom = true,
					Answers = new List<Answer>() {
						new Answer(Guid.NewGuid()){Key="A", Text="Answer 5.1", IsCorrect=false, Ordinal=1 },
						new Answer(Guid.NewGuid()){Key="B", Text="Answer 5.2", IsCorrect=true, Ordinal=2 },
						new Answer(Guid.NewGuid()){Key="C", Text="Answer 5.3", IsCorrect=false, Ordinal=3 },
						new Answer(Guid.NewGuid()){Key="D", Text="Answer 5.4", IsCorrect=false, Ordinal=4 },
					}
				},
				new Question(Guid.NewGuid()) {
					ID = 11,
					Type = QuestionEnum.TF,
					Body = "This is Question #6 Body",
					IsRandom = false,
					Answers = new List<Answer>() {
						new Answer(Guid.NewGuid()){ Key="1", Text = "Answer 6.1", IsCorrect=true, Ordinal=4}
						, new Answer(Guid.NewGuid()){Key="2", Text = "Answer 6.2", IsCorrect=false, Ordinal=9}
					}
				},
				new Question(Guid.NewGuid()) {
					ID = 13,
					Type = QuestionEnum.MCL,
					Body = "This is Question #7 Body",
					IsRandom = false,
					Answers = new List<Answer>() {
						new Answer(Guid.NewGuid()){Key="A", Text="Answer 7.1", IsCorrect=false, Ordinal=1 },
						new Answer(Guid.NewGuid()){Key="B", Text="Answer 7.2", IsCorrect=true, Ordinal=2 },
						new Answer(Guid.NewGuid()){Key="C", Text="Answer 7.3", IsCorrect=false, Ordinal=3 },
						new Answer(Guid.NewGuid()){Key="D", Text="Answer 7.4", IsCorrect=false, Ordinal=4 },
						new Answer(Guid.NewGuid()){Key="E", Text="Answer 7.4", IsCorrect=false, Ordinal=5 },
						new Answer(Guid.NewGuid()){Key="F", Text="Answer 7.4", IsCorrect=false, Ordinal=6 },
						new Answer(Guid.NewGuid()){Key="G", Text="Answer 7.4", IsCorrect=false, Ordinal=7 },
						new Answer(Guid.NewGuid()){Key="H", Text="Answer 7.4", IsCorrect=false, Ordinal=8 },
					}
				},
				new Question(Guid.NewGuid()) {
					ID = 17,
					Type = QuestionEnum.MCN,
					Body = "This is Question #8 Body",
					IsRandom = false,
					Answers = new List<Answer>() {
						new Answer(Guid.NewGuid()){Key="1", Text="Answer 8.1", IsCorrect=false, Ordinal=1 },
						new Answer(Guid.NewGuid()){Key="2", Text="Answer 8.2", IsCorrect=false, Ordinal=2 },
						new Answer(Guid.NewGuid()){Key="3", Text="Answer 8.3", IsCorrect=true, Ordinal=3 },
						new Answer(Guid.NewGuid()){Key="4", Text="Answer 8.4", IsCorrect=false, Ordinal=4 },
						new Answer(Guid.NewGuid()){Key="5", Text="Answer 8.5", IsCorrect=false, Ordinal=5 },
						new Answer(Guid.NewGuid()){Key="6", Text="Answer 8.6", IsCorrect=false, Ordinal=6 },
					}
				},
				new Question(Guid.NewGuid()) {
					ID = 19,
					Type = QuestionEnum.MAN,
					Body = "This is Question #9 Body",
					IsRandom = false,
					Answers = new List<Answer>() {
						new Answer(Guid.NewGuid()){Key="1", Text="Answer 9.1", IsCorrect=false, Ordinal=1 },
						new Answer(Guid.NewGuid()){Key="2", Text="Answer 9.2", IsCorrect=false, Ordinal=2 },
						new Answer(Guid.NewGuid()){Key="3", Text="Answer 9.3", IsCorrect=true, Ordinal=3 },
						new Answer(Guid.NewGuid()){Key="4", Text="Answer 9.4", IsCorrect=true, Ordinal=4 },
						new Answer(Guid.NewGuid()){Key="5", Text="Answer 9.5", IsCorrect=true, Ordinal=5 },
						new Answer(Guid.NewGuid()){Key="6", Text="Answer 9.6", IsCorrect=false, Ordinal=6 },
					}
				},
				new Question(Guid.NewGuid()) {
					ID = 23,
					Type = QuestionEnum.MAL,
					Body = "This is Question #10 Body",
					IsRandom = false,
					Answers = new List<Answer>() {
						new Answer(Guid.NewGuid()){Key="A", Text="Answer 10.1", IsCorrect=true, Ordinal=1 },
						new Answer(Guid.NewGuid()){Key="B", Text="Answer 10.2", IsCorrect=true, Ordinal=2 },
						new Answer(Guid.NewGuid()){Key="C", Text="Answer 10.3", IsCorrect=false, Ordinal=3 },
						new Answer(Guid.NewGuid()){Key="D", Text="Answer 10.4", IsCorrect=false, Ordinal=4 },
						new Answer(Guid.NewGuid()){Key="E", Text="Answer 10.5", IsCorrect=false, Ordinal=5 },
						new Answer(Guid.NewGuid()){Key="F", Text="Answer 10.6", IsCorrect=false, Ordinal=6 },
					}
				}
			};
#endif
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">Long value; Represents the Quiz ID</param>
		/// <returns></returns>
		public IEnumerable<Question> GetQuestionsView(long id) {
#if DEBUG
			return this._quests;
#else
			return null;
#endif
		}

		/// <summary>
		/// Return the Question details for the id passed
		/// </summary>
		/// <param name="id">Int64/long value</param>
		/// <returns></returns>
		public Question GetQuestion(Int64 id) {
#if DEBUG
			return this._quests.FirstOrDefault(q => q.ID == id);
#else
			return null;
#endif
		}

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
