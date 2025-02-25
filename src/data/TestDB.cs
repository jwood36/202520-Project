using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

#if DEBUG
#endif


namespace coding_lms.data {
	public class TestDB : RootDBContext {
		public TestDB() { }

		#region Quiz ONLY Method/Functions
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
#if DEBUG
		// This is to test functionality during ALPHA DEBUG development
		public IEnumerable<Question> GetQuestion(Guid pooltest) {

			yield return new Question(Guid.NewGuid()) {
				Type = QuestionEnum.TF,
				Body = "This is Question #1 Body",
				IsRandom = true,
				Answers = new List<Answer>() {
					new Answer(Guid.NewGuid()){ Text = "Answer 1.1", IsCorrect=true, Ordinal=1}
					, new Answer(Guid.NewGuid()){Text = "Answer 1.2", IsCorrect=false, Ordinal=2}
				}
			};
			yield return new Question(Guid.NewGuid()) {
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
			};
			yield return new Question(Guid.NewGuid()) {
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
			};
			yield return new Question(Guid.NewGuid()) {
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
			};
			yield return new Question(Guid.NewGuid()) {
				Type = QuestionEnum.MCL,
				Body = "This is Question #5 Body",
				IsRandom = true,
				Answers = new List<Answer>() {
					new Answer(Guid.NewGuid()){Key="A", Text="Answer 5.1", IsCorrect=false, Ordinal=1 },
					new Answer(Guid.NewGuid()){Key="B", Text="Answer 5.2", IsCorrect=true, Ordinal=2 },
					new Answer(Guid.NewGuid()){Key="C", Text="Answer 5.3", IsCorrect=false, Ordinal=3 },
					new Answer(Guid.NewGuid()){Key="D", Text="Answer 5.4", IsCorrect=false, Ordinal=4 },
				}
			};
			yield return new Question(Guid.NewGuid()) {
				Type = QuestionEnum.TF,
				Body = "This is Question #6 Body",
				IsRandom = false,
				Answers = new List<Answer>() {
					new Answer(Guid.NewGuid()){ Key="1", Text = "Answer 6.1", IsCorrect=true, Ordinal=4}
					, new Answer(Guid.NewGuid()){Key="2", Text = "Answer 6.2", IsCorrect=false, Ordinal=9}
				}
			};
			yield return new Question(Guid.NewGuid()) {
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
			};
			yield return new Question(Guid.NewGuid()) {
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
			};
			yield return new Question(Guid.NewGuid()) {
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
			};
			yield return new Question(Guid.NewGuid()) {
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
			};
#else
		public Question GetQuestion(Guid pooltest) {
			Question ret;

						return ret;
#endif
		}
		#endregion

		#region Attempt ONLY Method/Functions
		/// <summary>
		/// Returns a single Attempt record
		/// </summary>
		/// <param name="id">Long Type; the ID value for the Attempt</param>
		/// <returns></returns>
		public Attempt GetAttempt(Int64 id) {
#if DEBUG
			var ret = new Attempt() {
				ID = id,
				UID = Guid.NewGuid(),
				Student = new Student("A0123456789") {
					UUID = Guid.NewGuid(),
					Email = "test.student@alabama.edu",
					FirstName = "Test",
					LastName = "Student"
				},
				Quiz = new Quiz(202520, "20123", "some-test") {
					UUID = Guid.NewGuid(),
					Time = 1024,
					IsRandom = true,
					PPQ = 1
				}
			};
			ret.Results = new List<AttemptPool>() {
					new AttemptPool(ret) {
						Question = Guid.NewGuid(),
						Answer = Guid.NewGuid(),
						IsCorrect = false,
						Points = 0
					},
					new AttemptPool(ret){
						Question = Guid.NewGuid(),
						Answer = Guid.NewGuid(),
						IsCorrect = true,
						Points = 1
					},
					new AttemptPool(ret){
						Question = Guid.NewGuid(),
						Answer = Guid.NewGuid(),
						IsCorrect = true,
						Points = 1
					},
					new AttemptPool(ret){
						Question = Guid.NewGuid(),
						Answer = Guid.NewGuid(),
						IsCorrect = true,
						Points = 1
					},
					new AttemptPool(ret){
						Question = Guid.NewGuid(),
						Answer = Guid.NewGuid(),
						IsCorrect = true,
						Points = 1
					},
					new AttemptPool(ret){
						Question = Guid.NewGuid(),
						Answer = Guid.NewGuid(),
						IsCorrect = false,
						Points = 0
					},
					new AttemptPool(ret){
						Question = Guid.NewGuid(),
						Answer = Guid.NewGuid(),
						IsCorrect = false,
						Points = 0
					},
					new AttemptPool(ret){
						Question = Guid.NewGuid(),
						Answer = Guid.NewGuid(),
						IsCorrect = false,
						Points = 0
					},
					new AttemptPool(ret){
						Question = Guid.NewGuid(),
						Answer = Guid.NewGuid(),
						IsCorrect = true,
						Points = 1
					},
					new AttemptPool(ret){
						Question = Guid.NewGuid(),
						Answer = Guid.NewGuid(),
						IsCorrect = true,
						Points = 1
					}
				};

			return ret;
#else
			// Open DBContext

			// 
			return null;
#endif
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
		public IEnumerable<Question> GetQuestions(string course = null) {
			return this.ExecuteSProc<Question>("dbo.ap_Question_Get @CourseID=@cid"
				, new SqlParameter("@cid", course ?? ( object )DBNull.Value)
			);
		}


		public ResultPool GetTestResult() {
			return null;
		}


		#endregion

	}
}
