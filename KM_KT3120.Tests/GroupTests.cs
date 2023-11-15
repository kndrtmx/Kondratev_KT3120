using System.Text.RegularExpressions;

namespace KM_KT3120.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT3120_True()
        {
            var testGroup = new Group { GroupName = "KT-31-20" };
            var result = testGroup.IsValidGroupName();
            Assert.True(result);
        }
        public class Group
        {
            public int GroupId { get; set; }
            public string? GroupName { get; set; }
            public bool IsValidGroupName()
            {
                return Regex.Match(GroupName, @"\D*-\d*-\d\d").Success;
            }
        }
    }
}