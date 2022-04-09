namespace projectPhase2
{
    //facade pattern to simplify Book class
    public interface IBookFacade
    {
        string getName();
        string getCategory();
        string getAuthor();
        string getPublisher();

    }
}
