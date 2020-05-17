
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*use System to eventually implement DateTime objects into SQL */
using System;

[Table("Test")]
public class Test{
    [Key]
    public string sessionID { get; set; } 
        //In javascript Date object notation, TODO: Convert into SQL date time 
    public DateTime startTime { get; set; } 
    //In javascript Date object notation, TODO: Convert into SQL date time   
    public DateTime testTime { get; set; }
    // in JSON structure: create class to deserialize all the indices
    public string rustPacket { get; set; }
    public string mode { get; set; }
    public string initialState { get; set; }
    public int numStates { get; set; }
    public int numAccepting { get; set; }
    public int numTransitions { get; set; }
    public string testStrings { get; set; }
        public string testID { get; set; }
}