// **************************************************
// ***** Step (1) ***********************************
// **************************************************
//namespace Dtat
//{
//	public class Result<T> : object
//	{
//		public Result() : base()
//		{
//		}

//		public T Value { get; set; }

//		public bool IsFailed { get; set; }

//		public bool IsSuccess { get; set; }

//		public System.Collections.Generic.List<string> Errors { get; set; }

//		public System.Collections.Generic.List<string> Successes { get; set; }
//	}
//}
// **************************************************
// دو ایراد دارد
// اول این‌که هر زمان که می‌خواهیم یک خطا ثبت کنیم، باید نال بودن یا نبودن مجموعه را چک کنیم
// دوم آن‌که تیم یو آی، همیشه باید نال بودن و نیز صفر بودن طول این مجمموعه را تست کند

// Result<int> result = new Result<int>();

// result.Errors.Add("Error Message (1)!"); // Runtime Error!
//
// if(result.Errors == null)
// {
//		result.Errors =
//			new System.Collections.Generic.List<string>();
// }

// result.Errors.Add("Error Message (1)!");
// **************************************************
// ***** /Step (1) **********************************
// **************************************************

// **************************************************
// ***** Step (2) ***********************************
// **************************************************
//namespace Dtat
//{
//	public class Result<T> : object
//	{
//		public Result() : base()
//		{
//			Errors =
//				new System.Collections.Generic.List<string>();

//			Successes =
//				new System.Collections.Generic.List<string>();
//		}

//		public T Value { get; set; }

//		public bool IsFailed { get; set; }

//		public bool IsSuccess { get; set; }

//		public System.Collections.Generic.IList<string> Errors { get; set; }

//		public System.Collections.Generic.IList<string> Successes { get; set; }
//	}
//}
// **************************************************
// با تغییرات فوق، دو مشکل اول حل می‌شود

// با توجه به این‌که مجموعه‌ها
// set
// دارند، یک برنامه‌نویس معمولی ممکن است که این مجموعه را به اشتباه با مجموعه دیگری جابجا کند

// var someList =
//		new System.Collections.Generic.List<string>();

// someList.Add("Error Message (4)!");
// someList.Add("Error Message (5)!");

// Result<int> result = new Result<int>();

// result.Errors.Add("Error Message (1)!");
// result.Errors.Add("Error Message (2)!");
// result.Errors.Add("Error Message (3)!");

// result.Errors = someList;

// در این حالت سه پیغام خطای از یک تا سه را از دست می‌دهیم
// **************************************************
// ***** /Step (2) **********************************
// **************************************************

// **************************************************
// ***** Step (3) ***********************************
// **************************************************
//namespace Dtat
//{
//	public class Result<T> : object
//	{
//		public Result() : base()
//		{
//			Errors =
//				new System.Collections.Generic.List<string>();

//			Successes =
//				new System.Collections.Generic.List<string>();
//		}

//		public T Value { get; set; }

//		public bool IsFailed { get; set; }

//		public bool IsSuccess { get; set; }

//		public System.Collections.Generic.IList<string> Errors { get; }

//		public System.Collections.Generic.IList<string> Successes { get; }
//	}
//}
// **************************************************
// مشکل این سورس‌کد آن است که به صورت مدیریت شده نمی‌توانیم خطاها و موفقیت‌ها را ثبت کنیم
// یعنی نمی‌توانیم جلوی درج پیغام‌های نال و نال استرینگ و یا تکراری را بگیریم

// Result<int> result = new Result<int>();

// result.Errors.Add(null);
// result.Errors.Add(string.Empty);
// result.Errors.Add("     ");
// result.Errors.Add("Error Message (1)!");
// result.Errors.Add("Error Message (1)!");
// **************************************************
// ***** /Step (3) **********************************
// **************************************************

// **************************************************
// ***** Step (4) ***********************************
// **************************************************
//namespace Dtat
//{
//	public class Result<T> : object
//	{
//		public Result() : base()
//		{
//			Errors =
//				new System.Collections.Generic.List<string>();

//			Successes =
//				new System.Collections.Generic.List<string>();
//		}

//		public T Value { get; set; }

//		public bool IsFailed { get; set; }

//		public bool IsSuccess { get; set; }

//		public System.Collections.Generic.IList<string> Errors { get; }

//		public System.Collections.Generic.IList<string> Successes { get; }

//		public void AddErrorMessage(string message)
//		{
//			message =
//				String.Fix(text: message);

//			if (message == null)
//			{
//				return;
//			}

//			if (Errors.Contains(message))
//			{
//				return;
//			}

//			Errors.Add(message);
//		}

//		public void AddSuccessMessage(string message)
//		{
//			message =
//				String.Fix(text: message);

//			if (message == null)
//			{
//				return;
//			}

//			if (Successes.Contains(message))
//			{
//				return;
//			}

//			Successes.Add(message);
//		}
//	}
//}
// **************************************************
// درست است که با ایجاد توابع فوق، یک مدیریت قوی برای درج پیغام‌ها ایجاد کرده‌ایم

// Result<int> result = new Result<int>();

// result.AddErrorMessage(null);
// result.AddErrorMessage(string.Empty);
// result.AddErrorMessage("     ");
// result.AddErrorMessage("Error Message (1)!");
// result.AddErrorMessage("Error Message (1)!");

// [Error Message (1)!]

// ولی کماکان یک برنامه‌نویس ساده می‌تواند به اشتباه مستقیقا از خود مجموعه برای درج پیغام‌ها استفاده کند

// Result<int> result = new Result<int>();

// result.Errors.Add(null);
// result.Errors.Add(string.Empty);
// result.Errors.Add("     ");
// result.Errors.Add("Error Message (1)!");
// result.Errors.Add("Error Message (1)!");

// باید دقت داشته باشیم که مجموعه‌ها را نمی‌توانیم
// private / protected
// تعریف نماییم! چرا که دیگر
// Serialize
// نشده و در شیء
// Json
// قرار نمی‌گیرند
// **************************************************
// ***** /Step (4) **********************************
// **************************************************

// **************************************************
// ***** Step (5) ***********************************
// **************************************************
//namespace Dtat
//{
//	public class Result<T> : object
//	{
//		public Result() : base()
//		{
//			_errors =
//				new System.Collections.Generic.List<string>();

//			_successes =
//				new System.Collections.Generic.List<string>();
//		}

//		public T Value { get; set; }

//		public bool IsFailed { get; set; }

//		public bool IsSuccess { get; set; }

//		[System.Text.Json.Serialization.JsonIgnore]
//		private readonly System.Collections.Generic.List<string> _errors;

//		public System.Collections.Generic.IReadOnlyList<string> Errors
//		{
//			get
//			{
//				return _errors;
//			}
//		}

//		[System.Text.Json.Serialization.JsonIgnore]
//		private readonly System.Collections.Generic.List<string> _successes;

//		public System.Collections.Generic.IReadOnlyList<string> Successes
//		{
//			get
//			{
//				return _successes;
//			}
//		}

//		public void AddErrorMessage(string message)
//		{
//			message =
//				String.Fix(text: message);

//			if (message == null)
//			{
//				return;
//			}

//			if (_errors.Contains(message))
//			{
//				return;
//			}

//			_errors.Add(message);
//		}

//		public void AddSuccessMessage(string message)
//		{
//			message =
//				String.Fix(text: message);

//			if (message == null)
//			{
//				return;
//			}

//			if (_successes.Contains(message))
//			{
//				return;
//			}

//			_successes.Add(message);
//		}
//	}
// **************************************************
// ***** /Step (5) **********************************
// **************************************************

// **************************************************
// ***** Step (6) ***********************************
// **************************************************
namespace Dtat
{
	public class Result : object
	{
		public Result() : base()
		{
			_errors =
				new System.Collections.Generic.List<string>();

			_successes =
				new System.Collections.Generic.List<string>();
		}

		public bool IsFailed { get; set; }

		public bool IsSuccess { get; set; }

		[System.Text.Json.Serialization.JsonIgnore]
		private readonly System.Collections.Generic.List<string> _errors;

		public System.Collections.Generic.IReadOnlyList<string> Errors
		{
			get
			{
				return _errors;
			}
		}

		[System.Text.Json.Serialization.JsonIgnore]
		private readonly System.Collections.Generic.List<string> _successes;

		public System.Collections.Generic.IReadOnlyList<string> Successes
		{
			get
			{
				return _successes;
			}
		}

		public void AddErrorMessage(string message)
		{
			message =
				String.Fix(text: message);

			if (message == null)
			{
				return;
			}

			if (_errors.Contains(message))
			{
				return;
			}

			_errors.Add(message);
		}

		public void RemoveErrorMessage(string message)
		{
			message =
				String.Fix(text: message);

			if (message == null)
			{
				return;
			}

			_errors.Remove(message);
		}

		public void ClearErrorMessages()
		{
			_errors.Clear();
		}

		public void AddSuccessMessage(string message)
		{
			message =
				String.Fix(text: message);

			if (message == null)
			{
				return;
			}

			if (_successes.Contains(message))
			{
				return;
			}

			_successes.Add(message);
		}

		public void RemoveSuccessMessage(string message)
		{
			message =
				String.Fix(text: message);

			if (message == null)
			{
				return;
			}

			_successes.Remove(message);
		}

		public void ClearSuccessMessages()
		{
			_successes.Clear();
		}
	}

	public class Result<T> : Result
	{
		public Result() : base()
		{
		}

		public T Value { get; set; }
	}

	public static class ResultExtensions
	{
		static ResultExtensions()
		{
		}

		public static Result ConvertToDtatResult(this FluentResults.Result result)
		{
			Result DtatResult = new()
			{
				IsFailed = result.IsFailed,
				IsSuccess = result.IsSuccess,
			};

			if (result.Errors != null)
			{
				foreach (var item in result.Errors)
				{
					DtatResult.AddErrorMessage(message: item.Message);
				}
			}

			if (result.Successes != null)
			{
				foreach (var item in result.Successes)
				{
					DtatResult.AddSuccessMessage(message: item.Message);
				}
			}

			return DtatResult;
		}

		public static Result<T> ConvertToDtatResult<T>(this FluentResults.Result<T> result)
		{
			Result<T> DtatResult = new()
			{
				IsFailed = result.IsFailed,
				IsSuccess = result.IsSuccess,
			};

			if (result.IsFailed == false)
			{
				DtatResult.Value = result.Value;
			}

			if (result.Errors != null)
			{
				foreach (var item in result.Errors)
				{
					DtatResult.AddErrorMessage(message: item.Message);
				}
			}

			if (result.Successes != null)
			{
				foreach (var item in result.Successes)
				{
					DtatResult.AddSuccessMessage(message: item.Message);
				}
			}

			return DtatResult;
		}
	}
}
// **************************************************
// ***** /Step (6) **********************************
// **************************************************
