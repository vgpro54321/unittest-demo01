namespace UnitTestDemo.Services
{
    public interface IPersonRepository
    {
        PersonDto PersonSelect(int personId);
        PersonDto PersonCreate(PersonDto personDraft);
        void PersonUpdate(PersonDto personDraft);
        void PersonDelete(int personId);
    }
}
