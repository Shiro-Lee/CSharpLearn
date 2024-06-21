using TestApp;	//引入被测试项目
using Xunit.Abstractions;   //使用ITestOutputHelper输出测试信息
using System.Reflection;

namespace XUnitTestProject
{
	public class UnitTest: IDisposable
	{
		public static ITestOutputHelper? OutputHelper { get; set; } //输出类接口

		public static int Runtime { get; set; } = 0;	//记录实例化次数

		public UnitTest(ITestOutputHelper helper) { 
			OutputHelper = helper;
			OutputHelper.WriteLine("ConstructUnitTest");
			Runtime++;
		} 

		public static List<object[]> FieldCases = [
				["Ren", "Amamiya", "Ren Amamiya"],
				["Ann", "Takamaki", "Ann Takamaki"],
				["Ryuji", "Sakamoto", "Ryuji Sakamoto"]];

		public static List<object[]> PropertyCases { 
			get {
				List<object[]> cases = [
					["Futaba", "Sakura", "Futaba Sakura"], 
					["Haru", "Okumura", "Haru Okumura"]];
				OutputHelper?.WriteLine($"{MethodBase.GetCurrentMethod()!.Name}, Runtime: {Runtime}");
				return cases;
			} }

		[Fact]	//标记测试方法无参
		public void TestAddNum()
		{
			Program pro = new Program();	//Arrange
			int sum = pro.AddNum(1, 2);		//Act
			Assert.Equal(3, sum);           //Assert
			OutputHelper?.WriteLine($"{MethodBase.GetCurrentMethod()!.Name}, Runtime: {Runtime}");
		}

		[Fact(Timeout = 500)]	//标记限定测试执行时间
		public async Task TestTimeout() 
		{
			Assert.NotNull(FieldCases);
			Assert.NotEmpty(PropertyCases);
			await Task.Delay(10);
			OutputHelper?.WriteLine($"{MethodBase.GetCurrentMethod()!.Name}, Runtime: {Runtime}");
		}

		[Theory]	//标记测试方法带参
		[MemberData(nameof(PropertyCases))] //标记测试方法从字段/属性/方法中获取测试数据（静态IEnumerable<object[]>）
		public void TestCombineString(string str1, string str2, string str3)
		{
			Program pro = new Program();
			string str = pro.CombineString(str1, str2);
			Assert.Equal(str3, str);
			OutputHelper?.WriteLine($"{MethodBase.GetCurrentMethod()!.Name}, Runtime: {Runtime}");
		}

		[Theory]
		[InlineData(DayOfWeek.Monday, false)]	//标记测试使用指定输入参数
		[InlineData(DayOfWeek.Friday, false)]
		[InlineData(DayOfWeek.Sunday, true)]
		public void TestIsWeekend(DayOfWeek day, bool isWeekend)
		{
			Program pro = new Program();
			Assert.True(pro.IsWeekend(day) == isWeekend);
			OutputHelper?.WriteLine($"{MethodBase.GetCurrentMethod()!.Name}, Runtime: {Runtime}");
		}

		[Fact(Skip = "跳过测试")]
		public async Task TestExecption()
		{
			await Assert.ThrowsAsync<IOException>(Program.ThrowTask<IOException>);
			OutputHelper?.WriteLine($"{MethodBase.GetCurrentMethod()!.Name}, Runtime: {Runtime}");
		}

		public void Dispose()
		{
			OutputHelper?.WriteLine("DisposeUnitTest");
		}
	}
}