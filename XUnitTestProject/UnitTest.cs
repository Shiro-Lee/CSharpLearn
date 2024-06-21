using TestApp;	//���뱻������Ŀ
using Xunit.Abstractions;   //ʹ��ITestOutputHelper���������Ϣ
using System.Reflection;

namespace XUnitTestProject
{
	public class UnitTest: IDisposable
	{
		public static ITestOutputHelper? OutputHelper { get; set; } //�����ӿ�

		public static int Runtime { get; set; } = 0;	//��¼ʵ��������

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

		[Fact]	//��ǲ��Է����޲�
		public void TestAddNum()
		{
			Program pro = new Program();	//Arrange
			int sum = pro.AddNum(1, 2);		//Act
			Assert.Equal(3, sum);           //Assert
			OutputHelper?.WriteLine($"{MethodBase.GetCurrentMethod()!.Name}, Runtime: {Runtime}");
		}

		[Fact(Timeout = 500)]	//����޶�����ִ��ʱ��
		public async Task TestTimeout() 
		{
			Assert.NotNull(FieldCases);
			Assert.NotEmpty(PropertyCases);
			await Task.Delay(10);
			OutputHelper?.WriteLine($"{MethodBase.GetCurrentMethod()!.Name}, Runtime: {Runtime}");
		}

		[Theory]	//��ǲ��Է�������
		[MemberData(nameof(PropertyCases))] //��ǲ��Է������ֶ�/����/�����л�ȡ�������ݣ���̬IEnumerable<object[]>��
		public void TestCombineString(string str1, string str2, string str3)
		{
			Program pro = new Program();
			string str = pro.CombineString(str1, str2);
			Assert.Equal(str3, str);
			OutputHelper?.WriteLine($"{MethodBase.GetCurrentMethod()!.Name}, Runtime: {Runtime}");
		}

		[Theory]
		[InlineData(DayOfWeek.Monday, false)]	//��ǲ���ʹ��ָ���������
		[InlineData(DayOfWeek.Friday, false)]
		[InlineData(DayOfWeek.Sunday, true)]
		public void TestIsWeekend(DayOfWeek day, bool isWeekend)
		{
			Program pro = new Program();
			Assert.True(pro.IsWeekend(day) == isWeekend);
			OutputHelper?.WriteLine($"{MethodBase.GetCurrentMethod()!.Name}, Runtime: {Runtime}");
		}

		[Fact(Skip = "��������")]
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