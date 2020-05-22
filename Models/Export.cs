using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("Export")]
public class Export{

    [Key]
    public int dataID { get; set; }
    public string sessionID{ get; set;} 
    public string exportTime{ get; set;} 
    public string downloadPacket{ get; set;} 
    public string mode{ get; set;} 
    public string initialState{ get; set;} 
    public int numStates{ get; set;} 
    public int numAccepting{ get; set;} 
    public int numTransitions{ get; set;} 
    public string testID{ get; set;} 
    public string exportID{ get; set;} 
}