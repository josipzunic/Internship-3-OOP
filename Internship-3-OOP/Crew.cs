namespace Internship_3_OOP;

public class CrewMember : AirportPersonnel
{
    private static int _idCounter = 1;
    public int id { get; private set; }
    public string position { get; set; }

    public CrewMember(string name, string surname, DateTime dateOfBirth, string sex, string position)
        : base(name, surname, dateOfBirth, sex)
    {
        this.position = position;
        id = _idCounter;
        _idCounter++;
    }
}

public class Crew
{
    public string crewName { get; set; }
    public List<CrewMember> crewList {get; set;}
    public Crew(string crewName, List<CrewMember> crewList)
        
    {
        this.crewName = crewName;
        this.crewList = crewList;
    }

    public string ReturnCrewMembers()
    {
        var crewList = new List<string>();
        foreach (var crewMember in this.crewList)
        {
            crewList.Add(crewMember.name);
        }
        return string.Join(", ", crewList);
    }

    public string ReturnCrewMembersInfo()
    {
        var crewListInfo = new List<string>();
        foreach (var crewMember in this.crewList)
        {
            crewListInfo.Add($"{crewMember.id} - {crewMember.name} - {crewMember.surname} - " +
                             $"{crewMember.position} - {crewMember.sex} - " +
                             $"{crewMember.dateOfBirth.ToString("yyyy-MM-dd")}");
        }
        return string.Join("\n", crewListInfo);
    }
}