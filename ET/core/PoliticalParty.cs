using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
    public class PoliticalParty {
        private long id;
        private string name;
        private string abbreviation;
        private IList<Candidate> candidates;
        private bool isActive = true;

    <<<<<<< .
        mine
        public virtual IList<Candidate> Candidates {
    =======

        #region Properties

        public virtual IList<Candidate> Candidates {
    >>>>>>> .

        private r61 get {
            return 
            candidates;
        }

        set
    {
        candidates = value;
    }
    }

    public virtual
long ID
{
    get
    {
        return id;
    }
    set
    {
        id = value;
    }
}

    [RequiredProperty("Political Party Name")]
    public virtual
string Name
{
    get
    {
        return name;
    }
    set
    {
        name = value;
    }
}

    [RequiredProperty("Political Party Abbreviation")]
    public virtual
string Abbreviation
{
    get
    {
        return abbreviation;
    }
    set
    {
        abbreviation = value;
    }
}

    public virtual
bool IsActive
{
    get
    {
        return isActive;
    }
    set
    {
        isActive = value;
    }
}

    #endregion

    public override
string ToString()
{
    return name + " (" + abbreviation + ")";
}
}

}