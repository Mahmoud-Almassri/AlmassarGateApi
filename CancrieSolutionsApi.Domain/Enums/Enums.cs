namespace AlmassarGate.Domain.Enums
{
    public enum RoleTypes
    {
        Admin = 1,
        Seller = 2,
        Driver = 3
    }

    public enum DomainCodes
    {
        OrderStatus = 1,
    }

    public enum BaseStatus
    {
        NotStarted = 1,
        InProgress = 2,
        Opened = 3,
        Closed = 4,
        Rejected = 5,
        ReturnedForModification = 6
    }
    public enum GroupTitle
    {
        how = 1,
        what = 2,
        when = 3
    }

    public enum PayStatus
    {
        NotPayd = 1,
        Payed = 2,
    } 
    public enum EntitiesEnum
    {
        Task = 1,
        Project = 2,
        Approval = 3,
    }
    public enum ActionType
    {
        Approve = 1,
        Submit = 2,
        Reject=3,
        ReturnForModification=4,
        CloseProject=5,
        ChecklistSubmission=6
    }
    public enum ChecklistAnswers
    {
        Passed = 1,
        Failed = 2,
        NA=3
    }

}
