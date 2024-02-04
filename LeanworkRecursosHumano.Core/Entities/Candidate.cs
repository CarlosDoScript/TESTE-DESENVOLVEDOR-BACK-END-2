namespace LeanworkRecursosHumano.Core.Entities
{
    public class Candidate
    {
        public Candidate() { }

        public Candidate(int id, string name, string email, string cellPhone, bool active, int idJobOpening)
        {
            Id = id;
            Name = name;
            Email = email;
            CellPhone = cellPhone;
            Active = active;
            IdJobOpening = idJobOpening;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string CellPhone { get; private set; }
        public bool Active { get; private set; }
        public int IdJobOpening { get; private set; }
    }
}
