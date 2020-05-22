
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TestResult")]
public class TestResult{
    [Key]
    public string dataID { get; set;  }
    public string sessionID { get; set;} 
    public string testID{ get; set;} 
        //In javascript Date object notation, TODO: Convert into SQL date time 
    public string callbackTime{ get; set;} 
    public string callbackPacket{ get; set;} 
    public string callbackHint{ get; set;} 
    public string testStringsCorrect{ get; set;} 
    public int numCorrect{ get; set;} 
}