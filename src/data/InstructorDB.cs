using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace coding_lms.data {
	public class InstructorDB : RootDBContext {
		public InstructorDB() {
		}

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

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Term> GetTerms() {
#if DEBUG
			return new List<Term>(){
				new Term{ID = 202520, SchoolYear=2025, Name=TermEnum.Spring},
				new Term{ID = 202510, SchoolYear=2025, Name=TermEnum.Fall },
				new Term{ID = 202430, SchoolYear=2024, Name=TermEnum.Summer },
				new Term{ID=202420, SchoolYear=2024, Name=TermEnum.Spring}
			};
#else
			return null;
#endif
		}

#if DEBUG
		private IEnumerable<SectionView> _sections {
			get {
				return new List<SectionView>() {
					// Spring 2025
					new SectionView(){Term=202520, Course="CIS-150", CRN=23456, StudentCount=25}
					,new SectionView(){Term=202520, Course="HED-2256", CRN=24567, StudentCount=15}
					,new SectionView(){Term=202520, Course="CIS-2156", CRN=27851, StudentCount=35}
					,new SectionView(){Term=202520, Course="CDA-1150", CRN=25678, StudentCount=100}
					// Fall 2024
					,new SectionView(){Term=202510, Course="CIS-150", CRN=13456, StudentCount=25}
					,new SectionView(){Term=202510, Course="CDA-1150", CRN=15678, StudentCount=15}
					,new SectionView(){Term=202510, Course="CIS-2156", CRN=17851, StudentCount=35}
					,new SectionView(){Term=202510, Course="ART-1000", CRN=15678, StudentCount=10}
					// Summer 2024
					,new SectionView(){Term=202430, Course="ART-1000", CRN=35678, StudentCount=15}
					,new SectionView(){Term=202430, Course="CIS-150", CRN=33456, StudentCount=10}
					,new SectionView(){Term=202430, Course="CIS-2156", CRN=37851, StudentCount=500}
					,new SectionView(){Term=202430, Course="CDA-1150", CRN=35678, StudentCount=20}
					// Spring 2024
					,new SectionView(){Term=202420, Course="CIS-150", CRN=23456, StudentCount=25}
				};
			}
		}
#endif

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id">int (Int32) value; Term.ID field value</param>
		/// <returns></returns>
		public IEnumerable<SectionView> GetSectionsView(int? id = null) {
#if DEBUG
			var ret = new List<SectionView>();

			if ( id.HasValue ) {
				ret = this._sections.Where(sv => sv.Term == id.Value).ToList();
			}
			else {
				ret = this._sections.ToList();
			}

			return ret;
#else
			return null;
#endif
		}


#if DEBUG
		private IEnumerable<EnrollmentView> _enrollments {
			get {
				return new List<EnrollmentView>() {
					// Spring 2025
					new EnrollmentView(){Term=202520, Course="CIS-150", CRN=23456, StudentCount=25}
					,new EnrollmentView(){Term=202520, Course="HED-2256", CRN=24567, StudentCount=15}
					,new EnrollmentView(){Term=202520, Course="CIS-2156", CRN=27851, StudentCount=35}
					,new EnrollmentView(){Term=202520, Course="CDA-1150", CRN=25678, StudentCount=100}
					// Fall 2024
					,new EnrollmentView(){Term=202510, Course="CIS-150", CRN=13456, StudentCount=25}
					,new EnrollmentView(){Term=202510, Course="CDA-1150", CRN=15678, StudentCount=15}
					,new EnrollmentView(){Term=202510, Course="CIS-2156", CRN=17851, StudentCount=35}
					,new EnrollmentView(){Term=202510, Course="ART-1000", CRN=15678, StudentCount=10}
					// Summer 2024
					,new EnrollmentView(){Term=202430, Course="ART-1000", CRN=35678, StudentCount=15}
					,new EnrollmentView(){Term=202430, Course="CIS-150", CRN=33456, StudentCount=10}
					,new EnrollmentView(){Term=202430, Course="CIS-2156", CRN=37851, StudentCount=500}
					,new EnrollmentView(){Term=202430, Course="CDA-1150", CRN=35678, StudentCount=20}
					// Spring 2024
					,new EnrollmentView(){Term=202420, Course="CIS-150", CRN=23456, StudentCount=25}
				};
			}
		}
#endif

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public IEnumerable<EnrollmentView> GetEnrollmentViews(string id = null) {
#if DEBUG
			var ret = this._enrollments.ToList();

			if ( String.IsNullOrEmpty(id) ) {
				ret = this._enrollments.Where(ev => ev.ID == id).ToList();
			}

			return ret;
#else
			return null;
#endif
		}

#if DEBUG
		public IEnumerable<Student> _students = new List<Student>() {
			new Student {UUID = Guid.NewGuid(), SRN="A123456789", LastName = "Doe", FirstName = "John", Email = "john.doe@school.edu"}
			,new Student {UUID = Guid.NewGuid(), SRN="A234567891", LastName = "Doe", FirstName = "Jane", Email = "jane.doe@school.edu"}
			,new Student {UUID = Guid.NewGuid(), SRN="A345678912", LastName = "Davis", FirstName = "Jack", Email = "jackdavis1234@school.edu"}
			,new Student {UUID = Guid.NewGuid(), SRN="A456789123", LastName = "Davis", FirstName = "Jaqueline", Email = "jaqdavis0345@school.edu"}
			,new Student {UUID = Guid.NewGuid(), SRN = "A567891234", LastName = "Smith", FirstName = "John", Email = "josmith@school.edu"}
			,new Student {UUID = Guid.NewGuid(), SRN = "A678912345", LastName = "Smith", FirstName = "Jane", Email = "jasmith@school.edu"}
			,new Student {UUID = Guid.NewGuid(), SRN = "A789123456", LastName = "Smith", FirstName = "Mark", Email = "mark.smith@school.edu"}
		};

#endif

		/// <summary>
		/// 
		/// </summary>
		/// <param name="section"></param>
		/// <returns></returns>
		public IEnumerable<StudentView> GetStudentsView(string section) {
#if DEBUG
			return this._students;
#else
			return null;
#endif
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="uuid"></param>
		/// <returns></returns>
		public Student GetStudent(Guid uuid) {
#if DEBUG
			return this._students.FirstOrDefault((student) => student.UUID == uuid);
#else
			return null;
#endif
		}
	}
}
